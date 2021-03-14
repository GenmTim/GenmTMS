using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
