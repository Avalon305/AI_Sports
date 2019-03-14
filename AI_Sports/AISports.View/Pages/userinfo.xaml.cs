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
using AI_Sports.AISports.Util;
using System.ComponentModel;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// userinfo.xaml 的交互逻辑
    /// </summary>
    public partial class userinfo : Page
    {
        //用于语音分析的参数
        double? weight = new double?();
        double? height = new double?();
        int? max_heart_rate = new int?();
        int? suitable_heart_rate = new int?();
        //语音分析的后台任务 不用后台任务则界面卡死 无法进行其他操作
        private BackgroundWorker worker = new BackgroundWorker();
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
            if (member != null)
            {
                string sex = member.Sex;                             //性别
                string member_familyName = member.Member_familyName;         //member_familyName是数据库中姓氏的字段
                string member_firstName = member.Member_firstName;
                string address = member.Address; //住址
                string email_address = member.Email_address;//邮箱地址
                string work_phone = member.Work_phone;        //工作电话
                string birth_date = member.Birth_date.ToString();     //出生日期
                string mobile_phone = member.Mobile_phone;      //手机号码
                weight = member.Weight;                         //体重（kg）
                height = member.Height;                        //身高 (cm)
                max_heart_rate = member.Max_heart_rate;                //最大心率
                suitable_heart_rate = member.Suitable_heart_rate;//最宜心率
                this.suitableHeartRate.Content += suitable_heart_rate.ToString() + "次/分钟";//最宜心率
                string lastlogin = member.Last_login_date.Value.ToString("yyyy年MM月dd日 HH:mm");       //上次登录时间

                if (lastlogin != null)
                {
                    this.lastTime.Content += lastlogin;       //显示上次登录时间
                }
                else
                    this.lastTime.Content += "无上次登录时间信息";

                /*
                 * 如果路径存在就显示，不存在就显示另一张图片
                 **/
                if (!File.Exists(photopath))
                {
                    this.headphoto.Source = new BitmapImage(new Uri(@photopath, UriKind.Relative));
                }
                //Style myStyle = (Style)this.FindResource("{DynamicResource h4}");//TabItemStyle 这个样式是引用的资源文件中的样式名称
                //this.familyName.Style = Style;
                if ((member_familyName != null || member_familyName != "") & (member_firstName != null || member_firstName != ""))
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
              


                if (weight != null && height != null)
                {
                    //计算BMI指数
                    double? bmiValue = Math.Round(((weight.Value / (height.Value * height.Value)) * 10000), 1);
                    StringBuilder speechBuilder = new StringBuilder();
                    speechBuilder.Append("尊敬的会员您好，您的身高为");
                    speechBuilder.Append(height);
                    speechBuilder.Append("厘米，体重维");
                    speechBuilder.Append(weight);
                    speechBuilder.Append("千克。智能教练计算出您的身体质量指数为：");
                    speechBuilder.Append(bmiValue);
                    if (bmiValue <= 18.5)//偏瘦
                    {
                        speechBuilder.Append("，您的体型偏瘦，体重过轻，建议您初级课程使用力量循环加强肌肉锻炼，高级课程使用设备的增肌模式进一步强化肌肉。智能教练建议您在增肌训练过程中增加蛋白质、碳水化合物、维生素的摄入，比如牛肉、鸡胸肉、牛奶、燕麦、菠菜、苹果等食物。增加力量训练并及时补充营养，坚持不懈才能达到良好的增肌增重效果。");

                    }
                    else if (bmiValue > 18.5 && bmiValue <= 23.9)//标准
                    {
                        speechBuilder.Append("，您的体重属于中国体质标准正常范围。建议您的训练计划以增肌、塑形为主，建议训练活动选择力量循环与力量耐力循环，有氧运动与无氧运动相结合，从而进一步降低体脂，增加肌肉，塑造健美身材。");

                    }
                    else if (bmiValue >= 24.0 && bmiValue <= 27.9)//超重
                    {
                        speechBuilder.Append("，您的体重稍微超过中国体质标准正常范围，建议您的训练计划以增肌、减脂为主，建议开启减脂模式，增加力量耐力循环的训练，通过高强度力量训练与有氧训练交替进行，可以在短时间内达到超高的能量消耗效果，并且让身体在训练后也继续保持燃脂状态，达到优秀的减脂效果。");

                    }
                    else if (bmiValue >= 28.0 && bmiValue < 30)//轻度肥胖
                    {
                        speechBuilder.Append("，属于轻度肥胖，建议您的训练计划以减脂为主，建议开启减脂模式，增加力量耐力循环的训练，通过高强度力量训练与有氧训练交替进行，可以在短时间内达到超高的能量消耗效果，并且让身体在训练后也继续保持燃脂状态，达到优秀的减脂效果。建议您在减脂过程中少吃油腻食物，多吃水果蔬菜，保持饮食清淡、营养均衡。");

                    }
                    else if (bmiValue >= 30 && bmiValue < 35)//中度肥胖
                    {
                        speechBuilder.Append("，属于中度肥胖，建议您的训练计划以减脂为主，建议开启减脂模式，减脂模式会结合力量耐力循环，智能指导您充分使用有氧设备，辅助使用力量设备进行训练，每次训练包括全身唤醒、心肺改善、强化燃脂三个阶段。根据全身燃动理论，通过高强度力量训练与有氧训练交替进行，可以在短时间内达到超高的能量消耗效果，并且让身体在训练后也继续保持燃脂状态，达到优秀的减脂效果。建议您在减脂过程中少吃油腻食物，多吃水果蔬菜，保持饮食清淡、营养均衡。");
                    }
                    else if (bmiValue >= 35)//重度肥胖
                    {
                        speechBuilder.Append("，属于重度肥胖，建议您的训练计划以减脂为主，建议开启减脂模式，减脂模式会结合力量耐力循环，智能指导您充分使用有氧设备，辅助使用力量设备进行训练，每次训练包括全身唤醒、心肺改善、强化燃脂三个阶段。根据全身燃动理论，通过高强度力量训练与有氧训练交替进行，可以在短时间内达到超高的能量消耗效果，并且让身体在训练后也继续保持燃脂状态，达到优秀的减脂效果。建议您在减脂过程中少吃油腻食物，多吃水果蔬菜，保持饮食清淡、营养均衡。");

                    }
                    speechBuilder.Append("根据您的年龄、身高、体重、历史运动数据，智能计算得出您的最大心率为");
                    speechBuilder.Append(max_heart_rate);
                    speechBuilder.Append(",最适宜心率为");
                    speechBuilder.Append(suitable_heart_rate);
                    speechBuilder.Append(",建议您在运动过程中的心率不要超过最大心率");
                    //speechBuilder.Append(max_heart_rate);
                    speechBuilder.Append("，避免受伤，建议将心率保持在最宜心率");
                    speechBuilder.Append(suitable_heart_rate);
                    speechBuilder.Append("左右，可以保持较高的燃脂效率，并且受伤风险较低，运动后身体不会感觉过于疲劳，让您运动得更安全、更有效、更健康。");

                    Console.WriteLine("用户页面userInfo语音文本：" + speechBuilder.ToString());


                    //调用Util读
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
}
