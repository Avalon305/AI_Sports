using AI_Sports.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AI_Sports.Util
{
    /// <summary>
    /// 训练活动分组的head用到的把分组依据的编码转换为展示值“力量循环”或者力量耐力循环
    /// </summary>
    class ActivityGroupHeadConvert : IValueConverter
    {
        TrainingActivityService trainingActivityService = new TrainingActivityService();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string activityType = trainingActivityService.GetActivityType(value.ToString());
            return activityType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
