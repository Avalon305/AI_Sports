using AI_Sports.AISports.Dao;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
    /// allSettings.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateActivity : Page
    {
        TrainingActivityService trainingActivityService = new TrainingActivityService();
		MemberService memberService = new MemberService();
		DatacodeDAO datacodeDAO = new DatacodeDAO();
        SystemSettingDAO systemSettingDAO = new SystemSettingDAO();
        PersonalSettingService personalSettingService = new PersonalSettingService();
		MemberEntity memberEntity = new MemberEntity();
		//静态活动类型参数来接收编辑活动页传来的活动类型
		private static string activityType = "";
        
        public UpdateActivity()
        {
            InitializeComponent();
            //加载训练模式选择框
            List<DatacodeEntity> datacodeEntities = datacodeDAO.ListByTypeId("TRAIN_MODE");
            //查询系统设置表中的版本是豪华版还是普通版 查询id为1的 注意插入的时候直接设置id为1.
            SystemSettingEntity systemSettingEntity = systemSettingDAO.Load(1);
			//获取登陆对象的个人信息
			memberEntity = memberService.GetMember(CommUtil.GetSettingString("memberId"));
			//更新页面是否开启减脂模式
			if (memberEntity.Is_open_fat_reduction == false)
			{
				this.is_open_fat.Text = "未开启";
			}
			else
			{
				this.is_open_fat.Text = "开启";
			}
			if (systemSettingEntity.System_version == 0)
            {
                //普通版少3中训练模式 移除指定索引段 移除心率模式和增肌模式被动模式和主被动模式
                datacodeEntities.RemoveRange(3, 4);
                Console.WriteLine("当前系统为标准版");

            }
            else if(systemSettingEntity.System_version == 1)
            {
                Console.WriteLine("当前系统为豪华版");
            }
            //加载训练模式选择框
            this.CB_train_mode.ItemsSource = datacodeEntities;
        }
        
        /// <summary>
        /// 获得从EditActivity页面传来的活动类型参数 根据传来的参数更新活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            if (e.ExtraData != null)
            {
                activityType = (string)e.ExtraData;
                Console.WriteLine("更新活动页收到的activityType：" + activityType);
                
                //查询轮次
                int? targetTurnNumber = trainingActivityService.GetTargetTurnNumByType(activityType);
                this.lunci_content.Content = targetTurnNumber.ToString();
            }

        }
        /// <summary>
        /// 某一活动所有设备的个人设置：根据当前活动类型和会员卡号更新其某个活动类型的个人设置
        /// </summary>
        public void UpdatePersonalSettingByTypeMemberId()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			//string addTest = this.LB_consequent_force.Content.ToString();
			//int add = int.Parse(addTest);
			//if (!(add == 100))//如果add等于100或者0为真的话
			//{
			//    add = add + 1;
			//}

			//this.LB_consequent_force.Content = add;
			if (Convert.ToInt32(this.LB_consequent_force.Content) < 100)
			{
				this.LB_consequent_force.Content = Convert.ToString(Convert.ToInt32(this.LB_consequent_force.Content) + 1);
			}

		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
			//string addTest = this.LB_consequent_force.Content.ToString();
			//int add = int.Parse(addTest);
			//if (!(add == 1))
			//    add = add - 1;

			//this.LB_consequent_force.Content = add;
			if (Convert.ToInt32(this.LB_consequent_force.Content) > 0)
			{
				this.LB_consequent_force.Content = Convert.ToString(Convert.ToInt32(this.LB_consequent_force.Content) - 1);
			}
		}

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
			//string minusTest = this.LB_Reverse_force.Content.ToString();
			//int min = int.Parse(minusTest);
			//if (!(min == 100))
			//{
			//    min = min + 1;
			//}
			//this.LB_Reverse_force.Content = min;
			if (Convert.ToInt32(this.LB_Reverse_force.Content) < 100)
			{
				this.LB_Reverse_force.Content = Convert.ToString(Convert.ToInt32(this.LB_Reverse_force.Content) + 1);
			}
		}

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
			//string minusTest = this.LB_Reverse_force.Content.ToString();
			//int min = int.Parse(minusTest);
			//if (!(min == 1))
			//{
			//    min = min - 1;
			//}
			//this.LB_Reverse_force.Content = min;
			if (Convert.ToInt32(this.LB_Reverse_force.Content) >0)
			{
				this.LB_Reverse_force.Content = Convert.ToString(Convert.ToInt32(this.LB_Reverse_force.Content) - 1);
			}
		}
        /// <summary>
        /// 点击取消回到EditActivity页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/EditActivity.xaml", UriKind.Relative));
        }
        /// <summary>
        /// 点击保存按钮 更新个人设置和训练活动轮次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //根据选择的速度给跑步机和单车的功率赋初值
            int? power = 0;
			//默认不开启减脂模式
			Boolean if_fat = false;
			switch (this.CB_speed.Text)
            {
                case "慢":
                    power = 30;
                    break;
                case "标准":
                    power = 50;
                    break;
                case "快速":
                    power = 70;
                    break;
                default:
                    break;
            }
			switch (this.is_open_fat.Text)
			{
				case "开启":
					if_fat = true;
					break;
				case "未开启":
					if_fat = false;
					break;

				default:
					break;
			}
			//获得训练模式的存储值
			string trainMode = this.CB_train_mode.SelectedValue.ToString();
            //顺向力
            double? consequentForce =  ParseIntegerUtil.ParseInt(this.LB_consequent_force.Content.ToString());
            //反向力
            double? reverseForce = ParseIntegerUtil.ParseInt(this.LB_Reverse_force.Content.ToString());
            //构建个人设置实体类 sql里有判断哪个更哪个不更 用一个实体类就行
            PersonalSettingEntity personalSettingEntity = new PersonalSettingEntity();

            personalSettingEntity.Member_id = CommUtil.GetSettingString("memberId");
            personalSettingEntity.Activity_type = activityType;
            personalSettingEntity.Training_mode = trainMode;
            personalSettingEntity.Power = power;
            personalSettingEntity.Consequent_force = consequentForce;
            personalSettingEntity.Reverse_force = reverseForce;

            //构建活动实体类
            ActivityEntity activityEntity = new ActivityEntity();
            activityEntity.Fk_training_course_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId"));
            activityEntity.Activity_type = activityType;
            activityEntity.Target_turn_number = ParseIntegerUtil.ParseInt(this.lunci_content.Content.ToString());

            //两个更新用事务包裹
            using (TransactionScope ts = new TransactionScope())
            {
                //更新活动轮次
                trainingActivityService.UpdateTargetTurnNumber(activityEntity);

				//更新是否开启减脂模式
				memberService.UpdateDeFatState(CommUtil.GetSettingString("memberId"), enable: if_fat);

				//分类更新个人设置
				if ("0".Equals(activityType))
                {
                    //力量循环更新个人设置，不更新功率
                    personalSettingService.UpdateStrengthDeviceSettingByType(personalSettingEntity);

                }
                else if ("1".Equals(activityType))
                {
                    //力量耐力循环更新个人设置，普通设备和单车跑步机分开更新，单车跑步机单独更新功率
                    //更新单车跑步机
                    personalSettingService.UpdateEnduranceDeviceSettingByType(personalSettingEntity);
                    //更新其他力量训练设备
                    personalSettingService.UpdateStrengthDeviceSettingByType(personalSettingEntity);
                }
                Console.WriteLine("更新活动和个人设置成功");
                ts.Complete();
                //MessageBox.Show("更新活动成功");
                MessageBoxX.Show("提示", "更新活动与个人设置成功");
            }
            

               
        }
        private void Lunci_minus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            if (!(text == 1))
            { text--; }
            lunci_content.Content = text.ToString();
        }
        private void Lunci_plus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            if (!(text == 10))
            { text++; }
            lunci_content.Content = text.ToString();
        }


    }
}
