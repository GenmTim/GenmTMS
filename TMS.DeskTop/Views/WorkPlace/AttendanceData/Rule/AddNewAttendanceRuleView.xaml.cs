using System.Windows.Controls;

namespace TMS.DeskTop.Views.WorkPlace.AttendanceData.Rule
{
    /// <summary>
    /// AddNewAttendanceRuleView.xaml 的交互逻辑
    /// </summary>
    public partial class AddNewAttendanceRuleView : UserControl
    {
        public AddNewAttendanceRuleView()
        {
            InitializeComponent();
        }

        public static string Title { get; internal set; } = "新建考勤规则";
    }
}
