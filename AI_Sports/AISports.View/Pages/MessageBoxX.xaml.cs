using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace spms.view.Pages
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBoxX : Window
    {
    
        /// <summary>
        /// 结果，用户点击确定Result=true;
        /// </summary>
        public bool Result { get; private set; }

        private static readonly Dictionary<string, Brush> _Brushes = new Dictionary<string, Brush>();

        public MessageBoxX(EnumNotifyType type, string mes)
        {
            InitializeComponent();
            this.Width = SystemParameters.WorkArea.Size.Width * 0.277;
            this.Height = this.Width / 2.2;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.txtMessage.Text = mes;
            this.txtMessage.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            //type
            btnCancel.Visibility = Visibility.Collapsed;
            //Console.WriteLine(type);
            this.SetForeground(type);
            switch (type)
            {
                case EnumNotifyType.Error:
                    this.ficon.Text = "\ue644";
                    this.ficon.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    break;
                case EnumNotifyType.Warning:
                    this.ficon.Text = "\ue60b";
                    this.ficon.Foreground = new SolidColorBrush(Color.FromRgb(255, 215, 0));
                    break;
                case EnumNotifyType.Info:
                    this.ficon.Text = "\ue659";
                    this.ficon.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    break;
                case EnumNotifyType.Question:
                    this.ficon.Text = "\ue60e";
                    this.ficon.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                    this.btnCancel.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void SetForeground(EnumNotifyType type)
        {
            string key = "Foreground";
            if (!_Brushes.ContainsKey(key))
            {
                var b = this.TryFindResource(key) as Brush;
                _Brushes.Add(key, b);
            }
            this.Foreground = _Brushes[key];
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Result = true;
            this.Close();
            e.Handled = true;
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Result = false;
            this.Close();
            e.Handled = true;
        }

        /********************* public static method **************************/

        /// <summary>
        /// 提示错误消息
        /// </summary>
        public static void Error(string mes, Window owner = null)
        {
            Show(EnumNotifyType.Error, mes, owner);
        }

        /// <summary>
        /// 提示普通消息
        /// </summary>
        public static void Info(string mes, Window owner = null)
        {
            Show(EnumNotifyType.Info, mes, owner);
        }

        /// <summary>
        /// 提示警告消息
        /// </summary>
        public static void Warning(string mes, Window owner = null)
        {
            Show(EnumNotifyType.Warning, mes, owner);
        }

        /// <summary>
        /// 提示询问消息
        /// </summary>
        public static bool Question(string mes, Window owner = null)
        {
            return Show(EnumNotifyType.Question, mes, owner);
        }

        /// <summary>
        /// 显示提示消息框，
        /// owner指定所属父窗体，默认参数值为null，则指定主窗体为父窗体。
        /// </summary>
        private static bool Show(EnumNotifyType type, string mes, Window owner = null)
        {
            var res = true;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                MessageBoxX nb = new MessageBoxX(type, mes) { Title = MessageBoxX.GetDescription(type)
                    
            };
                //nb.Width = SystemParameters.WorkArea.Size.Width * 0.277;
               // nb.Height = nb.Width / 2.2;
                nb.Owner = owner ?? Application.Current.MainWindow;
                //nb.AllowsTransparency = false;
                nb.ShowDialog();
                res = nb.Result;
            }));
            return res;
        }

        /// <summary>
        /// 通知消息类型
        /// </summary>
        public enum EnumNotifyType
        {
            [Description("错误")]
            Error,
            [Description("警告")]
            Warning,
            [Description("提示信息")]
            Info,
            [Description("询问信息")]
            Question,
        }
        public static string GetDescription(EnumNotifyType en)
        {
            Type type = en.GetType();   //获取类型  
            MemberInfo[] memberInfos = type.GetMember(en.ToString());   //获取成员  
            if (memberInfos != null && memberInfos.Length > 0)
            {
                DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];   //获取描述特性  

                if (attrs != null && attrs.Length > 0)
                {
                    return attrs[0].Description;    //返回当前描述  
                }
            }
            return en.ToString();
        }

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        public int IsTrue = 0;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        private void window_loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
