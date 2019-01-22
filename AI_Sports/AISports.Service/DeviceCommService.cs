using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;
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
        private TrainingActivityRecordDAO trainingActivityRecordDAO = new TrainingActivityRecordDAO();
        /// <summary>
        /// 处理登录请求
        /// </summary>
        /// <param name="request"></param>
        public LoginResponse LoginRequest(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            response.Uid = request.Uid;
            response.ActivityType = request.ActivityType;
            //TODO 待训练列表
            //response. = null;
            //response.DeviceTypeArr.Add(DeviceType.E10);
            var setDto = personalSettingDAO.GetSettingByMemberIdDeviceType(request.Uid, request.DeviceType,request.ActivityType);
            if (setDto != null && setDto.PersonalSettingEntity != null)
            {
                response.ExisitSetting = true;
            }
            else
            {
                return response;
            }
            var pSetting = setDto.PersonalSettingEntity;
            response.TrainMode = (TrainMode)Enum.Parse(typeof(TrainMode), pSetting.Training_mode);
            MemberEntity member= memberDAO.Load(pSetting.Fk_member_id);
            response.DefatModeEnable = member.Is_open_fat_reduction;
            response.SeatHeight = pSetting.Seat_height==null ? 0: (int)pSetting.Seat_height;
            response.BackDistance = pSetting.Backrest_distance == null ? 0 : (int)pSetting.Backrest_distance;
            // 可动杠杆长度cm
            response.LeverLength = pSetting.Lever_length == null ? 0 : (int)pSetting.Lever_length;
            response.ForwardLimit = pSetting.Front_limit == null ? 0 : (int)pSetting.Front_limit;
            response.BackLimit = pSetting.Backrest_distance == null ? 0 : (int)pSetting.Backrest_distance;
            //杠杆角度
            response.LeverAngle = pSetting.Lever_angle == null ? 0 : (double)pSetting.Lever_angle;
            response.ForwardForce = pSetting.Consequent_force == null ? 0 : (double)pSetting.Consequent_force;
            response.ReverseForce = pSetting.Reverse_force == null ? 0 : (double)pSetting.Reverse_force;
            response.Power = pSetting.Power == null ? 0 : (double)pSetting.Power;

            //课程ID、训练活动ID、训练活动记录ID
            response.CourseId = setDto.Fk_training_course_id;
            response.ActivityId = pSetting.Fk_training_activity_id;

            var recordEntity = trainingActivityRecordDAO.GetByActivityId(pSetting.Fk_training_activity_id);
            if (recordEntity == null)
            {//没有训练课程记录就插入一条新的
                recordEntity = new TrainingActivityRecordEntity
                {
                    Id = KeyGenerator.GetNextKeyValueLong("bdl_training_activity_record"),
                    Gmt_create = DateTime.Now,
                    Fk_activity_id = pSetting.Fk_training_activity_id,
                    Activity_type = ((int)request.ActivityType).ToString(),
                    Is_complete = false,
                    Fk_training_course_id = setDto.Fk_training_course_id,
                    Course_count = 0//新插入的课程计数是0
                };
                trainingActivityRecordDAO.Insert(recordEntity);
            }
            response.ActivityRecordId = recordEntity.Id;

            return response;
        }

        /// <summary>
        /// 处理上传训练结果请求
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UploadResponse UploadRequest(UploadRequest request)
        {
            UploadResponse response = new UploadResponse
            {
                Uid = request.Uid,
                DeviceType = request.DeviceType,
                ActivityType = request.ActivityType
            };

            response.Finished = true;
            response.Success = true;

            return response;
        }
    }
}
