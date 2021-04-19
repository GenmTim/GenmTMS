using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering
{
    class EnteringStepViewModel : BindableBase
    {
        public class UpdateEntryFileInfo : PubSubEvent<FileInfo> { }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public FileInfo EntryFileInfo;


        public EnteringStepViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<UpdateEntryFileInfo>().Subscribe((fileInfo) =>
            {
                EntryFileInfo = fileInfo;
            });
        }
    }
}
