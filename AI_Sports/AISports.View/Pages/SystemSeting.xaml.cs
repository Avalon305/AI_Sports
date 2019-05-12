using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AI_Sports.AISports.Constant;
using AI_Sports.AISports.Service;
using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Util;
using AISports.Util;

namespace AI_Sports.AISports.View.Pages
{
	/// <summary>
	/// SystemSeting.xaml 的交互逻辑
	/// </summary>
	public partial class SystemSeting : Page
	{

		private SystemSettingService systemSettingService = new SystemSettingService();
		private int isNUll; //0为空，1位非空
		SystemSettingEntity AddsystemSettingEntity = new SystemSettingEntity();

        public static SerialPort serialPort = null;

        public SystemSeting()
		{
			InitializeComponent();
            //自动初始化串口
            autoContentPort();
            SystemSettingEntity systemSettingEntity = systemSettingService.GetSystemSetting();
			
			if (systemSettingEntity != null)
			{
				isNUll = 1;
				string name = systemSettingEntity.Organization_name;
				string phone = systemSettingEntity.Organization_phone;
				string address = systemSettingEntity.Organization_address;
				int? version = systemSettingEntity.System_version;
				if (name != null)
				{
					this.Oname.Text = name;
				}
				else
				{
					this.Oname.Text = "";
				}

				if (phone != null)
				{
					this.Ophone.Text = phone;
				}
				else {
					this.Ophone.Text = "";
				}

				if (address != null)
				{
					this.Oaddress.Text = address;
				}
				else
				{
					this.Oaddress.Text = "";
				}
				if (version != null)
				{
					if(version == 0)
					{
						this.Oversion.Text = "标准版（三种训练模式）";
					}
					else if(version ==1)
					{
						this.Oversion.Text = "豪华版（六种训练模式）";

					}

				}
				else
				{
					this.Oversion.Text = "";

				}
                

			}
			else
			{
				isNUll = 0;

				
			}
			 
		}
		private void WrapPanel_MouseUp(object sender, MouseButtonEventArgs e)
		{
			//MessageBox.Show("hello");
			Moudle moudle = new Moudle();
			moudle.ShowDialog();
			if (moudle.SystemPassword.Password == ConfigUtil.Get("SystemSettingPassword"))
			{
				this.Oversion.IsEnabled = true;
			}
			else
			{
				MessageBoxX.Show("错误","密码输入错误");
			}

		}
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void Button_Click(object sender, RoutedEventArgs e)
		{
            //连接所选串口 并更新配置类读卡器串口
            Serial_Connect();


            if (isNUll == 0) { 
				//此时为插入一条新数据
			SystemSettingEntity sse = new SystemSettingEntity();
			sse.Id = 1;
			sse.Organization_name = this.Oname.Text;
			sse.Organization_phone = this.Ophone.Text;
			sse.Organization_address = this.Oaddress.Text;
			sse.Ip_address = "127.0.0.1";
			if (this.Oversion.Text == "标准版（三种训练模式）")
			{
				sse.System_version = 0;

			}
			else
			{
				sse.System_version = 1;
			}
                //初始化使用时间：开机时间加上六个月
                sse.Auth_OfflineTime = DateTime.Now.AddMonths(+6);
                //客户机状态为正常状态
                sse.User_Status = SystemSettingEntity.USER_STATUS_GENERAL;

                //获取mac地址
                StringBuilder stringBuilder = new StringBuilder();
                //string strMac = CommUtil.GetMacAddress();
                // List<string> Macs = CommUtil.GetMacByWMI();
                List<string> Macs = CommUtil.GetMacByIPConfig();
                foreach (string mac in Macs)
                {
                    string prefix = "物理地址. . . . . . . . . . . . . : ";
                    string Mac = mac.Substring(prefix.Length - 1);
                    stringBuilder.Append(Mac);
                }

                //mac地址先变为byte[]再aes加密
                byte[] byteMac = Encoding.GetEncoding("GBK").GetBytes(stringBuilder.ToString());
                byte[] AesMac = AesUtil.Encrypt(byteMac, ProtocolConstant.USB_DOG_PASSWORD);
                //存入数据库
                //setter.Set_Unique_Id = Encoding.GetEncoding("GBK").GetString(AesMac);
                sse.Set_Unique_Id = ProtocolUtil.BytesToString(AesMac);

                //如果为空才可以插入
                if (systemSettingService.GetSystemSetting() == null)
                {
                    systemSettingService.InsertSystemSet(sse);
                }
            }
			else if(isNUll==1){
				//为1时，是更新数据
			
				SystemSettingEntity sse = new SystemSettingEntity();
                //更新之前查出不需要更改的那部分内容（用户状态，使用时间，客户机唯一id），再重新赋值
                SystemSettingEntity systemSetting = new SystemSettingEntity();
                systemSetting = systemSettingService.GetSystemSetting();
                //赋值
                sse.User_Status = systemSetting.User_Status;
                sse.Set_Unique_Id = systemSetting.Set_Unique_Id;
                sse.Auth_OfflineTime = systemSetting.Auth_OfflineTime;

                sse.Id = 1;
				sse.Organization_name = this.Oname.Text;
				sse.Organization_phone = this.Ophone.Text;
				sse.Organization_address = this.Oaddress.Text;
				sse.Ip_address = "127.0.0.1";
				if (this.Oversion.Text == "标准版（三种训练模式）")
				{
					sse.System_version = 0;

				}
				else
				{
					sse.System_version = 1;
				}


				systemSettingService.UpdataSystemSet(sse);
			}

            MessageBoxX.Show("温馨提示","保存成功");
		}

