using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class TrainingDeviceRecordDTO
    {
        public string Id;
        /// 会员id
        public string MemberId;
        /// 外键训练活动记录id
        public string FkTrainingActivityRecordId;
        /// 训练活动类型编码
        public string ActivityType;
        /// 设备在循环中的序号
        public string DeviceOrderNumber;
        /// 设备名
        public string DeviceCode;
        /// 训练模式
        public string TrainingMode;
        /// 向心力
        public string ConsequentForce;
        /// 离心力
        public string ReverseForce;
        /// 功率
        public string Power;
        /// 训练个数
        public string Count;
        /// 速度 1位小数 千米每时,暂不上报
        public string Speed;
        /// 距离 千米，两位小数
        public string Distance;
        /// 训练总耗能 单位卡路里
        public string Energy;
        /// 训练时间 单位秒
        public string TrainingTime;
        /// 平均心率
        public string AvgHeartRate;
        /// 最大心率
        public string MaxHeartRate;
        /// 最小心率
        public string MinHeartRate;
        /// 创建时间
        public string GmtCreate;
        public string GmtModified;
        public TrainingDeviceRecordDTO ()
        {

        }
        public TrainingDeviceRecordDTO (TrainingDeviceRecordEntity trainingDeviceRecordEntity)
        {
            this.Id = trainingDeviceRecordEntity.Id.ToString();
            this.MemberId = trainingDeviceRecordEntity.Member_id;
            this.FkTrainingActivityRecordId = trainingDeviceRecordEntity.Fk_training_activity_record_id.ToString();
            this.ActivityType = trainingDeviceRecordEntity.Activity_type;
            this.DeviceOrderNumber = trainingDeviceRecordEntity.Device_order_number.ToString();
            this.DeviceCode = trainingDeviceRecordEntity.Device_code;
            this.TrainingMode = trainingDeviceRecordEntity.Training_mode;
            this.ConsequentForce = trainingDeviceRecordEntity.Consequent_force.ToString();
            this.ReverseForce = trainingDeviceRecordEntity.Reverse_force.ToString();
            this.Power = trainingDeviceRecordEntity.Power.ToString();
            this.Count = trainingDeviceRecordEntity.Count.ToString();
            this.Speed = trainingDeviceRecordEntity.Speed.ToString();
            this.Distance = trainingDeviceRecordEntity.Distance.ToString();
            this.Energy = trainingDeviceRecordEntity.Energy.ToString();
            this.TrainingTime = trainingDeviceRecordEntity.Training_time.ToString();
            this.AvgHeartRate = trainingDeviceRecordEntity.Avg_heart_rate.ToString();
            this.MaxHeartRate = trainingDeviceRecordEntity.Max_heart_rate.ToString();
            this.MinHeartRate = trainingDeviceRecordEntity.Min_heart_rate.ToString();
            this.GmtCreate = trainingDeviceRecordEntity.Gmt_create.ToString().Replace("/", "-");
            this.GmtModified = trainingDeviceRecordEntity.Gmt_modified.ToString().Replace("/", "-");
        }
    }
}
