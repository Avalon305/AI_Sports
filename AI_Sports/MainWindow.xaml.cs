using AI_Sports.AISports.View.Pages;
using AI_Sports.Constant;
using AI_Sports.Service;
using AI_Sports.Util;
using NLog;
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
        private MemberService memberService = new MemberService();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
            this.mainpage.Source = new Uri("/AI_Sports;component/LoginWindow.xaml", UriKind.Relative);//跳转页面

            //显示欢迎页，验证后返回。
            //LoginWindow loginWindow = new LoginWindow();
            //loginWindow.ShowDialog(); //showdialog显示窗口要关闭此窗口后才能操作其他窗口
            //                          //测试CQZ
            //loginWindow.Close();//关闭欢迎页
            //只要教练ID不为空就登陆到教练页面
            //if (CommUtil.GetSettingString("coachId") != null && CommUtil.GetSettingString("coachId") != "")
            //{
            //    this.mainpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/UserManage.xaml", UriKind.Relative);//跳转页面
            //}
            //else
            //{
            //    this.mainpage.Source = new Uri("/AI_Sports;component/AISports.View/Pages/User.xaml", UriKind.Relative);//跳转页面

            //}
            // this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

            //  this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

            //if (loginWindow.DialogResult == true)//返回dialogresult为教练
            //{
            //    loginWindow.Close();//关闭欢迎页
            //this.mainpage.Navigate(new Uri("AISports.View/Pages/Admin.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri
            //}
            //else if (loginWindow.DialogResult == false)//返回dialogresult为用户
            //{
            //    loginWindow.Close();//关闭欢迎页
            //    this.mainpage.Navigate(new Uri("AISports.View/Pages/User.XAML", UriKind.Relative));//设定用户页面 urlkind相对uri
            //}

        }
        /// <summary>
        /// 四种登录情况的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Enum resultCode = null;
            if (e.Key == Key.D1)
            {//模拟用户登录
                resultCode = memberService.Login("305865088");
                switch (resultCode)
                {
                    case LoginPageStatus.CoachPage:
                        logger.Info("返回教练登陆页面");
                        //this.Close();
                        //用这种实例化的方法可以刷新页面，导航方式不会刷新
                        UserManage userManage = new UserManage();
                        this.mainpage.Content = userManage;
                        //this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                        break;
                    case LoginPageStatus.UserPage:
                        logger.Debug("返回用户登陆页面");
                        //this.Close();
                        User user = new User();
                        this.mainpage.Content = user;
                        //this.mainpage.Navigate(new Uri("AISports.View/Pages/User.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                        break;
                    case LoginPageStatus.RepeatLogins:
                        logger.Debug("拦截重复登陆，请先退出。");
                        break;
                    case LoginPageStatus.UnknownID:
                        logger.Debug("未知ID，禁止登录。");
                        break;
                    default:
                        break;
                }
            }
            else if (e.Key == Key.D0)
            {//模拟教练登陆
                resultCode = memberService.Login("17863979633");
                switch (resultCode)
                {
                    case LoginPageStatus.CoachPage:
                        logger.Debug("教练正常登陆");
                        //this.Close();
                        this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                        break;
                    case LoginPageStatus.UserPage:
                        logger.Debug("用户正常登陆");
                        //this.Close();
                        this.mainpage.Navigate(new Uri("AISports.View/Pages/User.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                        break;
                    case LoginPageStatus.RepeatLogins:
                        logger.Debug("拦截重复登陆，请先退出。");
                        break;
                    case LoginPageStatus.UnknownID:
                        logger.Debug("未知ID，禁止登录。");
                        break;
                    default:
                        break;
                }

            }
            else if (e.Key == Key.Enter)
            {
                BluetoothLogin bluetoothWindow = new BluetoothLogin();


                // 订阅事件
                bluetoothWindow.PassValuesEvent += new BluetoothLogin.PassValuesHandler(ReceiveValues);


                bluetoothWindow.ShowDialog();
            }

            

            // this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

        }
        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void ReceiveValues(object sender)
        {
            string memberId = sender.ToString();
            Console.WriteLine("主窗体接受到的会员ID："+memberId);
            Enum resultCode = null;

            resultCode = memberService.Login(memberId);
            switch (resultCode)
            {
                case LoginPageStatus.CoachPage:
                    logger.Debug("教练正常登陆");
                    //this.Close();
                    this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                    break;
                case LoginPageStatus.UserPage:
                    logger.Debug("用户正常登陆");
                    //this.Close();
                    this.mainpage.Navigate(new Uri("AISports.View/Pages/User.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                    break;
                case LoginPageStatus.RepeatLogins:
                    logger.Debug("拦截重复登陆，请先退出。");
                    break;
                case LoginPageStatus.UnknownID:
                    logger.Debug("未知ID，禁止登录。");
                    break;
                default:
                    break;
            }
        }


        private void Login(string sender)
        {
            string memberId = sender;
            Console.WriteLine("串口登陆 用户ID：" + memberId);
            Enum resultCode = null;

            resultCode = memberService.Login(memberId);
            switch (resultCode)
            {
                case LoginPageStatus.CoachPage:
                    logger.Debug("教练正常登陆");
                    //this.Close();
                    this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                    break;
                case LoginPageStatus.UserPage:
                    logger.Debug("用户正常登陆");
                    //this.Close();
                    this.mainpage.Navigate(new Uri("AISports.View/Pages/User.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                    break;
                case LoginPageStatus.RepeatLogins:
                    logger.Debug("拦截重复登陆，请先退出。");
                    break;
                case LoginPageStatus.UnknownID:
                    logger.Debug("未知ID，禁止登录。");
                    break;
                default:
                    break;
            }
        }

    }


}
