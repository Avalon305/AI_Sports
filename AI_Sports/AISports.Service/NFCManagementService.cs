using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Service
{
    /// <summary>
    /// 手环和卡的NFC管理业务类
    /// </summary>
    class NFCManagementService
    {
        /// <summary>
        /// 1.该方法可用于刷卡后，根据传入卡号更新App.config。然后调用登陆读取App.config的appSettings
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
    }
}
