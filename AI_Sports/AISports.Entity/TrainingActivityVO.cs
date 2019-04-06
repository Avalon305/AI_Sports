using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;


namespace AI_Sports.Entity
{
    [Serializable]
    public class TrainingActivityVO
    {
        public long Id { get; set; }
        /// 会员id
        public string Member_id { get; set; }
        /// 外键训练活动记录id
        public long Fk_training_activity_record_id { get; set; }
        /// 设备表中的训练活动类型编码
        //public string Activity_type { get; set; }
        /// 设备在循环中的序号
        public int? Device_order_number { get; set; }
        /// 设备名
        public string Device_code { get; set; }
        /// 训练模式
        public string Training_mode { get; set; }
        /// 向心力
        public double? Consequent_force { get; set; }
        /// 离心力
        public double? Reverse_force { get; set; }
        /// 功率
        public double? Power { get; set; }
        /// 训练个数
        public int? Count { get; set; }
        /// 速度 1位小数 千米每时,暂不上报
        public double? Speed { get; set; }
        /// 距离 千米，两位小数
        public double? Distance { get; set; }
        /// 训练总耗能 单位卡路里
        public double? Energy { get; set; }
        /// 训练时间 单位秒
        public int? Training_time { get; set; }
        /// 平均心率
        public int? Avg_heart_rate { get; set; }
        /// 最大心率
        public int? Max_heart_rate { get; set; }
        /// 最小心率
        public int? Min_heart_rate { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }

        /// 外键训练课程id
        public long Fk_training_course_id { get; set; }
        /// 外键，训练活动ID
        public long Fk_activity_id { get; set; }
        /// 活动表中的训练活动编码：力量循环或者力量耐力循环
        public string Activity_type { get; set; }
        /// 课程轮次计数：等于插入时训练课程表的当前课程计数，标志这条训练活动记录属于第几次的课程
        public int? Course_count { get; set; }
        /// 是否完成 默认0:未完成。1:完成)
        public Boolean? Is_complete { get; set; }
        /// 训练活动记录的创建时间
        public DateTime? Act_gmt_create { get; set; }
        /// <summary>
        /// 存储值
        /// </summary>
        public String Code_s_value { get; set; }

        /// <summary>
        /// 展示值
        /// </summary>
        public String Code_d_value { get; set; }
        /// <summary>
        /// 设备图片存储路径
        /// </summary>
        public String Code_ext_value4 { get; set; }
    }
}
