
using System.Windows.Controls;


namespace TMS.DeskTop.Views.WorkPlace.Evaluation
{
    /// <summary>
    /// NewEvaluationRuleView.xaml 的交互逻辑
    /// </summary>
    public partial class NewEvaluationRuleView : UserControl
    {
        private static string title = "新建考勤规则";
        public static string Title { get => title; set => title = value; }

        public NewEvaluationRuleView()
        {
            InitializeComponent();
        }

    }
}
