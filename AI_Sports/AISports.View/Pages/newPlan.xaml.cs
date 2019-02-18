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
    /// 新建训练计划.xaml 的交互逻辑
    /// </summary>
    public partial class 新建训练计划 : Page
    {
        public 新建训练计划()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/newPlan.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/useTemplate.xaml", UriKind.Relative));
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/Xw_1.xaml", UriKind.Relative));

            
        }

        private void Aim_LostFocus(object sender, RoutedEventArgs e)
        {
            this.aim.Text = "请输入您的目标";
        }

        private void Aim_GotFocus(object sender, RoutedEventArgs e)
        {
            this.aim.Text ="";
        }

        private void Text_GotFocus(object sender, RoutedEventArgs e)
        {
            this.text.Text = "";
        }

        private void Text_LostFocus(object sender, RoutedEventArgs e)
        {
            this.text.Text = "请输入标题";
        }
    }
   
}
