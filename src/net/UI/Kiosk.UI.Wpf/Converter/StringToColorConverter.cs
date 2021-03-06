using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Kiosk.UI.Wpf.Converter;

public class StringToColorConverter
    : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (SolidColorBrush)new BrushConverter().ConvertFrom($"#{value}");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
