using System.Windows;

namespace TMS.DeskTop.UserControls.Attach
{
    public class KeyValueAttach
    {
        public static readonly DependencyProperty KeyProperty = DependencyProperty.RegisterAttached(
"Key", typeof(string), typeof(KeyValueAttach), new PropertyMetadata(default(string)));

        public static void SetKey(DependencyObject element, string value)
            => element.SetValue(KeyProperty, value);

        public static string GetKey(DependencyObject element)
    => (string)element.GetValue(KeyProperty);

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
    "Value", typeof(string), typeof(KeyValueAttach), new PropertyMetadata(default(string)));

        public static void SetValue(DependencyObject element, string value)
            => element.SetValue(ValueProperty, value);

        public static string GetValue(DependencyObject element)
    => (string)element.GetValue(ValueProperty);
    }
}
