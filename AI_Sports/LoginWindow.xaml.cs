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
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private MemberService memberService = new MemberService();
        /// <summary>
        /// 刷完卡后，调用的登陆方法。读取App.config里的会员ID,根据角色跳转不同的页面。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MemberLogin(object sender, RoutedEventArgs e)
        {
            //1.获得登录会员的会员id与权限
            string memberId = CommUtil.GetSettingString("memberId");
            ///string roleId = CommUtil.GetSettingString("roleId");
            Console.WriteLine("memberId:{0}", memberId);
            //2.根据卡号查询用户详细信息
            MemberEntity member = memberService.GetMember(memberId);
            //如果能查到用户信息，不为null。则登陆
            if (member != null)
            {
                //3.根据权限跳转不同的页面
                //如果是会员登陆，跳转会员首页
                if (member.Role_id == 1)
                {
                    this.DialogResult = false;
                    //成功登陆，跳转
                    //MainPage mainpage = new MainPage();
                    //this.Content = mainpage;
                }
                //如果教练登陆，跳转教练首页
                else if (member.Role_id == 0)
                {
                    this.DialogResult = true;
                    //成功登陆，跳转
                    //MainPage mainpage = new MainPage();
                    //this.Content = mainpage;
                }
            }
            else
            {
                Console.WriteLine("无效卡！");
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
            // this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

        }
    }
}
