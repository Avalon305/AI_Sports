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
            string photopath = "/AI_Sports;component/AISports.View/Images/photo.jpg";  //头像路径(这里可能会有很多问题)
            //string photopath = null;
            int sex = 1;                             //性别
            string member_familyName = "陈";         //member_familyName是数据库中姓氏的字段
            string address = "青岛市崂山区朱家洼村"; //住址
            string email_address = "10000000@qq.com";//邮箱地址
            string work_phone = "1000000001";        //工作电话
            string birth_date = "1995年12月6日";     //出生日期
            string mobile_phone = "1000000003";      //手机号码
            int weight = 80;                         //体重（kg）
            int height = 180;                        //身高 (cm)
            int max_heart_rate = 190;                //最大心率
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
            if (sex == 1)
            {
                this.familyName.Content = member_familyName + " 先生";
            }
            else
                if (sex == 0)
            {
                this.familyName.Content = member_familyName + " 女士";
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
