using AI_Sports.Constant;
using AI_Sports.Service;
using NLog;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AI_Sports
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Page
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private MemberService memberService = new MemberService();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 键盘监听事件：按
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Window_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Enum resultCode = null;
        //    if (e.Key == Key.U)
        //    {
        //        resultCode =  memberService.Login("305865088");
        //    }
        //    else if (e.Key == Key.C)
        //    {
        //        resultCode = memberService.Login("17863979633");

        //    }
           
        //    switch (resultCode)
        //    {
        //        case LoginPageStatus.CoachPage:
        //            logger.Debug("教练正常登陆");

        //            //this.Close();
        //            break;
        //        case LoginPageStatus.UserPage:
        //            logger.Debug("用户正常登陆");
        //            //this.Close();
        //            break;
        //        case LoginPageStatus.RepeatLogins:
        //            logger.Debug("拦截重复登陆，请先退出。");
        //            break;
        //        case LoginPageStatus.UnknownID:
        //            logger.Debug("未知ID，禁止登录。");
        //            break;
        //        default:
        //            break;
        //    }
            

        //}
    }
}
