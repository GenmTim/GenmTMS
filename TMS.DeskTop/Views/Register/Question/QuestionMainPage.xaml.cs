
using Prism.Commands;
using Prism.Events;
using System.Windows.Controls;
using TMS.Core.Event;

namespace TMS.DeskTop.Views.Register.Question
{
    /// <summary>
    /// QuestionMainPage.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionMainPage : UserControl
    {
        IEventAggregator eventAggregator;
        public QuestionMainPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.DataContext = this;
            this.eventAggregator = eventAggregator;
            this.NextNavigateCmd = new DelegateCommand<string>(GoNext);
            this.BackCmd = new DelegateCommand(GoBack);
        }

        public DelegateCommand<string> NextNavigateCmd { get; set; }

        private void GoNext(string view)
        {
            if (view.Equals("Next"))
                eventAggregator.GetEvent<JumpEvent>().Publish(new QuestionEndPage(eventAggregator));
            else
            {
                if (view == "BasicInfo")
                {
                    eventAggregator.GetEvent<JumpEvent>().Publish(new BasicInfo.Question1Page(eventAggregator));
                }
                else if (view == "EducationExperience")
                {
                    eventAggregator.GetEvent<JumpEvent>().Publish(new EducationExperience.Question1Page(eventAggregator));
                }
                else if (view == "WorkExperience")
                {
                    eventAggregator.GetEvent<JumpEvent>().Publish(new WorkExperience.Question1Page(eventAggregator));
                }
            }
        }

        public DelegateCommand BackCmd { get; private set; }

        private void GoBack()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(new QuestionMainPage(eventAggregator));
        }
    }
}
