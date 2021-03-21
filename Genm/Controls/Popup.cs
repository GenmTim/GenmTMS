using System.Windows.Input;

namespace Genm.Controls
{
    public class Popup : System.Windows.Controls.Primitives.Popup
    {
        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            bool isOpen = this.IsOpen;
            base.OnPreviewMouseLeftButtonDown(e);

            // 不让事件再进行传递
            if (isOpen && !this.IsOpen)
                e.Handled = true;
        }


    }
}
