using AI_Sports.Dao;
using AI_Sports.Dto;
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
        private TrainingDeviceRecordDAO trainingDeviceRecordDAO = new TrainingDeviceRecordDAO();
        /// <summary>
        /// 处理登录请求
        /// </summary>
        /// <param name="request"></param>
        public LoginResponse LoginRequest(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            response.Uid = request.Uid;
            response.ActivityType = request.ActivityType;

            var setDto = personalSettingDAO.GetSettingByMemberIdDeviceType(request.Uid, request.DeviceType, request.ActivityType);
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
            MemberEntity member = memberDAO.Load(pSetting.Fk_member_id);
            response.DefatModeEnable = member.Is_open_fat_reduction;
            response.SeatHeight = pSetting.Seat_height == null ? 0 : (int)pSetting.Seat_height;
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
                    Course_count = setDto.Current_course_count
                };
                trainingActivityRecordDAO.Insert(recordEntity);
            }
            response.ActivityRecordId = recordEntity.Id;

            // 待训练列表
            List<DeviceType> todoDevices = GenToDoDevices(request.Uid, request.ActivityType, setDto.Is_open_fat_reduction);
            response.DeviceTypeArr.AddRange(todoDevices);
            return response;
        }

        /// <summary>
        /// 获取待训练设备列表
        /// </summary>
        /// <param name="request"></param>
        /// <param name="setDto"></param>
        /// <returns></returns>
        private List<DeviceType> GenToDoDevices(string uid, ActivityType activityType, bool Is_open_fat_reduction)
        {
            List<DeviceDoneDTO> doneList = personalSettingDAO.ListDeviceDone(uid, activityType);
            var todoDevices = new List<DeviceType>();

            if (activityType == ActivityType.PowerCycle)//力量循环
            {
                todoDevices.AddRange(new DeviceType[]{
                    DeviceType.P00, DeviceType.P01, DeviceType.P02,DeviceType.P03,DeviceType.P04,DeviceType.P05,DeviceType.P06,
                    DeviceType.P07,DeviceType.P08,DeviceType.P09
                });
            }
            else if (activityType == ActivityType.EnduranceCycle)//力量耐力循环需要考虑减脂模式
            {
                if (Is_open_fat_reduction)
                {//减脂模式
                    todoDevices.Add(DeviceType.E16);//动感单车
                    todoDevices.Add(DeviceType.E12);//椭圆跑步机
                }
                todoDevices.AddRange(new DeviceType[]{
                    DeviceType.E10,DeviceType.E11,DeviceType.E12,DeviceType.E13,DeviceType.E14,DeviceType.E15,DeviceType.E16
                });
                if (Is_open_fat_reduction)
                {//减脂模式
                    todoDevices.Add(DeviceType.E16);//动感单车
                    todoDevices.Add(DeviceType.E12);//椭圆跑步机
                }
            }
            foreach (var d in doneList)//移除掉已经完成的设备
            {
                int ecode = int.Parse(d.Device_code);
                todoDevices.Remove((DeviceType)ecode);
            }

            return todoDevices;
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
            //插入训练设备记录表
            var deviceRecord = new TrainingDeviceRecordEntity
            {
                Id = KeyGenerator.GetNextKeyValueLong("bdl_training_device_record"),
                Member_id = request.Uid,
                Fk_training_activity_record_id = request.ActivityRecord,
                Activity_type = ((int)request.ActivityType).ToString(),
                Device_code = ((int)request.DeviceType).ToString(),
                Training_mode = ((int)request.TrainMode).ToString(),
                Consequent_force = request.ForwardForce,
                Reverse_force = request.ReverseForce,
                Power = request.Power,
                Count = request.FinishCount,
                Distance = request.FinalDistance,
                Energy = request.Calorie,
                Training_time = request.TrainTime,
                Avg_heart_rate = request.HeartRateAvg,
                Max_heart_rate = request.HeartRateMax,
                Min_heart_rate = request.HeartRateMin,
                Gmt_create = DateTime.Now

            };
            trainingDeviceRecordDAO.Insert(deviceRecord);
            //查一下是否是该循环最后一个设备，是的话更新训练活动表课程数量加一并看一下是否已完成,训练活动记录表标志位已完成，
            List<DeviceType> todoList =  this.GenToDoDevices(request.Uid, request.ActivityType, request.DefatModeEnable);
            if (todoList.Count == 0)//训练完毕一个循环
            {
                var activityRecord = trainingActivityRecordDAO.Load(request.ActivityRecordId);
                if (activityRecord != null)
                {
                  
                }
            }
            return response;
        }
    }
}
