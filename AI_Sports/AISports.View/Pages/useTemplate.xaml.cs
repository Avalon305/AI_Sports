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
    /// 使用模板.xaml 的交互逻辑
    /// </summary>
    public partial class 使用模板 : Page
    {
        public 使用模板()
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

        private void RadioButton1_Click(object sender, RoutedEventArgs e)
        {
            
            
                radioButton2.IsChecked =false;
                radioButton3.IsChecked =false;
            

        }

        private void RadioButton2_Click(object sender, RoutedEventArgs e)
        {
           
                radioButton1.IsChecked = false;
                radioButton3.IsChecked = false;
            
        }

        private void RadioButton3_Click(object sender, RoutedEventArgs e)
        {
            
                radioButton1.IsChecked = false;
                radioButton2.IsChecked = false;
            
        }
    }
}
