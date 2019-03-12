using AI_Sports.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AI_Sports.Util
{
    /// <summary>
    /// 编辑训练活动页面，分组头的转换器 转换为活动名（轮次）
    /// </summary>
    class EditActivityGroupHeadConvert : IValueConverter
    {
        TrainingActivityService trainingActivityService = new TrainingActivityService();
        /// <summary>
        /// 传入活动类型 根据课程id和活动类型查找目标轮次
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string activityType = "0";
            if ("力量循环".Equals(value.ToString()))
            {
                activityType = "0";
            }
            else if ("力量耐力循环".Equals(value.ToString()))
            {
                activityType = "1";
            }
            //目标训练轮次
            int? targetTurnNum = trainingActivityService.GetTargetTurnNumByType(activityType);
            //拼接成活动名（X轮次的形式）
            string groupHead = value.ToString() + "(" + targetTurnNum + "轮次" + ")";
            return groupHead;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
