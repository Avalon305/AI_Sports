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
            //StartBleDeviceWatcher();
            //WriteLine("qqq");

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
            deviceWatcher.Stopped += DeviceWatcher_Stopped;



            // Start over with an empty collection.
            KnownDevices.Clear();

            deviceWatcher.Start();
            Debug.WriteLine("初次启动搜索蓝牙" + System.DateTime.Now);

            //启动定时任务 定时查询要写入的数据 并与对应蓝牙配对
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
            TimeSpan period = TimeSpan.FromSeconds(10);
            var timer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                try
                {
                    //do something
                    WriteLine("定时任务开启");
                    //if (deviceWatcher == null)
                    //{
                    Debug.WriteLine("启动搜索蓝牙" + System.DateTime.Now);
                    //查询要写入的数据
                    List<BluetoothWriteEntity> bluetoothWriteEntitys = SQLiteUtil.OnReadWrite();

                    string bluetoothName = "";
                    //写入集合大于0则写入 给需要连接的手环名赋值
                    if (bluetoothWriteEntitys.Count > 0)
                    {
                        bluetoothName = bluetoothWriteEntitys[0].Bluetooth_name;
                        Debug.WriteLine("写入蓝牙：从库查到的写入设备名："+ bluetoothName+",写入状态："+ bluetoothWriteEntitys[0].Write_state);
                    }

                    //遍历搜索到的蓝牙集合 找出对应要写入的蓝牙实体类 传递给配对方法
                    foreach (var item in KnownDevices)
                    {
                        BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay = item as BluetoothLEDeviceDisplay;
                        Debug.WriteLine("写入蓝牙：搜索到的蓝牙设备" + bluetoothLEDeviceDisplay.Id + bluetoothLEDeviceDisplay.Name);
                        
                        //判断实体与要写入蓝牙名称相同 则传值写入
                        if ((bluetoothLEDeviceDisplay.Name).Equals(bluetoothName))
                        {
                            Debug.WriteLine("找到对应手环，开始配对。名称:"+ bluetoothLEDeviceDisplay.Name);
                            //与蓝牙手环配对
                            PairBluetooth(bluetoothLEDeviceDisplay);
                            //设置配置类的蓝牙id和名称 后边写入需要这两个数据
                            rootPage.SelectedBleDeviceId = bluetoothLEDeviceDisplay.Id;
                            rootPage.SelectedBleDeviceName = bluetoothLEDeviceDisplay.Name;
                            //与选择手环自动连接
                            ConnectButton_Click();
                        }

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
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            foreach (var item in KnownDevices)
            {
                BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay = item as BluetoothLEDeviceDisplay;
                Debug.WriteLine("蓝牙列表" + bluetoothLEDeviceDisplay.Id + bluetoothLEDeviceDisplay.Name);


            }

            // Start over with an empty collection.
            KnownDevices.Clear();

            // Start the watcher. Active enumeration is limited to approximately 30 seconds.
            // This limits power usage and reduces interference with other Bluetooth activities.
            // To monitor for the presence of Bluetooth LE devices for an extended period,
            // use the BluetoothLEAdvertisementWatcher runtime class. See the BluetoothAdvertisement
            // sample for an example.
            deviceWatcher.Start();
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


            //deviceWatcher.Start();
            //Debug.WriteLine("启动搜索蓝牙");
            //自己加的 在这里搜索完成的时候停止搜索
            deviceWatcher.Stop();
            Debug.WriteLine("停止搜索蓝牙" + System.DateTime.Now);


            //实例化插入集合
            List<BluetoothReadEntity> bluetoothReadEntities = new List<BluetoothReadEntity>();

            foreach (var item in KnownDevices)
            {
                BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay = item as BluetoothLEDeviceDisplay;
                Debug.WriteLine("搜索到的蓝牙设备" + bluetoothLEDeviceDisplay.Id + bluetoothLEDeviceDisplay.Name);
                //时间戳
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);

                var bluetoothReadEntity = new BluetoothReadEntity
                {
                    Member_id = bluetoothLEDeviceDisplay.Name,
                    Scan_count = 0,
                    Gmt_modified = Convert.ToInt64(ts.TotalSeconds)

                };
                //添加进插入集合
                bluetoothReadEntities.Add(bluetoothReadEntity);

            }

            //批量插入数据库
            SQLiteUtil.BatchInsertRead(bluetoothReadEntities);

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
        }
        /// <summary>
        /// 停止搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeviceWatcher_Stopped(DeviceWatcher sender, object e)
        {
            // Start over with an empty collection. 先清空列表再搜索

            deviceWatcher.Start();
            Debug.WriteLine("STOP事件重新开始搜索蓝牙" + System.DateTime.Now);
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    rootPage.NotifyUser($"No longer watching for devices.",
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
        private async void PairBluetooth(BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay)
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
            //var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;
            //新的连接方式 根据传入对象连接
            var bleDeviceDisplay = bluetoothLEDeviceDisplay;
            // BT_Code: Pair the currently selected device.
            DevicePairingResult result = await bleDeviceDisplay.DeviceInformation.Pairing.PairAsync();
            Debug.WriteLine("配对手环连接结果 = "+result.Status);

            //如果配对成功 给配置类中存储的id和手环名称赋值：
            

            rootPage.NotifyUser($"Pairing result = {result.Status}",
                result.Status == DevicePairingResultStatus.Paired || result.Status == DevicePairingResultStatus.AlreadyPaired
                    ? NotifyType.StatusMessage
                    : NotifyType.ErrorMessage);



            isBusy = false;
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
        /// 1.连接按钮
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
                //根据选择的设备id进行连接  前边把数据库查出来的数据赋值给了配置类
                // BT_Code: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
                bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(rootPage.SelectedBleDeviceId);
                //连接失败
                if (bluetoothLeDevice == null)
                {
                    rootPage.NotifyUser("Failed to connect to device.", NotifyType.ErrorMessage);
                }
            }
            catch (Exception ex) when (ex.HResult == E_DEVICE_NOT_AVAILABLE)
            {
                rootPage.NotifyUser("Bluetooth radio is not on.", NotifyType.ErrorMessage);
            }
            //连接成功
            if (bluetoothLeDevice != null)
            {
                // Note: BluetoothLEDevice.GattServices property will return an empty list for unpaired devices. For all uses we recommend using the GetGattServicesAsync method.
                // BT_Code: GetGattServicesAsync returns a list of all the supported services of the device (even if it's not paired to the system).
                // If the services supported by the device are expected to change during BT usage, subscribe to the GattServicesChanged event.
                //获得连接蓝牙的GATT服务列表
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

                    //遍历服务列表 自动选择custom service 000001ff-3c17-d293-8e48-14fe2e4da212
                    foreach (var service in services)
                    {
                        Debug.WriteLine("当前连接蓝牙包含的服务：DeviceId:{0},Uuid:{1},AttributeHandle:{2}", service.DeviceId,service.Uuid,service.AttributeHandle);

                    }

                }
                else
                {
                    rootPage.NotifyUser("Device unreachable", NotifyType.ErrorMessage);
                }
            }
            //ConnectButton.IsEnabled = true;
        }
        #endregion


        #region Enumerating Characteristics 
        /// <summary>
        /// 服务列表选择事件 点击该事件获得服务集合 传入的参数为选择的蓝牙设备的服务
        /// </summary>
        private async void ServiceList_SelectionChanged(BluetoothLEAttributeDisplay attributeInfoDisp)
        {
            //var attributeInfoDisp = (BluetoothLEAttributeDisplay)ServiceList.SelectedItem;

            //CharacteristicCollection.Clear();
            //RemoveValueChangedHandler();

            IReadOnlyList<GattCharacteristic> characteristics = null;
            try
            {
                // Ensure we have access to the device.
                var accessStatus = await attributeInfoDisp.service.RequestAccessAsync();
                if (accessStatus == DeviceAccessStatus.Allowed)
                {
                    // BT_Code: Get all the child characteristics of a service. Use the cache mode to specify uncached characterstics only 
                    // and the new Async functions to get the characteristics of unpaired devices as well. 
                    var result = await attributeInfoDisp.service.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        characteristics = result.Characteristics;
                    }
                    else
                    {
                        rootPage.NotifyUser("Error accessing service.", NotifyType.ErrorMessage);

                        // On error, act as if there are no characteristics.
                        characteristics = new List<GattCharacteristic>();
                    }
                }
                else
                {
                    // Not granted access
                    rootPage.NotifyUser("Error accessing service.", NotifyType.ErrorMessage);

                    // On error, act as if there are no characteristics.
                    characteristics = new List<GattCharacteristic>();

                }
            }
            catch (Exception ex)
            {
                rootPage.NotifyUser("Restricted service. Can't read characteristics: " + ex.Message,
                    NotifyType.ErrorMessage);
                // On error, act as if there are no characteristics.
                characteristics = new List<GattCharacteristic>();
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
        /// 选择特征事件
        /// </summary>
        private async void CharacteristicList_SelectionChanged()
        {
            selectedCharacteristic = null;

            //var attributeInfoDisp = (BluetoothLEAttributeDisplay)CharacteristicList.SelectedItem;
            //if (attributeInfoDisp == null)
            //{
            //    //EnableCharacteristicPanels(GattCharacteristicProperties.None);
            //    return;
            //}

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
        /// 写入UTF-8按钮点击事件调用的写入函数 传入要写入的2进制字符串
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private async Task<bool> WriteBufferToSelectedCharacteristicAsync(IBuffer buffer)
        {
            try
            {
                //猜测BT_CODE代表比特码？将字节写入方法
                // BT_Code: Writes the value from the buffer to the characteristic.
                var result = await selectedCharacteristic.WriteValueWithResultAsync(buffer);

                if (result.Status == GattCommunicationStatus.Success)
                {
                    rootPage.NotifyUser("Successfully wrote value to device", NotifyType.StatusMessage);
                    return true;
                }
                else
                {
                    rootPage.NotifyUser($"Write failed: {result.Status}", NotifyType.ErrorMessage);
                    return false;
                }
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_INVALID_PDU)
            {
                rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                return false;
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED || ex.HResult == E_ACCESSDENIED)
            {
                // This usually happens when a device reports that it support writing, but it actually doesn't.
                rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                return false;
            }
        }


        #endregion
    }

}
