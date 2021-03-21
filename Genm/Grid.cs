using System.Windows.Input;

namespace Genm
{
    public class Grid : System.Windows.Controls.Grid
    {
        public Grid()
        {
            this.Focusable = true;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            this.Focus();
        }
    }
}
