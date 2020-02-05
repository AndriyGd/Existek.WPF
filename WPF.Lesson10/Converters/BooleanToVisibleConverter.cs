using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace WPF.Lesson10.Converters
{
    class BooleanToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool isChecked)) return Visibility.Collapsed;

            return isChecked ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
