using AI_Sports.AISports.Constant;
using AI_Sports.AISports.Util;
using AI_Sports.AISports.View.Pages;
using AI_Sports.Constant;
using AI_Sports.Service;
using AI_Sports.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace AI_Sports
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MemberService memberService = new MemberService();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static SerialPort serialPort = null;

        public MainWindow()
        {
            InitializeComponent();
            this.mainpage.Source = new Uri("/AI_Sports;component/LoginWindow.xaml", UriKind.Relative);//跳转页面
            //窗口最前
            //this.Topmost = true;
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
            //获得配置文件中串口号
            string configPortName = CommUtil.GetSettingString("SerialPort");

            serialPort = new SerialPort();
            serialPort.PortName = configPortName != "" ? configPortName : "COM4";
            serialPort.BaudRate = 115200;
            serialPort.ReadTimeout = 3000; //单位毫秒
            serialPort.WriteTimeout = 3000; //单位毫秒
            serialPort.ReceivedBytesThreshold = 1;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(OnPortDataReceived);
            try
            {
                //serialPort.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBoxX.Show( "温馨提示", "串口被占用");
            }
            catch (IOException ex)
            {
                MessageBoxX.Show( "温馨提示", "串口不存在");
            }

        }
        /// <summary>
        /// 接收方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPortDataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("接受到数据");
            Thread.Sleep(50);
            byte[] buffer = null; ;
            int len = serialPort.BytesToRead;
            byte[] first = new byte[len];
            serialPort.Read(first, 0, len);
            Console.WriteLine(SerialPortUtil.ByteToHexStr(first));
            int offset = 0;
            //校验帧头
            if (len > 0 && first[0] == 0xAA)
            {

                byte datalen = first[2];
                buffer = new byte[datalen + 5];

                for (int i = 0; i < first.Length; i++)
                {
                    buffer[i] = first[i];
                }
                offset = first.Length;

            }
            else
            {
                serialPort.DiscardInBuffer();
                return;
            }

            //下面是完整数据
            if (buffer != null)
            {
                Console.WriteLine("buffer不为空，通过校验");
                //既然已经到了这里说明帧头帧尾已校验通过

                //取出命令字
                byte[] cmd = { buffer[1] };

                //取出数据长度 byte中为0x10那么string(x2)就为10,string()为16
                int data_len = int.Parse(buffer[2].ToString());

                //取出数据
                byte[] obj_data = new byte[data_len];
                for (int i = 0; i < data_len; i++)
                {
                    obj_data[i] = buffer[i + 3];
                }

                //XOR校验,如果错误直接返回
                byte[] data_xor = new byte[2 + obj_data.Length];
                data_xor[0] = cmd[0];
                data_xor[1] = buffer[2];
                Buffer.BlockCopy(obj_data, 0, data_xor, 2, obj_data.Length);
                Console.WriteLine(SerialPortUtil.ByteToHexStr(data_xor));
                byte compute_xor = SerialPortUtil.Get_CheckXor(data_xor);
                Console.WriteLine("compute_xor为" + compute_xor.ToString("x2"));
                if (!buffer[buffer.Length - 2].Equals(compute_xor))
                {
                    return;
                }

                //如果命令字等于发卡的应答
                Console.WriteLine("cmd为" + cmd[0]);
                Console.WriteLine("CommondConstant.readCard" + CommondConstant.readCard[0]);

                //如果命令字等于读卡
                if (cmd[0] == CommondConstant.readCard[0])
                {
                    byte[] namebytewithzero = new byte[10];
                    //byte[] phonebyte = new byte[2];
                    byte[] phonebyte = new byte[4];
                    byte[] crc = new byte[2];
                    Buffer.BlockCopy(obj_data, 0, namebytewithzero, 0, namebytewithzero.Length);//提取姓名
                    string strName = SerialPortUtil.GetEndString(namebytewithzero, 0);
                    Console.WriteLine(strName);//解析姓名
                    Buffer.BlockCopy(obj_data, 10, phonebyte, 0, phonebyte.Length);//提取手机号
                    string strPhone = Encoding.ASCII.GetString(phonebyte);
                    Console.WriteLine(strPhone);//解析手机号
                    //Buffer.BlockCopy(obj_data, 12, crc, 0, crc.Length);//提取CRC
                    //string strCRC = SerialPortUtil.ByteToHexStr(crc);
                    //string lowStrCRC = obj_data[12].ToString();
                    //string highStrCRC = obj_data[13].ToString();
                    //string strCRC = lowStrCRC + highStrCRC;
                    //Console.WriteLine(strCRC);//解析CRC
                    //ReceiveValues(strName + strPhone + strCRC);
                    string memberId = strName + strPhone;
                    //工作线程中调用主线程委托调用提示窗或者跳转页面
                    App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        Login(memberId);


                    }));
                }


            }
        }
        /// <summary>
        /// 四种登录情况的测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Enum resultCode = null;
            if (e.Key == Key.U)
            {//模拟用户登录
                resultCode = memberService.Login("305865088");
                switch (resultCode)
                {
                    case LoginPageStatus.CoachPage:
                        logger.Debug("返回教练登陆页面");
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
                        MessageBoxX.Show("温馨提示", "重复登陆，请先退出当前用户");
                        break;
                    case LoginPageStatus.UnknownID:
                        logger.Debug("未知ID，禁止登录。");
                        MessageBoxX.Show("温馨提示", "未知ID，登录失败");

                        break;
                    default:
                        break;
                }
            }
            else if (e.Key == Key.C)
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
                        MessageBoxX.Show("温馨提示", "重复登陆，请先退出当前用户");

                        break;
                    case LoginPageStatus.UnknownID:
                        logger.Debug("未知ID，禁止登录。");
                        MessageBoxX.Show("温馨提示", "未知ID，登录失败");

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
                    this.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        this.mainpage.Navigate(new Uri("AISports.View/Pages/User.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri

                    });

                    break;
                case LoginPageStatus.RepeatLogins:
                    logger.Debug("拦截重复登陆，请先退出。");
                    MessageBoxX.Show("温馨提示", "重复登陆，请先退出当前用户");

                    break;
                case LoginPageStatus.UnknownID:
                    logger.Debug("未知ID，禁止登录。");
                    MessageBoxX.Show("温馨提示", "未知ID，登录失败");

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 读卡专用登陆方法
        /// </summary>
        /// <param name="sender"></param>
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
                    MessageBoxX.Show("温馨提示", "重复登陆，请先退出当前用户");

                    break;
                case LoginPageStatus.UnknownID:
                    logger.Debug("未知ID，禁止登录。");
                    MessageBoxX.Show("温馨提示", "未知ID，登录失败");

                    break;
                default:
                    break;
            }
        }

    }


}
