using System.Windows;

namespace TMS.DeskTop.UserControls.Views
{
    public class ValueAttach
    {
        public static readonly DependencyProperty IntegerProperty = DependencyProperty.RegisterAttached(
   "Integer", typeof(int), typeof(ValueAttach), new PropertyMetadata(default(int)));

        public static void SetInteger(DependencyObject element, int value)
            => element.SetValue(IntegerProperty, value);

        public static int GetInteger(DependencyObject element)
    => (int)element.GetValue(IntegerProperty);

        public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached(
    "Text", typeof(string), typeof(ValueAttach), new PropertyMetadata(default(string)));

        public static void SetText(DependencyObject element, string value)
            => element.SetValue(TextProperty, value);

        public static string GetText(DependencyObject element)
    => (string)element.GetValue(TextProperty);
    }
}
