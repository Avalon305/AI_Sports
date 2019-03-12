using AI_Sports.AISports.Service;
using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using Calendar = System.Windows.Controls.Calendar;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// attendance.xaml 的交互逻辑
    /// </summary>
    public partial class attendance : Page
    {
        TrainingDeviceRecordService trainingDeviceRecordService = new TrainingDeviceRecordService();
        TrainingCourseService courseService = new TrainingCourseService();
        MemberService memberService = new MemberService();
        public attendance()
        {


            InitializeComponent();
            //初次训练日期
            this.LB_FirstDate.Content = trainingDeviceRecordService.GetMinTrainingDate(CommUtil.GetSettingString("memberId")).ToString();
            //上次训练日期
            this.LB_LastDate.Content = trainingDeviceRecordService.GetMaxTrainingDate(CommUtil.GetSettingString("memberId")).ToString();



            string memberId = CommUtil.GetSettingString("memberId");


            //根据会员id查询出勤，加载到日历中
            if (memberId != null && memberId != "")
            {
                //查询出当前用户所有训练记录
                List<TrainingDeviceRecordEntity> trainingDeviceRecords = trainingDeviceRecordService.ListRecordById(memberId);

                if (trainingDeviceRecords != null)
                {
                    //加载总训练天数
                    this.LB_AllDayCount.Content = trainingDeviceRecords.Count();

                    //循环加载日历出勤日期，往日历中循环添加出勤记录集合中的日期
                    foreach (var item in trainingDeviceRecords)
                    {
                        DateTime date = item.Gmt_create.Value;
                        int year = date.Year;
                        int month = date.Month;
                        int day = date.Day;

                        Console.WriteLine("时间:" + date);
                        //DateTime date = item.Gmt_create.Value;
                        Calendar_Attendance.SelectedDates.Add(new DateTime(year, month, day));

                    }
                }

                //查询当前月训练记录
                List<TrainingDeviceRecordEntity> currentMonthRecord = trainingDeviceRecordService.ListCurrentMonthRecordById(memberId);
                if (currentMonthRecord != null)
                {
                    //前端加载本月训练天数
                    this.LB_CurrentMonthDayCount.Content = currentMonthRecord.Count();
                }



                //Calendar_Attendance.SelectedDates.AddRange(new DateTime(2019,3,1),new DateTime(2019,3,6));
            }




        }
        /// <summary>
        /// 后退按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/analyze.xaml", UriKind.Relative));

        }
        /// <summary>
        /// 语音分析按钮，只分析当前月的 非常直白的数据就不分析了 分析合理的训练间隔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speech_Click(object sender, RoutedEventArgs e)
        {
            //初始化语音文本
            StringBuilder speechBuilder = new StringBuilder();


            string memberId = CommUtil.GetSettingString("memberId");

            //查询当前月训练记录
            List<TrainingDeviceRecordEntity> currentMonthRecord = trainingDeviceRecordService.ListCurrentMonthRecordById(memberId);
            if (currentMonthRecord != null)
            {
                //前端加载本月训练天数
                speechBuilder.Append("您本月共出勤训练");
                speechBuilder.Append(currentMonthRecord.Count);
                speechBuilder.Append("天。");

            }
            //查询训练间隔
            TrainingCourseEntity trainingCourseEntity = courseService.GetCourseByMemberId();
            if (trainingCourseEntity != null)
            {

                speechBuilder.Append("您的训练频率为每");
                speechBuilder.Append(trainingCourseEntity.Rest_days);
                speechBuilder.Append("天一次，每月至少出勤训练");
                speechBuilder.Append(30 / trainingCourseEntity.Rest_days);
                speechBuilder.Append("天才能完成目标。当前课程开始日期为");
                speechBuilder.Append(trainingCourseEntity.Start_date.Value.Year);
                speechBuilder.Append("年");
                speechBuilder.Append(trainingCourseEntity.Start_date.Value.Month);
                speechBuilder.Append("月");
                speechBuilder.Append(trainingCourseEntity.Start_date.Value.Day);
                speechBuilder.Append("日,");
                speechBuilder.Append("根据您当前进度分析出预计结束日期为");
                //如果当前预计结束日期不为空，则使用当前预计结束日期 否则使用end_date
                if (trainingCourseEntity.Current_end_date != null)
                {
                    speechBuilder.Append(trainingCourseEntity.Current_end_date.Value.Year);
                    speechBuilder.Append("年");
                    speechBuilder.Append(trainingCourseEntity.Current_end_date.Value.Month);
                    speechBuilder.Append("月");
                    speechBuilder.Append(trainingCourseEntity.Current_end_date.Value.Day);
                    speechBuilder.Append("日");
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
            }
            //根据训练目标分析训练间隔时间建议
            MemberEntity memberEntity = new MemberEntity();
            if (memberEntity != null)
            {
                //会员的训练目标数组，用英文逗号分隔
                string[] label_Name = memberEntity.Label_name.Split(',');
                //使用lambda表达式过滤掉空字符串
                label_Name = label_Name.Where(s => !string.IsNullOrEmpty(s)).ToArray();

                //训练标签分析 注意此处别用else if 因为标签是多选，用else if那样只会添加一种文本
                if (label_Name != null && label_Name.Length > 0)
                {
                    speechBuilder.Append("您的训练目标为");
                    speechBuilder.Append(label_Name.ToString());
                    speechBuilder.Append(",智能教练建议您，");

                    if (label_Name.Contains("增肌"))
                    {
                        speechBuilder.Append("增肌训练每周锻炼三到五次，建议采用隔天锻炼，也可以采用锻炼两天或三天休息一天的模式。休息是为了让锻炼的肌肉得到恢复，从而更好得增长。");

                    }

                    if (label_Name.Contains("塑形"))
                    {
                        speechBuilder.Append("塑形训练每周至少锻炼3次，注意每次侧重锻炼不同部位的肌肉，给肌肉充分的休息成长时间，使全身各个肌肉群均衡发展，塑造紧致健美身材。");

                    }

                    if (label_Name.Contains("减脂"))
                    {
                        speechBuilder.Append("减脂训练每周至少锻炼3次，最好天天进行有氧锻炼，训练次数越多，消耗的热量也就越多，减脂效果也就越好。");

                    }

                    if (label_Name.Contains("康复"))
                    {
                        speechBuilder.Append("康复训练每周锻炼3次，采用隔天锻炼。可以使用力量循环与量耐力循环，采用力量训练和有氧训练相结合的方式进行。建议使用设备上的专业康复训练模式：等速模式、被动模式、主被动模式，可以达到更加安全高效的康复训练效果。");

                    }

                }
                Console.WriteLine("出勤页面语音文本："+speechBuilder.ToString());

                //调用API读
                SpeechUtil.read(speechBuilder.ToString());
            }
        }
    }
}
