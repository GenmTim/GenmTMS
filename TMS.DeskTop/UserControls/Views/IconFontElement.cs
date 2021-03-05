using System;
using System.Windows;

namespace TMS.DeskTop.UserControls.Views
{
    class IconFontElement
    {
        public static readonly DependencyProperty GeometryProperty = DependencyProperty.RegisterAttached(
           "Geometry", typeof(String), typeof(IconFontElement), new PropertyMetadata(default(String)));

        public static void SetGeometry(DependencyObject element, String value)
            => element.SetValue(GeometryProperty, value);

        public static String GetGeometry(DependencyObject element)
            => (String)element.GetValue(GeometryProperty);

        public static readonly DependencyProperty IconNameProperty = DependencyProperty.RegisterAttached(
            "IconName", typeof(String), typeof(IconFontElement), new PropertyMetadata(default(String)));

        public static void SetIconName(DependencyObject element, String value)
            => element.SetValue(IconNameProperty, value);

        public static String GetIconName(DependencyObject element)
            => (String)element.GetValue(IconNameProperty);
    }
}
