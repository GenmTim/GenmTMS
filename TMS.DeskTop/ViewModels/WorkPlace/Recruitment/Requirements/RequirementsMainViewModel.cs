using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.Recruitment;

namespace TMS.DeskTop.ViewModels.WorkPlace.Recruitment.Requirements
{
    class RequirementsMainViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public RequirementsMainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            this.NavigationCommand = new DelegateCommand<string>(NavigationPage);
            this.GoBackToNavigationCmd = new DelegateCommand(GoBackToNavigation);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }
        public DelegateCommand GoBackToNavigationCmd { get; private set; }

        private void NavigationPage(string view)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.RecruitmentRequirementsMainContent, view);
        }

        private void GoBackToNavigation()
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.RecruitmentContent, typeof(RecruitmentNavigationView));
        }
    }
}
