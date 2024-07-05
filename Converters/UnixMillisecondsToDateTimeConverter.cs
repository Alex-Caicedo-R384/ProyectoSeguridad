using System;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace ProyectoSeguridad.Converters
{
    public class UnixMillisecondsToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long milliseconds)
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds).DateTime;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
