
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TMS.Core.Data.Value;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Common.ViewModels;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Views.WorkPlace.Evaluation
{
    /// <summary>
    /// NewEvaluationRuleView.xaml 的交互逻辑
    /// </summary>
    public partial class NewEvaluationRuleView : UserControl
    {
        private static string title = "新建考勤规则";
        public static string Title { get => title; set => title = value; }

        public NewEvaluationRuleView(IDialogHostService dialogHost)
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
