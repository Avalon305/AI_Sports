using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Service;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
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
    /// TrainingCourseAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class TrainingCourseAnalysis : Page
    {
        TrainingCourseService trainingCourseService = new TrainingCourseService();
        public TrainingCourseAnalysis()
        {
            InitializeComponent();
            //图表
            Web.ObjectForScripting = new WebTrainingCourse();
            //获取项目的根路径
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            Web.Navigate(new Uri(rootpath + "AISports.Echarts/dist/CourseRecord.html"));

            //查询课程记录集合 绑定ItemsSource
            List<TrainingCourseVO> trainingCourseVOs = trainingCourseService.listCourseRecord();

            this.TrainingCourseRecords.ItemsSource = trainingCourseVOs;

        }
        /// <summary>
        /// 点击表格行，鼠标抬起时传参跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrainingCourseRecords_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TrainingCourseVO trainingCourseVO = this.TrainingCourseRecords.SelectedItem as TrainingCourseVO;
            if(trainingCourseVO != null)
            {
                int? Course_count = trainingCourseVO.Course_count;

                Console.WriteLine("课程页选中行的course_count：" + Course_count);
                //跳转到训练活动页面 传参只需要在后边加上参数即可
                TrainingActivityAnalysis trainingActivityAnalysis = new TrainingActivityAnalysis();
                this.NavigationService.Navigate(trainingActivityAnalysis, Course_count);
                //加载从训练课程页面传来的参数 //注意LoadCompleted 事件的位置在 Page1.cs 中
                this.NavigationService.LoadCompleted += trainingActivityAnalysis.NavigationService_LoadCompleted;

            }

        }



        private void TrainingCourseRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// 点击后退按钮，退到训练计划页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/TrainingPlanAnalysis.xaml", UriKind.Relative));

        }

        private void Speech_Click(object sender, RoutedEventArgs e)
        {
            //查询课程记录集合 绑定ItemsSource
            List<TrainingCourseVO> trainingCourseVOs = trainingCourseService.listCourseRecord();
            StringBuilder speechText = new StringBuilder();
            speechText.Append("您总共进行了");
            speechText.Append(trainingCourseVOs.Count);
            speechText.Append("次训练课程。");
            foreach (var item in trainingCourseVOs)
            {
                
                speechText.Append("第");
                speechText.Append(item.Course_count);
                speechText.Append("次训练课程训练");
                speechText.Append(item.Sum_time);
                speechText.Append("分钟，消耗热量");
                speechText.Append(item.Sum_energy);
                speechText.Append("千卡，总共使用设备完成了");
                speechText.Append(item.Sum_count);
                speechText.Append("次往复运动，");
                speechText.Append("在不同设备上进行了");
                speechText.Append(item.Dev_count);
                speechText.Append("次一分钟的训练，");
                speechText.Append("其中平均顺向力为");
                speechText.Append(item.Avg_consequent_force);
                speechText.Append("千克，平均反向力为");
                speechText.Append(item.Avg_reverse_force);
                speechText.Append("千克。");

            }
            Console.WriteLine("训练课程语音文本："+speechText.ToString());
            SpeechUtil.read(speechText.ToString());

        }
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebTrainingCourse
    {

        TrainingCourseService trainingCourseService = new TrainingCourseService();

        //X轴动态加载数据
        public int maxCourseRecord()
        {
            int maxCourseRecord = trainingCourseService.selectMAxCourseRecord();
            Console.WriteLine("成功:" + maxCourseRecord);
            return maxCourseRecord;
        }
        //根据课程轮次数从小到大排序查询力量耐力循环（有氧）的总能量
        public double aerobicEnduranceEnergy()
        {
            double aerobicEnduranceEnergy = trainingCourseService.selectAerobicEnduranceEnergy();
            return aerobicEnduranceEnergy;
        }
        //根据课程轮次数从小到大排序查询力量耐力循环（力量）的总能量
        public double forceEnduranceEnergy()
        {
            double forceEnduranceEnergy = trainingCourseService.selectForceEnduranceEnergy();
            return forceEnduranceEnergy;
        }

        //根据课程轮次数从小到大排序查询力量循环的总能量
        public double forceEnergy()
        {
            double forceEnergy = trainingCourseService.selectForceEnergy();
            return forceEnergy;
        }

    }

}
