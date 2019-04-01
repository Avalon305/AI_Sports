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
    /// <summary>
    /// 返回的登陆页面
    /// </summary>
    public enum LoginPageStatus
    {
        /// <summary>
        /// 用户登录页
        /// </summary>
        UserPage,
        /// <summary>
        /// 教练登陆页面
        /// </summary>
        CoachPage,
        /// <summary>
        /// 重复登录
        /// </summary>
        RepeatLogins,
        /// <summary>
        /// 未识别的ID
        /// </summary>
        UnknownID,
    }
    /// <summary>
    /// 训练计划模板
    /// </summary>
    public enum PlanTemplate
    {
        /// <summary>
        /// 力量循环
        /// </summary>
        StrengthCycle,
        /// <summary>
        /// 耐力循环
        /// </summary>
        EnduranceCycle,
        /// <summary>
        /// 力量耐力循环
        /// </summary>
        StrengthEnduranceCycle
    }
}
