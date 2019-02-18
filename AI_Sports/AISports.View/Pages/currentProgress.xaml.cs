using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
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
    /// userFrist.xaml 的交互逻辑
    /// </summary>
    public partial class currentProgress : Page
    {
        public currentProgress()
        {
            InitializeComponent();
            TrainingCourseService trainingCourseService = new TrainingCourseService();
            //查询训练课程
            TrainingCourseEntity trainingCourse = trainingCourseService.GetCourseByMemberId();
            double target = (double)trainingCourse.Target_course_count;
            double current = (double)trainingCourse.Current_course_count;
            // 10/32训练课程已完成
            this.Jincheng.Content = current + "/" + target + this.Jincheng.Content;

            //进程百分比,整数
            double jinchengJindu = current / target;
            jinchengJindu = Math.Round(jinchengJindu * 100);

            //30%
            this.JinchengJindu.Content = jinchengJindu + "%";
            //进度条进度设置
            this.progressBar.Maximum = 100;
            this.progressBar.Value = (double)jinchengJindu;
            //目标百分比

        }
        /// <summary>
        /// 点击前往训练计划按钮,页面跳转到训练计划页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrainingProgram trainingProgram = new TrainingProgram();
            this.Content = trainingProgram;
        }
    }
}
