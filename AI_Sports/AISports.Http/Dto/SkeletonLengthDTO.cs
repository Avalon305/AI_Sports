using AI_Sports.AISports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class SkeletonLengthDTO
    {
        public string Id;
        // 关联bdl_member表的主键
        public string FkMemberId;
        public string BodyLength;
        //肩宽mm
        public string ShoulderWidth;
        //臂长(上)mm
        public string ArmLengthUp;
        //臂长(下)mm
        public string ArmLengthDown;
        //腿长(上)mm
        public string LegLengthUp;
        //腿长(下)mm
        public string LegLengthDown;
        public SkeletonLengthDTO ()
        {

        }
        public SkeletonLengthDTO (SkeletonLengthEntity skeletonLengthEntity)
        {
            this.Id = skeletonLengthEntity.Id.ToString();
            this.FkMemberId = skeletonLengthEntity.Fk_member_id.ToString();
            this.BodyLength = skeletonLengthEntity.Body_length.ToString();
            this.ShoulderWidth = skeletonLengthEntity.Shoulder_width.ToString();
            this.ArmLengthUp = skeletonLengthEntity.Arm_length_up.ToString();
            this.ArmLengthDown = skeletonLengthEntity.Arm_length_down.ToString();
            this.LegLengthUp = skeletonLengthEntity.Leg_length_up.ToString();
            this.LegLengthDown = skeletonLengthEntity.Leg_length_down.ToString();
        }
    }
}
