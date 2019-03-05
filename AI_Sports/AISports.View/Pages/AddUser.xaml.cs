using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// info.xaml 的交互逻辑
    /// </summary>
    public partial class AddUser : Page
    {
        private MemberService memberService = new MemberService();

        public AddUser()
        {
            // var temp = this.tb1.Text;
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //性别判断
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sex.Text = "先生";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            sex.Text = "女士";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("保存成功");
        }

        //非法日期的判断
        private void DatePicker_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
        {
            MessageBox.Show(e.Text + "非法日期" + e.Exception.Message);
        }
        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("取消");
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("已取消");

        }
        /// <summary>
        /// 时间选择时的绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.Birth_date.Text = this.birthDatePicker.Text;
            Console.WriteLine("");
        }
        /// <summary>
        /// 点击保存按钮，保存用户，跳转到MemberInfo页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            MemberEntity member = new MemberEntity();
            member.Address = this.Address.Text;
            //时间转化
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            member.Birth_date = Convert.ToDateTime(this.birthDatePicker.Text, dtFormat);
            member.Email_address = this.Email_address.Text;
            
            member.Height = double.Parse(this.height.Text);
            member.Weight = double.Parse(this.weight.Text);
            
            member.Max_heart_rate = ParseIntegerUtil.ParseInt(this.Max_heart_rate.Text);
            member.Member_familyName = this.Member_familyName.Text;
            member.Member_firstName = this.Member_firstName.Text;
            member.Mobile_phone = this.Mobile_phone.Text;
            member.Personal_phone = this.Personal_phone.Text;
            member.Work_phone = this.Work_phone.Text;
            member.Remark = this.Remark.Text;
            member.Role_id = 1;
            if ("先生".Equals(this.sex.Text))
            {
                member.Sex = "男";
            }
            else
            {
                member.Sex = "女";
            }
            //添加会员标签 用英文逗号分隔
            StringBuilder lableBuilder = new StringBuilder();
            if (this.CB_Zengji.IsChecked == true)
            {
                lableBuilder.Append("增肌,");
            }
            if (this.CB_Jianzhi.IsChecked == true)
            {
                lableBuilder.Append("减脂,");
            }
            if (this.CB_Suxing.IsChecked == true)
            {
                lableBuilder.Append("塑形,");
            }
            if (this.CB_Kangfu.IsChecked == true)
            {
                lableBuilder.Append("康复,");
            }
            member.Label_name = lableBuilder.ToString();


            Console.WriteLine("录入会员信息："+member.ToString());
            //插入会员
            long count = memberService.InsertMember(member);
            if (count > 0)
            {
                Console.WriteLine("增加会员成功");
            }
            //跳转到会员信息页面
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/MemberInfo.xaml", UriKind.Relative));



        }
        public class Person1
        {
            public string Name { get; set; }
        }
        //TextBox中只能输入数字
        private void Tb3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.\\-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Max_rate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        //根据出生年月日计算出年龄
        public int GetAgeByBirthdate(DateTime birthdate)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - birthdate.Year;
            if (now.Month < birthdate.Month || (now.Month == birthdate.Month && now.Day < birthdate.Day))
            {
                age--;
            }
            return age < 0 ? 0 : age;
        }
        //获得数据参数
        class Person
        {
            public string Name { get; set; }
        }

       

        //private void Slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    GetAgeByBirthdate;

        //}
        //     private void Grid1_Loaded(object sender, RoutedEventArgs e)
        //{
        //     Grid1.DataContext = getpersonfromdeatabase();
        //}
        // private Person GetPersonFromDateBase()
        // {
        //     //从数据库获得数据对象《演示》
        //     return new Person() (Name = "JRH");

        // }
    }
}