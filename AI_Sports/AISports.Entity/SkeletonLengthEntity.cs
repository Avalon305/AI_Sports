//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Entity
{
    [Serializable]
    [Table("bdl_skeleton_length")]
    class SkeletonLengthEntity
    {
        //主键自增id
        [ExplicitKey]
        public long Id { get; set; } = 0;
        // 关联bdl_member表的主键
        public string Fk_member_id { get; set; }
        public double Body_length { get; set; }
        //肩宽mm
        public double Shoulder_width { get; set; }
        //臂长(上)mm
        public double Arm_length_up { get; set; }
        //臂长(下)mm
        public double Arm_length_down { get; set; }
        //腿长(上)mm
        public double Leg_length_up { get; set; }
        //腿长(下)mm
        public double Leg_length_down { get; set; }
    }
}
