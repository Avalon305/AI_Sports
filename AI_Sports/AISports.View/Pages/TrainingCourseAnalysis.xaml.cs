using AI_Sports.Entity;
using AI_Sports.Service;
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

        private void TrainingCourseRecords_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int? Course_count = (this.TrainingCourseRecords.SelectedItem as TrainingCourseVO).Course_count;

            Console.WriteLine("选中行的course_count："+ Course_count);

        }

        private void TrainingCourseRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
