using System.Windows;

namespace TMS.DeskTop.UserControls.Attach
{
    public class VisualAttach
    {
        public static readonly DependencyProperty LengthProperty = DependencyProperty.RegisterAttached(
"Length", typeof(double), typeof(VisualAttach), new PropertyMetadata(default(double)));

        public static void SetLength(DependencyObject element, double value)
            => element.SetValue(LengthProperty, value);

        public static double GetLength(DependencyObject element)
    => (double)element.GetValue(LengthProperty);
    }
}
