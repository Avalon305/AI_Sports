using AI_Sports.AISports.Constant;
using AI_Sports.AISports.Util;
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
                    obj_data[i] = buffer[i + 2];
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
                if (cmd.Equals(CommondConstant.ResSendCard))
                {
                    MessageBox.Show("发卡成功");
                }

                //如果命令字等于读卡
                if (cmd.Equals(CommondConstant.ResSendCard))
                {
                    byte[] namebytewithzero = new byte[10];
                    byte[] phonebyte = new byte[4];
                    Buffer.BlockCopy(obj_data, 0, namebytewithzero, 0, namebytewithzero.Length);//提取姓名
                    Console.WriteLine(Encoding.GetEncoding("GBK").GetString(namebytewithzero));//解析姓名
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
                    MessageBox.Show("串口关闭失败");
                }
                return;
            }

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
                button.Content = "断开";
                button.Style = FindResource("btn-danger") as Style;
                button.ApplyTemplate();
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
            Console.WriteLine(SerialPortUtil.ByteToHexStr(data));
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
                MessageBox.Show("您没有发卡权限", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (button.Content.ToString() == "连接")
            {
                MessageBox.Show("请先连接串口", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else if (button.Content.ToString() == "未插卡")
            {
                MessageBox.Show("请先连接读卡器", "温馨提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            return true;
        }
        /// <summary>
        /// 打包数据部分
        /// </summary>
        private void packSendCard(ref byte[] data)
        {
            string telephone = "5791";
            string name = "徐靖皓";
            Encoding.GetEncoding("GBK").GetBytes(name, 0, name.Length, data, 0);
            Encoding.GetEncoding("ASCII").GetBytes(telephone, 0, telephone.Length, data, 10);

        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {

        }
    }
}
