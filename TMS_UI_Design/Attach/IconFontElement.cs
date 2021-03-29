using System;
using System.Windows;
using System.Windows.Media;

namespace TMS.DeskTop.UserControls.Attach
{
    class IconFontElement
    {
        public static readonly DependencyProperty GeometryProperty = DependencyProperty.RegisterAttached(
           "Geometry", typeof(string), typeof(IconFontElement), new PropertyMetadata(default(string)));

        public static void SetGeometry(DependencyObject element, string value)
            => element.SetValue(GeometryProperty, value);

        public static string GetGeometry(DependencyObject element)
            => (string)element.GetValue(GeometryProperty);

        public static readonly DependencyProperty NameProperty = DependencyProperty.RegisterAttached(
            "Name", typeof(string), typeof(IconFontElement), new PropertyMetadata(default(string)));

        public static void SetName(DependencyObject element, string value)
            => element.SetValue(NameProperty, value);

        public static string GetName(DependencyObject element)
            => (string)element.GetValue(NameProperty);

        public static readonly DependencyProperty ColorProperty = DependencyProperty.RegisterAttached(
            "Color", typeof(Brush), typeof(IconFontElement), new PropertyMetadata(default(Brush)));

        public static void SetColor(DependencyObject element, Brush value)
            => element.SetValue(ColorProperty, value);

        public static Brush GetColor(DependencyObject element)
            => (Brush)element.GetValue(ColorProperty);

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.RegisterAttached("Size", typeof(double), typeof(IconFontElement));

        public static double GetSize(DependencyObject obj)
        {
            return (double)obj.GetValue(SizeProperty);
        }

        public static void SetSize(DependencyObject obj, double value)
        {
            obj.SetValue(SizeProperty, value);
        }
    }
}
