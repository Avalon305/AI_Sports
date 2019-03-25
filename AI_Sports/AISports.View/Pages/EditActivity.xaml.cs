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

        /// <summary>
        /// 点击活动分组Expander的编辑训练活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Edit_Activity(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
            //System.Windows.MessageBox.Show("当前行的活动类型：" + btn.Tag.ToString());
            Console.WriteLine("当前行的活动类型：" + btn.Tag.ToString());
            //Expander分组头的名 为 XX循环（x轮次）这种格式
            string groupHead = btn.Tag.ToString();
            //活动类型变量
            string activityType = null;
            if (groupHead.Contains("力量循环"))
            {
                activityType = "0";
            }
            else if (groupHead.Contains("力量耐力循环"))
            {
                activityType = "1";
            }
            
            //跳转到更新训练活动页面 传参只需要在后边加上参数即可
            UpdateActivity updateActivity = new UpdateActivity();
            this.NavigationService.Navigate(updateActivity, activityType);
            //加载从训练课程页面传来的参数 //注意LoadCompleted 事件的位置在 Page1.cs 中
            this.NavigationService.LoadCompleted += updateActivity.NavigationService_LoadCompleted;

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
