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
using AI_Sports.AISports.Service;
using AI_Sports.Entity;
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
			systemSettingService.InsertSystemSet(sse);
			}
			else if(isNUll==1){
				//为1时，是更新数据
			
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


				systemSettingService.UpdataSystemSet(sse);
			}
		}
	}
}
