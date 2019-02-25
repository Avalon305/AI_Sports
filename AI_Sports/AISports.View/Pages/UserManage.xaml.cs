using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// admin.xaml 的交互逻辑
    /// </summary>
    public partial class UserManage : Page
    {
        public UserManage()
        {
            InitializeComponent();
            //设置登录用户头像和称呼
            int sex = 1;
            string member_familyName = "陈";         //member_familyName是数据库中姓氏的字段
            if (sex == 1)
            {
                this.familyName.Text = member_familyName + "先生";
            }
            else if (sex == 0)
            {
                this.familyName.Text = member_familyName + "女士";
            }
            else
                this.familyName.Text = "未登录";

            string photopath = "/AI_Sports;component/AISports.View/Images/photo.png";   //头像路径
            if (File.Exists(photopath) == false)
            {
                this.headphoto.Source = new BitmapImage(new Uri(@photopath, UriKind.Relative));
            }

            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/AddUser.xaml", UriKind.Relative);//跳转页面
        }
        //用户信息页面
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            this.btn1.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/MemberInfo.xaml", UriKind.Relative);//跳转页面
        }
        //训练计划页面
        private void Btn2_Click(object sender, RoutedEventArgs e)//
        {
            this.btn2.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/newPlan.xaml", UriKind.Relative);//跳转页面
        }
        //图表分析页面
        private void Btn3_Click(object sender, RoutedEventArgs e)//
        {
            this.btn3.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn4.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/TrainingPlanAnalysis.xaml", UriKind.Relative);//跳转页面
        }
        //生命体征页面
        private void Btn4_Click(object sender, RoutedEventArgs e)//
        {
            this.btn4.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn3.Background = null;
            //this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/VitalSigns.xaml", UriKind.Relative);//跳转页面TrainingCourseAnalysis
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/TrainingCourseAnalysis.xaml", UriKind.Relative);//跳转页面

        }
        //退出登录重新启动
        private void Logout(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            AI_Sports.App.Current.Shutdown();
        }
        /// <summary>
        /// 发卡按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Write_Card_Click(object sender, RoutedEventArgs e)
        {
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/TrainingActivityAnalysis.xaml", UriKind.Relative);//跳转页面
        }
    }
}
