using Prism.Commands;
using Prism.Events;
using System.Windows.Controls;
using TMS.Core.Event;

namespace TMS.DeskTop.Views.Register.Question
{
    /// <summary>
    /// Question2View.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionEndPage : UserControl
    {
        IEventAggregator eventAggregator;
        public QuestionEndPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.DataContext = this;
            this.eventAggregator = eventAggregator;
            this.NextNavigateCmd = new DelegateCommand(GoNext);
            this.BackCmd = new DelegateCommand(GoBack);
        }

        public DelegateCommand NextNavigateCmd { get; private set; }

        private void GoNext()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(null);
        }

        public DelegateCommand BackCmd { get; private set; }

        private void GoBack()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(new QuestionMainPage(eventAggregator));
        }
    }
}
