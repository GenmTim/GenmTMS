using System.Windows.Input;

namespace TMS.DeskTop.UserControls.Cmd
{
    public static class ControlCommands
    {
        public static RoutedCommand CompleteCheckCmd { get; } = new RoutedCommand(nameof(CompleteCheckCmd), typeof(ControlCommands));
    }
}
