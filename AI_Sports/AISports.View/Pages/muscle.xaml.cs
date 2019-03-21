using AI_Sports.AISports.Service;
using AI_Sports.AISports.Util;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// muscle.xaml 的交互逻辑
    /// </summary>
    public partial class muscle : Page
    {

        //语音分析的后台任务 不适用后台任务则界面卡死 无法进行其他操作
        private BackgroundWorker worker = new BackgroundWorker();

        public muscle()
        {
            InitializeComponent();
            Web.ObjectForScripting = new WebPie();
            Endurance.ObjectForScripting = new WebEndurancePie();
            //获取项目的根路径
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));

            Endurance.Navigate(new Uri(rootpath + "AISports.Echarts/dist/EndurancePie.html"));
            Web.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Pie.html"));

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


        }
        /// <summary>
        /// 语音分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speech_Click(object sender, RoutedEventArgs e)
        {


            //显示停止按钮
            this.stop.Visibility = Visibility.Visible;
            //禁用分析按钮
            this.speech.IsEnabled = false;

            // worker 要做的事情 使用了匿名的事件响应函数
            worker.DoWork += (o, ea) =>
            {


                StringBuilder speechBuilder = new StringBuilder();
                speechBuilder.Append("您可以在此查看您的主动肌对抗肌锻炼进度和各大肌肉群锻炼比例，以及各个设备对应锻炼的肌肉群分布，从而结合您的训练目标选择最适合您的设备进行锻炼。");
                Console.WriteLine("肌肉页面语音文本：" + speechBuilder.ToString());
                SpeechUtil.read(speechBuilder.ToString());


            };


            //注意：运行了下面这一行代码，worker才真正开始工作。上面都只是声明定义而已。
            worker.RunWorkerAsync();



            
        }

        /// <summary>
        /// 停止语音分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            //停止语音线程
            //worker.CancelAsync();
            // worker 完成事件响应

            SpeechUtil.stop();


            //隐藏停止按钮
            this.stop.Visibility = Visibility.Hidden;
            //可用分析按钮
            this.speech.IsEnabled = true;
        }

    }


    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebPie
    {
        public String Show()
        {
            return "60";
        }
        MusclePieChartService musclePieChartService = new MusclePieChartService();
        //获取 trainingCourseId
        string trainingCourseId = CommUtil.GetSettingString("trainingCourseId");
        //力量循环腹部训练个数
        public int abdomenTraining(string trainingCourseId)
        {
            Console.WriteLine("肌肉饼图训练课程ID" + trainingCourseId);
            Console.WriteLine("成功:" + musclePieChartService.selectAbdomenTraining(trainingCourseId)); 
            return musclePieChartService.selectAbdomenTraining(trainingCourseId);
        }

        //力量循环胸部训练个数
        public int chestTraining(string trainingCourseId)
        {
            return musclePieChartService.selectchestTraining(trainingCourseId);
        }

        //力量循环腿部训练个数
        public int legTraining(string trainingCourseId)
        {
            return musclePieChartService.selectLegTraining(trainingCourseId);
        }

        //力量循环手臂训练个数
        public int armTraining(string trainingCourseId)
        {
            return musclePieChartService.selectArmTraining(trainingCourseId);
        }

        //力量循环躯干训练个数
        public int trunkTraining(string trainingCourseId)
        {
            return musclePieChartService.selectTrunkTraining(trainingCourseId);
        }




    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebEndurancePie
    {
        public String Show()
        {
            return "60";
        }
        MusclePieChartService musclePieChartService = new MusclePieChartService();
        //获取 trainingCourseId
        string trainingCourseId = CommUtil.GetSettingString("trainingCourseId");

        //力量耐力循环胸部训练个数
        public int chestEnduranceTraining(string trainingCourseId)
        {
            Console.WriteLine("肌肉饼图训练课程ID" + trainingCourseId);
            return musclePieChartService.selectchestEnduranceTraining(trainingCourseId);
        }

        //力量耐力循环腿部训练个数
        public int legEnduranceTraining(string trainingCourseId)
        {
            return musclePieChartService.selectLegEnduranceTraining(trainingCourseId);
        }

        //力量耐力循环手臂训练个数
        public int armEnduranceTraining(string trainingCourseId)
        {
            return musclePieChartService.selectEnduranceArmTraining(trainingCourseId);
        }

        //力量耐力循环躯干训练个数
        public int trunkEnduranceTraining(string trainingCourseId)
        {
            return musclePieChartService.selectTrunkEnduranceTraining(trainingCourseId);
        }
    }


}
