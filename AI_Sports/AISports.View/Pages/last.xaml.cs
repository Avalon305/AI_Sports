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
    /// last.xaml 的交互逻辑
    /// </summary>
    public partial class last : Page
    {
        public last()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/allSettings.xaml", UriKind.Relative));
        }
        private void Lunci_minus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            if (!(text == 1))
            { text--; }
            lunci_content.Content = text.ToString();
        }
        private void Lunci_plus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            if (!(text == 10))
            { text++; }
            lunci_content.Content = text.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
