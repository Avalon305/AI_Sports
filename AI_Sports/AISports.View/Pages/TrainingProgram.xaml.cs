using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using AI_Sports.Constant;
using AI_Sports.AISports.Util;

namespace AI_Sports.AISports.View.Pages
{
	/// <summary>
	/// TrainingProgram.xaml 的交互逻辑
	/// </summary>
	class MainWindowViewModel
	{
        

        public CompleteFlag completeFlag;
		public ObservableCollection<TrainingPlan> trainingPlanGroup;

		public MainWindowViewModel()
		{
			completeFlag = new CompleteFlag();
			completeFlag.flag = 1;
			trainingPlanGroup = new ObservableCollection<TrainingPlan>();
		}
		public void AddThreePlans(List<ActivityEntity> activityList)
		{
            foreach (var activity in activityList)
            {
                switch (activity.Activity_type)
                {
                    case "0":
                        trainingPlanGroup.Add(new TrainingPlan() { trainingPlan = CycleTypeEnum.力量循环.ToString() + "(当前轮次/目标轮次:" + activity.current_turn_number + "/" + activity.Target_turn_number +")"});
                        break;
                    case "1":
                        trainingPlanGroup.Add(new TrainingPlan() { trainingPlan = CycleTypeEnum.力量耐力循环.ToString() + "(当前轮次/目标轮次:" + activity.current_turn_number + "/" + activity.Target_turn_number + ")"});
                        break;

                    default:
                        break;

                }
                
            }

        }
    }

    class CompleteFlag //训练完成标志
	{
		public int flag { get; set; }
	}
	class TrainingPlan //训练计划
	{
		public string trainingPlan { get; set; }
	}
	public partial class TrainingProgram : Page
	{
		private MainWindowViewModel viewModel = new MainWindowViewModel();
        private TrainingPlanService trainingPlanService = new TrainingPlanService();
        private TrainingActivityService activityService = new TrainingActivityService();
        public TrainingProgram()
		{
			InitializeComponent();

           
            
            //查询训练计划
            TrainingPlanEntity trainingPlanEntity = trainingPlanService.GetPlanByMumberId();
            //计划标题
            this.lable_planName.Content += trainingPlanEntity.Title; 

            String[] text = { "已完成", "持续进行" };
			if (trainingPlanEntity.Is_deleted == true)
			{
				this.completeFlag.SetBinding(TextBlock.TextProperty, new Binding(".") { Source = text[0] });
			}
			else if(trainingPlanEntity.Is_deleted == false)
			{
				this.completeFlag.SetBinding(TextBlock.TextProperty, new Binding(".") { Source = text[1] });
			}
            //加载训练活动
            List<ActivityEntity> activityList = activityService.ListActivitysByCourseId();
            //添加数据
            viewModel.AddThreePlans(activityList);
            //集合数据绑定
            this.listBox.ItemsSource = viewModel.trainingPlanGroup;
            
        }
        /// <summary>
        /// 跳过训练课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("训练课程已完成");
        }
        /// <summary>
        /// 语音分析按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speech_Click(object sender, RoutedEventArgs e)
        {
            List<ActivityEntity> activityList = activityService.ListActivitysByCourseId();
            StringBuilder speechBuilder = new StringBuilder();
            speechBuilder.Append("您可以在此查看当前训练课程中包含的训练活动的详细信息和进度。");

            if (activityList != null && activityList.Count > 0)
            {
                speechBuilder.Append("您的训练活动包括");
                foreach (var activity in activityList)
                {
                    switch (activity.Activity_type)
                    {
                        case "0":
                            speechBuilder.Append("力量循环、");
                            break;
                        case "1":
                            speechBuilder.Append("力量耐力循环、");
                            break;
                        default:
                            break;

                    }

                }
                foreach (var activity in activityList)
                {
                    switch (activity.Activity_type)
                    {
                        case "0":
                            speechBuilder.Append("力量循环当前已完成");
                            speechBuilder.Append(activity.current_turn_number);
                            speechBuilder.Append("轮，目标轮次为");
                            speechBuilder.Append(activity.Target_turn_number);
                            speechBuilder.Append("轮，还需要完成");
                            speechBuilder.Append(activity.Target_turn_number - activity.current_turn_number);
                            speechBuilder.Append("轮。");



                            break;
                        case "1":
                            speechBuilder.Append("力量耐力循环当前已完成");
                            speechBuilder.Append(activity.current_turn_number);
                            speechBuilder.Append("轮，目标轮次为");
                            speechBuilder.Append(activity.Target_turn_number);
                            speechBuilder.Append("轮，还需要完成");
                            speechBuilder.Append(activity.Target_turn_number - activity.current_turn_number);
                            speechBuilder.Append("轮。");
                            break;
                        default:
                            break;

                    }

                }
                speechBuilder.Append("加油！坚持完成每一个目标，持之以恒才能达到理想的锻炼效果。");
            }
            

            Console.WriteLine("训练活动页TrainingProgram语音文本："+speechBuilder.ToString());

            //调用工具类读
            SpeechUtil.read(speechBuilder.ToString());

        }
    }
}
