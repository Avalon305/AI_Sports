
using System.Windows;

using System.Windows.Input;


namespace AI_Sports.AISports.View.Pages
{
        /// <summary>
        /// UMessageBox.xaml 的交互逻辑
        /// </summary>
        public partial class MessageBoxX : Window
        {
            /// <summary>
            /// 禁止在外部实例化
            /// </summary>
            private MessageBoxX()
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

            private void Yes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DialogResult = true;
                this.Close();
            }


            private void No_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                this.DialogResult = false;
                this.Close();
            }
        }
    }
}
