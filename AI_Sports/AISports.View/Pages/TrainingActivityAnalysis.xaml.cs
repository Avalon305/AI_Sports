using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// TrainingActivityAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class TrainingActivityAnalysis : Page
    {

        TrainingActivityService trainingActivityService = new TrainingActivityService();
        //全局当前课程记录变量
        int? currentCourseCount = 0;
        //用于接收课程页面传来的对象
        TrainingCourseVO trainingCourseVO = new TrainingCourseVO();

        //语音分析的后台任务 不用后台任务则界面卡死 无法进行其他操作
        private BackgroundWorker worker = new BackgroundWorker();

        public TrainingActivityAnalysis()
        {
            InitializeComponent();
            //初始化后台任务
            InitializeBackgroundWorker();

        }
        /// <summary>
        /// 获得从课程分析页面传来的参数 根据传来的课程记录id初始化表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.ExtraData != null)
            {

                trainingCourseVO = (TrainingCourseVO)e.ExtraData;
                if (trainingCourseVO != null)
                {
                    currentCourseCount = trainingCourseVO.Course_count;
                    Console.WriteLine("活动分析页收到的currentCourseCount：" + currentCourseCount);
                    //传入课程记录id，根据此id查询加载表格
                    InitList(currentCourseCount);
                    //加载创建时间 格式化为 这种格式：2016年5月9日 13:09
                    string gmtCreate = trainingCourseVO.Gmt_create.Value.ToString("f");



                    this.timeLable.Content = gmtCreate;
                }

            }

        }

        /// <summary>
        /// 初始化listview表格
        /// </summary>
        public void InitList(int? currentCourseCount)
        {
            //查询数据
            List<TrainingActivityVO> trainingActivities = trainingActivityService.ListActivityRecords(currentCourseCount);
            //表格加载数据
            CollectionViewSource ListViewGroupSource = (CollectionViewSource)this.FindResource("ListViewGroupSource");
            ListViewGroupSource.Source = trainingActivities;





        }
        /// <summary>
        /// 点击后退按钮 退到训练课程分析页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/TrainingCourseAnalysis.xaml", UriKind.Relative));

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



                List<TrainingActivityVO> trainingActivities = trainingActivityService.ListActivityRecords(currentCourseCount);
                int? strengthActivityCount = 0;
                int? enduranceActivityCount = 0;
                StringBuilder speechText = new StringBuilder();

                if (trainingActivities != null && trainingActivities.Count > 0)
                {
                    foreach (var item in trainingActivities)
                    {
                        if ("0".Equals(item.Activity_type))
                        {
                            //力量循环加一
                            strengthActivityCount++;
                        }
                        else if ("1".Equals(item.Activity_type))
                        {
                            //力量耐力循环加一
                            enduranceActivityCount++;
                        }
                    }

                    speechText.Append("您可以在此查看选择的训练课程记录的详细信息，包括各轮训练活动记录，您当前查看的是第");
                    speechText.Append(currentCourseCount);
                    speechText.Append("次课程记录。");
                    speechText.Append("总共进行了");
                    speechText.Append(trainingActivities.Count);
                    speechText.Append("次训练活动，其中力量循环运动");
                    speechText.Append(strengthActivityCount);
                    speechText.Append("次，");
                    speechText.Append("力量耐力循环运动");
                    speechText.Append(enduranceActivityCount);
                    speechText.Append("次。您可以点击训练活动展开查看详细记录。");
                }
                else
                {
                    speechText.Append("您还没有训练记录，请在设备上完成一轮训练课程后再查看分析。");

                }




                Console.WriteLine("训练活动分析页面语音文本:" + speechText.ToString());
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

        ///按钮绑定测试
        //private void Button_Click(object sender, RoutedEventArgs e)
        //
        //    System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;
        //    System.Windows.MessageBox.Show("当前行的设备类型：" + btn.Tag.ToString());
        //}

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
}
