//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using static System.Diagnostics.Debug;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using BluetoothEntity;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace SDKTemplate
{
    // This scenario uses a DeviceWatcher to enumerate nearby Bluetooth Low Energy devices,
    // displays them in a ListView, and lets the user select a device and pair it.
    // This device will be used by future scenarios.
    // For more information about device discovery and pairing, including examples of
    // customizing the pairing process, see the DeviceEnumerationAndPairing sample.
    public sealed partial class Scenario1_Discovery : Page
    {
        private MainPage rootPage = MainPage.Current;

        private ObservableCollection<BluetoothLEDeviceDisplay> KnownDevices = new ObservableCollection<BluetoothLEDeviceDisplay>();
        private List<DeviceInformation> UnknownDevices = new List<DeviceInformation>();

        private DeviceWatcher deviceWatcher;

        //页面2用的展示集合
        private ObservableCollection<BluetoothLEAttributeDisplay> ServiceCollection = new ObservableCollection<BluetoothLEAttributeDisplay>();
        private ObservableCollection<BluetoothLEAttributeDisplay> CharacteristicCollection = new ObservableCollection<BluetoothLEAttributeDisplay>();

        //下面是从client页面拿来的写入用到的参数
        private BluetoothLEDevice bluetoothLeDevice = null;
        private GattCharacteristic selectedCharacteristic;
        //要写入的会员ID
        private string memberId = "";
        //全局变量 用于存储要写入的对象数据
        //说明 write_state字段的值代表的意义：0：待读取；1：写入成功；2：写入失败;3：已读取数据。WPF插入的待写入数据字段值为0，UWP查询值为0的数据，查询到立马将写入状态改为3，进行连接、写入操作，根据写入操作结果再更新状态。过程中出现任何异常立即把状态改为2。读到数据把状态改为3是为了保证一条数据就写入一次，防止出现一直循环写入，循环连接的太多connect方法偶尔会出现灾难性异常，try catch和锁都不怎么管用。
        private BluetoothWriteEntity bluetoothWriteEntity = new BluetoothWriteEntity();

        // Only one registered characteristic at a time.
        private GattCharacteristic registeredCharacteristic;
        private GattPresentationFormat presentationFormat;

        #region Error Codes
        readonly int E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED = unchecked((int)0x80650003);
        readonly int E_BLUETOOTH_ATT_INVALID_PDU = unchecked((int)0x80650004);
        readonly int E_ACCESSDENIED = unchecked((int)0x80070005);
        readonly int E_DEVICE_NOT_AVAILABLE = unchecked((int)0x800710df); // HRESULT_FROM_WIN32(ERROR_DEVICE_NOT_AVAILABLE)

        #region UI Code
        public Scenario1_Discovery()
        {
            InitializeComponent();

            //启动搜索蓝牙
            StartBleDeviceWatcher();


            //启动读取写入指令定时任务 定时查询要写入的数据，如果有要写入的数据就连接蓝牙写入
            Timer();


        }
        public void test(object source, ElapsedEventArgs e)
        {
            StartBleDeviceWatcher();
            // Console.WriteLine("OK, test event is fired at: " + DateTime.Now.ToString());

        }
        /// <summary>
        /// 轮询搜索写入蓝牙数据
        /// </summary>
        public void Timer()
        {
            //开启定时任务 遍历数据库查询要写入的数据
            TimeSpan period = TimeSpan.FromSeconds(5);
            var timer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                try
                {
                    //do something
                    WriteLine("定时任务开启 " + System.DateTime.Now);
                    //if (deviceWatcher == null)
                    //{
                    //查询要写入的数据
                    List<BluetoothWriteEntity> bluetoothWriteEntitys = await SQLiteUtil.OnReadWrite();

                    string bluetoothName = "";
                    //写入集合大于0则写入，说明有写入命令 给需要连接的手环名赋值  有写入命令才进行接下来的连接、搜索、写入操作
                    if (bluetoothWriteEntitys.Count > 0)
                    {
                        bluetoothName = bluetoothWriteEntitys[0].Bluetooth_name;
                        //给全局写入id赋值
                        memberId = bluetoothWriteEntitys[0].Member_id;
                        //全局对象赋值
                        bluetoothWriteEntity = bluetoothWriteEntitys[0];
                        //已经取得写入对象，更新数据库写入状态为3：已读取 防止出现有数据状态一直为0，一直连接造成connect方法灾难性异常
                        bluetoothWriteEntity.Write_state = 3;
                        //更新写入表
                        await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                        Debug.WriteLine("收到写入蓝牙命令：从库查到的写入设备名：" + bluetoothName + ",写入状态：" + bluetoothWriteEntitys[0].Write_state + "，用户ID：" + bluetoothWriteEntitys[0].Member_id);


                        //遍历搜索到的蓝牙集合 找出对应要写入的蓝牙实体类 传递给配对方法
                        foreach (var item in KnownDevices)
                        {
                            BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay = item as BluetoothLEDeviceDisplay;
                            Debug.WriteLine("收到写入蓝牙命令：搜索到的已知蓝牙设备ID:" + bluetoothLEDeviceDisplay.Id + " 蓝牙名：" + bluetoothLEDeviceDisplay.Name);

                            //判断实体与要写入蓝牙名称相同 则传值写入  写入操作加锁 阻塞 同步 否则重复连接会触发灾难性异常
                            //1.配对 2.连接
                            if ((bluetoothLEDeviceDisplay.Name).Equals(bluetoothName))
                            {

                                Debug.WriteLine("找到对应手环，开始配对。名称:" + bluetoothLEDeviceDisplay.Name);
                                //与蓝牙手环配对成功才进行连接，否则不连接
                                DevicePairingResult devicePairingResult = await PairBluetooth(bluetoothLEDeviceDisplay);

                                if (devicePairingResult.Status == DevicePairingResultStatus.Paired || devicePairingResult.Status == DevicePairingResultStatus.AlreadyPaired)
                                {
                                    //设置配置类的蓝牙id和名称 后边写入需要这两个数据
                                    rootPage.SelectedBleDeviceId = bluetoothLEDeviceDisplay.Id;
                                    rootPage.SelectedBleDeviceName = bluetoothLEDeviceDisplay.Name;
                                    //与选择手环自动连接 该方法连接成功后调用搜索服务、搜索特征、自动写入
                                    ConnectButton_Click();
                                }
                                else
                                {//配对不成功则更新为写入失败
                                    Debug.WriteLine("【写入蓝牙：设备配对失败】");

                                    rootPage.NotifyUser("蓝牙配对失败"+ devicePairingResult.Status.ToString(), NotifyType.ErrorMessage);
                                    //更新状态为写入失败
                                    //时间戳
                                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                                    //更新数据库write表写入状态
                                    bluetoothWriteEntity.Write_state = 2;//代表写入失败
                                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                                }
                                



                            }

                        }

                    }
                    else
                    {
                        Debug.WriteLine("无写入蓝牙命令");

                    }



                }
                catch (Exception e)
                {

                }
            },
            period);
        }


        /// <summary>
        /// 给当前选择的手环名称赋值
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            StopBleDeviceWatcher();

            // Save the selected device's ID for use in other scenarios.
            var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;
            if (bleDeviceDisplay != null)
            {
                rootPage.SelectedBleDeviceId = bleDeviceDisplay.Id;
                rootPage.SelectedBleDeviceName = bleDeviceDisplay.Name;
            }
        }
        private void EnumerateButton_Click()
        {
            if (deviceWatcher == null)
            {
                //StartBleDeviceWatcher();


                //for (int i=0;i<= KnownDevices.Count;i++)
                //{
                //    WriteLine("蓝牙列表" + KnownDevices[i].ToString());

                //}
                DataContractJsonSerializer json = new DataContractJsonSerializer(KnownDevices.GetType());
                string szJson = "";
                //序列化
                using (MemoryStream stream = new MemoryStream())
                {
                    json.WriteObject(stream, KnownDevices);
                    szJson = Encoding.UTF8.GetString(stream.ToArray());

                }
                WriteLine("蓝牙列表" + szJson);

                EnumerateButton.Content = "Stop enumerating";
                rootPage.NotifyUser($"Device watcher started.", NotifyType.StatusMessage);
            }
            else
            {
                StopBleDeviceWatcher();
                EnumerateButton.Content = "Start enumerating";
                rootPage.NotifyUser($"Device watcher stopped.", NotifyType.StatusMessage);
            }
        }
        #endregion

        #region Device discovery

        /// <summary>
        /// Starts a device watcher that looks for all nearby Bluetooth devices (paired or unpaired). 
        /// Attaches event handlers to populate the device collection.
        /// </summary>
        private void StartBleDeviceWatcher()
        {
            // Additional properties we would like about the device.
            // Property strings are documented here https://msdn.microsoft.com/en-us/library/windows/desktop/ff521659(v=vs.85).aspx
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected", "System.Devices.Aep.Bluetooth.Le.IsConnectable" };

            // BT_Code: Example showing paired and non-paired in a single query.
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            deviceWatcher =
                    DeviceInformation.CreateWatcher(
                        aqsAllBluetoothLEDevices,
                        requestedProperties,
                        DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            //触发停止事件时，对搜索到的数据进行更新、插入数据库操作
            deviceWatcher.Stopped += DeviceWatcher_Stopped;


            // Start over with an empty collection.
            KnownDevices.Clear();

            // Start the watcher. Active enumeration is limited to approximately 30 seconds.
            // This limits power usage and reduces interference with other Bluetooth activities.
            // To monitor for the presence of Bluetooth LE devices for an extended period,
            // use the BluetoothLEAdvertisementWatcher runtime class. See the BluetoothAdvertisement
            // sample for an example.
            deviceWatcher.Start();
            Debug.WriteLine("初次启动搜索蓝牙" + System.DateTime.Now);

        }

        /// <summary>
        /// Stops watching for all nearby Bluetooth devices.
        /// </summary>
        private void StopBleDeviceWatcher()
        {
            if (deviceWatcher != null)
            {
                // Unregister the event handlers.
                deviceWatcher.Added -= DeviceWatcher_Added;
                deviceWatcher.Updated -= DeviceWatcher_Updated;
                deviceWatcher.Removed -= DeviceWatcher_Removed;
                deviceWatcher.EnumerationCompleted -= DeviceWatcher_EnumerationCompleted;
                deviceWatcher.Stopped -= DeviceWatcher_Stopped;

                // Stop the watcher.
                deviceWatcher.Stop();
                deviceWatcher = null;
            }
        }

        private BluetoothLEDeviceDisplay FindBluetoothLEDeviceDisplay(string id)
        {
            foreach (BluetoothLEDeviceDisplay bleDeviceDisplay in KnownDevices)
            {
                if (bleDeviceDisplay.Id == id)
                {
                    return bleDeviceDisplay;
                }
            }
            return null;
        }

        private DeviceInformation FindUnknownDevices(string id)
        {
            foreach (DeviceInformation bleDeviceInfo in UnknownDevices)
            {
                if (bleDeviceInfo.Id == id)
                {
                    return bleDeviceInfo;
                }
            }
            return null;
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                lock (this)
                {
                    Debug.WriteLine(String.Format("Added {0}{1}", deviceInfo.Id, deviceInfo.Name));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        // Make sure device isn't already present in the list.
                        if (FindBluetoothLEDeviceDisplay(deviceInfo.Id) == null)
                        {
                            if (deviceInfo.Name != string.Empty)
                            {
                                // If device has a friendly name display it immediately.
                                KnownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));
                            }
                            else
                            {
                                // Add it to a list in case the name gets updated later. 
                                UnknownDevices.Add(deviceInfo);
                            }
                        }

                    }
                }
            });
        }

        private async void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                lock (this)
                {
                    Debug.WriteLine(String.Format("Updated {0}{1}", deviceInfoUpdate.Id, ""));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                        if (bleDeviceDisplay != null)
                        {
                            // Device is already being displayed - update UX.
                            bleDeviceDisplay.Update(deviceInfoUpdate);
                            return;
                        }

                        DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                        if (deviceInfo != null)
                        {
                            deviceInfo.Update(deviceInfoUpdate);
                            // If device has been updated with a friendly name it's no longer unknown.
                            if (deviceInfo.Name != String.Empty)
                            {
                                KnownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));
                                UnknownDevices.Remove(deviceInfo);
                            }
                        }
                    }
                }
            });
        }

        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                lock (this)
                {
                    Debug.WriteLine(String.Format("Removed {0}{1}", deviceInfoUpdate.Id, ""));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        // Find the corresponding DeviceInformation in the collection and remove it.
                        BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                        if (bleDeviceDisplay != null)
                        {
                            KnownDevices.Remove(bleDeviceDisplay);
                        }

                        DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                        if (deviceInfo != null)
                        {
                            UnknownDevices.Remove(deviceInfo);
                        }
                    }
                }
            });
        }

        private async void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    rootPage.NotifyUser($"{KnownDevices.Count} devices found. Enumeration completed.",
                        NotifyType.StatusMessage);

                }
            });


            //开始之前清空蓝牙设备集合 不再async事件里调用操作主线程全局变量的方法 会报应用程序调用一个已为另一线程的接口异常，直接退出 反正自己也会Remove不必要了
            //KnownDevices.Clear();
            //停止事件重新开始搜索蓝牙 注意别在DeviceWatcher_Stopped里自我调用 否则死循环 

            //这个地方更新Read表的时候可能和定时任务里更新write表并发冲突报Busy异常 SQLite没有复杂的锁机制
            try
            {
                //deviceWatcher.Start();
                //Debug.WriteLine("启动搜索蓝牙");

                //自己加的 在这里搜索完成的时候停止搜索

                Debug.WriteLine("对搜索到的蓝牙设备进行更新、插入处理");

                //实例化插入集合
                List<BluetoothReadEntity> bluetoothReadEntities = new List<BluetoothReadEntity>();

                for (int i = 0; i < KnownDevices.Count; i++)
                {
                    BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay = KnownDevices[i] as BluetoothLEDeviceDisplay;
                    Debug.WriteLine("搜索到的蓝牙设备" + bluetoothLEDeviceDisplay.Id + bluetoothLEDeviceDisplay.Name);
                    //时间戳
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);

                    //根据蓝牙名称查询数据库，若有数据就更新scan_count +1 ，否则插入数据。防止重复插入造成表中数据过多
                    List<BluetoothReadEntity> queryReadEntitys = await SQLiteUtil.GetReadEntityByBluetoothName(bluetoothLEDeviceDisplay.Name);

                    var bluetoothReadEntity = new BluetoothReadEntity();


                    //数据库中有该手环数据就更新计数 否则添加新纪录
                    if (queryReadEntitys.Count > 0)
                    {
                        //因为sql只能返回集合 所以根据修改时间由大到小排序选择最新第一条
                        bluetoothReadEntity = queryReadEntitys[0];
                        bluetoothReadEntity.Scan_count += 1;
                        bluetoothReadEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);
                        //更新read表
                        await SQLiteUtil.UpdateReadTable(bluetoothReadEntity);
                    }
                    else//数据库中没有该手环数据  添加进插入集合
                    {
                        bluetoothReadEntity.Member_id = bluetoothLEDeviceDisplay.Name;
                        bluetoothReadEntity.Scan_count = 0;
                        bluetoothReadEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                        //添加进插入集合
                        bluetoothReadEntities.Add(bluetoothReadEntity);
                    }




                }

                //把数据库中没有的数据 批量插入数据库
                await SQLiteUtil.BatchInsertRead(bluetoothReadEntities);


            }
            catch (Exception)
            {

                throw;
            }


            //停止搜索 触发停止事件
            deviceWatcher.Stop();






        }
        /// <summary>
        /// 停止搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeviceWatcher_Stopped(DeviceWatcher sender, object e)
        {
            // Start over with an empty collection. 先清空列表再搜索

            Debug.WriteLine("触发搜索蓝牙停止事件" + System.DateTime.Now);


            

            //重新开始搜索蓝牙
            deviceWatcher.Start();

            Debug.WriteLine("STOP事件重新开始搜索蓝牙" + System.DateTime.Now);

            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    rootPage.NotifyUser($"搜索停止No longer watching for devices.",
                            sender.Status == DeviceWatcherStatus.Aborted ? NotifyType.ErrorMessage : NotifyType.StatusMessage);
                }
            });
        }
        #endregion

        #region Pairing

        private bool isBusy = false;

        /// <summary>
        /// 配对连接方法 根据配对按钮改造 传入实体类参数
        /// </summary>
        /// <param name="bluetoothLEDeviceDisplay"></param>
        private async Task<DevicePairingResult> PairBluetooth(BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay)
        {
            //新的连接方式 根据传入对象连接
            var bleDeviceDisplay = bluetoothLEDeviceDisplay;
            // BT_Code: Pair the currently selected device.
            DevicePairingResult result = await bleDeviceDisplay.DeviceInformation.Pairing.PairAsync();

            // Do not allow a new Pair operation to start if an existing one is in progress.
            if (isBusy)
            {
                return result;
            }

            isBusy = true;

            rootPage.NotifyUser("已经开始配对 Pairing started. Please wait...", NotifyType.StatusMessage);

            // For more information about device pairing, including examples of
            // customizing the pairing process, see the DeviceEnumerationAndPairing sample.

            // Capture the current selected item in case the user changes it while we are pairing.
            //原来的连接方式 根据选择的连
            //var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;

            Debug.WriteLine("配对手环连接结果 = " + result.Status);
            rootPage.NotifyUser($"配对结果 Pairing result = {result.Status}",
                result.Status == DevicePairingResultStatus.Paired || result.Status == DevicePairingResultStatus.AlreadyPaired
                    ? NotifyType.StatusMessage
                    : NotifyType.ErrorMessage);
            //如果配对成功 给配置类中存储的id和手环名称赋值：


            isBusy = false;

            return result;





        }



        /// <summary>
        /// 配对连接按钮点击事件
        /// </summary>
        /// <param name="bluetoothLEDeviceDisplay"></param>
        private async void PairButton_Click()
        {
            // Do not allow a new Pair operation to start if an existing one is in progress.
            if (isBusy)
            {
                return;
            }

            isBusy = true;

            rootPage.NotifyUser("Pairing started. Please wait...", NotifyType.StatusMessage);

            // For more information about device pairing, including examples of
            // customizing the pairing process, see the DeviceEnumerationAndPairing sample.

            // Capture the current selected item in case the user changes it while we are pairing.
            //原来的连接方式 根据选择的连
            var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;
            // BT_Code: Pair the currently selected device.
            DevicePairingResult result = await bleDeviceDisplay.DeviceInformation.Pairing.PairAsync();
            rootPage.NotifyUser($"Pairing result = {result.Status}",
                result.Status == DevicePairingResultStatus.Paired || result.Status == DevicePairingResultStatus.AlreadyPaired
                    ? NotifyType.StatusMessage
                    : NotifyType.ErrorMessage);

            isBusy = false;
        }

        #endregion



        #region 以下几个方法是自动写入手环数据的方法

        /// <summary>
        /// 1.连接按钮 根据连接的设备ID查询服务
        /// </summary>
        private async void ConnectButton_Click()
        {
            //ConnectButton.IsEnabled = false;

            //if (!await ClearBluetoothLEDeviceAsync())
            //{
            //    rootPage.NotifyUser("Error: Unable to reset state, try again.", NotifyType.ErrorMessage);
            //    ConnectButton.IsEnabled = false;
            //    return;
            //}

            try
            {
                Debug.WriteLine("开始连接蓝牙");
                //根据选择的设备id进行连接  前边Timer中把数据库查出来的数据赋值给了配置类
                // BT_Code: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
                bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(rootPage.SelectedBleDeviceId);
                //连接失败 更新数据库状态为失败
                if (bluetoothLeDevice == null)
                {
                    rootPage.NotifyUser("Failed to connect to device.", NotifyType.ErrorMessage);
                    Debug.WriteLine("蓝牙连接失败");

                    //时间戳
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //更新数据库write表写入状态
                    bluetoothWriteEntity.Write_state = 2;//代表写入失败
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                }


                //连接成功
                if (bluetoothLeDevice != null)
                {
                    Debug.WriteLine("蓝牙连接成功");
                    rootPage.NotifyUser("蓝牙连接成功", NotifyType.StatusMessage);

                    // Note: BluetoothLEDevice.GattServices property will return an empty list for unpaired devices. For all uses we recommend using the GetGattServicesAsync method.
                    // BT_Code: GetGattServicesAsync returns a list of all the supported services of the device (even if it's not paired to the system).
                    // If the services supported by the device are expected to change during BT usage, subscribe to the GattServicesChanged event.
                    //获得连接蓝牙的GATT服务列表  这个地方，如果一直循环执行 会报灾难性异常
                    GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached);
                    //获得服务成功
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        //服务集合
                        var services = result.Services;
                        rootPage.NotifyUser(String.Format("Found {0} services", services.Count), NotifyType.StatusMessage);

                        //原先的遍历服务列表添加到界面的操作，不需要
                        //foreach (var service in services)
                        //{
                        //    ServiceCollection.Add(new BluetoothLEAttributeDisplay(service));
                        //}
                        //ConnectButton.Visibility = Visibility.Collapsed;
                        //ServiceList.Visibility = Visibility.Visible;

                        //遍历服务列表 自动选择custom service 000001ff-3c17-d293-8e48-14fe2e4da212 在这里选择自定义的写入服务，调用其查询特征方法
                        foreach (var service in services)
                        {//还是需要拿到数据就更改一下状态，否则，若连接的手环无服务，不会金像下边的操作，写入状态就一直是0，然后就一直尝试连接，就会灾难性异常
                            Debug.WriteLine("当前连接蓝牙包含的服务：DeviceId:{0},Uuid:{1},AttributeHandle:{2}", service.DeviceId, service.Uuid, service.AttributeHandle);
                            //遍历直到需要选择的写入服务，才对这一个服务调用查询特征方法
                            if ("000001ff-3c17-d293-8e48-14fe2e4da212".Equals(service.Uuid.ToString()))
                            {
                                Debug.WriteLine("【找到连接设备指定服务，接下来搜索特征】");
                                //下一步是根据服务查询特征 传入服务对象
                                BluetoothLEAttributeDisplay bluetoothLEAttributeDisplay = new BluetoothLEAttributeDisplay(service);
                                //调用查询特征方法：
                                ServiceList_SelectionChanged(bluetoothLEAttributeDisplay);
                            }


                        }

                    }
                    else
                    {
                        Debug.WriteLine("【写入蓝牙：获取GATT服务失败 Device unreachable】");

                        rootPage.NotifyUser("获取GATT服务失败 Device unreachable", NotifyType.ErrorMessage);
                        //更新状态为写入失败
                        //时间戳
                        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        //更新数据库write表写入状态
                        bluetoothWriteEntity.Write_state = 2;//代表写入失败
                        bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                        await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    }
                }

            }
            catch (Exception ex) when (ex.HResult == E_DEVICE_NOT_AVAILABLE)
            {
                rootPage.NotifyUser("Bluetooth radio is not on.", NotifyType.ErrorMessage);
                //更新状态为写入失败
                //时间戳
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //更新数据库write表写入状态
                bluetoothWriteEntity.Write_state = 2;//代表写入失败
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
            }

            //ConnectButton.IsEnabled = true;
        }
        #endregion


        #region Enumerating Characteristics 
        /// <summary>
        /// 服务列表更改事件 根据选择的服务查询其特征集合 传入的参数为选择的蓝牙设备的服务展示对象
        /// </summary>
        private async void ServiceList_SelectionChanged(BluetoothLEAttributeDisplay attributeInfoDisp)
        {
            //var attributeInfoDisp = (BluetoothLEAttributeDisplay)ServiceList.SelectedItem;

            //CharacteristicCollection.Clear();
            //RemoveValueChangedHandler();

            IReadOnlyList<GattCharacteristic> characteristics = null;
            try
            {
                // Ensure we have access to the device.确保我们可以连接到设备
                var accessStatus = await attributeInfoDisp.service.RequestAccessAsync();
                if (accessStatus == DeviceAccessStatus.Allowed)
                {
                    // BT_Code: Get all the child characteristics of a service. Use the cache mode to specify uncached characterstics only 
                    // and the new Async functions to get the characteristics of unpaired devices as well. 
                    //和查询服务类似 查询该服务对应的特征集合
                    var result = await attributeInfoDisp.service.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        //查询成功则把特征集合赋值
                        characteristics = result.Characteristics;
                        //然后遍历可以给全局变量当前选择的特征赋值 我们要选择的特征是6522
                        foreach (var characteristic in characteristics)
                        {
                            Debug.WriteLine("当前服务包含的特征：AttributeHandle:{0},UserDescription:{1},Uuid:{2},典型属性：{3}", characteristic.AttributeHandle, characteristic.UserDescription, characteristic.Uuid, characteristic.CharacteristicProperties);
                            //65282:AttributeHandle(特征唯一ID) = 12,CharacteristicProperties(特征属性):writeWithoutResponse
                            //65283:AttributeHandle(特征唯一ID) = 14,CharacteristicProperties(特征属性):write
                            //65282:AttributeHandle(特征唯一ID) = 16,CharacteristicProperties(特征属性):Read | Notify

                            //这里是根据AttributeHandle判断的所需服务 也可以根据UUID判断
                            if (characteristic.AttributeHandle == 14)
                            {
                                //给全局对象选择的特征赋值 写入的时候使用该特征写入
                                selectedCharacteristic = characteristic;
                                Debug.WriteLine("【已经找到指定特征，准备写入】");

                                if (memberId != null && memberId != "")
                                {
                                    Debug.WriteLine("需要写入的用户ID：" + memberId);
                                    //先转成UTF8的字节数组再加上协议头 整条数据是Hex数组
                                    byte[] group = Encoding.UTF8.GetBytes(memberId);

                                    byte[] writeData = ProtocolUtil.packWriteData(group);

                                    //调用写入方法
                                    await WriteBufferToSelectedCharacteristicAsync(ProtocolUtil.Bytes2Buffer(writeData));
                                }
                                //WriteBufferToSelectedCharacteristicAsync();
                            }
                            

                        }
                    }
                    else
                    {
                        rootPage.NotifyUser("无法搜索服务 Error accessing service.", NotifyType.ErrorMessage);

                        // On error, act as if there are no characteristics.
                        characteristics = new List<GattCharacteristic>();

                        //更新状态为写入失败
                        //时间戳
                        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        //更新数据库write表写入状态
                        bluetoothWriteEntity.Write_state = 2;//代表写入失败
                        bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                        await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    }
                }
                else
                {
                    // Not granted access
                    rootPage.NotifyUser("无法搜索服务 Error accessing service.", NotifyType.ErrorMessage);

                    // On error, act as if there are no characteristics.
                    characteristics = new List<GattCharacteristic>();


                    //更新状态为写入失败
                    //时间戳
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //更新数据库write表写入状态
                    bluetoothWriteEntity.Write_state = 2;//代表写入失败
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                }
            }
            catch (Exception ex)
            {
                rootPage.NotifyUser("无法读取特征 Restricted service. Can't read characteristics: " + ex.Message,
                    NotifyType.ErrorMessage);
                // On error, act as if there are no characteristics.
                characteristics = new List<GattCharacteristic>();

                //更新状态为写入失败
                //时间戳
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //更新数据库write表写入状态
                bluetoothWriteEntity.Write_state = 2;//代表写入失败
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
            }
            //界面特征集合
            //foreach (GattCharacteristic c in characteristics)
            //{
            //    CharacteristicCollection.Add(new BluetoothLEAttributeDisplay(c));
            //}
            //CharacteristicList.Visibility = Visibility.Visible;
        }
        #endregion


        /// <summary>
        /// 选择特征事件 其实就办了一个事  就是给全局对象选择的特征赋值 再确定下特征是否可用 不行就提示页面。这个方法不用了 直接在上一步选择服务给selectedCharacteristic赋值
        /// </summary>
        private async void CharacteristicList_SelectionChanged(GattCharacteristic autoSelectedCharacteristic)
        {
            selectedCharacteristic = null;

            //var attributeInfoDisp = (BluetoothLEAttributeDisplay)CharacteristicList.SelectedItem;
            //if (attributeInfoDisp == null)
            //{
            //    //EnableCharacteristicPanels(GattCharacteristicProperties.None);
            //    return;
            //}

            //这个很重要是 确定选择的服务 原先是根据界面的选择赋值 现在改成传入的服务对象参数
            //selectedCharacteristic = attributeInfoDisp.characteristic;

            if (selectedCharacteristic == null)
            {
                rootPage.NotifyUser("No characteristic selected", NotifyType.ErrorMessage);
                return;
            }

            // Get all the child descriptors of a characteristics. Use the cache mode to specify uncached descriptors only 
            // and the new Async functions to get the descriptors of unpaired devices as well. 
            var result = await selectedCharacteristic.GetDescriptorsAsync(BluetoothCacheMode.Uncached);
            if (result.Status != GattCommunicationStatus.Success)
            {
                rootPage.NotifyUser("Descriptor read failure: " + result.Status.ToString(), NotifyType.ErrorMessage);
            }

            // BT_Code: There's no need to access presentation format unless there's at least one. 
            presentationFormat = null;
            if (selectedCharacteristic.PresentationFormats.Count > 0)
            {

                if (selectedCharacteristic.PresentationFormats.Count.Equals(1))
                {
                    // Get the presentation format since there's only one way of presenting it
                    presentationFormat = selectedCharacteristic.PresentationFormats[0];
                }
                else
                {
                    // It's difficult to figure out how to split up a characteristic and encode its different parts properly.
                    // In this case, we'll just encode the whole thing to a string to make it easy to print out.
                }
            }

            // Enable/disable operations based on the GattCharacteristicProperties.
            //EnableCharacteristicPanels(selectedCharacteristic.CharacteristicProperties);
        }


        /// <summary>
        /// 写入UTF-8字符串
        /// </summary>
        private async void CharacteristicWriteButton_Click()
        {
            //判断要写入的文本不为空
            //if (!String.IsNullOrEmpty(CharacteristicWriteValue.Text))
            //{
            //    var writeBuffer = CryptographicBuffer.ConvertStringToBinary(CharacteristicWriteValue.Text,
            //        BinaryStringEncoding.Utf8);
            //    Debug.WriteLine("原本写入的2进制数据串：" + writeBuffer);


            //    //调用写入方法
            //    var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(writeBuffer);
            //}
            //else
            //{
            //    rootPage.NotifyUser("No data to write to device", NotifyType.ErrorMessage);
            //}
        }


        /// <summary>
        /// 写入UTF-8按钮点击事件调用的写入函数 传入要写入的数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private async Task<bool> WriteBufferToSelectedCharacteristicAsync(IBuffer buffer)
        {
            try
            {
                //猜测BT_CODE代表比特码？将字节写入方法
                // BT_Code: Writes the value from the buffer to the characteristic.
                //选择的特征 需要指定选中的特征
                var result = await selectedCharacteristic.WriteValueWithResultAsync(buffer);

                if (result.Status == GattCommunicationStatus.Success)
                {
                    Debug.WriteLine("【写入成功】");
                    rootPage.NotifyUser("Successfully wrote value to device", NotifyType.StatusMessage);
                    //时间戳
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //更新数据库write表写入状态
                    bluetoothWriteEntity.Write_state = 1;//代表写入成功
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    return true;
                }
                else
                {
                    Debug.WriteLine("【写入失败】");

                    rootPage.NotifyUser($"Write failed: {result.Status}", NotifyType.ErrorMessage);

                    //时间戳
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //更新数据库write表写入状态
                    bluetoothWriteEntity.Write_state = 2;//代表写入失败
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    return false;
                }
                //写入完成后断开蓝牙
                //调用读取特征
               
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_INVALID_PDU)
            {

                //更新状态为写入失败
                //时间戳
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //更新数据库write表写入状态
                bluetoothWriteEntity.Write_state = 2;//代表写入失败
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                return false;
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED || ex.HResult == E_ACCESSDENIED)
            {

                //更新状态为写入失败
                //时间戳
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //更新数据库write表写入状态
                bluetoothWriteEntity.Write_state = 2;//代表写入失败
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                // This usually happens when a device reports that it support writing, but it actually doesn't.
                rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// 读取数据方法
        /// </summary>
        //private async void CharacteristicReadButton_Click()
        //{
        //    // BT_Code: Read the actual value from the device by using Uncached.
        //    GattReadResult result = await selectedCharacteristic.ReadValueAsync(BluetoothCacheMode.Uncached);
        //    if (result.Status == GattCommunicationStatus.Success)
        //    {
        //        string formattedResult = FormatValueByPresentation(result.Value, presentationFormat);
        //        rootPage.NotifyUser($"Read result: {formattedResult}", NotifyType.StatusMessage);
        //    }
        //    else
        //    {
        //        rootPage.NotifyUser($"Read failed: {result.Status}", NotifyType.ErrorMessage);
        //    }
        //}


        #endregion
    }

}
