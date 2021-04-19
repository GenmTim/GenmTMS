using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

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
        private readonly IRegionManager regionManager;

        public PersonalInfoViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            this.eventAggregator.GetEvent<UpdateResumeEvent>().Subscribe((resume) =>
            {
                Resume = new Resume { Name = resume.Name };
            });
        }


        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string view)
        {
            if (view == null)
            {
                return;
            }
            RegionHelper.RequestNavigate(regionManager, RegionToken.PersonalInfoContent, view);
        }

    }
}
