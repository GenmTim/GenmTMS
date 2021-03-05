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
    }
}
