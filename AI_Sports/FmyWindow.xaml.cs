using AI_Sports.Service;
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
    /// FmyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FmyWindow : Window
    {
        public FmyWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var req = new LoginRequest();
            req.ActivityType = ActivityType.EnduranceCycle;
            req.DeviceType = DeviceType.E10;
            req.Uid = "123456";
            var resp = new DeviceCommService().LoginRequest(req);
            var ste = resp.ToString();
            Console.WriteLine(resp);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var req = new UploadRequest();
            req.Uid = "123456";
            req.DeviceType = DeviceType.E16;
            req.ActivityId = 1;
            req.ActivityRecordId = 201;
            req.ActivityType = ActivityType.EnduranceCycle;
            req.Calorie = 200;
            req.CourseId = 1;
            req.DefatModeEnable = true;
            req.TrainMode = TrainMode.AdapterMode;
            req.ReverseForce = 43;

            var resp = new DeviceCommService().UploadRequest(req);

            Console.WriteLine(resp);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var req = new PersonalSetRequest();
            req.Uid = "123456";
            req.DeviceType = DeviceType.E10;
            req.ForwardLimit = 333;
            req.ActivityType = ActivityType.EnduranceCycle;
            req.DefatModeEnable = false;
            var resp = new DeviceCommService().PersonalSetRequest(req);
            Console.WriteLine(resp);
        }
    }
}
