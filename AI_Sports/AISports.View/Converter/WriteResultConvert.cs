using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace AI_Sports.AISports.View.Converter
{
    class WriteResultConvert : IValueConverter
    {
       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = "";
            switch (value)
            {
                case 0:
                    result = "待写入";
                    break;
                case 1:
                    result = "成功";
                    break;
                case 2:
                    result = "失败";
                    break;
                case 3:
                    result = "超时";
                    break;
                default:
                    break;
            }
            return result;
        }

       

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
