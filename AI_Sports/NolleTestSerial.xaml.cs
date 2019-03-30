using AI_Sports.AISports.Constant;
using AI_Sports.AISports.Util;
using AI_Sports.AISports.View.Pages;
using AI_Sports.Util;
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

namespace AI_Sports
{
    /// <summary>
    /// NolleTestSerial.xaml 的交互逻辑
    /// </summary>
    public partial class NolleTestSerial : Window
    {

        public static SerialPort serialPort = null;
        public NolleTestSerial()
        {
            InitializeComponent();
            comboBox.ItemsSource = SerialPortUtil.initPort();
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
                byte compute_xor = SerialPortUtil.Get_CheckXor(data_xor);
                if (!buffer[buffer.Length - 2].Equals(compute_xor))
                {
                    return;
                }

                //如果命令字等于发卡的应答
                if (cmd[0].Equals(CommondConstant.ResSendCard))
                {
                    MessageBoxX.Show("成功","发卡成功");
                }

                //如果命令字等于读卡
                if (cmd[0].Equals(CommondConstant.ResSendCard))
                {
                    byte[] namebytewithzero = new byte[10];
                    byte[] phonebyte = new byte[4];
                    Buffer.BlockCopy(obj_data, 0, namebytewithzero, 0, namebytewithzero.Length);//提取姓名
                    Console.WriteLine(SerialPortUtil.GetEndString(namebytewithzero, 0));//解析姓名
                    Buffer.BlockCopy(obj_data, 10, phonebyte, 0, phonebyte.Length);//提取手机号
                    Console.WriteLine(Encoding.ASCII.GetString(phonebyte));//解析手机号

                }


            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (button.Content.ToString() == "断开")
            {
                button.Content = "连接";
                comboBox.IsEnabled = true;
                button.Style = FindResource("btn-success") as Style;
                button.ApplyTemplate();
                try
                {
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBoxX.Show("失败","串口关闭失败");
                }
                return;
            }

            if (comboBox.SelectedIndex == -1)
            {
                MessageBoxX.Show( "温馨提示", "请选择串口");
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
                button.Content = "断开";
                button.Style = FindResource("btn-danger") as Style;
                button.ApplyTemplate();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBoxX.Show( "温馨提示", "串口被占用");
                comboBox.IsEnabled = true;
            }
            catch (IOException ex)
            {
                MessageBoxX.Show( "温馨提示", "串口不存在");
                comboBox.IsEnabled = true;
            }

        }

        /// <summary>
        /// 发卡按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //发卡前校验-是否有发卡权限/是否连接串口/是否连接读卡器
            bool ispass = validateSendCard();
            if (!ispass)
            {
                return;
            }
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
        /// 发卡前校检 TODO
        /// </summary>
        private bool validateSendCard()
        {
            if (button.Content.ToString() == "xx")
            {
                MessageBoxX.Show("温馨提示", "您没有发卡权限");
                return false;
            }
            if (button.Content.ToString() == "连接")
            {
                MessageBoxX.Show( "温馨提示", "请先连接串口");
                return false;

            }
            else if (button.Content.ToString() == "未插卡")
            {
                MessageBoxX.Show("温馨提示", "请先连接读卡器");
                return false;

            }
            return true;
        }
        /// <summary>
        /// 打包数据部分
        /// </summary>
        private void packSendCard(ref byte[] data)
        {
            //string telephone = "5791";
            //string name = "徐靖皓";
            string memberId = "徐靖皓9101AA";//姓名-手机号后两位-CRC CommUtil.GetSettingString("memberId");
            string name = "";
            string phone = "";
            byte[] crc = new byte[2];
            SerialPortUtil.splitMemberId(ref name, ref crc, ref phone, memberId);
            Console.WriteLine("name:" + name);
            Console.WriteLine("phone:" + phone);
            Console.WriteLine("crc:" + SerialPortUtil.ByteToHexStr(crc));

            Encoding.GetEncoding("GBK").GetBytes(name, 0, name.Length, data, 0);
            Encoding.GetEncoding("ASCII").GetBytes(phone, 0, phone.Length, data, 10);
            Buffer.BlockCopy(crc, 0, data, 12, crc.Length);

        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {

        }
    }
}
