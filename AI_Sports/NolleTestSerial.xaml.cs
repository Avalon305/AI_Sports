using AI_Sports.AISports.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
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

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {

        }
    }
}
