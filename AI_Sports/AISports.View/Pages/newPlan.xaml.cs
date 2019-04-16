using AI_Sports.Constant;
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

        bool havePlanFlag = false;
        public NewPlan()
        {
            InitializeComponent();

            TrainingPlanEntity trainingPlanEntity = trainingPlanService.GetPlanByMumberId();
            if (trainingPlanEntity != null)
            {
                havePlanFlag = true;
                this.Lab_Title.Content = trainingPlanEntity.Title;
                this.Lab_Gmt_create.Content = trainingPlanEntity.Gmt_create.Value.ToString("f");
            }
            
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Template.Visibility = Visibility.Collapsed;
            this.Template.IsExpanded = false;

            this.SITE.Visibility = Visibility.Visible;
			this.SITE.IsExpanded = true;
		}
        /// <summary>
        /// 展开关闭训练计划模板Expander
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Template(object sender, RoutedEventArgs e)
        {
            this.SITE.Visibility = Visibility.Collapsed;
            this.SITE.IsExpanded = false;

            this.Template.Visibility = Visibility.Visible;
            this.Template.IsExpanded = true;
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
        /// <summary>
        /// 保存模板训练计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Save_Template(object sender, RoutedEventArgs e)
        {
            MemberEntity memberEntity = new MemberEntity();
            //判断登陆用户，是教练自己锻炼。还是教练为用户进行设置。决定传哪个主键设置
            string currentMemberPK = CommUtil.GetSettingString("memberPrimarykey");
            string currentCoachId = CommUtil.GetSettingString("coachId");
            if ((currentMemberPK == null || currentMemberPK == "") && (currentCoachId != null && currentCoachId != ""))
            {
                //无用户登陆。教练单独登陆时
                //  从app.config中取id,转成int赋值
                memberEntity.Id = ParseIntegerUtil.ParseInt(currentCoachId);
            }
            else
            {
                //只要用户登录，就是为用户进行设置
                //  从app.config中取id,转成int赋值
                memberEntity.Id = ParseIntegerUtil.ParseInt(currentMemberPK);

            }
            //  设置用户卡号
            memberEntity.Member_id = CommUtil.GetSettingString("memberId");

            //2019.3.28新增 如果有选择 就使用模板自动创建训练计划 没选择就不创建
            if (strengthRadioButton.IsChecked == true)//力量循环模板
            {
                trainingPlanService.AutoSaveNewPlan(memberEntity, PlanTemplate.StrengthCycle);
                Console.WriteLine("创建力量循环模板计划");
            }
            else if (enduranceRadioButton.IsChecked == true)//耐力循环模板
            {
                trainingPlanService.AutoSaveNewPlan(memberEntity, PlanTemplate.EnduranceCycle);
                Console.WriteLine("创建力量耐力循环模板计划");

            }
            else if (strengthEnduranceRadioButton.IsChecked == true)//力量循环与力量耐力循环模板
            {
                trainingPlanService.AutoSaveNewPlan(memberEntity, PlanTemplate.StrengthEnduranceCycle);
                Console.WriteLine("创建力量循环与力量耐力循环模板计划");

            }
            //调用2秒后自动关闭窗口的方法
            MessageBoxX messageBoxX = new MessageBoxX();
            messageBoxX.ShowLoading("温馨提示","创建中请稍等......",2);

            //隐藏模板Expander
            this.Template.Visibility = Visibility.Collapsed;
            this.Template.IsExpanded = false;
            //重新加载计划
            TrainingPlanEntity trainingPlanEntity = trainingPlanService.GetPlanByMumberId();
            if (trainingPlanEntity != null)
            {
                this.Lab_Title.Content = trainingPlanEntity.Title;
                this.Lab_Gmt_create.Content = trainingPlanEntity.Gmt_create.Value.ToString("f");
            }
        }
        /// <summary>
        /// 取消选择模板训练计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Cancle_Template(object sender, RoutedEventArgs e)
        {
            this.Template.Visibility = Visibility.Collapsed;
            this.Template.IsExpanded = false;
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
            if (havePlanFlag)
            {
                NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/AddCourse.xaml", UriKind.Relative));

            }
            else
            {
                MessageBoxX.Show("温馨提示","请先添加训练计划与训练课程。");

            }

        }
        /// <summary>
        /// 点击训练计划边框跳转到训练课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (havePlanFlag)
            {
                NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/AddCourse.xaml", UriKind.Relative));

            }
            else
            {
                MessageBoxX.Show("温馨提示","请先添加训练计划与训练课程。");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }




        //private void Text_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    this.TB_Title.Text = "请输入标题";
        //}
    }
   
}
