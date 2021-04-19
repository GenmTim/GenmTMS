using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.Recruitment
{
    class RecruitmentNavigationViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public RecruitmentNavigationViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            this.NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string view)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.RecruitmentContent, view);
        }
    }
}
