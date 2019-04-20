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

        //ҳ��2�õ�չʾ����
        private ObservableCollection<BluetoothLEAttributeDisplay> ServiceCollection = new ObservableCollection<BluetoothLEAttributeDisplay>();
        private ObservableCollection<BluetoothLEAttributeDisplay> CharacteristicCollection = new ObservableCollection<BluetoothLEAttributeDisplay>();

        //�����Ǵ�clientҳ��������д���õ��Ĳ���
        private BluetoothLEDevice bluetoothLeDevice = null;
        private GattCharacteristic selectedCharacteristic;
        //Ҫд��Ļ�ԱID
        private string memberId = "";
        //ȫ�ֱ��� ���ڴ洢Ҫд��Ķ�������
        //˵�� write_state�ֶε�ֵ��������壺0������ȡ��1��д��ɹ���2��д��ʧ��;3���Ѷ�ȡ���ݡ�WPF����Ĵ�д�������ֶ�ֵΪ0��UWP��ѯֵΪ0�����ݣ���ѯ������д��״̬��Ϊ3���������ӡ�д�����������д���������ٸ���״̬�������г����κ��쳣������״̬��Ϊ2���������ݰ�״̬��Ϊ3��Ϊ�˱�֤һ�����ݾ�д��һ�Σ���ֹ����һֱѭ��д�룬ѭ�����ӵ�̫��connect����ż��������������쳣��try catch����������ô���á�
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

            //������������
            StartBleDeviceWatcher();


            //������ȡд��ָ�ʱ���� ��ʱ��ѯҪд������ݣ������Ҫд������ݾ���������д��
            Timer();


        }
        public void test(object source, ElapsedEventArgs e)
        {
            StartBleDeviceWatcher();
            // Console.WriteLine("OK, test event is fired at: " + DateTime.Now.ToString());

        }
        /// <summary>
        /// ��ѯ����д����������
        /// </summary>
        public void Timer()
        {
            //������ʱ���� �������ݿ��ѯҪд�������
            TimeSpan period = TimeSpan.FromSeconds(5);
            var timer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                try
                {
                    //do something
                    WriteLine("��ʱ������ " + System.DateTime.Now);
                    //if (deviceWatcher == null)
                    //{
                    //��ѯҪд�������
                    List<BluetoothWriteEntity> bluetoothWriteEntitys = await SQLiteUtil.OnReadWrite();

                    string bluetoothName = "";
                    //д�뼯�ϴ���0��д�룬˵����д������ ����Ҫ���ӵ��ֻ�����ֵ  ��д������Ž��н����������ӡ�������д�����
                    if (bluetoothWriteEntitys.Count > 0)
                    {
                        bluetoothName = bluetoothWriteEntitys[0].Bluetooth_name;
                        //��ȫ��д��id��ֵ
                        memberId = bluetoothWriteEntitys[0].Member_id;
                        //ȫ�ֶ���ֵ
                        bluetoothWriteEntity = bluetoothWriteEntitys[0];
                        //�Ѿ�ȡ��д����󣬸������ݿ�д��״̬Ϊ3���Ѷ�ȡ ��ֹ����������״̬һֱΪ0��һֱ�������connect�����������쳣
                        bluetoothWriteEntity.Write_state = 3;
                        //����д���
                        await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                        Debug.WriteLine("�յ�д����������ӿ�鵽��д���豸����" + bluetoothName + ",д��״̬��" + bluetoothWriteEntitys[0].Write_state + "���û�ID��" + bluetoothWriteEntitys[0].Member_id);


                        //�������������������� �ҳ���ӦҪд�������ʵ���� ���ݸ���Է���
                        foreach (var item in KnownDevices)
                        {
                            BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay = item as BluetoothLEDeviceDisplay;
                            Debug.WriteLine("�յ�д�������������������֪�����豸ID:" + bluetoothLEDeviceDisplay.Id + " ��������" + bluetoothLEDeviceDisplay.Name);

                            //�ж�ʵ����Ҫд������������ͬ ��ֵд��  д��������� ���� ͬ�� �����ظ����ӻᴥ���������쳣
                            //1.��� 2.����
                            if ((bluetoothLEDeviceDisplay.Name).Equals(bluetoothName))
                            {

                                Debug.WriteLine("�ҵ���Ӧ�ֻ�����ʼ��ԡ�����:" + bluetoothLEDeviceDisplay.Name);
                                //�������ֻ���Գɹ��Ž������ӣ���������
                                DevicePairingResult devicePairingResult = await PairBluetooth(bluetoothLEDeviceDisplay);

                                if (devicePairingResult.Status == DevicePairingResultStatus.Paired || devicePairingResult.Status == DevicePairingResultStatus.AlreadyPaired)
                                {
                                    //���������������id������ ���д����Ҫ����������
                                    rootPage.SelectedBleDeviceId = bluetoothLEDeviceDisplay.Id;
                                    rootPage.SelectedBleDeviceName = bluetoothLEDeviceDisplay.Name;
                                    //��ѡ���ֻ��Զ����� �÷������ӳɹ�������������������������Զ�д��
                                    ConnectButton_Click();
                                }
                                else
                                {//��Բ��ɹ������Ϊд��ʧ��
                                    Debug.WriteLine("��д���������豸���ʧ�ܡ�");

                                    rootPage.NotifyUser("�������ʧ��"+ devicePairingResult.Status.ToString(), NotifyType.ErrorMessage);
                                    //����״̬Ϊд��ʧ��
                                    //ʱ���
                                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                                    //�������ݿ�write��д��״̬
                                    bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                                }
                                



                            }

                        }

                    }
                    else
                    {
                        Debug.WriteLine("��д����������");

                    }



                }
                catch (Exception e)
                {

                }
            },
            period);
        }


        /// <summary>
        /// ����ǰѡ����ֻ����Ƹ�ֵ
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
                //    WriteLine("�����б�" + KnownDevices[i].ToString());

                //}
                DataContractJsonSerializer json = new DataContractJsonSerializer(KnownDevices.GetType());
                string szJson = "";
                //���л�
                using (MemoryStream stream = new MemoryStream())
                {
                    json.WriteObject(stream, KnownDevices);
                    szJson = Encoding.UTF8.GetString(stream.ToArray());

                }
                WriteLine("�����б�" + szJson);

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
            //����ֹͣ�¼�ʱ���������������ݽ��и��¡��������ݿ����
            deviceWatcher.Stopped += DeviceWatcher_Stopped;


            // Start over with an empty collection.
            KnownDevices.Clear();

            // Start the watcher. Active enumeration is limited to approximately 30 seconds.
            // This limits power usage and reduces interference with other Bluetooth activities.
            // To monitor for the presence of Bluetooth LE devices for an extended period,
            // use the BluetoothLEAdvertisementWatcher runtime class. See the BluetoothAdvertisement
            // sample for an example.
            deviceWatcher.Start();
            Debug.WriteLine("����������������" + System.DateTime.Now);

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


            //��ʼ֮ǰ��������豸���� ����async�¼�����ò������߳�ȫ�ֱ����ķ��� �ᱨӦ�ó������һ����Ϊ��һ�̵߳Ľӿ��쳣��ֱ���˳� �����Լ�Ҳ��Remove����Ҫ��
            //KnownDevices.Clear();
            //ֹͣ�¼����¿�ʼ�������� ע�����DeviceWatcher_Stopped�����ҵ��� ������ѭ�� 

            //����ط�����Read���ʱ����ܺͶ�ʱ���������write������ͻ��Busy�쳣 SQLiteû�и��ӵ�������
            try
            {
                //deviceWatcher.Start();
                //Debug.WriteLine("������������");

                //�Լ��ӵ� ������������ɵ�ʱ��ֹͣ����

                Debug.WriteLine("���������������豸���и��¡����봦��");

                //ʵ�������뼯��
                List<BluetoothReadEntity> bluetoothReadEntities = new List<BluetoothReadEntity>();

                for (int i = 0; i < KnownDevices.Count; i++)
                {
                    BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay = KnownDevices[i] as BluetoothLEDeviceDisplay;
                    Debug.WriteLine("�������������豸" + bluetoothLEDeviceDisplay.Id + bluetoothLEDeviceDisplay.Name);
                    //ʱ���
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);

                    //�����������Ʋ�ѯ���ݿ⣬�������ݾ͸���scan_count +1 ������������ݡ���ֹ�ظ�������ɱ������ݹ���
                    List<BluetoothReadEntity> queryReadEntitys = await SQLiteUtil.GetReadEntityByBluetoothName(bluetoothLEDeviceDisplay.Name);

                    var bluetoothReadEntity = new BluetoothReadEntity();


                    //���ݿ����и��ֻ����ݾ͸��¼��� ��������¼�¼
                    if (queryReadEntitys.Count > 0)
                    {
                        //��Ϊsqlֻ�ܷ��ؼ��� ���Ը����޸�ʱ���ɴ�С����ѡ�����µ�һ��
                        bluetoothReadEntity = queryReadEntitys[0];
                        bluetoothReadEntity.Scan_count += 1;
                        bluetoothReadEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);
                        //����read��
                        await SQLiteUtil.UpdateReadTable(bluetoothReadEntity);
                    }
                    else//���ݿ���û�и��ֻ�����  ��ӽ����뼯��
                    {
                        bluetoothReadEntity.Member_id = bluetoothLEDeviceDisplay.Name;
                        bluetoothReadEntity.Scan_count = 0;
                        bluetoothReadEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                        //��ӽ����뼯��
                        bluetoothReadEntities.Add(bluetoothReadEntity);
                    }




                }

                //�����ݿ���û�е����� �����������ݿ�
                await SQLiteUtil.BatchInsertRead(bluetoothReadEntities);


            }
            catch (Exception)
            {

                throw;
            }


            //ֹͣ���� ����ֹͣ�¼�
            deviceWatcher.Stop();






        }
        /// <summary>
        /// ֹͣ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeviceWatcher_Stopped(DeviceWatcher sender, object e)
        {
            // Start over with an empty collection. ������б�������

            Debug.WriteLine("������������ֹͣ�¼�" + System.DateTime.Now);


            

            //���¿�ʼ��������
            deviceWatcher.Start();

            Debug.WriteLine("STOP�¼����¿�ʼ��������" + System.DateTime.Now);

            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    rootPage.NotifyUser($"����ֹͣNo longer watching for devices.",
                            sender.Status == DeviceWatcherStatus.Aborted ? NotifyType.ErrorMessage : NotifyType.StatusMessage);
                }
            });
        }
        #endregion

        #region Pairing

        private bool isBusy = false;

        /// <summary>
        /// ������ӷ��� ������԰�ť���� ����ʵ�������
        /// </summary>
        /// <param name="bluetoothLEDeviceDisplay"></param>
        private async Task<DevicePairingResult> PairBluetooth(BluetoothLEDeviceDisplay bluetoothLEDeviceDisplay)
        {
            //�µ����ӷ�ʽ ���ݴ����������
            var bleDeviceDisplay = bluetoothLEDeviceDisplay;
            // BT_Code: Pair the currently selected device.
            DevicePairingResult result = await bleDeviceDisplay.DeviceInformation.Pairing.PairAsync();

            // Do not allow a new Pair operation to start if an existing one is in progress.
            if (isBusy)
            {
                return result;
            }

            isBusy = true;

            rootPage.NotifyUser("�Ѿ���ʼ��� Pairing started. Please wait...", NotifyType.StatusMessage);

            // For more information about device pairing, including examples of
            // customizing the pairing process, see the DeviceEnumerationAndPairing sample.

            // Capture the current selected item in case the user changes it while we are pairing.
            //ԭ�������ӷ�ʽ ����ѡ�����
            //var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;

            Debug.WriteLine("����ֻ����ӽ�� = " + result.Status);
            rootPage.NotifyUser($"��Խ�� Pairing result = {result.Status}",
                result.Status == DevicePairingResultStatus.Paired || result.Status == DevicePairingResultStatus.AlreadyPaired
                    ? NotifyType.StatusMessage
                    : NotifyType.ErrorMessage);
            //�����Գɹ� ���������д洢��id���ֻ����Ƹ�ֵ��


            isBusy = false;

            return result;





        }



        /// <summary>
        /// ������Ӱ�ť����¼�
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
            //ԭ�������ӷ�ʽ ����ѡ�����
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



        #region ���¼����������Զ�д���ֻ����ݵķ���

        /// <summary>
        /// 1.���Ӱ�ť �������ӵ��豸ID��ѯ����
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
                Debug.WriteLine("��ʼ��������");
                //����ѡ����豸id��������  ǰ��Timer�а����ݿ����������ݸ�ֵ����������
                // BT_Code: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
                bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(rootPage.SelectedBleDeviceId);
                //����ʧ�� �������ݿ�״̬Ϊʧ��
                if (bluetoothLeDevice == null)
                {
                    rootPage.NotifyUser("Failed to connect to device.", NotifyType.ErrorMessage);
                    Debug.WriteLine("��������ʧ��");

                    //ʱ���
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //�������ݿ�write��д��״̬
                    bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                }


                //���ӳɹ�
                if (bluetoothLeDevice != null)
                {
                    Debug.WriteLine("�������ӳɹ�");
                    rootPage.NotifyUser("�������ӳɹ�", NotifyType.StatusMessage);

                    // Note: BluetoothLEDevice.GattServices property will return an empty list for unpaired devices. For all uses we recommend using the GetGattServicesAsync method.
                    // BT_Code: GetGattServicesAsync returns a list of all the supported services of the device (even if it's not paired to the system).
                    // If the services supported by the device are expected to change during BT usage, subscribe to the GattServicesChanged event.
                    //�������������GATT�����б�  ����ط������һֱѭ��ִ�� �ᱨ�������쳣
                    GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached);
                    //��÷���ɹ�
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        //���񼯺�
                        var services = result.Services;
                        rootPage.NotifyUser(String.Format("Found {0} services", services.Count), NotifyType.StatusMessage);

                        //ԭ�ȵı��������б���ӵ�����Ĳ���������Ҫ
                        //foreach (var service in services)
                        //{
                        //    ServiceCollection.Add(new BluetoothLEAttributeDisplay(service));
                        //}
                        //ConnectButton.Visibility = Visibility.Collapsed;
                        //ServiceList.Visibility = Visibility.Visible;

                        //���������б� �Զ�ѡ��custom service 000001ff-3c17-d293-8e48-14fe2e4da212 ������ѡ���Զ����д����񣬵������ѯ��������
                        foreach (var service in services)
                        {//������Ҫ�õ����ݾ͸���һ��״̬�����������ӵ��ֻ��޷��񣬲�������±ߵĲ�����д��״̬��һֱ��0��Ȼ���һֱ�������ӣ��ͻ��������쳣
                            Debug.WriteLine("��ǰ�������������ķ���DeviceId:{0},Uuid:{1},AttributeHandle:{2}", service.DeviceId, service.Uuid, service.AttributeHandle);
                            //����ֱ����Ҫѡ���д����񣬲Ŷ���һ��������ò�ѯ��������
                            if ("000001ff-3c17-d293-8e48-14fe2e4da212".Equals(service.Uuid.ToString()))
                            {
                                Debug.WriteLine("���ҵ������豸ָ�����񣬽���������������");
                                //��һ���Ǹ��ݷ����ѯ���� ����������
                                BluetoothLEAttributeDisplay bluetoothLEAttributeDisplay = new BluetoothLEAttributeDisplay(service);
                                //���ò�ѯ����������
                                ServiceList_SelectionChanged(bluetoothLEAttributeDisplay);
                            }


                        }

                    }
                    else
                    {
                        Debug.WriteLine("��д����������ȡGATT����ʧ�� Device unreachable��");

                        rootPage.NotifyUser("��ȡGATT����ʧ�� Device unreachable", NotifyType.ErrorMessage);
                        //����״̬Ϊд��ʧ��
                        //ʱ���
                        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        //�������ݿ�write��д��״̬
                        bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                        bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                        await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    }
                }

            }
            catch (Exception ex) when (ex.HResult == E_DEVICE_NOT_AVAILABLE)
            {
                rootPage.NotifyUser("Bluetooth radio is not on.", NotifyType.ErrorMessage);
                //����״̬Ϊд��ʧ��
                //ʱ���
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //�������ݿ�write��д��״̬
                bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
            }

            //ConnectButton.IsEnabled = true;
        }
        #endregion


        #region Enumerating Characteristics 
        /// <summary>
        /// �����б�����¼� ����ѡ��ķ����ѯ���������� ����Ĳ���Ϊѡ��������豸�ķ���չʾ����
        /// </summary>
        private async void ServiceList_SelectionChanged(BluetoothLEAttributeDisplay attributeInfoDisp)
        {
            //var attributeInfoDisp = (BluetoothLEAttributeDisplay)ServiceList.SelectedItem;

            //CharacteristicCollection.Clear();
            //RemoveValueChangedHandler();

            IReadOnlyList<GattCharacteristic> characteristics = null;
            try
            {
                // Ensure we have access to the device.ȷ�����ǿ������ӵ��豸
                var accessStatus = await attributeInfoDisp.service.RequestAccessAsync();
                if (accessStatus == DeviceAccessStatus.Allowed)
                {
                    // BT_Code: Get all the child characteristics of a service. Use the cache mode to specify uncached characterstics only 
                    // and the new Async functions to get the characteristics of unpaired devices as well. 
                    //�Ͳ�ѯ�������� ��ѯ�÷����Ӧ����������
                    var result = await attributeInfoDisp.service.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        //��ѯ�ɹ�����������ϸ�ֵ
                        characteristics = result.Characteristics;
                        //Ȼ��������Ը�ȫ�ֱ�����ǰѡ���������ֵ ����Ҫѡ���������6522
                        foreach (var characteristic in characteristics)
                        {
                            Debug.WriteLine("��ǰ���������������AttributeHandle:{0},UserDescription:{1},Uuid:{2},�������ԣ�{3}", characteristic.AttributeHandle, characteristic.UserDescription, characteristic.Uuid, characteristic.CharacteristicProperties);
                            //65282:AttributeHandle(����ΨһID) = 12,CharacteristicProperties(��������):writeWithoutResponse
                            //65283:AttributeHandle(����ΨһID) = 14,CharacteristicProperties(��������):write
                            //65282:AttributeHandle(����ΨһID) = 16,CharacteristicProperties(��������):Read | Notify

                            //�����Ǹ���AttributeHandle�жϵ�������� Ҳ���Ը���UUID�ж�
                            if (characteristic.AttributeHandle == 14)
                            {
                                //��ȫ�ֶ���ѡ���������ֵ д���ʱ��ʹ�ø�����д��
                                selectedCharacteristic = characteristic;
                                Debug.WriteLine("���Ѿ��ҵ�ָ��������׼��д�롿");

                                if (memberId != null && memberId != "")
                                {
                                    Debug.WriteLine("��Ҫд����û�ID��" + memberId);
                                    //��ת��UTF8���ֽ������ټ���Э��ͷ ����������Hex����
                                    byte[] group = Encoding.UTF8.GetBytes(memberId);

                                    byte[] writeData = ProtocolUtil.packWriteData(group);

                                    //����д�뷽��
                                    await WriteBufferToSelectedCharacteristicAsync(ProtocolUtil.Bytes2Buffer(writeData));
                                }
                                //WriteBufferToSelectedCharacteristicAsync();
                            }
                            

                        }
                    }
                    else
                    {
                        rootPage.NotifyUser("�޷��������� Error accessing service.", NotifyType.ErrorMessage);

                        // On error, act as if there are no characteristics.
                        characteristics = new List<GattCharacteristic>();

                        //����״̬Ϊд��ʧ��
                        //ʱ���
                        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        //�������ݿ�write��д��״̬
                        bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                        bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                        await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    }
                }
                else
                {
                    // Not granted access
                    rootPage.NotifyUser("�޷��������� Error accessing service.", NotifyType.ErrorMessage);

                    // On error, act as if there are no characteristics.
                    characteristics = new List<GattCharacteristic>();


                    //����״̬Ϊд��ʧ��
                    //ʱ���
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //�������ݿ�write��д��״̬
                    bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                }
            }
            catch (Exception ex)
            {
                rootPage.NotifyUser("�޷���ȡ���� Restricted service. Can't read characteristics: " + ex.Message,
                    NotifyType.ErrorMessage);
                // On error, act as if there are no characteristics.
                characteristics = new List<GattCharacteristic>();

                //����״̬Ϊд��ʧ��
                //ʱ���
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //�������ݿ�write��д��״̬
                bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
            }
            //������������
            //foreach (GattCharacteristic c in characteristics)
            //{
            //    CharacteristicCollection.Add(new BluetoothLEAttributeDisplay(c));
            //}
            //CharacteristicList.Visibility = Visibility.Visible;
        }
        #endregion


        /// <summary>
        /// ѡ�������¼� ��ʵ�Ͱ���һ����  ���Ǹ�ȫ�ֶ���ѡ���������ֵ ��ȷ���������Ƿ���� ���о���ʾҳ�档������������� ֱ������һ��ѡ������selectedCharacteristic��ֵ
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

            //�������Ҫ�� ȷ��ѡ��ķ��� ԭ���Ǹ��ݽ����ѡ��ֵ ���ڸĳɴ���ķ���������
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
        /// д��UTF-8�ַ���
        /// </summary>
        private async void CharacteristicWriteButton_Click()
        {
            //�ж�Ҫд����ı���Ϊ��
            //if (!String.IsNullOrEmpty(CharacteristicWriteValue.Text))
            //{
            //    var writeBuffer = CryptographicBuffer.ConvertStringToBinary(CharacteristicWriteValue.Text,
            //        BinaryStringEncoding.Utf8);
            //    Debug.WriteLine("ԭ��д���2�������ݴ���" + writeBuffer);


            //    //����д�뷽��
            //    var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(writeBuffer);
            //}
            //else
            //{
            //    rootPage.NotifyUser("No data to write to device", NotifyType.ErrorMessage);
            //}
        }


        /// <summary>
        /// д��UTF-8��ť����¼����õ�д�뺯�� ����Ҫд�������
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private async Task<bool> WriteBufferToSelectedCharacteristicAsync(IBuffer buffer)
        {
            try
            {
                //�²�BT_CODE��������룿���ֽ�д�뷽��
                // BT_Code: Writes the value from the buffer to the characteristic.
                //ѡ������� ��Ҫָ��ѡ�е�����
                var result = await selectedCharacteristic.WriteValueWithResultAsync(buffer);

                if (result.Status == GattCommunicationStatus.Success)
                {
                    Debug.WriteLine("��д��ɹ���");
                    rootPage.NotifyUser("Successfully wrote value to device", NotifyType.StatusMessage);
                    //ʱ���
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //�������ݿ�write��д��״̬
                    bluetoothWriteEntity.Write_state = 1;//����д��ɹ�
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    return true;
                }
                else
                {
                    Debug.WriteLine("��д��ʧ�ܡ�");

                    rootPage.NotifyUser($"Write failed: {result.Status}", NotifyType.ErrorMessage);

                    //ʱ���
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    //�������ݿ�write��д��״̬
                    bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                    bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                    await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);
                    return false;
                }
                //д����ɺ�Ͽ�����
                //���ö�ȡ����
               
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_INVALID_PDU)
            {

                //����״̬Ϊд��ʧ��
                //ʱ���
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //�������ݿ�write��д��״̬
                bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                return false;
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED || ex.HResult == E_ACCESSDENIED)
            {

                //����״̬Ϊд��ʧ��
                //ʱ���
                TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //�������ݿ�write��д��״̬
                bluetoothWriteEntity.Write_state = 2;//����д��ʧ��
                bluetoothWriteEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                await SQLiteUtil.UpdateWriteTable(bluetoothWriteEntity);

                // This usually happens when a device reports that it support writing, but it actually doesn't.
                rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                return false;
            }
        }
        /// <summary>
        /// ��ȡ���ݷ���
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
