using AI_Sports.AISports.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Controls;

namespace AI_Sports
{
    /// <summary>
    /// AndyTest.xaml 的交互逻辑
    /// </summary>
    public partial class AndyTest : Page
    {
        public AndyTest()
        {
            InitializeComponent();
        }

         private void Button_Click(object sender, RoutedEventArgs e)
         {
             Console.WriteLine("进入Bluetooth");
             // Process.Start(new ProcessStartInfo(@"C:\Users\HP\Desktop\Windows-universal-samples-master\Samples\BluetoothLE\cs\bin\x64\Debug\BluetoothLEUniversal.exe"));
             Process process = new Process();
             //process.StartInfo.FileName = @"C:\Users\HP\Desktop\Windows-universal-samples-master\Samples\BluetoothLE\cs\bin\x64\Debug\BluetoothLEUniversal.exe";
             Process.Start(new ProcessStartInfo("bluetoothzcr:"));
             //Process.Start(new ProcessStartInfo(@"C:\Program Files (x86)\Windows Kits\10\App Certification Kit\microsoft.windows.softwarelogo.appxlauncher.exe", "a2214a83-6d31-41dd-b75f-0b8e56be182d!AppId"));

             Console.WriteLine("Bluetooth结束");
         }



        /* private async void Button_Click(object sender, RoutedEventArgs e)
         {
             string str = "bluetoothzcr://";
             double lat = 11.0;
             double lon = 11.0;

             Uri uri = new Uri(str + "location?lat=" +
             lat.ToString() + "&?lon=" + lon.ToString());
             // Launch the URI
             var success = await Windows.System.Launcher.LaunchUriAsync(uri);
             if (success)
             {
             // URI launched
             Console.WriteLine("发射成功");
             }
             else
             {
             // URI launch failed
             Console.WriteLine("发射失败");
             }
         }*/

    }
}
