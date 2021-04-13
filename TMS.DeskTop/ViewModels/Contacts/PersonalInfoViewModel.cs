using Prism.Mvvm;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class ResumeFile
    {
        public string Name;
        public string Url;
    }

    public class PersonalInfoViewModel : BindableBase
    {
        private ResumeFile resumeFile;
        public ResumeFile ResumeFile
        {
            get => resumeFile;
            set
            {
                resumeFile = value;
                if (resumeFile != null)
                {
                    IsHasResumeFile = true;
                }
                RaisePropertyChanged();
            }
        }

        private bool isHasResumeFile;
        public bool IsHasResumeFile
        {
            get => isHasResumeFile;
            set
            {
                isHasResumeFile = value;
                RaisePropertyChanged();
            }
        }

        public PersonalInfoViewModel()
        {
        }
    }
}
