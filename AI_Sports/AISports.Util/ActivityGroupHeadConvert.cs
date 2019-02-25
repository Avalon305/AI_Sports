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
