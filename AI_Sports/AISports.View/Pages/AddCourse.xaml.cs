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
    /// Xw_1.xaml 的交互逻辑
    /// </summary>
    public partial class AddCourse : Page
    {
        public AddCourse()
        {
            InitializeComponent();

            //时间轴时间大小初始化
            Time_init();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this._number.Source = new Uri("Xw_2.xaml", UriKind.Relative);

        }
        public void CreateTimeNode()
        {
            WrapPanel wrapPanel = new WrapPanel();

            int number = int.Parse(xunliantime_text.Text) + 1;

            //WrapPanel previousWrapPanel = shijianzhou.FindName("wrapPanel") as WrapPanel;
            //if (previousWrapPanel != null)
            //{
            //    shijianzhou.UnregisterName("wrapPanel");                
            //}
            shijianzhou.Children.Add(wrapPanel);
            shijianzhou.RegisterName("time_node" + number, wrapPanel);

            Ellipse ellipse = new Ellipse();
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF4F4F5"));
            ellipse.Stroke = new SolidColorBrush(Colors.Black);
            wrapPanel.Children.Add(ellipse);
            //shijianzhou.RegisterName("ellipse", ellipse);
            Rectangle rectangle = new Rectangle();
            rectangle.Width = 10.5;
            rectangle.Height = 2;
            rectangle.Fill = new SolidColorBrush(Colors.Black);
            wrapPanel.Children.Add(rectangle);
            //shijianzhou.RegisterName("rectangle", rectangle);

        }
        public void DeleteTimeNode()
        {
            //Ellipse ellipse = shijianzhou.FindName("ellipse") as Ellipse;
            //Rectangle rectangle = shijianzhou.FindName("rectangle") as Rectangle;
            //if (ellipse != null || rectangle != null)
            //{
            //    shijianzhou.Children.Remove(ellipse);
            //    shijianzhou.Children.Remove(rectangle);
            //    shijianzhou.UnregisterName("ellipse");
            //    shijianzhou.UnregisterName("rectangle");
            //}


            int number = int.Parse(xunliantime_text.Text);

            WrapPanel wrapPanel = shijianzhou.FindName("time_node" + number) as WrapPanel;
            if (wrapPanel != null)
            {
                shijianzhou.Children.Remove(wrapPanel);
                shijianzhou.UnregisterName("time_node" + number);
            }
        }
        private void Xunliantime_minus(object sender, RoutedEventArgs e)
        {
            DeleteTimeNode();

            int xunLianTime = int.Parse(xunliantime_text.Text);
            xunLianTime--;
            xunliantime_text.Text = xunLianTime.ToString();

            if (time_position.Width > 20)
            {
                time_position.Width -= 20;
            }
            else
            {
                time_position.Width = 10;
            }

            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            string time1 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime dateTime1 = Convert.ToDateTime(time1);
            DateTime dateTime2 = dateTime1.AddDays(pauseTime * xunLianTime);
            string time2 = dateTime2.ToString("yyyy-MM-dd");
            time_size2.Content = time2;
        }
        private void Xunliantime_plus(object sender, RoutedEventArgs e)
        {
            CreateTimeNode();

            int xunLianTime = int.Parse(xunliantime_text.Text);
            xunLianTime++;
            xunliantime_text.Text = xunLianTime.ToString();

            time_position.Width += 20;

            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            string time1 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime dateTime1 = Convert.ToDateTime(time1);
            DateTime dateTime2 = dateTime1.AddDays(pauseTime * xunLianTime);
            string time2 = dateTime2.ToString("yyyy-MM-dd");
            time_size2.Content = time2;
        }
        private void Pausetime_minus(object sender, RoutedEventArgs e)
        {
            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            pauseTime--;
            pausetime_content.Content = pauseTime.ToString();

            int xunLianTime = int.Parse(xunliantime_text.Text);
            string time1 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime dateTime1 = Convert.ToDateTime(time1);
            DateTime dateTime2 = dateTime1.AddDays(pauseTime * xunLianTime);
            string time2 = dateTime2.ToString("yyyy-MM-dd");
            time_size2.Content = time2;
        }
        private void Pausetime_plus(object sender, RoutedEventArgs e)
        {
            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            pauseTime++;
            pausetime_content.Content = pauseTime.ToString();

            int xunLianTime = int.Parse(xunliantime_text.Text);
            string time1 = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime dateTime1 = Convert.ToDateTime(time1);
            DateTime dateTime2 = dateTime1.AddDays(pauseTime * xunLianTime);
            string time2 = dateTime2.ToString("yyyy-MM-dd");
            time_size2.Content = time2;
        }
        public void Time_init()
        {
            string time1 = DateTime.Now.ToString("yyyy-MM-dd");
            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            int xunLianTime = int.Parse(xunliantime_text.Text);
            DateTime dateTime1 = Convert.ToDateTime(time1);
            DateTime dateTime2 = dateTime1.AddDays(pauseTime * xunLianTime);
            string time2 = dateTime2.ToString("yyyy-MM-dd");

            time_size1.Content = time1;
            time_size2.Content = time2;
        }
    }
}
