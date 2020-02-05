using System;
using System.Windows.Data;
using System.Globalization;

namespace WPF.Lesson10.Converters
{
    class CityStreetToFullAddressConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(values[0] is string city) || string.IsNullOrWhiteSpace(city)) return string.Empty;
            if (!(values[1] is string street) || string.IsNullOrWhiteSpace(street)) return string.Empty;

            return $"{city}, {street}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] {"Hello", "World"};
        }
    }
}
