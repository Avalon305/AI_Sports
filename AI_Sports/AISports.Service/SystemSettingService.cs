using AI_Sports.AISports.Constant;
using AI_Sports.AISports.Util;
using AI_Sports.Dao;
using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Service
{
	class SystemSettingService
	{

		private SystemSettingDAO systemSettingDAO = new SystemSettingDAO();

		/// <summary>
		/// 获取系统设置的唯一记录
		/// </summary>
		/// <returns></returns>
		public SystemSettingEntity GetSystemSetting()
		{
			return systemSettingDAO.GetSystemSetting();
		}
		/// <summary>
		/// 新增一条记录
		/// </summary>
		/// <param name="systemSettingEntity"></param>
		/// <returns></returns>
		public int InsertSystemSet(SystemSettingEntity systemSettingEntity)
		{
			return systemSettingDAO.InsertSystemSet(systemSettingEntity);
		}
		public void UpdataSystemSet(SystemSettingEntity  systemSettingEntity)
		{
		  systemSettingDAO.UpdateByPrimaryKey(systemSettingEntity);
		}
        /// <summary>
        /// 检测客户机是否有权限使用，（使用时间，mac检测，用户状态）
        /// </summary>
        /// <returns></returns>
        public string LoginCheck()
        {
            SystemSettingService systemSettingService = new SystemSettingService();
            var result = systemSettingService.GetSystemSetting();

            string loginResult = "success";

            if (result == null)
            {
                loginResult = "登录异常.null";
                return loginResult;
            }

            //用户测试是否超时登录
            if (result.Auth_OfflineTime < DateTime.Now)
            {
                loginResult = "您的使用时间已经用尽，请联系宝德龙管理员";
                Console.WriteLine("+++++++++++++++" + loginResult);
                return loginResult;
            }
            //注释原因：数据库中的mac地址与本机获得mac地址有时不匹配
            /*
            string mac = "";
            try
            {
                byte[] a = ProtocolUtil.StringToBcd(result.Set_Unique_Id);
                byte[] b = AesUtil.Decrypt(a, ProtocolConstant.USB_DOG_PASSWORD);
                mac = Encoding.GetEncoding("GBK").GetString(b);
            }
            catch (Exception ex)
            {
                loginResult = "登录异常.mac异常";
                Console.WriteLine("+++++++++++++++" + loginResult);
                return loginResult;
            }

            //如果解密后的setter中的mac不包含现在获得的mac 
            if (mac.IndexOf(SystemInfo.GetMacAddress().Replace(":", "-")) == -1)
            {
                //Console.WriteLine("DB:"+ mac);
                //Console.WriteLine("current:" + SystemInfo.GetMacAddress().Replace(":","-"));
                loginResult = "登录异常mac错误";
                Console.WriteLine("+++++++++++++++" + loginResult);
                return loginResult;
            }
            */
            if (result.User_Status == SystemSettingEntity.USER_STATUS_FREEZE)
            {
                loginResult = "用户已被冻结";
                Console.WriteLine("+++++++++++++++" + loginResult);
                return loginResult;
            }
            return loginResult;
        }
    }
}
