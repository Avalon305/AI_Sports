using AI_Sports.Dao;
using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Service
{
    /// <summary>
    /// 与设备通信的Service
    /// </summary>
    class DeviceCommService
    {
    
        private PersonalSettingDAO personalSettingDAO = new PersonalSettingDAO();
        private MemberDAO memberDAO = new MemberDAO();
        /// <summary>
        /// 处理登录请求
        /// </summary>
        /// <param name="request"></param>
        public LoginResponse LoginRequest(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            response.Uid = request.Uid;
            response.CycleType = request.CycleType;
            //TODO 待训练列表
            //response. = null;
            var pSetting = personalSettingDAO.GetSettingByMemberIdDeviceType(request.Uid, request.DeviceType);

            if (pSetting != null)
            {
                response.ExisitSetting = true;
            }
            response.TrainMode = (TrainMode)Enum.Parse(typeof(TrainMode), pSetting.Training_mode);
            MemberEntity member= memberDAO.Load(pSetting.Fk_member_id);
            response.DefatModeEnable = member.Is_open_fat_reduction;
            response.SeatHeight = pSetting.Seat_height==null ? 0: (int)pSetting.Seat_height;
            response.BackDistance = pSetting.Backrest_distance == null ? 0 : (int)pSetting.Backrest_distance;
            //TODO 可动杠杆长度cm
            //response.LeverLength = 
            response.ForwardLimit = pSetting.Front_limit == null ? 0 : (int)pSetting.Front_limit;
            response.BackLimit = pSetting.Backrest_distance == null ? 0 : (int)pSetting.Backrest_distance;
            //TODO 杠杆角度
            //response.LeverAngle = 
            response.ForwardForce = pSetting.Consequent_force == null ? 0 : (double)pSetting.Consequent_force;
            response.ReverseForce = pSetting.Reverse_force == null ? 0 : (double)pSetting.Reverse_force;
            response.RunPower = pSetting.Power == null ? 0 : (double)pSetting.Power;
            //TODO 电机实时速度
            // response.RunSpeed = pSetting
            //TODO 跑步机和单车的运动距离（km）
            //response.Distance = 
            //TODO 课程ID、训练活动ID、训练活动记录ID
            return response;
        }
    }
}
