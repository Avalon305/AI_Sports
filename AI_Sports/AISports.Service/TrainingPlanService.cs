using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;

namespace AI_Sports.Service
{
    class TrainingPlanService
    {
        private TrainingPlanDAO trainingPlanDAO = new TrainingPlanDAO();
        /// <summary>
        /// 添加新的训练计划，需要先删除旧的训练计划
        /// </summary>
        /// <param name="trainingPlan"></param>
        /// <returns></returns>
        public string SaveNewTrainingPlan(TrainingPlanEntity trainingPlan)
        {
            //使整个代码块成为事务性代码
            using (TransactionScope ts = new TransactionScope())
            {
                string result = null;
                string memberId = CommUtil.GetSettingString("memberId");
                //1.删除旧的训练计划
                if (trainingPlanDAO.DeletePlanByMemberId(memberId) == 1)
                {
                    //2.新增训练计划
                    if (trainingPlanDAO.SaveTrainingPlan(trainingPlan) == 1)
                    {
                        result = "新增训练计划成功";
                    }
                    else
                    {
                        result = "新增训练计划失败";
                    }


                }
                else
                {
                    result = "删除旧训练计划失败";
                }
                ts.Complete();
                return result;
            }

        }
    }
}
