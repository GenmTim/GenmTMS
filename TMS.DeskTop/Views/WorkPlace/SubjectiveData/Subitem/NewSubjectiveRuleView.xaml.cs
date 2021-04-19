using System.Windows.Controls;
using TMS.Core.Data.Value;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Common.ViewModels;

namespace TMS.DeskTop.Views.WorkPlace.SubjectiveData.Subitem
{
    /// <summary>
    /// NewEvaluationRuleView.xaml 的交互逻辑
    /// </summary>
    public partial class NewSubjectiveRuleView : UserControl
    {
        private static string title = "新建主观评价规则";
        public static string Title { get => title; set => title = value; }

        public NewSubjectiveRuleView(IDialogHostService dialogHost)
        {
            InitializeComponent();
            InitControl();
            selectReciverBox.DataContext = new VariableListBoxModel(dialogHost);
        }

        private void InitControl()
        {
            InitStartTimeControl();
            InitEndCommitTimeControl();
        }

        private void InitStartTimeControl()
        {
            this.startCommitTime.DataContext = new MultiValueComboBoxModel()
            {
                OneValueList = Date.Weaks,
                TwoValueList = Date.Hours,
                ThreeValueList = Date.Minutes,
            };
        }

        private void InitEndCommitTimeControl()
        {
            this.endCommitTime.DataContext = new MultiValueComboBoxModel()
            {
                OneValueList = Date.Weaks,
                TwoValueList = Date.Hours,
                ThreeValueList = Date.Minutes,
            };
        }
    }
}
