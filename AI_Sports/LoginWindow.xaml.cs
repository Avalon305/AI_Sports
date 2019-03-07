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
        /// 键盘监听事件：按
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
            // this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

        }
    }
}
