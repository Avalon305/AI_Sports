using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Dto
{
    public class SettingInfoDTO
    {
        public int Current_course_count { get; set; }
        public int Target_course_count { get; set; }
        public long Course_id { get; set; }
        public bool Is_open_fat_reduction { get; set; }
        public string Memeber_id { get; set; }
        public long User_id { get; set; }
        public long Activity_id { get; set; }


    }
}
