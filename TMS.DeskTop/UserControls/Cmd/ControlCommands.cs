using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TMS.DeskTop.UserControls.Cmd
{
    public static class ControlCommands
    {
        public static RoutedCommand CompleteCheckCmd { get; } = new RoutedCommand(nameof(CompleteCheckCmd), typeof(ControlCommands));
    }
}
