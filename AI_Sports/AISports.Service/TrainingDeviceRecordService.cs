using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Service
{
    class TrainingDeviceRecordService
    {
        private TrainingDeviceRecordDAO trainingDeviceRecordDAO = new TrainingDeviceRecordDAO();

        public List<TrainingDeviceRecordEntity> GetRecordByIdAndTime(string memberId)
        {
            return trainingDeviceRecordDAO.GetRecordByIdAndTime(memberId);
        }

        public int GetTrainActivityRecordIdById(long Id) {
            return trainingDeviceRecordDAO.GetTrainActivityRecordIdById(Id);
        }
        public int GetRecordCountByIdAndDeviceCode(string memberId, string Device_code) {
            return trainingDeviceRecordDAO.GetRecordCountByIdAndDeviceCode(memberId, Device_code);
        }
        /// <summary>
        /// 根据会员卡号查询训练记录
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<TrainingDeviceRecordEntity> ListRecordById(string memberId)
        {
            return trainingDeviceRecordDAO.ListRecordById(memberId);
            
        }
        /// <summary>
        /// 查询用户当前月训练记录 出勤页
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<TrainingDeviceRecordEntity> ListCurrentMonthRecordById(string memberId)
        {
            return trainingDeviceRecordDAO.ListCurrentMonthRecordById(memberId);

        }

        /// <summary>
        /// 查询会员的初次训练日期
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DateTime? GetMinTrainingDate(string memberId)
        {
            return trainingDeviceRecordDAO.GetMinTrainingDate(memberId);
        }
        /// <summary>
        /// 查询最近训练日期
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DateTime? GetMaxTrainingDate(string memberId)
        {
            return trainingDeviceRecordDAO.GetMaxTrainingDate(memberId);
        }
    }
}
