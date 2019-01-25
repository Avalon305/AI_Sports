using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
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

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// CQZTest.xaml 的交互逻辑
    /// </summary>
    public partial class CQZTest : Page
    {
        public CQZTest()
        {
            InitializeComponent();
        }


        private MemberService memberService = new MemberService();

        private TrainingPlanService trainingPlanService = new TrainingPlanService();

        private void addUser(object sender, RoutedEventArgs e)
        {
            MemberEntity member = new MemberEntity();
            member.Address = "山东青岛";
            DateTime date = new DateTime(1998, 4, 5);
            member.Birth_date = date;
            member.Member_id = "20190114";
            member.Role_id = 1;
            member.Member_firstName = "Avalon";
            member.Member_familyName = "Saber";
            member.Sex = "1";

            int count = memberService.InsertMember(member);
            if (count > 0)
            {
                Console.WriteLine("增加会员成功");
            }
        }
        /// <summary>
        /// 删除原训练计划测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTrainPlan(object sender, RoutedEventArgs e)
        {
            //MemberEntity member = new MemberEntity();
            //member.Member_id = "123";
            //int? count = trainingPlanService.DeletePlanByMemberId(member);
            //if (count > 0)
            //{
            //    Console.WriteLine("删除原训练计划成功");
            //}

        }
        /// <summary>
        /// 1.该方法可用于刷卡后，传入卡号和角色id更新App.config。然后调用登陆读取App.config的appSettings
        /// 2.可用于退出时，传入两个空字符串更新缓存设置
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="roleId"></param>
        private void updateSetting(string memberId, string roleId)
        {
            //1.更新会员卡ID
            CommUtil.UpdateSettingString("memberId", memberId);
            //2.更新角色ID
            CommUtil.UpdateSettingString("roleId", roleId);
        }

        /// <summary>
        /// 刷完卡后，调用的登陆方法。读取App.config里的会员ID,根据角色跳转不同的页面。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memberLogin(object sender, RoutedEventArgs e)
        {
            //1.获得登录会员的会员id与权限
            string memberId = CommUtil.GetSettingString("memberId");
            ///string roleId = CommUtil.GetSettingString("roleId");
            Console.WriteLine("memberId:{0}", memberId);
            //2.根据卡号查询用户详细信息
            MemberEntity member = memberService.GetMember(memberId);
            //如果能查到用户信息，不为null。则登陆
            if (member != null)
            {
                //3.根据权限跳转不同的页面
                //如果是会员登陆，跳转会员首页
                if (member.Role_id == 1)
                {
                    //成功登陆，跳转
                    //MainPage mainpage = new MainPage();
                    //this.Content = mainpage;
                }
                //如果教练登陆，跳转教练首页
                else if (member.Role_id == 0)
                {
                    //成功登陆，跳转
                    //MainPage mainpage = new MainPage();
                    //this.Content = mainpage;
                }
            }
            else
            {
                Console.WriteLine("无效卡！");
            }

        }
        /// <summary>
        /// 设置会员id和角色id测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateSetting(object sender, RoutedEventArgs e)
        {
            updateSetting("123456789", "1");
        }
    }
}
