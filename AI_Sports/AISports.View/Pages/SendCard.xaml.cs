using AI_Sports.AISports.Constant;
using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
using AI_Sports.AISports.Util;
using AI_Sports.Service;
using AI_Sports.Util;
using NLog;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// WriteBluetooth.xaml 的交互逻辑
    /// </summary>
    public partial class SendCard : Window
    {
        public static SerialPort serialPort = null;

        public SendCard()
        {
            InitializeComponent();
            //自动初始化串口
            autoContentPort();
            this.TB_Member_Id.Text = CommUtil.GetSettingString("memberId");

        }

        /// <summary>
        /// 接收方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPortDataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("接受到数据");
            Thread.Sleep(50);
            byte[] buffer = null; ;
            int len = serialPort.BytesToRead;
            byte[] first = new byte[len];
            serialPort.Read(first, 0, len);
            Console.WriteLine(SerialPortUtil.ByteToHexStr(first));
            int offset = 0;
            //校验帧头
            if (len > 0 && first[0] == 0xAA)
            {

                byte datalen = first[2];
                buffer = new byte[datalen + 5];

                for (int i = 0; i < first.Length; i++)
                {
                    buffer[i] = first[i];
                }
                offset = first.Length;

            }
            else
            {
                serialPort.DiscardInBuffer();
                return;
            }

            //下面是完整数据
            if (buffer != null)
            {
                Console.WriteLine("buffer不为空，通过校验");
                //既然已经到了这里说明帧头帧尾已校验通过

                //取出命令字
                byte[] cmd = { buffer[1] };

                //取出数据长度 byte中为0x10那么string(x2)就为10,string()为16
                int data_len = int.Parse(buffer[2].ToString());

                //取出数据
                byte[] obj_data = new byte[data_len];
                for (int i = 0; i < data_len; i++)
                {
                    obj_data[i] = buffer[i + 3];
                }

                //XOR校验,如果错误直接返回
                byte[] data_xor = new byte[2 + obj_data.Length];
                data_xor[0] = cmd[0];
                data_xor[1] = buffer[2];
                Buffer.BlockCopy(obj_data, 0, data_xor, 2, obj_data.Length);
                Console.WriteLine(SerialPortUtil.ByteToHexStr(data_xor));
                byte compute_xor = SerialPortUtil.Get_CheckXor(data_xor);
                Console.WriteLine("compute_xor为" + compute_xor.ToString("x2"));
                if (!buffer[buffer.Length - 2].Equals(compute_xor))
                {
                    return;
                }

                //如果命令字等于发卡的应答
                Console.WriteLine("cmd为" + cmd[0]);
                Console.WriteLine("CommondConstant.ResSendCard为" + CommondConstant.ResSendCard[0]);
                if (cmd[0] == CommondConstant.ResSendCard[0])
                {
                    //MessageBox.Show("发卡成功");
                    if (obj_data[0] == CommondConstant.error)
                    {
                        this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                        {
                            MessageBoxX.Show("温馨提示", "发卡失败");
                        });
                    }

                    if (obj_data[0] == CommondConstant.success)
                    {
                        this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                        {
                            MessageBoxX.Show("温馨提示", "发卡成功");
                        });
                    }

                    if (obj_data[0] == CommondConstant.noCard)
                    {
                        this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                        {
                            MessageBoxX.Show("温馨提示", "无卡");

                            //MessageBox.Show("无卡", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                        });
                    }
                }

                //如果命令字等于读卡 此处无用！
                if (cmd[0] == CommondConstant.readCard[0])
                {
                    byte[] namebytewithzero = new byte[10];
                    byte[] phonebyte = new byte[4];
                    Buffer.BlockCopy(obj_data, 0, namebytewithzero, 0, namebytewithzero.Length);//提取姓名
                    Console.WriteLine(SerialPortUtil.GetEndString(namebytewithzero, 0));//解析姓名
                    Buffer.BlockCopy(obj_data, 10, phonebyte, 0, phonebyte.Length);//提取手机号
                    Console.WriteLine(Encoding.ASCII.GetString(phonebyte));//解析手机号

                }
                serialPort.Close();
            }
        }
        /// <summary>
        /// 发卡按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //发卡按钮点击自动连接选中的串口
            Serial_Connect();
            //初始化数组
            byte[] data = new byte[14];
            //打包数据
            packSendCard(ref data);
            Console.WriteLine("数据部分" + SerialPortUtil.ByteToHexStr(data));
            //组装协议头、协议尾
            byte[] buffer = SerialPortUtil.packData(CommondConstant.sendCard, data);
            //给出等待提示-正在发卡,请稍后
            //发卡
            serialPort.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 打包数据部分
        /// </summary>
        private void packSendCard(ref byte[] data)
        {
            //string telephone = "5791";
            //string name = "徐靖皓";
            string memberId = this.TB_Member_Id.Text;
            Console.WriteLine("写入用户Id:"+memberId.ToString());
            //string memberId = CommUtil.GetSettingString("memberId");//姓名-手机号后两位-CRC(0x01 0x02--12) CommUtil.GetSettingString("memberId");
            string name = "";
            string phone = "";
            //byte[] crc = new byte[2];
            //SerialPortUtil.splitMemberId(ref name, ref crc, ref phone, memberId);

            

            SerialPortUtil.splitMemberId(ref name, ref phone, memberId);
            Console.WriteLine("name:" + name);
            Console.WriteLine("phone:" + phone);
            //Console.WriteLine("crc:" + SerialPortUtil.ByteToHexStr(crc));

            Encoding.GetEncoding("GBK").GetBytes(name, 0, name.Length, data, 0);
            Encoding.GetEncoding("ASCII").GetBytes(phone, 0, phone.Length, data, 10);
            //Buffer.BlockCopy(crc, 0, data, 12, crc.Length);

        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //无法自动连接时,进行手动连接,初始化下拉列表
        private void comboBox_DropDownOpened(object sender, EventArgs e)
        {
            initPort();
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
        private void changeStateEnable(bool isEnable)
        {
            if (isEnable)
            {
                button4.IsEnabled = true;
            }
            else
            {
                button4.IsEnabled = false;
            }
        }
        //将连接按钮取消，点击发卡时自动连接选中的串口
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
            serialPort.DataReceived += new SerialDataReceivedEventHandler(OnPortDataReceived);
            try
            {
                serialPort.Open();

                //如果连接成功，插入串口号 
                if (CommUtil.GetSettingString("SerialPort") == "")
                {
                    CommUtil.UpdateSettingString("SerialPort", name1);
                }
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
        /// <summary>
        /// 自动选中串口
        /// </summary>
        private void autoContentPort()
        {
            string port = "";
            //从app.config中获取
            port = CommUtil.GetSettingString("SerialPort");
            initPort();

            if (port != "")
            {
                //如果有串口，选中串口
                comboBox.SelectedValue = port;
            }
        }

    }

}

