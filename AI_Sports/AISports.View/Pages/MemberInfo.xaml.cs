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
        MemberService memberService = new MemberService();


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
                //会员的训练目标数组，用英文逗号分隔
                String[] label_Name = memberEntity.Label_name.Split(',');
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
                //获得会员卡号 查询训练日期必须要求卡号不为空
                string memberId = CommUtil.GetSettingString("memberId");
                if (memberId != null && memberId != "")
                {
                    //如果卡号不为空 加载进度条以及进度信息
                    //查询训练课程
                    TrainingCourseEntity trainingCourse = trainingCourseService.GetCourseByMemberId();
                    double target = (double)trainingCourse.Target_course_count;
                    double current = (double)trainingCourse.Current_course_count;
                    // 例如10/32训练课程已完成
                    this.Jincheng.Content = current + "/" + target + " 训练课程已完成";

                    //进程百分比,整数
                    double jinchengJindu = current / target;
                    jinchengJindu = Math.Round(jinchengJindu * 100);

                    //例如30%，进程后的百分比数字
                    this.JinchengJindu.Content = jinchengJindu + "%"; 
                    //进度条进度设置
                    this.progressBar.Maximum = 100;
                    this.progressBar.Value = (double)jinchengJindu;

                    //初次训练日期
                    this.L2.Content = memberService.GetMinTrainingDate(memberId).ToString();
                    //上次最近训练日期
                    this.L3.Content = memberService.GetMaxTrainingDate(memberId).ToString();
                }



                //加载关联教练
                if (memberEntity.Fk_coach_id != null)
                {
                    MemberEntity coach = memberService.GetMemberByPk(memberEntity.Fk_coach_id);
                    this.L1.Content = coach.Member_familyName + coach.Member_firstName;
                }
                

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(memberEntity.Member_familyName);
                stringBuilder.Append(memberEntity.Member_firstName);
                //会员名字
                this.Name.Content = stringBuilder.ToString();
                //jiekou.addperson();
                //jiekou.addtype();


                //jiekou.addcard();  //这个不是很明白啥意思，应该是在这


                //创建线程
                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += (s, e) =>
                {

                    //修改UI线程中的对象

                    //如果卡号为空或者MTK没有点击确定按钮，就把 卡的形状隐藏 暴露出“用户在此需要进行身份验证”一行字

                    if (jiekou.card.Score1 == null || Window1.success_Flag == false)
                    {
                        x1.Visibility = Visibility.Visible;
                        x2.Visibility = Visibility.Collapsed;

                    }
                    else
                    if (Window1.success_Flag) //MTK中点击确定按钮后，success_Flag原本为false，变为true
                    {

                        x1.Visibility = Visibility.Collapsed;
                        x2.Visibility = Visibility.Visible;
                        this.x3.DataContext = jiekou.card;

                        //点击确定按钮就停止timer，维持卡片的状态显示卡号
                        timer.Stop();
                    }
                    //jiekou.addperson();//这个不是很明白啥意思，放的位置可能不对

                };

                timer.Start();
            }
            catch (Exception e)
            {

                throw e;
            }



        }



        //前往训练计划按钮
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/Training.xaml", UriKind.Relative));

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
            Customer customer = Window1.customer;

            //将卡号传给card.Scorel
            card.Score1 = Window1.customer.ID;

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
