using System.Windows.Controls;

namespace TMS.DeskTop.Views.WorkPlace.Recruitment.Requirements.Subitem
{
    /// <summary>
    /// NewRequirementView.xaml 的交互逻辑
    /// </summary>
    public partial class NewRequirementView : UserControl
    {
        public NewRequirementView()
        {
            InitializeComponent();
        }

        public static string Title { get; internal set; } = "发布招聘需求";
    }
}
