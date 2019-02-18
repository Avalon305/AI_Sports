﻿using AI_Sports.AISports.Entity;
using AI_Sports.AISports.Service;
using AI_Sports.Dao;
using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
        ActivityDAO activityDAO = new ActivityDAO();
        List<string> list0CF = new List<string>();
        List<string> list0RF = new List<string>();
        List<string> list0Rate = new List<string>();

        List<string> list1CF = new List<string>();
        List<string> list1RF = new List<string>();
        List<string> list1Rate = new List<string>();

        List<string> list2CF = new List<string>();
        List<string> list2RF = new List<string>();
        List<string> list2Rate = new List<string>();

        List<string> list3CF = new List<string>();
        List<string> list3RF = new List<string>();
        List<string> list3Rate = new List<string>();

        List<string> list4CF = new List<string>();
        List<string> list4RF = new List<string>();
        List<string> list4Rate = new List<string>();

        List<string> list5CF = new List<string>();
        List<string> list5RF = new List<string>();
        List<string> list5Rate = new List<string>();

        List<string> list6CF = new List<string>();
        List<string> list6RF = new List<string>();
        List<string> list6Rate = new List<string>();

        List<string> list7CF = new List<string>();
        List<string> list7RF = new List<string>();
        List<string> list7Rate = new List<string>();

        List<string> list8CF = new List<string>();
        List<string> list8RF = new List<string>();
        List<string> list8Rate = new List<string>();


        List<string> list9CF = new List<string>();
        List<string> list9RF = new List<string>();
        List<string> list9Rate = new List<string>();

        List<string> list10CF = new List<string>();
        List<string> list10RF = new List<string>();
        List<string> list10Rate = new List<string>();

        List<string> list11CF = new List<string>();
        List<string> list11RF = new List<string>();
        List<string> list11Rate = new List<string>();

        List<string> list12CF = new List<string>();
        List<string> list12RF = new List<string>();
        List<string> list12Rate = new List<string>();

        List<string> list13CF = new List<string>();
        List<string> list13RF = new List<string>();
        List<string> list13Rate = new List<string>();

        List<string> list14CF = new List<string>();
        List<string> list14RF = new List<string>();
        List<string> list14Rate = new List<string>();

        List<string> list15CF = new List<string>();
        List<string> list15RF = new List<string>();
        List<string> list15Rate = new List<string>();

        List<string> list16CF = new List<string>();
        List<string> list16RF = new List<string>();
        List<string> list16Rate = new List<string>();
        public NolleWindow()
        {
            InitializeComponent();
            List<TrainingDeviceRecordEntity> list = trainingDeviceRecordService.GetRecordByIdAndTime("123456");
            List<CustomExpander> listCS = new List<CustomExpander>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            foreach (var item in list)
            {
                CustomExpander ce = new CustomExpander();
                ce.Modified_time = item.Gmt_modified.ToString();
                switch (item.Device_code)
                {
                    case "0":
                        ce.Name = "腿部推蹬机";
                        ce.Image_address = "0.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list0CF.Add(item.Consequent_force.ToString());
                        list0RF.Add(item.Reverse_force.ToString());
                        list0Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        CHEST.DataContext = ce;
                        Aerobic0.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic0.ObjectForScripting = new WebAerobic0();
                        CHEST.Visibility = Visibility.Visible;
                        break;
                    case "1":
                        ce.Name = "坐式背阔肌高拉机";
                        ce.Image_address = "1.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list1CF.Add(item.Consequent_force.ToString());
                        list1RF.Add(item.Reverse_force.ToString());
                        list1Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        LEG.DataContext = ce;
                        Aerobic1.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic1.ObjectForScripting = new WebAerobic1();
                        LEG.Visibility = Visibility.Visible;
                        break;
                    case "2":
                        ce.Name = "三头肌训练机";
                        ce.Image_address = "2.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list2CF.Add(item.Consequent_force.ToString());
                        list2RF.Add(item.Reverse_force.ToString());
                        list2Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        LAT.DataContext = ce;
                        Aerobic2.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic2.ObjectForScripting = new WebAerobic2();
                        LAT.Visibility = Visibility.Visible;
                        break;
                    case "3":
                        ce.Name = "腿部内弯机";
                        ce.Image_address = "3.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list3CF.Add(item.Consequent_force.ToString());
                        list3RF.Add(item.Reverse_force.ToString());
                        list3Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        SEATED.DataContext = ce;
                        Aerobic3.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic3.ObjectForScripting = new WebAerobic3();
                        SEATED.Visibility = Visibility.Visible;
                        break;
                    case "4":
                        ce.Name = "腿部外弯机";
                        ce.Image_address = "4.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list4CF.Add(item.Consequent_force.ToString());
                        list4RF.Add(item.Reverse_force.ToString());
                        list4Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        ADDUCTOR.DataContext = ce;
                        Aerobic4.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic4.ObjectForScripting = new WebAerobic4();
                        ADDUCTOR.Visibility = Visibility.Visible;
                        break;
                    case "5":
                        ce.Name = "蝴蝶机";
                        ce.Image_address = "5.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list5CF.Add(item.Consequent_force.ToString());
                        list5RF.Add(item.Reverse_force.ToString());
                        list5Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        BUTTERFLY.DataContext = ce;
                        Aerobic5.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic5.ObjectForScripting = new WebAerobic5();
                        BUTTERFLY.Visibility = Visibility.Visible;
                        break;
                    case "6":
                        ce.Name = "反向蝴蝶机";
                        ce.Image_address = "6.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list6CF.Add(item.Consequent_force.ToString());
                        list6RF.Add(item.Reverse_force.ToString());
                        list6Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        BR.DataContext = ce;
                        Aerobic6.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic6.ObjectForScripting = new WebAerobic6();
                        BR.Visibility = Visibility.Visible;
                        break;
                    case "7":
                        ce.Name = "坐式背部伸展机";
                        ce.Image_address = "7.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list7CF.Add(item.Consequent_force.ToString());
                        list7RF.Add(item.Reverse_force.ToString());
                        list7Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        BEB.DataContext = ce;
                        Aerobic7.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic7.ObjectForScripting = new WebAerobic7();
                        BEB.Visibility = Visibility.Visible;
                        break;
                    case "8":
                        ce.Name = "躯干扭转组合";
                        ce.Image_address = "8.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list8CF.Add(item.Consequent_force.ToString());
                        list8RF.Add(item.Reverse_force.ToString());
                        list8Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        RC1.DataContext = ce;
                        Aerobic8.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic8.ObjectForScripting = new WebAerobic8();
                        RC1.Visibility = Visibility.Visible;
                        break;
                    case "9":
                        ce.Name = "坐式腿伸展训练机";
                        ce.Image_address = "9.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list9CF.Add(item.Consequent_force.ToString());
                        list9RF.Add(item.Reverse_force.ToString());
                        list9Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S1.DataContext = ce;
                        Aerobic9.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic9.ObjectForScripting = new WebAerobic9();
                        S1.Visibility = Visibility.Visible;
                        break;
                    case "10":
                        ce.Name = "坐式推胸机";
                        ce.Image_address = "10.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list10CF.Add(item.Consequent_force.ToString());
                        list10RF.Add(item.Reverse_force.ToString());
                        list10Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S2.DataContext = ce;
                        Aerobic10.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic10.ObjectForScripting = new WebAerobic10();
                        S2.Visibility = Visibility.Visible;
                        break;
                    case "11":
                        ce.Name = "坐式划船机";
                        ce.Image_address = "11.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list11CF.Add(item.Consequent_force.ToString());
                        list11RF.Add(item.Reverse_force.ToString());
                        list11Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S3.DataContext = ce;
                        Aerobic11.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic11.ObjectForScripting = new WebAerobic11();
                        S3.Visibility = Visibility.Visible;
                        break;
                    case "12":
                        //当前设置为功率
                        ce.Name = "椭圆跑步机";
                        ce.Image_address = "12.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Power.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list12CF.Add(item.Consequent_force.ToString());
                        list12RF.Add(item.Reverse_force.ToString());
                        list12Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S4.DataContext = ce;
                        Aerobic12.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic12.ObjectForScripting = new WebAerobic12();
                        S4.Visibility = Visibility.Visible;
                        break;
                    case "13":
                        ce.Name = "坐式屈腿训练机";
                        ce.Image_address = "13.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list13CF.Add(item.Consequent_force.ToString());
                        list13RF.Add(item.Reverse_force.ToString());
                        list13Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S5.DataContext = ce;
                        Aerobic13.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic13.ObjectForScripting = new WebAerobic13();
                        S5.Visibility = Visibility.Visible;
                        break;
                    case "14":
                        ce.Name = "腹肌训练机";
                        ce.Image_address = "14.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list14CF.Add(item.Consequent_force.ToString());
                        list14RF.Add(item.Reverse_force.ToString());
                        list14Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S6.DataContext = ce;
                        Aerobic14.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic14.ObjectForScripting = new WebAerobic14();
                        S6.Visibility = Visibility.Visible;
                        break;
                    case "15":
                        ce.Name = "坐式背部伸展机";
                        ce.Image_address = "15.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Consequent_force.ToString() + " / " + item.Reverse_force.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list15CF.Add(item.Consequent_force.ToString());
                        list15RF.Add(item.Reverse_force.ToString());
                        list15Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S7.DataContext = ce;
                        Aerobic15.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic15.ObjectForScripting = new WebAerobic15();
                        S7.Visibility = Visibility.Visible;
                        break;
                    case "16":
                        //当前设置为功率
                        ce.Name = "健身车";
                        ce.Image_address = "16.png";
                        ce.Modified_time = item.Gmt_modified.ToString();
                        ce.Current_set = item.Power.ToString();
                        ce.Rate = trainingDeviceRecordService.GetRecordCountByIdAndDeviceCode("123456", item.Device_code) + " / " + activityDAO.GetTargetTurnNumById(trainingDeviceRecordService.GetTrainActivityRecordIdById(item.Id)).ToString();
                        list16CF.Add(item.Consequent_force.ToString());
                        list16RF.Add(item.Reverse_force.ToString());
                        list16Rate.Add((item.Consequent_force / item.Reverse_force).ToString());
                        S8.DataContext = ce;
                        Aerobic16.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Line.html"));
                        Aerobic16.ObjectForScripting = new WebAerobic16();
                        S8.Visibility = Visibility.Visible;
                        break;
                }
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic0
        {
            public string drawCF()
            {
                string str0CF = string.Join(",", new NolleWindow().list0CF);
                return str0CF;
            }
            public string drawRF()
            {
                string str0RF = string.Join(",", new NolleWindow().list0RF);
                return str0RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic1
        {
            public string drawCF()
            {
                string str1CF = string.Join(",", new NolleWindow().list1CF);
                return str1CF;
            }
            public string drawRF()
            {
                string str1RF = string.Join(",", new NolleWindow().list1RF);
                return str1RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic2
        {
            public string drawCF()
            {
                string str2CF = string.Join(",", new NolleWindow().list2CF);
                return str2CF;
            }
            public string drawRF()
            {
                string str2RF = string.Join(",", new NolleWindow().list2RF);
                return str2RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic3
        {
            public string drawCF()
            {
                string str3CF = string.Join(",", new NolleWindow().list3CF);
                return str3CF;
            }
            public string drawRF()
            {
                string str3RF = string.Join(",", new NolleWindow().list3RF);
                return str3RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic4
        {
            public string drawCF()
            {
                string str4CF = string.Join(",", new NolleWindow().list4CF);
                return str4CF;
            }
            public string drawRF()
            {
                string str4RF = string.Join(",", new NolleWindow().list4RF);
                return str4RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic5
        {
            public string drawCF()
            {
                string str5CF = string.Join(",", new NolleWindow().list5CF);
                return str5CF;
            }
            public string drawRF()
            {
                string str5RF = string.Join(",", new NolleWindow().list5RF);
                return str5RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic6
        {
            public string drawCF()
            {
                string str6CF = string.Join(",", new NolleWindow().list6CF);
                return str6CF;
            }
            public string drawRF()
            {
                string str6RF = string.Join(",", new NolleWindow().list6RF);
                return str6RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic7
        {
            public string drawCF()
            {
                string str7CF = string.Join(",", new NolleWindow().list7CF);
                return str7CF;
            }
            public string drawRF()
            {
                string str7RF = string.Join(",", new NolleWindow().list7RF);
                return str7RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic8
        {
            public string drawCF()
            {
                string str8CF = string.Join(",", new NolleWindow().list8CF);
                return str8CF;
            }
            public string drawRF()
            {
                string str8RF = string.Join(",", new NolleWindow().list8RF);
                return str8RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic9
        {
            public string drawCF()
            {
                string str9CF = string.Join(",", new NolleWindow().list9CF);
                return str9CF;
            }
            public string drawRF()
            {
                string str9RF = string.Join(",", new NolleWindow().list9RF);
                return str9RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic10
        {
            public string drawCF()
            {
                string str10CF = string.Join(",", new NolleWindow().list10CF);
                return str10CF;
            }
            public string drawRF()
            {
                string str10RF = string.Join(",", new NolleWindow().list10RF);
                return str10RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic11
        {
            public string drawCF()
            {
                string str11CF = string.Join(",", new NolleWindow().list11CF);
                return str11CF;
            }
            public string drawRF()
            {
                string str11RF = string.Join(",", new NolleWindow().list11RF);
                return str11RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic12
        {
            public string drawCF()
            {
                string str12CF = string.Join(",", new NolleWindow().list12CF);
                return str12CF;
            }
            public string drawRF()
            {
                string str12RF = string.Join(",", new NolleWindow().list12RF);
                return str12RF;
            }
        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic13
        {
            public string drawCF()
            {
                string str13CF = string.Join(",", new NolleWindow().list13CF);
                return str13CF;
            }
            public string drawRF()
            {
                string str13RF = string.Join(",", new NolleWindow().list13RF);
                return str13RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic14
        {
            public string drawCF()
            {
                string str14CF = string.Join(",", new NolleWindow().list14CF);
                return str14CF;
            }
            public string drawRF()
            {
                string str14RF = string.Join(",", new NolleWindow().list14RF);
                return str14RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic15
        {
            public string drawCF()
            {
                string str15CF = string.Join(",", new NolleWindow().list15CF);
                return str15CF;
            }
            public string drawRF()
            {
                string str15RF = string.Join(",", new NolleWindow().list15RF);
                return str15RF;
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        [System.Runtime.InteropServices.ComVisible(true)]
        public class WebAerobic16
        {
            public string drawCF()
            {
                string str16CF = string.Join(",", new NolleWindow().list16CF);
                return str16CF;
            }
            public string drawRF()
            {
                string str16RF = string.Join(",", new NolleWindow().list16RF);
                return str16RF;
            }
        }

    }
}