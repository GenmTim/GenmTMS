using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
