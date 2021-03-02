using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
