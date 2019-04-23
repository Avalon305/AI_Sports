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
    /// Page1.xaml 的交互逻辑
    /// </summary>
    public partial class analyze : Page
    {
        public analyze()
        {
            InitializeComponent();


        }

        private void Button_Click_Attendance(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/attendance.xaml", UriKind.Relative));
        }
        private void Button_Click_Statistics(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/TrainingPlanAnalysis.xaml", UriKind.Relative));
        }
        private void Button_Click_Practice(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/Practice.xaml", UriKind.Relative));
        }
        private void Button_Click_Process(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/ProcessChart.xaml", UriKind.Relative));
        }
        private void Button_Click_Muscle(object sender, RoutedEventArgs e)
        {

            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/muscle.xaml", UriKind.Relative));
        }
        
    }
}
