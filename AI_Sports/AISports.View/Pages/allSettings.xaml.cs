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
    /// allSettings.xaml 的交互逻辑
    /// </summary>
    public partial class allSettings : Page
    {
        public allSettings()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string addTest = this.@out.Content.ToString();
            int add = int.Parse(addTest);
            if (!(add == 100))//如果add等于100或者0为真的话
            {
                add = add + 1;
            }

            this.@out.Content = add;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string addTest = this.@out.Content.ToString();
            int add = int.Parse(addTest);
            if (!(add == 1))
                add = add - 1;

            this.@out.Content = add;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string minusTest = this.minus.Content.ToString();
            int min = int.Parse(minusTest);
            if (!(min == 100))
            {
                min = min + 1;
            }
            this.minus.Content = min;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string minusTest = this.minus.Content.ToString();
            int min = int.Parse(minusTest);
            if (!(min == 1))
            {
                min = min - 1;
            }
            this.minus.Content = min;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/trainingCourse.xaml", UriKind.Relative));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/trainingCourse.xaml", UriKind.Relative));
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


    }
}
