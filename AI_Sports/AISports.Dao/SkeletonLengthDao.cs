using AI_Sports.AISports.Entity;
using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Dao
{
    class SkeletonLengthDAO
    {
        public int insertSkeletonLengthRecord(SkeletonLengthEntity skeletonLengthEntity)
        {
            using (var conn = DbUtil.getConn())
            {
                const string insert = "INSERT INTO bdl_skeleton_length (`fk_member_id`, `body_length`, `shoulder_width`, `arm_length_up`, `arm_length_down`, `leg_length_up`, `leg_length_down`) VALUES (@Fk_member_id, @Body_length, @Shoulder_width, @Arm_length_up, @Arm_length_down, @Leg_length_up, @Leg_length_down)";

                return conn.Execute(insert, skeletonLengthEntity);

            }
        }
    }
}
