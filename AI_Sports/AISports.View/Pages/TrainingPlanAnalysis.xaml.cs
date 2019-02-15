using AI_Sports.Entity;
using AI_Sports.Service;
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
    /// TrainingPlanAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class TrainingPlanAnalysis : Page
    {
        public TrainingPlanAnalysis()
        {
            InitializeComponent();

            TrainingPlanService trainingPlanService = new TrainingPlanService();

            //查询VO
            TrainingPlanVO trainingPlanVO = trainingPlanService.GetTrainingPlanVO();
            //绑定训练计划标题
            this.Lab_Title.Content = trainingPlanVO.Title;
            //绑定训练计划创建时间
            this.Lab_Gmt_create.Content += trainingPlanVO.Gmt_create.ToString();
            //绑定课程记录
            this.Lab_Current_course_count.Content = trainingPlanVO.Current_course_count + "次";
            //绑定总耗能
            this.Lab_SumEnergy.Content = (trainingPlanVO.SumEnergy/1000)+ "千卡";
            //绑定总时间
            this.Lab_SumTime.Content = (trainingPlanVO.SumTime / 60) + "分钟";
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("点击border跳转到新页面");
            //页面跳转
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/TrainingCourseAnalysis.xaml", UriKind.Relative));
            //NavigationService.GetNavigationService(this).GoForward();//向后转
            //NavigationService.GetNavigationService(this).GoBack();　 //向前转
        }
    }
}
