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
    /// Xw_2.xaml 的交互逻辑
    /// </summary>
    public partial class Xw_2 : Page
    {
        public Xw_2()
        {
            InitializeComponent();

            //活动数量初始化
            int text = huodong.Items.Count;
            huodongshu.Text = text.ToString();
        }
        private void Lunci_minus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            text--;
            lunci_content.Content = text.ToString();
        }
        private void Lunci_plus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            text++;
            lunci_content.Content = text.ToString();
        }

        private void clip3 (object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/trainingCourse.xaml", UriKind.Relative));
        }
    }
}
