using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Event;

namespace TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions
{
    /// <summary>
    /// Question2View.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionEndPage : UserControl
    {
        public QuestionEndPage(IRegionManager regionManager)
        {
            InitializeComponent();
            this.NextNavigateCmd = new DelegateCommand(() =>
            {
                //eventAggregator.GetEvent<JumpEvent>().Publish("测试");
            });
        }

        public DelegateCommand NextNavigateCmd { get; set; }
    }
}
