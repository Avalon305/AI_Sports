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

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// 新建训练计划.xaml 的交互逻辑
    /// </summary>
    public partial class NewPlan : Page
    {
        TrainingPlanService trainingPlanService = new TrainingPlanService();
        public NewPlan()
        {
            InitializeComponent();

            TrainingPlanEntity trainingPlanEntity = trainingPlanService.GetPlanByMumberId();
            if (trainingPlanEntity != null)
            {
                this.Lab_Title.Content = trainingPlanEntity.Title;
                this.Lab_Gmt_create.Content = trainingPlanEntity.Gmt_create;
            }
            
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
			//NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/newPlan.xaml", UriKind.Relative));
			this.SITE.Visibility = Visibility.Visible;
			this.SITE.IsExpanded = true;
		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/useTemplate.xaml", UriKind.Relative));
        }

        /// <summary>
        ///获得前端数据，传到后台保存插入 然后跳转到训练课程页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                TrainingPlanEntity trainingPlanEntity = new TrainingPlanEntity();


                //获得前端数据，传到后台
                //标题
                trainingPlanEntity.Title = this.TB_Title.Text;
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd";
                //开始时间
                trainingPlanEntity.Start_date = Convert.ToDateTime(this.DP_StartDate.Text, dtFormat);
                //训练目标
                trainingPlanEntity.Training_target = this.CB_Target.Text;
                //传入service 添加训练计划的同时还会添加一个默认的训练课程，训练课程添加成功则跳转，直接把保存的训练课程查询出来
                trainingPlanService.SaveNewTrainingPlan(trainingPlanEntity);
                //跳转到添加课程页面
                NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/AddCourse.xaml", UriKind.Relative));
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        //private void Aim_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    this.CB_Target.Text = "请输入您的目标";
        //}

        //private void Aim_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    this.CB_Target.Text ="";
        //}

        private void Text_GotFocus(object sender, RoutedEventArgs e)
        {
            this.TB_Title.Text = "";
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Cancle(object sender, RoutedEventArgs e)
        {
            this.TB_Title.Text = "";
            this.DP_StartDate.Text = "";
            this.CB_Target.Text = "";
        }
        /// <summary>
        /// 查看当前课程点击事件 跳转到当前课程页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_CurrentCourse(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/AddCourse.xaml", UriKind.Relative));

        }
		

	

		//private void Text_LostFocus(object sender, RoutedEventArgs e)
		//{
		//    this.TB_Title.Text = "请输入标题";
		//}
	}
   
}
