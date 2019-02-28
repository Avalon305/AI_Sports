using AI_Sports.AISports.Dto;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// trainingCourse.xaml 的交互逻辑
    /// </summary>
    public partial class EditActivity : Page
    {
        TrainingActivityService trainingActivityService = new TrainingActivityService();
        public EditActivity()
        {
            InitializeComponent();
            //初始化分组Expander查询
            InitListViewGroup();
        }
        /// <summary>
        /// 初始化分组listView查询
        /// </summary>
        public void InitListViewGroup()
        {
            List<ActivityGroupDTO> activityGroupDTOs = trainingActivityService.ListActivitysGroupAndPersonalSetting();
            //表格加载数据
            CollectionViewSource ListViewGroupSource = (CollectionViewSource)this.FindResource("ListViewGroupSource");
            ListViewGroupSource.Source = activityGroupDTOs;
        }

        ///按钮绑定测试
        private void Button_Edit_Activity(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
            System.Windows.MessageBox.Show("当前行的设备类型：" + btn.Tag.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/last.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/last.xaml", UriKind.Relative));
        }
    }
}
