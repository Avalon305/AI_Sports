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
using System.IO;
using AI_Sports.Service;
using AI_Sports.Util;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// user.xaml 的交互逻辑
    /// </summary>
    public partial class User : Page
    {
        private MemberService memberService = new MemberService();

        public User()
        {
            InitializeComponent();
            //首页当前进度
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/currentProgress.xaml", UriKind.Relative);

            //设置登录用户头像和称呼
            //int sex = 1;
            //string member_familyName = "陈";         //member_familyName是数据库中姓氏的字段
            //if (sex == 1)
            //{
            //    this.familyName.Text = member_familyName + "先生";
            //}
            //else if (sex == 0)
            //{
            //    this.familyName.Text = member_familyName + "女士";
            //}
            //else
            //    this.familyName.Text = "未登录";
            string MemberId = (CommUtil.GetSettingString("memberId"));
			string Name = memberService.GetMember(MemberId).Member_familyName + memberService.GetMember(MemberId).Member_firstName;
			if (MemberId != null)
			{
				this.familyName.Text = Name;
			}
			else
			{
				this.familyName.Text = "未登录";
			}

			string photopath = "/AI_Sports;component/AISports.View/Images/photo.png";   //头像路径
            if (File.Exists(photopath) == false)
            {
                this.headphoto.Source = new BitmapImage(new Uri(@photopath, UriKind.Relative));
            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)//用户信息
        {
            this.btn1.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/userinfo.xaml", UriKind.Relative);
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)//当前进度
        {
            this.btn2.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn3.Background = null;
            this.btn4.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/currentProgress.xaml", UriKind.Relative);
        }
        private void Btn3_Click(object sender, RoutedEventArgs e)//训练计划
        {
            this.btn3.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn4.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/TrainingProgram.xaml", UriKind.Relative);
        }
        private void Btn4_Click(object sender, RoutedEventArgs e)//图表分析
        {
            this.btn4.Background = new SolidColorBrush(Color.FromRgb(246, 214, 0));
            this.btn1.Background = null;
            this.btn2.Background = null;
            this.btn3.Background = null;
            this.contentpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/analyze.xaml", UriKind.Relative);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            //清空配置类
            memberService.Logout();
            //退出登录 跳转到登录页
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/LoginWindow.xaml", UriKind.Relative));

            //System.Windows.Forms.Application.Restart();
            //AI_Sports.App.Current.Shutdown();
            //显示欢迎页，验证后返回。
            //LoginWindow loginWindow = new LoginWindow();
            ////loginWindow.ShowDialog(); //showdialog显示窗口要关闭此窗口后才能操作其他窗口
            //this.Content = loginWindow;
        }

    }
}
