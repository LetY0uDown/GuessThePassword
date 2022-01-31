namespace GuessThePassword.Converters;

using System;
using System.Globalization;
using System.Windows.Data;

public class AttemptsLimitConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return $"Всего: {value}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}