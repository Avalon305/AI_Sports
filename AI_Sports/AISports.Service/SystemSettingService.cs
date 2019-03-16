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

	}
}
