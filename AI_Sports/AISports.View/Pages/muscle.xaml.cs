﻿using AI_Sports.AISports.Service;
using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Service;
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
           
            //获取 currentCourseCount
            string currentCourseCount = CommUtil.GetSettingString("currentCourseCount");
           
            TrainingActivityService trainingActivityService = new TrainingActivityService();
            List<ActivityEntity> activityEntity = trainingActivityService.ListActivitysByCourseId();
            //目标值
            int? targetValue = activityEntity[0].Target_turn_number;
            //坐式推胸肌实际值
            int? sittingChestPusherValue = sittingChestPusher(currentCourseCount);
            Console.WriteLine("坐式推胸肌实际值" + sittingChestPusherValue);
            //坐式划船机实际值
            int? sittingRowerValue = sittingRower(currentCourseCount);
            //坐式背部伸展机实际值
            int? sittingBackStretcherValue = sittingBackStretcher(currentCourseCount);
            //腹肌训练机实际值
            int? abdominalMuscleTrainingValue = abdominalMuscleTraining(currentCourseCount);
            //坐式腿伸展训练机实际值
            int? sittingLegStretchingValue = sittingLegStretching(currentCourseCount);
            //坐式曲腿训练机实际值
            int? sittingCurvingLegValue = sittingCurvingLeg(currentCourseCount);
            //健身车实际值
            int? exerciseBikeValue = exerciseBike(currentCourseCount);
            //椭圆跑步机实际值
            int? ellipticalTreadmillValue = ellipticalTreadmill(currentCourseCount);
            //坐式背阔肌高拉机实际值
            int? sittinglatissimusDorsiElevatorValue = sittinglatissimusDorsiElevator(currentCourseCount);
            //三头肌训练机实际值
            int? tricepsTrainingMachineValue = tricepsTrainingMachine(currentCourseCount);
            //腿部内弯机实际值
            int? legBenderValue = legBender(currentCourseCount);
            //腿部外弯机实际值
            int? legValue = leg(currentCourseCount);
            //蝴蝶机实际值
            int? butterflyMachineValue = butterflyMachine(currentCourseCount);
            //反向蝴蝶机实际值
            int? reverseButterflyMachineValue = reverseButterflyMachine(currentCourseCount);
            //坐式背部伸展机实际值
            int? sittingBackValue = sittingBack(currentCourseCount);
            //躯干扭转组合实际值
            int? trunkTorsionCombinationValue = trunkTorsionCombination(currentCourseCount);
            //腿部推蹬机实际值
            int? legPusherValue = legPusher(currentCourseCount);

            //坐式推胸肌赋值
            data1.Content = sittingChestPusherValue + "/" + targetValue;
            //坐式划船机赋值
            data2.Content = sittingRowerValue + "/" + targetValue;
            //坐式背部伸展机实际值
            data3.Content = sittingBackStretcherValue + "/" + targetValue;
            //腹肌训练机实际值 
            data4.Content = abdominalMuscleTrainingValue + "/" + targetValue;
            //坐式腿伸展训练机实际值
            data5.Content = sittingLegStretchingValue + "/" + targetValue;
            //坐式曲腿训练机实际值
            data6.Content = sittingCurvingLegValue + "/" + targetValue;
            //健身车实际值
            data7.Content = exerciseBikeValue + "/" + targetValue;
            //椭圆跑步机实际值
            data8.Content = ellipticalTreadmillValue + "/" + targetValue;
            //坐式背阔肌高拉机实际值 
            data9.Content = sittinglatissimusDorsiElevatorValue + "/" + targetValue;
            //三头肌训练机实际值
            data10.Content = tricepsTrainingMachineValue + "/" + targetValue;
            //腿部内弯机实际值
            data11.Content = legBenderValue + "/" + targetValue;
            //腿部外弯机实际值
            data12.Content = legValue + "/" + targetValue;
            //蝴蝶机实际值
            data13.Content = butterflyMachineValue + "/" + targetValue;
            //反向蝴蝶机实际值 
            data14.Content = reverseButterflyMachineValue + "/" + targetValue;
            //坐式背部伸展机实际值
            data15.Content = sittingBackValue + "/" + targetValue;
            //躯干扭转组合实际值
            data16.Content = trunkTorsionCombinationValue + "/" + targetValue;
            //腿部推蹬机实际值
            data17.Content = legPusherValue + "/" + targetValue;

            //图表
            Web.ObjectForScripting = new WebPie();
            Endurance.ObjectForScripting = new WebEndurancePie();
            //获取项目的根路径
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));

            Endurance.Navigate(new Uri(rootpath + "AISports.Echarts/dist/EndurancePie.html"));
            Web.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Pie.html"));

        }

        //力量耐力循环肌肉图
        MuscleService muscleService = new MuscleService();
       
        //坐式推胸肌实际值
        public int? sittingChestPusher(string currentCourseCount)
        {
            return muscleService.selectsittingChestPusher(currentCourseCount);
        }
        //坐式划船机实际值
        public int? sittingRower(string currentCourseCount)
        {
            return muscleService.selectSittingRower(currentCourseCount);
        }
        //坐式背部伸展机实际值
        public int? sittingBackStretcher(string currentCourseCount)
        {
            return muscleService.selectsittingBackStretcher(currentCourseCount);
        }
        //腹肌训练机实际值
        public int? abdominalMuscleTraining(string currentCourseCount)
        {
            return muscleService.selectAbdominalMuscleTraining(currentCourseCount);
        }
        //坐式腿伸展训练机实际值
        public int? sittingLegStretching(string currentCourseCount)
        {
            return muscleService.selectSittingLegStretching(currentCourseCount);
        }
        //坐式曲腿训练机实际值
        public int? sittingCurvingLeg(string currentCourseCount)
        {
            return muscleService.selectSittingCurvingLeg(currentCourseCount);
        }
        //健身车实际值
        public int? exerciseBike(string currentCourseCount)
        {
            return muscleService.selectExerciseBike(currentCourseCount);
        }
        //椭圆跑步机实际值
        public int? ellipticalTreadmill(string currentCourseCount)
        {
            return muscleService.selectEllipticalTreadmill(currentCourseCount);
        }
        //力量循环肌肉图

        //坐式背阔肌高拉机实际值
        public int? sittinglatissimusDorsiElevator(string currentCourseCount)
        {
            return muscleService.selectSittinglatissimusDorsiElevator(currentCourseCount);
        }
        //三头肌训练机实际值
        public int? tricepsTrainingMachine(string currentCourseCount)
        {
            return muscleService.selectTricepsTrainingMachine(currentCourseCount);
        }
        //腿部内弯机实际值
        public int? legBender(string currentCourseCount)
        {
            return muscleService.selectLegBender(currentCourseCount);
        }
        //腿部外弯机实际值
        public int? leg(string currentCourseCount)
        {
            return muscleService.selectLeg(currentCourseCount);
        }
        //蝴蝶机实际值
        public int? butterflyMachine(string currentCourseCount)
        {
            return muscleService.selectButterflyMachine(currentCourseCount);
        }
        //反向蝴蝶机实际值
        public int? reverseButterflyMachine(string currentCourseCount)
        {
            return muscleService.selectReversebutterflyMachine(currentCourseCount);
        }
        //坐式背部伸展机实际值
        public int? sittingBack(string currentCourseCount)
        {
            return muscleService.SittingBack(currentCourseCount);
        }
        //躯干扭转组合实际值
        public int? trunkTorsionCombination(string currentCourseCount)
        {
            return muscleService.selectTrunkTorsionCombination(currentCourseCount);
        }
        //腿部推蹬机实际值
        public int? legPusher(string currentCourseCount)
        {
            return muscleService.selectLegPusher(currentCourseCount);
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
        public int? abdomenTraining()
        {
            
            Console.WriteLine("肌肉饼图训练课程ID" + trainingCourseId);
            Console.WriteLine("成功:" + musclePieChartService.selectAbdomenTraining(trainingCourseId)); 
            return musclePieChartService.selectAbdomenTraining(trainingCourseId);
        }

        //力量循环胸部训练个数
        public int? chestTraining()
        {
            return musclePieChartService.selectchestTraining(trainingCourseId);
        }

        //力量循环腿部训练个数
        public int? legTraining()
        {
            return musclePieChartService.selectLegTraining(trainingCourseId);
        }

        //力量循环手臂训练个数
        public int? armTraining()
        {
            return musclePieChartService.selectArmTraining(trainingCourseId);
        }

        //力量循环躯干训练个数
        public int? trunkTraining()
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
        public int? chestEnduranceTraining()
        {
            return musclePieChartService.selectchestEnduranceTraining(trainingCourseId);
        }

        //力量耐力循环腿部训练个数
        public int? legEnduranceTraining()
        {
            return musclePieChartService.selectLegEnduranceTraining(trainingCourseId);
        }

        //力量耐力循环手臂训练个数
        public int? armEnduranceTraining()
        {
            return musclePieChartService.selectEnduranceArmTraining(trainingCourseId);
        }

        //力量耐力循环躯干训练个数
        public int? trunkEnduranceTraining()
        {
            return musclePieChartService.selectTrunkEnduranceTraining(trainingCourseId);
        }
    }


}
