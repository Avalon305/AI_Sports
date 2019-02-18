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
    class TrainingCourseService
    {
        private TrainingCourseDAO trainingCourseDAO = new TrainingCourseDAO();
        /// <summary>
        /// 添加训练课程
        /// </summary>
        /// <param name="trainingCourseEntity"></param>
        /// <returns></returns>
        public long SaveTrainingCourse(TrainingCourseEntity trainingCourseEntity)
        {
            trainingCourseEntity.Id = KeyGenerator.GetNextKeyValueLong("bdl_training_course");
            //设置外键训练计划id
            trainingCourseEntity.Fk_training_plan_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingPlanId"));
            //设置会员卡号
            trainingCourseEntity.Member_id = CommUtil.GetSettingString("memberId");
            return trainingCourseDAO.Insert(trainingCourseEntity);
        }
        /// <summary>
        /// 根据登陆会员卡号查询训练课程
        /// </summary>
        /// <returns></returns>
        public TrainingCourseEntity GetCourseByMemberId()
        {
            string memberId = CommUtil.GetSettingString("memberId");
            return trainingCourseDAO.GetCourseByMemberId(memberId);
        }
        /// <summary>
        /// 课程分析页面，查询课程记录列表
        /// </summary>
        /// <returns></returns>
        public List<TrainingCourseVO> listCourseRecord()
        {
            string trainingCourseId = CommUtil.GetSettingString("trainingCourseId");
            return trainingCourseDAO.listCourseRecord(trainingCourseId);
        }

        public int selectMAxCourseRecord()
        {
            return trainingCourseDAO.selectMAxCourseRecord();
        }

        public double selectAerobicEnduranceEnergy()
        {
            return trainingCourseDAO.selectAerobicEnduranceEnergy();
        }

        public double selectForceEnduranceEnergy()
        {
            return trainingCourseDAO.selectForceEnduranceEnergy();
        }

        public double selectForceEnergy()
        {
            return trainingCourseDAO.selectForceEnergy();
        }
    }
}
