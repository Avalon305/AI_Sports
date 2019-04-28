
using System;
using System.Windows;

using System.Windows.Input;
using System.Windows.Threading;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// UMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxX : Window
    {

        //声明定时任务 WPF与界面交互专用定时任务
        private static DispatcherTimer timer = new DispatcherTimer();
        /// <summary>
        /// 禁止在外部实例化
        /// </summary>
        public MessageBoxX()
        {
            InitializeComponent();
        }

        public new string Title
        {
            get { return this.lblTitle.Text; }
            set { this.lblTitle.Text = value; }
        }

        public string Message
        {
            get { return this.lblMsg.Text; }
            set { this.lblMsg.Text = value; }
        }

        /// <summary>
        /// 静态方法 模拟MESSAGEBOX.Show方法
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static bool? Show(string title, string msg)
        {
            var msgBox = new MessageBoxX();
            msgBox.Title = title;
            msgBox.Message = msg;
            return msgBox.ShowDialog();
        }
        /// <summary>
        /// 显示窗口不等待关闭继续往下执行 byCQZ
        /// </summary>
        /// <param name="title"></param>
        /// <param name="msg"></param>
        public static void ShowAsync(string title, string msg)
        {
            var msgBox = new MessageBoxX();
            msgBox.Title = title;
            msgBox.Message = msg;
            msgBox.Show();
        }
        /// <summary>
        /// 自定义加载等待界面，会等待几秒自动关闭
        /// </summary>
        /// <param name="title"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public void ShowLoading(string title, string msg ,int loadSecond)
        {
            //初始化注册定时器
            timer.Tick += new EventHandler(timeCycle);
            //3秒后关闭窗口
            timer.Interval = new TimeSpan(0, 0, 0, loadSecond);
            timer.Start();
            //显示提示框
            //var msgBox = new MessageBoxX();
            this.Title = title;
            this.Message = msg;
            this.ShowDialog();
            

            

        }
        //定时任务调用方法 
        private void timeCycle(object sender, EventArgs e)
        {
            //this.DialogResult = true;
            timer.Stop();
            timer.Tick -= timeCycle; // 取消注册
            this.Close();
        }

        private void Yes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DialogResult = true;
            this.Close();
        }


        private void No_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DialogResult = false;
            this.Close();
        }
    }
}

