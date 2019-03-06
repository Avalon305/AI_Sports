using AI_Sports.AISports.Service;
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
        MemberService memberService = new MemberService();
        TrainingDeviceRecordService trainingDeviceRecordService = new TrainingDeviceRecordService();
        public attendance()
        {


            InitializeComponent();
            this.LB_FirstDate.Content = memberService.GetMinTrainingDate(CommUtil.GetSettingString("memberId")).ToString();
            this.LB_LastDate.Content = memberService.GetMaxTrainingDate(CommUtil.GetSettingString("memberId")).ToString();

            string memberId = CommUtil.GetSettingString("memberId");

           
            //根据会员id查询出勤，加载到日历中
            if (memberId != null && memberId != "")
            {
                List<TrainingDeviceRecordEntity> trainingDeviceRecords =  trainingDeviceRecordService.ListRecordById(memberId);
                
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

                //Calendar_Attendance.SelectedDates.AddRange(new DateTime(2019,3,1),new DateTime(2019,3,6));
            }

           


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/analyze.xaml", UriKind.Relative));

        }
    }
}
