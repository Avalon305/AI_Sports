using AI_Sports.Constant;
using AI_Sports.Dao;
using AI_Sports.Entity;
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
            var a = DbUtil.getConn();
            var c = new ActivityDAO().Load(1);
            MessageBox.Show(c.Is_complete.ToString());
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
            MessageBox.Show("当前选中的是编码值是："+TestCombox.SelectedValue.ToString());
        }
    }
}
