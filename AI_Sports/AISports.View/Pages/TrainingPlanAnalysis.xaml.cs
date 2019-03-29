using AI_Sports.Entity;
using AI_Sports.Service;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Runtime.Serialization.Json;
using AI_Sports.AISports.Util;
using System.ComponentModel;
using AI_Sports.Util;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// TrainingPlanAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class TrainingPlanAnalysis : Page
    {
        string sumEnergy = "";
        string sumTime = "";
        int? courseCount = new int?();//当前次数
        int? targetCourseCount = new int?(); //目标次数

        //语音分析的后台任务 不适用后台任务则界面卡死 无法进行其他操作
        private BackgroundWorker worker = new BackgroundWorker();

        public TrainingPlanAnalysis()
        {
            InitializeComponent();
            //初始化后台任务
            InitializeBackgroundWorker();

            //获取 trainingPlanId
            string trainingPlanId = CommUtil.GetSettingString("trainingPlanId");

            //图表
            this.Web.ObjectForScripting = new WebAdapter();
            //获取项目的根路径
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            Web.Navigate(new Uri(rootpath + "AISports.Echarts/dist/TrainingUnit.html"));

            TrainingPlanService trainingPlanService = new TrainingPlanService();

            //查询VO
            TrainingPlanVO trainingPlanVO = trainingPlanService.GetTrainingPlanVO();
            if (trainingPlanVO != null)
            {
                //绑定训练计划标题
                this.Lab_Title.Content = trainingPlanVO.Title;
                //绑定训练计划创建时间
                this.Lab_Gmt_create.Content += trainingPlanVO.Gmt_create.Value.ToString("f");
                //绑定课程记录
                this.Lab_Current_course_count.Content = trainingPlanVO.Current_course_count + "次";
                //绑定总耗能
                this.Lab_SumEnergy.Content = (trainingPlanVO.SumEnergy / 1000) + "千卡";
                //绑定总时间
                this.Lab_SumTime.Content = (trainingPlanVO.SumTime / 60) + "分钟";
                //给语音分析参数赋值
                sumEnergy = this.Lab_SumEnergy.Content.ToString();
                sumTime = this.Lab_SumTime.Content.ToString();
                courseCount = trainingPlanVO.Current_course_count;
                targetCourseCount = trainingPlanVO.Target_course_count;
            }
            
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("点击border跳转到新页面");
            //页面跳转
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/TrainingCourseAnalysis.xaml", UriKind.Relative));
            //NavigationService.GetNavigationService(this).GoForward();//向后转
            //NavigationService.GetNavigationService(this).GoBack();　 //向前转
        }
        /// <summary>
        /// 点击后退按钮。退到分析导航页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/analyze.xaml", UriKind.Relative));

        }

        /// <summary>
        /// 初始化后台任务worker
        /// </summary>
        private void InitializeBackgroundWorker()
        { //初始化注册后台事件
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            // worker 要做的事情 使用了匿名的事件响应函数
            worker.DoWork += (o, ea) =>
            {
                //WPF中线程只能控制自己创建的控件，
                //如果要修改主线程创建的MainWindow界面的内容,
                //可以委托主线程的Dispatcher处理。
                //在这里，委托内容为一个匿名的Action对象。
                //this.Dispatcher.Invoke((Action)(() =>
                //{
                //    this.TextBox1.Text = "worker started";
                //}));
                //Thread.Sleep(1000);
                if (courseCount != null && sumEnergy != null && sumTime != null && targetCourseCount != null && courseCount != null)
                {
                    String speechText = "您本次训练计划共完成" + courseCount + "次训练课程,共消耗热量" + sumEnergy + ",训练总时间" + sumTime + "，目标总课时数为" + targetCourseCount + "次，还需要完成" + (targetCourseCount - courseCount) + "次训练课程";
                    Console.WriteLine("训练计划语音文本：" + speechText);
                    SpeechUtil.read(speechText);
                }
                else
                {
                    string speechText = "您还没有训练计划，请联系教练添加训练计划。";
                    SpeechUtil.read(speechText);

                    Console.WriteLine("无训练计划数据，播报提示信息");
                }




            };

            //worker完成事件
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

        }

        /// <summary>
        /// 语音分析按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    public class WebAdapter
    {
        TrainingPlanService trainingPlanService = new TrainingPlanService();
        //获取 trainingPlanId
        string trainingPlanId = CommUtil.GetSettingString("trainingPlanId");
        //X轴动态加载数据(未用到)
        public int recordNumber()
        {
            int recordNumber = trainingPlanService.selectRecordNumber();
            return recordNumber;
        }

        //X轴动态加载数据
        public string  Xaxis()
        {
            //获取 currentCourseCount
            string currentCourseCountValue = CommUtil.GetSettingString("currentCourseCount");
            Console.WriteLine("训练计划currentCourseCount" + currentCourseCountValue);
            return currentCourseCountValue;

        }

        //根据课程轮次数从小到大排序查询有氧训练设备的总能量
        public String aerobicEnergy()
        {  
            List<double> aerobicEnergy = trainingPlanService.selectAerobicEnergy(trainingPlanId);
            DataContractJsonSerializer json = new DataContractJsonSerializer(aerobicEnergy.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, aerobicEnergy);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }
            Console.WriteLine("成功L:" + szJson.Count());
            return szJson.ToString();
        }
        //根据课程轮次数从小到大排序查询力量训练设备的总能量
        public String forceEnergy()
        {
            //获取 trainingPlanId
            string trainingPlanId = CommUtil.GetSettingString("trainingPlanId");
            List<double> forceEnergy = trainingPlanService.selectForceEnergy(trainingPlanId);
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
