using System.Windows;
using System.Windows.Controls;
using TMS.Core.Data.Enums;

namespace TMS.DeskTop.UserControls.Views
{
    /// <summary>
    /// Kalendar.xaml 的交互逻辑
    /// </summary>
    public partial class Kalendar : UserControl
    {
        public Kalendar()
        {
            InitializeComponent();
        }

        public CalendarViewType SelectedViewType
        {
            get { return (CalendarViewType)GetValue(SelectedViewTypeProperty); }
            set { }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedViewTypeProperty =
            DependencyProperty.Register("SelectedViewType", typeof(CalendarViewType), typeof(Kalendar), new PropertyMetadata(default(CalendarViewType)));




    }
}