        /// <summary>
        /// 自动选中串口 addbyCQZ 5.11 从发卡窗口迁移过来统一设置
        /// </summary>
        private void autoContentPort()
        {
            string port = "";
            //从app.config中获取
            port = CommUtil.GetSettingString("ReadSerialPort");
            initPort();

            if (port != "")
            {
                //如果有串口，选中串口
                comboBox.SelectedValue = port;
            }
        }

        /// <summary>
        /// 初始化搜索到的串口
        /// </summary>
        private void initPort()
        {
            string[] names = SerialPort.GetPortNames();
            List<String> list = new List<String>();
            foreach (string name in names)
            {
                list.Add(name);
            }
            comboBox.ItemsSource = list;
        }
        /// <summary>
        /// 连接串口 更新配置中的读卡器串口
        /// </summary>
        private void Serial_Connect()
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("请选择串口", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            comboBox.IsEnabled = false;


            string name1 = comboBox.SelectedValue.ToString();
            serialPort = new SerialPort();
            serialPort.PortName = name1;
            serialPort.BaudRate = 115200;
            serialPort.ReadTimeout = 3000; //单位毫秒
            serialPort.WriteTimeout = 3000; //单位毫秒
            serialPort.ReceivedBytesThreshold = 1;
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(OnPortDataReceived);
            try
            {
                MainWindow.serialPort.Open();

                //如果连接成功，更新读卡串口号 
                CommUtil.UpdateSettingString("ReadSerialPort", name1);
                MessageBoxX.Show("温馨提示","读卡器串口连接成功，请重启系统后生效");
                //if (CommUtil.GetSettingString("SerialPort") == "")
                //{
                //}
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("串口被占用", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                comboBox.IsEnabled = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("串口不存在", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                comboBox.IsEnabled = true;
            }

        }

        //无法自动连接时,进行手动连接,初始化下拉列表
        private void comboBox_DropDownOpened(object sender, EventArgs e)
        {
            initPort();
        }
        /// <summary>
        /// 接收方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OnPortDataReceived(Object sender, SerialDataReceivedEventArgs e)
        //{
        //    Console.WriteLine("接受到数据");
        //    Thread.Sleep(50);
        //    byte[] buffer = null; ;
        //    int len = serialPort.BytesToRead;
        //    byte[] first = new byte[len];
        //    serialPort.Read(first, 0, len);
        //    Console.WriteLine(SerialPortUtil.ByteToHexStr(first));
        //    int offset = 0;
        //    //校验帧头
        //    if (len > 0 && first[0] == 0xAA)
        //    {

        //        byte datalen = first[2];
        //        buffer = new byte[datalen + 5];

        //        for (int i = 0; i < first.Length; i++)
        //        {
        //            buffer[i] = first[i];
        //        }
        //        offset = first.Length;

        //    }
        //    else
        //    {
        //        serialPort.DiscardInBuffer();
        //        return;
        //    }

        //    //下面是完整数据
        //    if (buffer != null)
        //    {
        //        Console.WriteLine("buffer不为空，通过校验");
        //        //既然已经到了这里说明帧头帧尾已校验通过

        //        //取出命令字
        //        byte[] cmd = { buffer[1] };

        //        //取出数据长度 byte中为0x10那么string(x2)就为10,string()为16
        //        int data_len = int.Parse(buffer[2].ToString());

        //        //取出数据
        //        byte[] obj_data = new byte[data_len];
        //        for (int i = 0; i < data_len; i++)
        //        {
        //            obj_data[i] = buffer[i + 3];
        //        }

        //        //XOR校验,如果错误直接返回
        //        byte[] data_xor = new byte[2 + obj_data.Length];
        //        data_xor[0] = cmd[0];
        //        data_xor[1] = buffer[2];
        //        Buffer.BlockCopy(obj_data, 0, data_xor, 2, obj_data.Length);
        //        Console.WriteLine(SerialPortUtil.ByteToHexStr(data_xor));
        //        byte compute_xor = SerialPortUtil.Get_CheckXor(data_xor);
        //        Console.WriteLine("compute_xor为" + compute_xor.ToString("x2"));
        //        if (!buffer[buffer.Length - 2].Equals(compute_xor))
        //        {
        //            return;
        //        }

        //        //如果命令字等于发卡的应答
        //        Console.WriteLine("cmd为" + cmd[0]);
        //        Console.WriteLine("CommondConstant.readCard" + CommondConstant.readCard[0]);

        //        //如果命令字等于读卡
        //        if (cmd[0] == CommondConstant.readCard[0])
        //        {
        //            byte[] namebytewithzero = new byte[10];
        //            //byte[] phonebyte = new byte[2];
        //            byte[] phonebyte = new byte[4];
        //            byte[] crc = new byte[2];
        //            Buffer.BlockCopy(obj_data, 0, namebytewithzero, 0, namebytewithzero.Length);//提取姓名
        //            string strName = SerialPortUtil.GetEndString(namebytewithzero, 0);
        //            Console.WriteLine(strName);//解析姓名
        //            Buffer.BlockCopy(obj_data, 10, phonebyte, 0, phonebyte.Length);//提取手机号
        //            string strPhone = Encoding.ASCII.GetString(phonebyte);
        //            Console.WriteLine(strPhone);//解析手机号
        //            //Buffer.BlockCopy(obj_data, 12, crc, 0, crc.Length);//提取CRC
        //            //string strCRC = SerialPortUtil.ByteToHexStr(crc);
        //            //string lowStrCRC = obj_data[12].ToString();
        //            //string highStrCRC = obj_data[13].ToString();
        //            //string strCRC = lowStrCRC + highStrCRC;
        //            //Console.WriteLine(strCRC);//解析CRC
        //            //ReceiveValues(strName + strPhone + strCRC);
        //            string memberId = strName + strPhone;
        //            //工作线程中调用主线程委托调用提示窗或者跳转页面
        //            //App.Current.Dispatcher.Invoke(new Action(() =>
        //            //{
        //            //    Login(memberId);


        //            //}));
        //        }


        //    }
        //}
    }
}
