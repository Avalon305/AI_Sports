using AI_Sports.AISports.View.Pages;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private TrainingCourseService trainingCourseService = new TrainingCourseService();
        private TrainingActivityService trainingActivityService = new TrainingActivityService();
        public AddCourse()
        {
            InitializeComponent();
            //如果当前课程的训练活动记录不为NULL，就显示编辑活动页面，否则显示添加活动页面
            List<ActivityEntity> activityEntities = trainingActivityService.ListActivitysByCourseId();
            if (activityEntities.Count > 0)
            {
                //跳转编辑训练活动frame
                this.ActivityFrame.Source = new Uri("/AI_Sports;component/AISports.View/Pages/EditActivity.xaml", UriKind.Relative);
            }
            else
            {
                //跳转添加训练活动frame
                this.ActivityFrame.Source = new Uri("/AI_Sports;component/AISports.View/Pages/AddActivitys.xaml", UriKind.Relative);
            }
            


            //时间轴时间大小初始化
            Time_init();
            
        }
        /// <summary>
        /// 展开加载添加训练活动frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    this._number.Source = new Uri("AddActivitys.xaml", UriKind.Relative);

        //}
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
        /// <summary>
        /// 减少课程天数按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Xunliantime_minus(object sender, RoutedEventArgs e)
        {
            

            int xunLianTime = int.Parse(xunliantime_text.Text);
            //最小值为2，因为至少一个起始日期 一个截止日期
            if (xunLianTime > 2)
            {
                //删除时间轴结点
                DeleteTimeNode();
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
                //获得当前页面上的开始时间
                DateTime dateTime1 = Convert.ToDateTime(this.time_size1.Content);
                //默认结束日期 = 开始日期 + (暂停时间*(课程天数 - 1))  减一是因为当天算是第一天
                DateTime dateTime2 = dateTime1.AddDays(pauseTime * (xunLianTime - 1));
                string time2 = dateTime2.ToString("yyyy-MM-dd");
                time_size2.Content = time2;
            }
            
        }
        /// <summary>
        /// 训练课程天数增加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Xunliantime_plus(object sender, RoutedEventArgs e)
        {
            CreateTimeNode();

            int xunLianTime = int.Parse(xunliantime_text.Text);
            xunLianTime++;
            xunliantime_text.Text = xunLianTime.ToString();

            time_position.Width += 20;

            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            
            //获得当前页面上的开始日期
            DateTime dateTime1 = Convert.ToDateTime(this.time_size1.Content);
            //默认结束日期 = 开始日期 + (暂停时间*(课程天数 - 1))  减一是因为当天算是第一天
            DateTime dateTime2 = dateTime1.AddDays(pauseTime * (xunLianTime - 1));
            string time2 = dateTime2.ToString("yyyy-MM-dd");
            time_size2.Content = time2;
        }
        /// <summary>
        /// 暂停时间减少按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pausetime_minus(object sender, RoutedEventArgs e)
        {
            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            //最小值为1
            if (pauseTime > 1)
            {
                pauseTime--;
                pausetime_content.Content = pauseTime.ToString();

                int xunLianTime = int.Parse(xunliantime_text.Text);
                
                //获得当前页面上的开始时间
                DateTime dateTime1 = Convert.ToDateTime(this.time_size1.Content);
                //默认结束日期 = 开始日期 + (暂停时间*(课程天数 - 1))  减一是因为当天算是第一天
                DateTime dateTime2 = dateTime1.AddDays(pauseTime * (xunLianTime - 1));
                string time2 = dateTime2.ToString("yyyy-MM-dd");
                time_size2.Content = time2;
            }
            
        }
        /// <summary>
        /// 休息时间增加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pausetime_plus(object sender, RoutedEventArgs e)
        {
            int pauseTime = int.Parse(pausetime_content.Content.ToString());
            pauseTime++;
            pausetime_content.Content = pauseTime.ToString();

            int xunLianTime = int.Parse(xunliantime_text.Text);
            

            //获得当前页面上的开始时间
            DateTime dateTime1 = Convert.ToDateTime(this.time_size1.Content);

            //默认结束日期 = 开始日期 + (暂停时间*(课程天数 - 1))  减一是因为当天算是第一天
            DateTime dateTime2 = dateTime1.AddDays(pauseTime * (xunLianTime - 1));
            string time2 = dateTime2.ToString("yyyy-MM-dd");
            time_size2.Content = time2;
        }
        /// <summary>
        /// 从数据库查询自动添加的训练课程 根据查询数据初始化时间轴
        /// </summary>
        public void Time_init()
        {
            //查询自动添加的训练课程
            TrainingCourseEntity trainingCourseEntity = trainingCourseService.GetCourseByMemberId();
            //存储课程主键id
            CommUtil.UpdateSettingString("trainingCourseId", trainingCourseEntity.Id.ToString());
            //给页面上的数据赋值

            //开始时间
            time_size1.Content = trainingCourseEntity.Start_date.Value.ToString("yyyy-MM-dd");
            //结束时间
            time_size2.Content = trainingCourseEntity.End_date.Value.ToString("yyyy-MM-dd");
            //暂停天数
            pausetime_content.Content = trainingCourseEntity.Rest_days;
            //课程天数
            xunliantime_text.Text = trainingCourseEntity.Target_course_count.ToString();

            //前端的静态数据 废弃：
            //string time1 = DateTime.Now.ToString("yyyy-MM-dd");
            //int pauseTime = int.Parse(pausetime_content.Content.ToString());
            //int xunLianTime = int.Parse(xunliantime_text.Text);
            //DateTime dateTime1 = Convert.ToDateTime(time1);
            //DateTime dateTime2 = dateTime1.AddDays(pauseTime * xunLianTime);
            //string time2 = dateTime2.ToString("yyyy-MM-dd");

            //time_size1.Content = time1;
            //time_size2.Content = time2;
        }
        /// <summary>
        /// 点击保存按钮，更新训练课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SaveCourse_Click(object sender, RoutedEventArgs e)
        {
            TrainingCourseEntity trainingCourseEntity = new TrainingCourseEntity();
            //id
            trainingCourseEntity.Id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId"));
            //结束时间
            trainingCourseEntity.End_date = Convert.ToDateTime(time_size2.Content);
            //暂停天数
            trainingCourseEntity.Rest_days = ParseIntegerUtil.ParseInt(pausetime_content.Content.ToString());
            //课程天数
            trainingCourseEntity.Target_course_count = ParseIntegerUtil.ParseInt(xunliantime_text.Text);
            //更新训练课程
            if (trainingCourseService.UpdateTrainingCourseById(trainingCourseEntity.Rest_days,trainingCourseEntity.End_date,trainingCourseEntity.Target_course_count,trainingCourseEntity.Id) > 0)
            {
                Console.WriteLine("保存训练课程成功");
                MessageBoxX.Show("温馨提示","更新训练课程成功");
            }
            else
            {
                Console.WriteLine("保存训练课程失败");
                MessageBoxX.Show("温馨提示", "更新训练课程失败");

            }
        }

       
    }
}
