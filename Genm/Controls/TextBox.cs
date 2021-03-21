using System.Windows.Input;

namespace Genm.Controls
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
        }
    }
}
