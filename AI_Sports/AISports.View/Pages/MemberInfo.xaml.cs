using AI_Sports.AISports.Service;
using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
/*
*这一块是从当前状态页面复制过来的，我注释掉了，你加上就可以 
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;*/

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// MemberInfo.xaml 的交互逻辑
    /// </summary>

    public partial class MemberInfo : Page
    {
        private jieMain jiekou = new jieMain();

        TrainingCourseService trainingCourseService = new TrainingCourseService();
        TrainingDeviceRecordService trainingDeviceRecordService = new TrainingDeviceRecordService();

        MemberService memberService = new MemberService();
        //语音分析用 进度条进度数字
        private double jinchengJindu = 0;
        //训练目的标签数组
        private String[] label_Name = { };

        //语音分析的后台任务
        private BackgroundWorker worker = new BackgroundWorker();

        public MemberInfo()
        {


            InitializeComponent();

            try
            {
                x1.Visibility = Visibility.Visible;
                x2.Visibility = Visibility.Collapsed;

                String image_Path = "/AI_Sports;component/AISports.View/Images/photo.png";
                if (!File.Exists(image_Path))
                {
                    this.headphoto.Source = new BitmapImage(new Uri(@image_Path, UriKind.Relative));
                }

                //查询登陆会员信息 显示会员的目标属性小方块图形 ByCQZ
                MemberEntity memberEntity = memberService.InitMemberInfo();
                if (memberEntity != null)
                {
                    //添加标签
                    if (memberEntity.Label_name != null && memberEntity.Label_name != "")
                    {
                        //会员的训练目标数组，用英文逗号分隔
                        label_Name = memberEntity.Label_name.Split(',');
                        //使用lambda表达式过滤掉空字符串
                        label_Name = label_Name.Where(s => !string.IsNullOrEmpty(s)).ToArray();

                        //String[] label_Name = { "增肌", "减脂", "塑性", "康复", "美容", "美发", "挖掘机", "水电焊" };//这个是接口,把字符串数组里面的所有的标签名字都给显示出来


                        String[] border_Color = { "Yellow", "Red", "Blue", "Green", "DarkTurquoise", "LightSeaGreen", "Teal", "RoyalBlue", "Orange", "Aqua", "Gray", "Cyan", "Lime" };//这是border的几种颜色


                        //遍历字符串数组，添加标签UI
                        for (int i = 0; i < label_Name.Length; i++)
                        {

                            //Border的属性设置
                            Border border = new Border();
                            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(border_Color[i]));
                            border.CornerRadius = new CornerRadius(3);
                            border.Width = 10;
                            border.Height = 10;
                            border.Margin = new Thickness(10, 0, 5, 0);


                            //Label的属性设置
                            Label label = new Label();
                            label.Width = 150;
                            label.Height = 50;
                            label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#04243D"));
                            label.Style = (Style)Resources["{DynamicResource h3}"];
                            label.Content = label_Name[i];
                            label.Name = "runtime" + Convert.ToString(i + 1);
                            label.VerticalAlignment = VerticalAlignment.Center;
                            label.FontFamily = new FontFamily("Microsoft YaHei");
                            label.FontSize = 22;

                            //在stackpanel位置增加Border和label
                            this.stackPanel1.Children.Add(border);
                            this.stackPanel1.Children.Add(label);

                        }
                    }
                   
                    //获得会员卡号 查询训练日期必须要求卡号不为空
                    string memberId = CommUtil.GetSettingString("memberId");

                    //在界面加载memeberId
                    this.Lab_memberId.Content = memberId;
                    //如果训练课程不为空 加载进度条以及进度信息
                    //查询训练课程
                    TrainingCourseEntity trainingCourse = trainingCourseService.GetCourseByMemberId();
                    if (trainingCourse != null)
                    {
                        
                        double target = (double)trainingCourse.Target_course_count;
                        double current = (double)trainingCourse.Current_course_count;
                        // 例如10/32训练课程已完成
                        this.Jincheng.Content = current + "/" + target + " 训练课程已完成";

                        //进程百分比,整数
                        jinchengJindu = current / target;
                        jinchengJindu = Math.Round(jinchengJindu * 100);

                        //例如30%，进程后的百分比数字
                        this.JinchengJindu.Content = jinchengJindu + "%";
                        //进度条进度设置
                        this.progressBar.Maximum = 100;
                        this.progressBar.Value = (double)jinchengJindu;

                        //初次训练日期
                        DateTime? firstTrainDate = trainingDeviceRecordService.GetMinTrainingDate(memberId);
                        if (firstTrainDate != null)
                        {
                            this.L2.Content = firstTrainDate.ToString();

                        }
                        //上次最近训练日期
                        DateTime? leastTrainDate = trainingDeviceRecordService.GetMaxTrainingDate(memberId);
                        if (leastTrainDate != null)
                        {
                            this.L3.Content = leastTrainDate.ToString();

                        }
                    }



                    //加载关联教练
                    if (memberEntity.Fk_coach_id != null)
                    {
                       
                        MemberEntity coach = memberService.GetMemberByPk(memberEntity.Fk_coach_id);
                        this.L1.Content = coach.Member_familyName + coach.Member_firstName;
                    }
                    else
                    {
                        //无关联教练 使关联教练属性隐藏
                        this.AssociateCoach.Visibility = Visibility.Hidden;
                    }


                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(memberEntity.Member_familyName);
                    stringBuilder.Append(memberEntity.Member_firstName);
                    //会员名字
                    this.Name.Content = stringBuilder.ToString();


                    //jiekou.addcard();  //这个不是很明白啥意思，应该是在这


                }

                //创建线程
                //DispatcherTimer timer = new DispatcherTimer();
                //timer.Tick += (s, e) =>
                //{

                //    //修改UI线程中的对象

                //    //如果卡号为空或者MTK没有点击确定按钮，就把 卡的形状隐藏 暴露出“用户在此需要进行身份验证”一行字

                //    if (jiekou.card.Score1 == null || WriteCardWindow.success_Flag == false)
                //    {
                //        x1.Visibility = Visibility.Visible;
                //        x2.Visibility = Visibility.Collapsed;

                //    }
                //    else
                //    if (WriteCardWindow.success_Flag) //MTK中点击确定按钮后，success_Flag原本为false，变为true
                //    {

                //        x1.Visibility = Visibility.Collapsed;
                //        x2.Visibility = Visibility.Visible;
                //        this.x3.DataContext = jiekou.card;

                //        //点击确定按钮就停止timer，维持卡片的状态显示卡号
                //        timer.Stop();
                //    }
                //    //jiekou.addperson();//这个不是很明白啥意思，放的位置可能不对

                //};

                //timer.Start();
            }
            catch (Exception ex)
            {
                
                throw new Exception("MemberInfo页面初始化加载数据异常",ex);
            }



        }



        //前往训练计划按钮
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/TrainingProgram.xaml", UriKind.Relative));

        }
        /// <summary>
        /// 语音分析按钮
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
                //WPF中线程只能控制自己创建的控件，
                //如果要修改主线程创建的MainWindow界面的内容,
                //可以委托主线程的Dispatcher处理。
                //在这里，委托内容为一个匿名的Action对象。
                //this.Dispatcher.Invoke((Action)(() =>
                //{
                //    this.TextBox1.Text = "worker started";
                //}));
                //Thread.Sleep(1000);


                TrainingCourseEntity trainingCourseEntity = trainingCourseService.GetCourseByMemberId();
                if (trainingCourseEntity != null)
                {
                    StringBuilder speechBuilder = new StringBuilder();
                    speechBuilder.Append("您当前训练课程共");
                    speechBuilder.Append(trainingCourseEntity.Target_course_count);
                    speechBuilder.Append("课时，现在已完成");
                    speechBuilder.Append(trainingCourseEntity.Current_course_count);
                    speechBuilder.Append("课时，占总进度的百分之");
                    speechBuilder.Append(jinchengJindu);

                    speechBuilder.Append("。您的训练频率为每");
                    speechBuilder.Append(trainingCourseEntity.Rest_days);
                    speechBuilder.Append("天一次。当前课程开始日期为");
                    speechBuilder.Append(trainingCourseEntity.Start_date.Value.Year);
                    speechBuilder.Append("年");
                    speechBuilder.Append(trainingCourseEntity.Start_date.Value.Month);
                    speechBuilder.Append("月");
                    speechBuilder.Append(trainingCourseEntity.Start_date.Value.Day);
                    speechBuilder.Append("日,");
                    speechBuilder.Append("根据您当前进度预计结束日期为");
                    //如果当前预计结束日期不为空，则使用当前预计结束日期 否则使用end_date
                    if (trainingCourseEntity.Current_end_date != null)
                    {
                        speechBuilder.Append(trainingCourseEntity.Current_end_date.Value.Year);
                        speechBuilder.Append("年");
                        speechBuilder.Append(trainingCourseEntity.Current_end_date.Value.Month);
                        speechBuilder.Append("月");
                        speechBuilder.Append(trainingCourseEntity.Current_end_date.Value.Day);
                        speechBuilder.Append("日。");
                    }
                    else
                    {
                        speechBuilder.Append(trainingCourseEntity.End_date.Value.Year);
                        speechBuilder.Append("年");
                        speechBuilder.Append(trainingCourseEntity.End_date.Value.Month);
                        speechBuilder.Append("月");
                        speechBuilder.Append(trainingCourseEntity.End_date.Value.Day);
                        speechBuilder.Append("日。");
                    }

                    //训练标签分析 注意此处别用else if 因为标签是多选，用else if那样只会添加一种文本
                    if (label_Name != null && label_Name.Length > 0)
                    {
                        speechBuilder.Append("您的训练目标为");
                        speechBuilder.Append(string.Join("，", label_Name));
                        speechBuilder.Append(",智能教练建议您使用");

                        if (label_Name.Contains("增肌"))
                        {
                            speechBuilder.Append("增肌模式、");

                        }
                        if (label_Name.Contains("塑形"))
                        {
                            speechBuilder.Append("适应性模式、");

                        }
                        if (label_Name.Contains("减脂"))
                        {
                            speechBuilder.Append("减脂模式、");

                        }
                        if (label_Name.Contains("康复"))
                        {
                            speechBuilder.Append("等速模式、被动模式、主被动模式");

                        }
                        speechBuilder.Append("进行训练。");

                        //各个模式的特点说明
                        if (label_Name.Contains("增肌"))
                        {
                            speechBuilder.Append("增肌模式会根据您的力量智能增加训练强度，充分刺激六大肌群每一块肌肉，塑造健康饱满身材。");

                        }
                        if (label_Name.Contains("塑形"))
                        {
                            speechBuilder.Append("适应性模式会根据您的体力情况智能调节训练强度，对全身主要肌群进行锻炼以达到塑形效果，使全身肌肉线条更加匀称美观，塑造紧致健美身材。");

                        }
                        if (label_Name.Contains("减脂"))
                        {
                            speechBuilder.Append("减脂模式会结合力量耐力循环，智能指导您充分使用有氧设备，辅助使用力量设备进行训练，每次训练包括全身唤醒、心肺改善、强化燃脂三个阶段。根据全身燃动理论，通过高强度力量训练与有氧训练交替进行，可以在短时间内达到超高的能量消耗效果，并且让身体在训练后也继续保持燃脂状态，达到优秀的减脂效果。");

                        }
                        if (label_Name.Contains("康复"))
                        {
                            speechBuilder.Append("等速模式会根据您的每次发力智能调节设备力度，在安全稳定的前提下最大程度使肌肉得到充分锻炼。被动模式维康复初级模式，设备会平缓得带动您完成每一次运动，使肌肉充分伸展、刺激恢复。主被动模式维康复进阶模式，您可以主动发力控制设备运动，设备也可以随时自动切换到被动模式辅助您完成运动，进行安全高效的康复训练。");

                        }

                    }
                    Console.WriteLine("MemberInfo页面语音文本：" + speechBuilder.ToString());
                    //调用工具类读
                    SpeechUtil.read(speechBuilder.ToString());

                }


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

    class jieMain
    {
        public person person;
        public type type;
        public Card card;
        public jieMain()
        {
            person = new person();

            type = new type();
            card = new Card();
        }
        public void addperson()
        {
            person.Coach = "123";
            person.FirstTime = "1-1";
            person.LastTime = "1-10";
            person.Name = "陈 先生";
        }


        public void addtype()
        {
            type.a1 = true;
            type.a2 = true;
            type.a3 = true;
            type.a4 = true;
        }


        public void addcard()
        {


            //从MTK页面传过来已经赋好值customer类
            Customer customer = WriteCardWindow.customer;

            //将卡号传给card.Scorel
            card.Score1 = WriteCardWindow.customer.ID;

        }

    }

    public class Card
    {
        public string Score1 { get; set; }

    }
    public class type
    {
        public bool a1 { get; set; }
        public bool a2 { get; set; }
        public bool a3 { get; set; }
        public bool a4 { get; set; }
    }

    class person
    {

        public string Name { get; set; }
        public string Coach { get; set; }
        public string FirstTime { get; set; }
        public string LastTime { get; set; }


    }






}
