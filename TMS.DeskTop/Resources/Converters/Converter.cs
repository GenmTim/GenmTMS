using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TMS.DeskTop.Resources.Converters
{
    class LinearGradientConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            Color color = (Color)ColorConverter.ConvertFromString((string)value); ;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = new System.Windows.Point(0, 0.5);
            linearGradientBrush.EndPoint = new System.Windows.Point(8, 0.5);
            linearGradientBrush.GradientStops.Add(new GradientStop(color, 0));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 1));
            return linearGradientBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class FetchFirstCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            String str = (String)value;
            return str.Length > 0 ? str.Substring(0, 1) : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
