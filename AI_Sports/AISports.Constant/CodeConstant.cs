using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Constant
{
    /// <summary>
    /// 枚举
    /// </summary>
    public enum DatacodeTypeEnum
    {
        /// <summary>
        /// 父级编码列表 0
        /// </summary>
        DList,
        /// <summary>
        /// 性别
        /// </summary>
        Sex,
        /// <summary>
        /// 设备类型
        /// </summary>
        DeviceType,
       
    }

    public enum CycleTypeEnum 
    {
        力量循环 = 0,
        力量耐力循环 = 1,
    }

    public enum TrainModeEnum : byte
    {
        标准模式 = 0,
        适应性模式 = 1,
        等速模式 = 2,
        心率模式 = 3,
        增肌模式 = 4
    }
}
