using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// 进程页面VO
/// <author>
/// <name></name>
/// <date>2019-02-07</date>
/// </author>
/// </summary>

namespace AI_Sports.AISports.Entity
{
    [DataContract]
    public class ProcessVO
    {
        /// <summary>
        /// 平均值
        /// </summary>
        [DataMember]
        public double? AvgValue { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        public DateTime? ProcessTime { get; set; }
        public override string ToString()
        {
            return $"{nameof(AvgValue)}: {AvgValue}, {nameof(ProcessTime)}: {ProcessTime}";
        }
    }
}
