using System.Windows.Input;

namespace Genm
{
    public class TextBox : System.Windows.Controls.TextBox
    {
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
        }
    }
}
