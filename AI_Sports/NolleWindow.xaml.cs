using AI_Sports.AISports.Entity;
using AI_Sports.AISports.Service;
using AI_Sports.Dao;
using AI_Sports.Entity;
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
    /// NolleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class NolleWindow : Window
    {
        TrainingDeviceRecordService trainingDeviceRecordService = new TrainingDeviceRecordService();
        DatacodeDAO datacodeDAO = new DatacodeDAO();
        public NolleWindow()
        {
            InitializeComponent();
            List<TrainingDeviceRecordEntity> list=trainingDeviceRecordService.GetRecordByIdAndTime("123456");
            List<CustomExpander> listCS = new List<CustomExpander>();
            foreach (var item in list) {
                CustomExpander ce = new CustomExpander();
                ce.Modified_time = item.Gmt_modified.ToString();
                switch(item.Device_code){
                    case "0":
                        ce.Name = "腿部推蹬机";
                        ce.Image_address = "0.png";
                        CHEST.DataContext = ce;
                        CHEST.Visibility = Visibility.Visible;
                        break;
                    case "1":
                        ce.Name = "坐式背阔肌高拉机";
                        ce.Image_address = "1.png";
                        LEG.DataContext = ce;
                        LEG.Visibility = Visibility.Visible;
                        break;
                    case "2":
                        ce.Name = "三头肌训练机";
                        ce.Image_address = "2.png";
                        LAT.DataContext = ce;
                        LAT.Visibility = Visibility.Visible;
                        break;
                    case "3":
                        ce.Name = "腿部内弯机";
                        ce.Image_address = "3.png";
                        SEATED.DataContext = ce;
                        SEATED.Visibility = Visibility.Visible;
                        break;
                    case "4":
                        ce.Name = "腿部外弯机";
                        ce.Image_address = "4.png";
                        ADDUCTOR.DataContext = ce;
                        ADDUCTOR.Visibility = Visibility.Visible;
                        break;
                    case "5":
                        ce.Name = "蝴蝶机";
                        ce.Image_address = "5.png";
                        BUTTERFLY.DataContext = ce;
                        BUTTERFLY.Visibility = Visibility.Visible;
                        break;
                    case "6":
                        ce.Name = "反向蝴蝶机";
                        ce.Image_address = "6.png";
                        BR.DataContext = ce;
                        BR.Visibility = Visibility.Visible;
                        break;
                    case "7":
                        ce.Name = "坐式背部伸展机";
                        ce.Image_address = "7.png";
                        BEB.DataContext = ce;
                        BEB.Visibility = Visibility.Visible;
                        break;
                    case "8":
                        ce.Name = "躯干扭转组合";
                        ce.Image_address = "8.png";
                        RC1.DataContext = ce;
                        RC1.Visibility = Visibility.Visible;
                        break;
                    case "9":
                        ce.Name = "坐式腿伸展训练机";
                        ce.Image_address = "9.png";
                        S1.DataContext = ce;
                        S1.Visibility = Visibility.Visible;
                        break;
                    case "10":
                        ce.Name = "坐式推胸机";
                        ce.Image_address = "10.png";
                        S2.DataContext = ce;
                        S2.Visibility = Visibility.Visible;
                        break;
                    case "11":
                        ce.Name = "坐式划船机";
                        ce.Image_address = "11.png";
                        S3.DataContext = ce;
                        S3.Visibility = Visibility.Visible;
                        break;
                    case "12":
                        ce.Name = "椭圆跑步机";
                        ce.Image_address = "12.png";
                        S4.DataContext = ce;
                        S4.Visibility = Visibility.Visible;
                        break;
                    case "13":
                        ce.Name = "坐式屈腿训练机";
                        ce.Image_address = "13.png";
                        S5.DataContext = ce;
                        S5.Visibility = Visibility.Visible;
                        break;
                    case "14":
                        ce.Name = "腹肌训练机";
                        ce.Image_address = "14.png";
                        S6.DataContext = ce;
                        S6.Visibility = Visibility.Visible;
                        break;
                    case "15":
                        ce.Name = "坐式背部伸展机";
                        ce.Image_address = "15.png";
                        S7.DataContext = ce;
                        S7.Visibility = Visibility.Visible;
                        break;
                    case "16":
                        ce.Name = "健身车";
                        ce.Image_address = "16.png";
                        S8.DataContext = ce;
                        S8.Visibility = Visibility.Visible;
                        break;
                }
            }
        }


    }
}
