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
		public void AddThreePlans()
		{
			trainingPlanGroup.Add(new TrainingPlan() { trainingPlan = "TrainingA" });
			trainingPlanGroup.Add(new TrainingPlan() { trainingPlan = "TrainingB" });
			trainingPlanGroup.Add(new TrainingPlan() { trainingPlan = "TrainingC" });
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
		public TrainingProgram()
		{
			InitializeComponent();
			String[] text = { "未完成", "持续进行" };
			if (viewModel.completeFlag.flag == 0)
			{
				this.completeFlag.SetBinding(TextBlock.TextProperty, new Binding(".") { Source = text[0] });
			}
			else
			{
				this.completeFlag.SetBinding(TextBlock.TextProperty, new Binding(".") { Source = text[1] });
			}
			//集合数据绑定
			this.listBox.ItemsSource = viewModel.trainingPlanGroup;
			//添加数据
			viewModel.AddThreePlans();
		}
	}
}
