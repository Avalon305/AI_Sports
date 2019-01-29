using System;
using System.Collections.Generic;
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
using System.IO;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// userinfo.xaml 的交互逻辑
    /// </summary>
    public partial class userinfo : Page
    {
        public userinfo()
        {
            InitializeComponent();
            /**
             * 以下为变量赋值，如果数据库中某一内容为null，就请赋值给对应变量为null
             **/
            string photopath = "/AI_Sports;component/AISports.View/Images/photo.png";  //头像路径(这里可能会有很多问题)
            //string photopath = null;
            //查询当前登陆会员
            MemberService memberService = new MemberService();
            //测试用户ID
            //CommUtil.UpdateSettingString("memberId","305865088");
            MemberEntity member = memberService.GetMember(CommUtil.GetSettingString("memberId"));

            string sex = member.Sex;                             //性别
            string member_familyName = member.Member_familyName;         //member_familyName是数据库中姓氏的字段
            string member_firstName = member.Member_firstName;
            string address = member.Address; //住址
            string email_address = member.Email_address;//邮箱地址
            string work_phone = member.Work_phone;        //工作电话
            string birth_date = member.Birth_date.ToString();     //出生日期
            string mobile_phone = member.Mobile_phone;      //手机号码
            double? weight = member.Weight;                         //体重（kg）
            double? height = member.Height;                        //身高 (cm)
            int? max_heart_rate = member.Max_heart_rate;                //最大心率
            string lastlogin = "2018年1月23日";       //上次登录时间

            if (lastlogin != null)
            {
                this.lastTime.Content += lastlogin;       //显示上次登录时间
            }
            else
                this.lastTime.Content += "尚未提供上次登录时间信息";

            /*
             * 如果路径存在就显示，不存在就显示另一张图片
             **/
            if (!File.Exists(photopath))
            {
                this.headphoto.Source = new BitmapImage(new Uri(@photopath, UriKind.Relative));
            }
            //Style myStyle = (Style)this.FindResource("{DynamicResource h4}");//TabItemStyle 这个样式是引用的资源文件中的样式名称
            //this.familyName.Style = Style;
            if ((member_familyName != null || member_familyName !="")&(member_firstName != null || member_firstName != ""))
            {
                this.familyName.Content = member_familyName + member_firstName;
            }
            else
                this.familyName.Content = "未登录";

            if (address != null)
            {
                this.addressInfo.Content = address;
            }

            if (weight != 0)
            {
                this.weightInfo.Content = this.weightInfo.Content + weight.ToString() + "kg";
            }
            else
                this.weightInfo.Content = "尚未提供体重信息";

            if (height != 0)
            {
                this.heightInfo.Content = this.heightInfo.Content + height.ToString() + "cm";
            }
            else
                this.heightInfo.Content = "尚未提供身高信息";

            if (max_heart_rate != 0)
            {
                this.heartRate.Content = this.heartRate.Content + max_heart_rate.ToString() + "次/分钟";
            }
            else
                this.heartRate.Content = "尚未获取最大心率信息";

            if (birth_date != null)
            {
                this.birthInfo.Content = birth_date;
            }

            if (email_address != null)
            {
                this.mailBox.Content += email_address;
            }
            else
                this.mailBox.Content = "尚未提供邮箱信息";

            if (work_phone != null)
            {
                this.workPhone.Content += work_phone;
            }
            else
                this.workPhone.Content = "尚未提供公司电话信息";



            if (mobile_phone != null)
            {
                this.phoneNumber.Content += mobile_phone;
            }
            else
                this.phoneNumber.Content = "尚未提供手机号码信息";
        }
    }
}
