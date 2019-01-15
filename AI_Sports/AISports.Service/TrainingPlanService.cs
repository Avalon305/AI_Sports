using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI_Sports.Dao;
using AI_Sports.Entity;

namespace AI_Sports.Service
{
    class TrainingPlanService
    {
        private TrainingPlanDAO trainingPlanDAO = new TrainingPlanDAO();
        public int DeletePlanByMemberId(MemberEntity memberEntity)
        {
            return trainingPlanDAO.DeletePlanByMemberId(memberEntity);
        }
    }
}
