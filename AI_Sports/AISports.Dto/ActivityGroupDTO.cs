using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Dto
{
    class ActivityGroupDTO
    {

        public long Id { get; set; }
        public long Fk_member_id { get; set; }
        public string Member_id { get; set; }
        /// 训练活动id
        public long Fk_training_activity_id { get; set; }
        /// 训练活动类型编码
        public string Activity_type { get; set; }
        /// 设备名
        public string Device_code { get; set; }
        /// 设备序号
        public int? Device_order_number { get; set; }
        /// 训练模式
        public string Training_mode { get; set; }
        /// 座位高度cm
        public int? Seat_height { get; set; }
        /// 靠背距离cm
        public int? Backrest_distance { get; set; }
        /// 前方限制cm
        public int? Front_limit { get; set; }
        /// 后方限制cm
        public int? Back_limit { get; set; }
        /// 顺向力
        public double? Consequent_force { get; set; }
        /// 反向力
        public double? Reverse_force { get; set; }
        /// 功率
        public double? Power { get; set; }
        /// <summary>
        /// 杠杆长度 cm
        /// </summary>
        public int? Lever_length { get; set; }
        /// <summary>
        /// 杠杆角度
        /// </summary>
        public double? Lever_angle { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extra_setting { get; set; }
        

        //训练活动表部分属性
        public long Fk_training_course_id { get; set; }
        /// 目标轮次数量，目标在这一圈训练几轮
        public int? Target_turn_number { get; set; }
        /// 当前轮次计数
        public int? current_turn_number { get; set; } 
        /// 是否完成 默认0:未完成。1:完成)
        public Boolean? Is_complete { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }
        public DateTime? Gmt_modified { get; set; }

        /// <summary>
        /// 展示值
        /// </summary>
        public String Code_d_value { get; set; }

    }
}
