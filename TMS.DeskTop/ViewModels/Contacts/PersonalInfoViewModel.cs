using Prism.Events;
using Prism.Mvvm;
using System.IO;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class Resume
    {
        public string Name;
        public string Url;
    }

    public class PersonalInfoViewModel : BindableBase
    {
        public class UpdateResumeEvent : PubSubEvent<FileInfo> { }

        private Resume resume;
        public Resume Resume
        {
            get => resume;
            set
            {
                resume = value;
                if (resume == null)
                {
                    IsHasResume = false;
                }
                else
                {
                    IsHasResume = true;
                }
                RaisePropertyChanged();
            }
        }

        private bool isHasResume;
        public bool IsHasResume
        {
            get => isHasResume;
            set
            {
                isHasResume = value;
                RaisePropertyChanged();
            }
        }

        private readonly IEventAggregator eventAggregator;

        public PersonalInfoViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<UpdateResumeEvent>().Subscribe((resume) =>
            {
                Resume = new Resume { Name = resume.Name };
            });
        }
    }
}
