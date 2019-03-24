using AI_Sports.AISports.Util;
using System;
using System.Collections.Generic;
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
    /// NolleTest.xaml 的交互逻辑
    /// </summary>
    public partial class NolleTest : Window
    {
        public NolleTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SpeechUtil.read("hello 徐靖皓");
            string name = "徐靖皓";
            Console.WriteLine(name.Length);
            Console.WriteLine(SerialPortUtil.strToToHexByte("1010")[0].ToString("x2"));
            byte[] arr = { 0x31, 0x32, 0x33, 0x34 };
           Console.WriteLine( SerialPortUtil.CRC16(arr)[0].ToString());
        }
    }
}
