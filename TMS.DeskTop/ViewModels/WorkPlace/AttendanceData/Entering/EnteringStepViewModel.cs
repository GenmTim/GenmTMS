using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.IO;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

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
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<UpdateEntryFileInfo>().Subscribe((fileInfo) =>
            {
                EntryFileInfo = fileInfo;
            });
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.AttendanceEnteringStepContent, obj);
        }
    }
}
