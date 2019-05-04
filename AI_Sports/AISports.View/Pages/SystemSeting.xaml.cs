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
using AI_Sports.AISports.Constant;
using AI_Sports.AISports.Service;
using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Util;
using AISports.Util;

namespace AI_Sports.AISports.View.Pages
{
	/// <summary>
	/// SystemSeting.xaml 的交互逻辑
	/// </summary>
	public partial class SystemSeting : Page
	{

		private SystemSettingService systemSettingService = new SystemSettingService();
		private int isNUll; //0为空，1位非空
		SystemSettingEntity AddsystemSettingEntity = new SystemSettingEntity();
		public SystemSeting()
		{
			InitializeComponent();

		 SystemSettingEntity systemSettingEntity = systemSettingService.GetSystemSetting();
			

			if (systemSettingEntity != null)
			{
				isNUll = 1;
				string name = systemSettingEntity.Organization_name;
				string phone = systemSettingEntity.Organization_phone;
				string address = systemSettingEntity.Organization_address;
				int? version = systemSettingEntity.System_version;
				if (name != null)
				{
					this.Oname.Text = name;
				}
				else
				{
					this.Oname.Text = "";
				}

				if (phone != null)
				{
					this.Ophone.Text = phone;
				}
				else {
					this.Ophone.Text = "";
				}

				if (address != null)
				{
					this.Oaddress.Text = address;
				}
				else
				{
					this.Oaddress.Text = "";
				}
				if (version != null)
				{
					if(version == 0)
					{
						this.Oversion.Text = "标准版（三种训练模式）";
					}
					else if(version ==1)
					{
						this.Oversion.Text = "豪华版（六种训练模式）";

					}

				}
				else
				{
					this.Oversion.Text = "";

				}

			}
			else
			{
				isNUll = 0;

				
			}
			 
		}
		private void WrapPanel_MouseUp(object sender, MouseButtonEventArgs e)
		{
			//MessageBox.Show("hello");
			Moudle moudle = new Moudle();
			moudle.ShowDialog();
			if (moudle.SystemPassword.Password == ConfigUtil.Get("SystemSettingPassword"))
			{
				this.Oversion.IsEnabled = true;
			}
			else
			{
				MessageBoxX.Show("错误","密码输入错误");
			}

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (isNUll == 0) { 
				//此时为插入一条新数据
			SystemSettingEntity sse = new SystemSettingEntity();
			sse.Id = 1;
			sse.Organization_name = this.Oname.Text;
			sse.Organization_phone = this.Ophone.Text;
			sse.Organization_address = this.Oaddress.Text;
			sse.Ip_address = "127.0.0.1";
			if (this.Oversion.Text == "标准版（三种训练模式）")
			{
				sse.System_version = 0;

			}
			else
			{
				sse.System_version = 1;
			}
                //初始化使用时间：开机时间加上六个月
                sse.Auth_OfflineTime = DateTime.Now.AddMonths(+6);
                //客户机状态为正常状态
                sse.User_Status = SystemSettingEntity.USER_STATUS_GENERAL;

                //获取mac地址
                StringBuilder stringBuilder = new StringBuilder();
                //string strMac = CommUtil.GetMacAddress();
                // List<string> Macs = CommUtil.GetMacByWMI();
                List<string> Macs = CommUtil.GetMacByIPConfig();
                foreach (string mac in Macs)
                {
                    string prefix = "物理地址. . . . . . . . . . . . . : ";
                    string Mac = mac.Substring(prefix.Length - 1);
                    stringBuilder.Append(Mac);
                }

                //mac地址先变为byte[]再aes加密
                byte[] byteMac = Encoding.GetEncoding("GBK").GetBytes(stringBuilder.ToString());
                byte[] AesMac = AesUtil.Encrypt(byteMac, ProtocolConstant.USB_DOG_PASSWORD);
                //存入数据库
                //setter.Set_Unique_Id = Encoding.GetEncoding("GBK").GetString(AesMac);
                sse.Set_Unique_Id = ProtocolUtil.BytesToString(AesMac);

                //如果为空才可以插入
                if (systemSettingService.GetSystemSetting() == null)
                {
                    systemSettingService.InsertSystemSet(sse);
                }
            }
			else if(isNUll==1){
				//为1时，是更新数据
			
				SystemSettingEntity sse = new SystemSettingEntity();
                //更新之前查出不需要更改的那部分内容（用户状态，使用时间，客户机唯一id），再重新赋值
                SystemSettingEntity systemSetting = new SystemSettingEntity();
                systemSetting = systemSettingService.GetSystemSetting();
                //赋值
                sse.User_Status = systemSetting.User_Status;
                sse.Set_Unique_Id = systemSetting.Set_Unique_Id;
                sse.Auth_OfflineTime = systemSetting.Auth_OfflineTime;

                sse.Id = 1;
				sse.Organization_name = this.Oname.Text;
				sse.Organization_phone = this.Ophone.Text;
				sse.Organization_address = this.Oaddress.Text;
				sse.Ip_address = "127.0.0.1";
				if (this.Oversion.Text == "标准版（三种训练模式）")
				{
					sse.System_version = 0;

				}
				else
				{
					sse.System_version = 1;
				}


				systemSettingService.UpdataSystemSet(sse);
			}

            MessageBoxX.Show("温馨提示","保存成功");
		}
	}
}
