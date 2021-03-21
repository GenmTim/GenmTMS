using Prism.Commands;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.Auth
{
    public class AuthMainViewModel
    {
        private readonly IRegionManager regionManager;

        public AuthMainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }


        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.AuthMainContent, obj);
        }
    }
}
