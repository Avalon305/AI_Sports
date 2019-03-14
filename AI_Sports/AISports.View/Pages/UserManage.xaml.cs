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
using AI_Sports.Service;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// admin.xaml 的交互逻辑
    /// </summary>
    public partial class UserManage : Page
    {
        private MemberService memberService = new MemberService();
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
            //MemberInfo memberInfo = new MemberInfo();
            //this.contentpage.Content = memberInfo;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/MemberInfo.xaml", UriKind.Relative);//跳转页面
        }
        //用户信息页面
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            this.btn1.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.btn5.Background = null;
            this.Btn_MemberManage.Background = null;
            this.Btn_SystemSetting.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/MemberInfo.xaml", UriKind.Relative);//跳转页面
        }
        //训练计划页面
        private void Btn2_Click(object sender, RoutedEventArgs e)//
        {
            this.btn2.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.btn5.Background = null;
            this.Btn_MemberManage.Background = null;
            this.Btn_SystemSetting.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/newPlan.xaml", UriKind.Relative);//跳转页面
        }
        //图表分析页面
        private void Btn3_Click(object sender, RoutedEventArgs e)//
        {
            this.btn3.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn4.Background = null;
            this.btn5.Background = null;
            this.Btn_MemberManage.Background = null;
            this.Btn_SystemSetting.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/analyze.xaml", UriKind.Relative);//跳转页面
        }
        //生命体征页面
        private void Btn4_Click(object sender, RoutedEventArgs e)//
        {
            this.btn4.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.btn5.Background = null;
            this.Btn_MemberManage.Background = null;
            this.Btn_SystemSetting.Background = null;
            //this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/VitalSigns.xaml", UriKind.Relative);//跳转页面TrainingCourseAnalysis
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/VitalSigns.xaml", UriKind.Relative);//跳转页面

        }
        //添加会员页面
        private void Btn5_Click(object sender, RoutedEventArgs e)//
        {
            this.btn5.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.Btn_MemberManage.Background = null;
            this.Btn_SystemSetting.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/AddUser.xaml", UriKind.Relative);//跳转页面

        }
        /// <summary>
        /// 系统设置点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SystemSetting_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_SystemSetting.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.btn5.Background = null;
            this.Btn_MemberManage.Background = null;
            //this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/AddUser.xaml", UriKind.Relative);//跳转页面
        }
        /// <summary>
        /// 会员管理点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MemberManage_Click(object sender, RoutedEventArgs e)
        {
            this.Btn_MemberManage.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.btn5.Background = null;
            this.Btn_SystemSetting.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/AddUser.xaml", UriKind.Relative);//跳转页面

        }

        //退出登录重新启动
        private void Logout(object sender, RoutedEventArgs e)
        {
            //清空配置类
            memberService.Logout();
            //退出登录 跳转到登录页
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/LoginWindow.xaml", UriKind.Relative));
            //System.Windows.Forms.Application.Restart();
            //AI_Sports.App.Current.Shutdown();
            //显示欢迎页，验证后返回。
            // LoginWindow loginWindow = new LoginWindow();
            ////loginWindow.ShowDialog(); //showdialog显示窗口要关闭此窗口后才能操作其他窗口
            //this.Content = loginWindow;
        }
        /// <summary>
        /// 发卡按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Write_Card_Click(object sender, RoutedEventArgs e)
        {
            //串口测试页面
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/NolleTestSerial.xaml", UriKind.Relative));

            WriteCardWindow writeCardWindow = new WriteCardWindow();
            //弹出窗体的时候将程序中断在pw窗体，它的操作会对下面的程序产生影响，从而使pw窗体影响下面运行的效果。
            //比如说下面的程序要通过pw窗体中的某个参数进行判断来运行的话，用这种方法很合适。
            writeCardWindow.ShowDialog();
        }

        /// <summary>
        /// 3D扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3DScan(object sender, RoutedEventArgs e)
        {
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/NuitrackScan.xaml", UriKind.Relative);//跳转页面
        }

        
    }
}
