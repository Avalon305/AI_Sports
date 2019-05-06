using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class TrainingPlanDTO
    {
        public string Id;

        /// <summary>
        /// 外键会员id
        /// </summary>
        public string FkMemberId;
        /// <summary>
        /// 会员ID非主键
        /// </summary>
        public string MemberId;
        /// <summary>
        /// 训练标题
        /// </summary>
        public string Title;

        /// <summary>
        /// 起始日期
        /// </summary>
        public string StartDate;

        /// <summary>
        /// 训练目标
        /// </summary>
        public string TrainingTarget;

        /// <summary>
        /// 是否删除 1:删除;0:未删除
        /// </summary>
        public string IsDeleted;

        /// <summary>
        /// 创建时间
        /// </summary>
        public string GmtCreate;

        /// <summary>
        /// gmt_modified
        /// </summary>
        public string GmtModified;
        public TrainingPlanDTO ()
        {

        }
        public TrainingPlanDTO (TrainingPlanEntity trainingPlanEntity)
        {
            this.Id = trainingPlanEntity.Id.ToString();
            this.FkMemberId = trainingPlanEntity.Fk_member_id.ToString();
            this.MemberId = trainingPlanEntity.Member_id;
            this.Title = trainingPlanEntity.Title;
            this.StartDate = trainingPlanEntity.Start_date.ToString().Replace("/", "-");
            this.TrainingTarget = trainingPlanEntity.Training_target;
            this.IsDeleted = trainingPlanEntity.Is_deleted.ToString();
            this.GmtCreate = trainingPlanEntity.Gmt_create.ToString().Replace("/", "-");
            this.GmtModified = trainingPlanEntity.Gmt_modified.ToString().Replace("/", "-");
        }
    }
}
