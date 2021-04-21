
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Windows.Controls;
using TMS.Core.Event;

namespace TMS.DeskTop.Views.Register.Question
{
    public class QuestionMainPageModel : BindableBase
    {
        IEventAggregator eventAggregator;

        private string educationInfoState;
        public string EducationInfoState 
        {
            get => educationInfoState;
            set
            {
                educationInfoState = value;
                RaisePropertyChanged();
            }
        }

        private string workInfoState;
        public string WorkInfoState 
        {
            get => workInfoState;
            set
            {
                workInfoState = value;
                RaisePropertyChanged();
            }
        }

        public QuestionMainPageModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.NextNavigateCmd = new DelegateCommand<string>(GoNext);
            this.BackCmd = new DelegateCommand(GoBack);
            EducationInfoState = "待填写";
            WorkInfoState = "待填写";
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
                    EducationInfoState = "填写完成";
                }
                else if (view == "WorkExperience")
                {
                    eventAggregator.GetEvent<JumpEvent>().Publish(new WorkExperience.Question1Page(eventAggregator));
                    WorkInfoState = "填写完成";
                }
            }
        }

        public DelegateCommand BackCmd { get; private set; }

        private void GoBack()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(new QuestionMainPage(eventAggregator));
        }
    }

    /// <summary>
    /// QuestionMainPage.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionMainPage : UserControl
    {
        IEventAggregator eventAggregator;

        public string EducationInfoState { get; set; }
        public string WorkInfoState { get; set; }

        public QuestionMainPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.DataContext = new QuestionMainPageModel(eventAggregator); ;
            this.eventAggregator = eventAggregator;
            this.NextNavigateCmd = new DelegateCommand<string>(GoNext);
            this.BackCmd = new DelegateCommand(GoBack);
            EducationInfoState = "待填写";
            WorkInfoState = "待填写";
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
                    EducationInfoState = "填写完成";
                }
                else if (view == "WorkExperience")
                {
                    eventAggregator.GetEvent<JumpEvent>().Publish(new WorkExperience.Question1Page(eventAggregator));
                    WorkInfoState = "填写完成";
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
