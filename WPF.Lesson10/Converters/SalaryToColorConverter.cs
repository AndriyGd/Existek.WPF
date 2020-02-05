using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace WPF.Lesson10.Converters
{
    class SalaryToColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double salary)) return Brushes.Transparent;

            if (salary >= 3000 && salary <= 5000) return Brushes.Red;
            if (salary > 5000 && salary <= 7000) return Brushes.Yellow;
            if (salary > 7000 && salary <= 9000) return Brushes.Green;

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
