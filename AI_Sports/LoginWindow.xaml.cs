using AI_Sports.AISports.View.Pages;
using AI_Sports.Constant;
using AI_Sports.Service;
using NLog;
using System;
using System.Text.RegularExpressions;
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

		//页面传参对象
		public delegate void PassValuesHandler(object sender);
		//传值事件
		public event PassValuesHandler PassValuesEvent;
		private MemberService memberService = new MemberService();
        private static Logger logger = LogManager.GetCurrentClassLogger();

		//private void Mytext_TextChanged(object sender, TextChangedEventArgs e)
		//{
		//	var reg = new Regex("[\u4e00-\u9fa5]");
		//	string text = mytext.Text;
		//	if (reg.IsMatch(text))
		//	{
		//		MessageBoxX.Show("提示", "请切换英文输入法");

		//	}
		//	if (text.Length == 16)
		//	{
		//		Console.WriteLine("test:" + text.ToString());
		//		mytext.Clear();
		//	}
		//}

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
