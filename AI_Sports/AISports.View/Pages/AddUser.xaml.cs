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
            sex.Text = "男";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            sex.Text = "女";
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
            int? inputCount = 0;
            StringBuilder stringBuilder = new StringBuilder();
            //判断输入的内容是否为空
            if (string.IsNullOrWhiteSpace(Member_familyName.Text))
            {
                stringBuilder.Append("姓氏");
                inputCount++;
            }
            if (string.IsNullOrWhiteSpace(Member_firstName.Text))
            {
                stringBuilder.Append("名字");

                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(birthDatePicker.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(Address.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(sex.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(Personal_phone.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(Mobile_phone.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(Work_phone.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(Email_address.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(weight.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(height.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(Max_heart_rate.Text))
            {
                inputCount++;

            }
            if (string.IsNullOrWhiteSpace(Remark.Text))
            {
                inputCount++;

            }

            //都不为空则添加
            if (inputCount ==0)
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
                //通过出生日期获得出生年份字符串
                string birthYear = member.Birth_date.Value.ToString("yyyy");
                //安全得将出生年份字符串转换为整型
                int? parseInt = ParseIntegerUtil.ParseInt(birthYear);
                //当前年份转为整型
                int? currentYear = ParseIntegerUtil.ParseInt(DateTime.Now.Year.ToString());
                //当前年份与出生年份相减计算年龄    
                member.Age = (currentYear - parseInt);
                member.Max_heart_rate = ParseIntegerUtil.ParseInt(this.Max_heart_rate.Text);
                member.Member_familyName = this.Member_familyName.Text;
                member.Member_firstName = this.Member_firstName.Text;
                member.Mobile_phone = this.Mobile_phone.Text;
                member.Personal_phone = this.Personal_phone.Text;
                member.Work_phone = this.Work_phone.Text;
                member.Remark = this.Remark.Text;
                member.Sex = sex.Text;
                //插入角色
                if ("会员".Equals(TB_Role.Text))
                {
                    member.Role_id = 1;
                }
                else if ("教练".Equals(TB_Role.Text))
                {
                    member.Role_id = 0;

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


                Console.WriteLine("录入会员信息：" + member.ToString());
                //插入会员
                long count = memberService.InsertMember(member);
                if (count > 0)
                {
                    Console.WriteLine("增加会员成功");
                }
                //跳转到会员信息页面
                NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/MemberInfo.xaml", UriKind.Relative));
            }
            else
            {
                  //弹出提示框
            }





        }
        //手机号码和电话号码只能输入数字
        private void Personal_phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.\\-]+");
            e.Handled = regex.IsMatch(e.Text);

        }
        //验证邮箱格式
        private void Email_address_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //string emailStr =@"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
            //Regex emailReg = new Regex(emailStr);
            //if (emailReg.IsMatch(Email_address.Text.Trim()))
            //{
            //    Console.WriteLine("格式正确");

            //}
            //else
            //{
            //    Console.WriteLine("格式错误，请重新输入");
            //}
            Regex r = new Regex(@"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+");
            e.Handled = r.IsMatch(e.Text);

            //if (r.IsMatch(jieta@sina.com))
            //{
            //    MessageBox.Show("This is a true email");
            //}
            //else
            //{
            //    MessageBox.Show("This is not a email");
            //}
        }

       
        /// <summary>
        /// 选择日期改变时触发计算建议最大心率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.birthDatePicker.Text != null && this.birthDatePicker.Text != "")
            {
                DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
                dtFormat.ShortDatePattern = "yyyy-MM-dd";
                DateTime Birth_date = Convert.ToDateTime(this.birthDatePicker.Text, dtFormat);
                //通过出生日期获得出生年份字符串
                string birthYear = Birth_date.ToString("yyyy");
                //安全得将出生年份字符串转换为整型
                int? parseInt = ParseIntegerUtil.ParseInt(birthYear);
                //当前年份转为整型
                int? currentYear = DateTime.Now.Year;
                //当前年份与出生年份相减计算年龄    
                int? Age = (currentYear - parseInt);
                this.LB_SuggestMaxHeartRate.Content = "建议最大心率:" + (220-Age).ToString();
            }
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 角色：会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            TB_Role.Text = "会员";
        }
        /// <summary>
        /// 角色：教练
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            TB_Role.Text = "教练";
        }
    }
}