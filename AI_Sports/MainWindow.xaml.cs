using AI_Sports.Constant;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AI_Sports
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test2();
           
        }
        private void test2()
        {
            var service = new DeviceCommService();
            var requset = new PersonalSetRequest();
            requset.Uid = "1234567";
            requset.DeviceType = DeviceType.P01;
            requset.SeatHeight = 100;
            requset.ActivityType = ActivityType.PowerCycle;
            var resp = service.PersonalSetRequest(requset);
            MessageBox.Show(resp.Success.ToString());
        }

        private void test()
        {
            var service = new DeviceCommService();
            var requset = new LoginRequest();
            requset.Uid = "123456";
            requset.DeviceType = DeviceType.P01;
            requset.ActivityType = ActivityType.PowerCycle;
            var resp = service.LoginRequest(requset);
            MessageBox.Show(resp.CourseId.ToString());
        }
        //载入数据时加载数据源
        private void TestCombox_Loaded(object sender, RoutedEventArgs e)
        {
            List<DatacodeEntity> list = DataCodeCache.GetInstance().GetDateCodeList(DatacodeTypeEnum.Sex);

            // TestCombox.SelectedIndex = 0;
            TestCombox.ItemsSource = list;
        }
        //获取下拉框的编码值
        private void TestCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("当前选中的是编码值是：" + TestCombox.SelectedValue.ToString());
        }
    }
}
