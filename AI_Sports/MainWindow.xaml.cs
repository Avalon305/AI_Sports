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
        public MainWindow()
        {
            InitializeComponent();

            //显示欢迎页，验证后返回。
            //LoginWindow loginWindow = new LoginWindow();
            //loginWindow.ShowDialog(); //showdialog显示窗口要关闭此窗口后才能操作其他窗口
            //                          //测试CQZ
            //loginWindow.Close();//关闭欢迎页
 
           // this.mainpage.Navigate(new Uri("AISports.View/Pages/UserManage.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri
 
            this.mainpage.Navigate(new Uri("AISports.View/Pages/muscle.XAML", UriKind.Relative));//设定教练页面 urlkind相对uri
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

        //private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
