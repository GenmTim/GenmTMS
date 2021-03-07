using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.Attendance
{
    class AttendanceMainViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;



        public AttendanceMainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string view)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.AttendanceMainContent, view);
        }
    }
}
