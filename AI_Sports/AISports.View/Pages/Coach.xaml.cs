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

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// Coach.xaml 的交互逻辑
    /// </summary>
    public partial class Coach : Page
    {
        public Coach()
        {
            InitializeComponent();
        }
        //用户信息录入页面
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            this.btn1.Background = new SolidColorBrush(Color.FromRgb(162, 162, 162));
            this.btn2.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.btn3.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.btn4.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.contentpage.Source = new Uri("AISports.View/Pages/AddUser.xaml", UriKind.Relative);//跳转页面
        }
        //训练计划页面
        private void Btn2_Click(object sender, RoutedEventArgs e)//
        {
            this.btn2.Background = new SolidColorBrush(Color.FromRgb(162, 162, 162));
            this.btn1.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            this.btn3.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.btn4.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.contentpage.Source = new Uri("AISports.View/Pages/AddPlan.xaml", UriKind.Relative);//跳转页面
        }
        //分析页面
        private void Btn3_Click(object sender, RoutedEventArgs e)//
        {
            this.btn3.Background = new SolidColorBrush(Color.FromRgb(162, 162, 162));
            this.btn1.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            this.btn2.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.btn4.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.contentpage.Source = new Uri("AISports.View/Pages/TrainingProgram.xaml", UriKind.Relative);//跳转页面
        }
        //控制面板页面
        private void Btn4_Click(object sender, RoutedEventArgs e)//
        {
            this.btn4.Background = new SolidColorBrush(Color.FromRgb(162, 162, 162));
            this.btn1.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            this.btn2.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.btn3.Background = new SolidColorBrush(Color.FromRgb(28, 67, 100));
            this.contentpage.Source = new Uri("AISports.View/Pages/Welcome_first.xaml", UriKind.Relative);//跳转页面
        }
        //退出登录重新启动
        private void Logout(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Restart();
            AI_Sports.App.Current.Shutdown();
        }
    }
}
