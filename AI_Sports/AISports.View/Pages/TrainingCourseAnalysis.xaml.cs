using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
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

        //语音分析的后台任务 不用后台任务则界面卡死 无法进行其他操作
        private BackgroundWorker worker = new BackgroundWorker();

        public TrainingCourseAnalysis()
        {
            InitializeComponent();
            //初始化语音后台任务
            InitializeBackgroundWorker();
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
                //跳转到训练活动页面 传参只需要在后边加上参数即可 传递整个对象
                TrainingActivityAnalysis trainingActivityAnalysis = new TrainingActivityAnalysis();
                this.NavigationService.Navigate(trainingActivityAnalysis, trainingCourseVO);
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
        /// <summary>
        /// 初始化后台任务worker
        /// </summary>
        private void InitializeBackgroundWorker()
        {
            //初始化注册后台事件
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            // worker 要做的事情 使用了匿名的事件响应函数
            worker.DoWork += (o, ea) =>
            {
                //查询课程记录集合 绑定ItemsSource
                List<TrainingCourseVO> trainingCourseVOs = trainingCourseService.listCourseRecord();

                StringBuilder speechText = new StringBuilder();

                if (trainingCourseVOs != null && trainingCourseVOs.Count > 0)
                {
                    speechText.Append("您可以在此查看各次训练课程的统计信息，您总共进行了");
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
                }
                else
                {
                    speechText.Append("您还没有训练记录，请在设备上完成一轮训练课程后再查看分析。");
                }


                Console.WriteLine("训练课程语音文本：" + speechText.ToString());
                SpeechUtil.read(speechText.ToString());




            };

            //worker完成事件
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

        }
        private void Speech_Click(object sender, RoutedEventArgs e)
        {
            //防止连续点击造成的后台任务繁忙异常
            if (worker.IsBusy == true)
            {
                Console.WriteLine("后台语音任务正忙");

                return;
            }
            else
            {
                //显示停止按钮
                this.stop.Visibility = Visibility.Visible;
                //禁用分析按钮
                this.speech.IsEnabled = false;


                //注意：运行了下面这一行代码，worker才真正开始工作。上面都只是声明定义而已。
                worker.RunWorkerAsync();
            }


        }
        /// <summary>
        /// 语音后台任务完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Console.WriteLine("语音播放完毕");
                //隐藏停止按钮
                this.stop.Visibility = Visibility.Hidden;
                //可用分析按钮
                this.speech.IsEnabled = true;
            }
            catch (Exception)
            {

                throw new NotImplementedException();

            }
        }

        /// <summary>
        /// 停止语音分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //取消朗读
                SpeechUtil.stop();
                //取消后台任务
                this.worker.CancelAsync();
                //隐藏停止按钮
                this.stop.Visibility = Visibility.Hidden;
                //可用分析按钮
                this.speech.IsEnabled = true;
            }
            catch (Exception)
            {
                Console.WriteLine("停止语音按钮异常");
                throw;
            }

        }
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebTrainingCourse
    {

        TrainingCourseService trainingCourseService = new TrainingCourseService();
        
        //获取 trainingPlanId
        string trainingPlanId = CommUtil.GetSettingString("trainingPlanId");

        //X轴动态加载数据(未用到)
        public int maxCourseRecord()
        {
            int maxCourseRecord = trainingCourseService.selectMAxCourseRecord();
            Console.WriteLine("成功:" + maxCourseRecord);
            return maxCourseRecord;
        }
        //X轴动态加载数据
        public string Xaxis()
        {
            //获取 currentCourseCount
            string currentCourseCount = CommUtil.GetSettingString("currentCourseCount");

            Console.WriteLine("强强强强强强强强强强强强强强强强"+ currentCourseCount);
            return currentCourseCount;

        }
        //根据课程轮次数从小到大排序查询力量耐力循环（有氧）的总能量
        public string aerobicEnduranceEnergy()
        {
            List<double> aerobicEnduranceEnergy = trainingCourseService.selectAerobicEnduranceEnergy(trainingPlanId);
            Console.WriteLine("力量耐力循环（有氧）的总能量" + aerobicEnduranceEnergy);
            DataContractJsonSerializer json = new DataContractJsonSerializer(aerobicEnduranceEnergy.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, aerobicEnduranceEnergy);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }
            Console.WriteLine("成功:" + szJson);
            return szJson;
        }
        //根据课程轮次数从小到大排序查询力量耐力循环（力量）的总能量
        public string forceEnduranceEnergy()
        {
            List<double> forceEnduranceEnergy = trainingCourseService.selectForceEnduranceEnergy(trainingPlanId);
            DataContractJsonSerializer json = new DataContractJsonSerializer(forceEnduranceEnergy.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, forceEnduranceEnergy);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }
            Console.WriteLine("成功:" + szJson);
            return szJson;
        }

        //根据课程轮次数从小到大排序查询力量循环的总能量
        public string forceEnergy()
        {
            List<double> forceEnergy = trainingCourseService.selectForceEnergy(trainingPlanId);
            Console.WriteLine("力量循环的总能量" + forceEnergy);
            DataContractJsonSerializer json = new DataContractJsonSerializer(forceEnergy.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, forceEnergy);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }
            Console.WriteLine("成功:" + szJson);
            return szJson;
        }

    }

}
