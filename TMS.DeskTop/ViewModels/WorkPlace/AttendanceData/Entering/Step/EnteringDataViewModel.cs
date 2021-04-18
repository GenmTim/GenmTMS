using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using TMS.Core.Event;
using static TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering.EnteringStepViewModel;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering.Step
{
    public class EnteringDataViewModel : BindableBase
    {
        public class InComingFileEvent : PubSubEvent<string> { }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        private bool isHasComingFile = false;
        public bool IsHasComingFile
        {
            get => isHasComingFile;
            set
            {
                isHasComingFile = value;
                RaisePropertyChanged();
            }
        }

        private FileInfo inComingFile;
        public FileInfo InComingFile
        {
            get => inComingFile;
            set
            {
                inComingFile = value;
                RaisePropertyChanged();
            }
        }

        private EnteringDataViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NextStepCmd = new DelegateCommand(NextStep);
            this.eventAggregator.GetEvent<InComingFileEvent>().Subscribe((fileFullName) =>
            {
                InComingFile = new FileInfo(fileFullName);
                eventAggregator.GetEvent<UpdateEntryFileInfo>().Publish(InComingFile);
                IsHasComingFile = true;
            });
            this.ClearInComingFileCmd = new DelegateCommand(() =>
            {
                IsHasComingFile = false;
                InComingFile = null;
            });
        }


        public DelegateCommand NextStepCmd { get; private set; }
        public DelegateCommand ClearInComingFileCmd { get; private set; }
        private void NextStep()
        {
            eventAggregator.GetEvent<NextStepEvent>().Publish();
        }
    }
}
