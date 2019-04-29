using AI_Sports.AISports.Entity;
using AI_Sports.Constant;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AI_Sports.Service
{
    class TrainingCourseService
    {
        private TrainingCourseDAO trainingCourseDAO = new TrainingCourseDAO();
        private TrainingActivityService trainingActivityService = new TrainingActivityService();
        /// <summary>
        /// 添加训练课程
        /// </summary>
        /// <param name="trainingCourseEntity"></param>
        /// <returns></returns>
        public void SaveTrainingCourse(DateTime? startDate)
        {
            TrainingCourseEntity trainingCourseEntity = new TrainingCourseEntity();

            //主键id
            trainingCourseEntity.Id = KeyGenerator.GetNextKeyValueLong("bdl_training_course");
            //设置外键训练计划id
            trainingCourseEntity.Fk_training_plan_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingPlanId"));
            //设置会员卡号
            trainingCourseEntity.Member_id = CommUtil.GetSettingString("memberId");
            //当前创建时间
            trainingCourseEntity.Gmt_create = System.DateTime.Now;
            //6.创建一个默认的训练课程
            //  课程开始时间 = 训练计划的开始时间
            trainingCourseEntity.Start_date = startDate;
            //  默认暂停时间是4天
            trainingCourseEntity.Rest_days = 2;
            //  默认课程天数是16天
            trainingCourseEntity.Target_course_count = 16;
            //  默认结束日期 = 开始日期 + (暂停时间*(课程天数 - 1))  减一是因为当天算第一天
            trainingCourseEntity.End_date = trainingCourseEntity.Start_date.Value.AddDays(trainingCourseEntity.Rest_days.Value * (trainingCourseEntity.Target_course_count.Value - 1));
            //  状态未完成
            trainingCourseEntity.Is_complete = false;
            //  当前计数默认0
            trainingCourseEntity.Current_course_count = 0;
            //  保存课程


            //这个插入基类有BUG 明明插入进入了 但是返回的结果为0，所以不要返回值了。反正如果插入失败也报异常，返回值也没啥用
            trainingCourseDAO.Insert(trainingCourseEntity);
            //插入至上传表
            UploadManagementDAO uploadManagementDao = new UploadManagementDAO();
            uploadManagementDao.Insert(new UploadManagement(trainingCourseEntity.Id, "bdl_training_course", 0));
            //更新配置中的课程id 
            CommUtil.UpdateSettingString("trainingCourseId", (trainingCourseEntity.Id).ToString());
            //训练课程目标天数
            CommUtil.UpdateSettingString("targetCourseCount", (trainingCourseEntity.Target_course_count).ToString());


        }


        /// <summary>
        /// 自动创建模板训练课程
        /// </summary>
        /// <param name="trainingCourseEntity"></param>
        /// <returns></returns>
        public void AutoSaveNewTemplateCourse(TrainingPlanEntity trainingPlan, PlanTemplate planTemplate)
        {

            //使整个代码块成为事务性代码
            using (TransactionScope ts = new TransactionScope())
            {
                TrainingCourseEntity trainingCourseEntity = new TrainingCourseEntity();

                //主键id
                trainingCourseEntity.Id = KeyGenerator.GetNextKeyValueLong("bdl_training_course");
                //设置外键训练计划id
                trainingCourseEntity.Fk_training_plan_id = trainingPlan.Id;
                //设置会员卡号
                trainingCourseEntity.Member_id = trainingPlan.Member_id;
                //当前创建时间
                trainingCourseEntity.Gmt_create = System.DateTime.Now;
                //6.创建一个默认的训练课程
                //  课程开始时间 = 训练计划的开始时间
                trainingCourseEntity.Start_date = trainingPlan.Start_date;
                //  默认暂停时间是2天
                trainingCourseEntity.Rest_days = 2;
                //  默认课程天数是16天
                trainingCourseEntity.Target_course_count = 16;
                //  当前计数默认0
                trainingCourseEntity.Current_course_count = 0;
                //  默认结束日期 = 开始日期 + (暂停时间*(课程天数 - 1))  减一是因为当天算第一天
                trainingCourseEntity.End_date = trainingCourseEntity.Start_date.Value.AddDays(trainingCourseEntity.Rest_days.Value * (trainingCourseEntity.Target_course_count.Value - 1));
                //  状态未完成
                trainingCourseEntity.Is_complete = false;
               
                //  保存课程
                //这个插入基类有BUG 明明插入进入了 但是返回的结果为0，所以不要返回值了。反正如果插入失败也报异常，返回值也没啥用
                trainingCourseDAO.Insert(trainingCourseEntity);
                //插入至上传表
                UploadManagementDAO uploadManagementDao = new UploadManagementDAO();
                uploadManagementDao.Insert(new UploadManagement((int)trainingCourseEntity.Id, "bdl_training_course", 0));
                //更新配置中的课程id 
                CommUtil.UpdateSettingString("trainingCourseId", (trainingCourseEntity.Id).ToString());
                //训练课程目标天数
                CommUtil.UpdateSettingString("targetCourseCount", (trainingCourseEntity.Target_course_count).ToString());
                //调用创建模板训练活动
                trainingActivityService.AutoSaveActivityTemplate(trainingCourseEntity , trainingPlan.Fk_member_id.Value, planTemplate);
                ts.Complete();
            }

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
        /// <summary>
        /// 根据主键id更新训练课程
        /// </summary>
        /// <param name="trainingCourseEntity"></param>
        /// <returns></returns>
        public int UpdateTrainingCourseById(int? restDays, DateTime? endDate, int? targetCourseCount, long? Id)
        {
            return trainingCourseDAO.UpdateTrainingCourseById(restDays, endDate, targetCourseCount, Id);
        }
        ///zfc
        /// <summary>
        /// 根据当前课程ID完成/跳过训练课程 计数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateCourseCount(int id)
        {
            return trainingCourseDAO.UpdateCourseCount(id);
        }

        public int? selectMAxCourseRecord()
        {
            return trainingCourseDAO.selectMAxCourseRecord();
        }

        public List<double> selectAerobicEnduranceEnergy(string trainingPlanId)
        {
            return trainingCourseDAO.selectAerobicEnduranceEnergy(trainingPlanId);
        }

        public List<double> selectForceEnduranceEnergy(string trainingPlanId)
        {
            return trainingCourseDAO.selectForceEnduranceEnergy(trainingPlanId);
        }

        public List<double> selectForceEnergy(string trainingPlanId)
        {
            return trainingCourseDAO.selectForceEnergy(trainingPlanId);
        }
    }
}
