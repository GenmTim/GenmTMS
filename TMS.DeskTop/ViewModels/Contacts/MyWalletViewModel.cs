using Prism.Commands;
using Prism.Regions;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class MyWalletViewModel
    {
        private readonly IRegionManager regionManager;

        public MyWalletViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCmd { get; set; }

        private void NavigationPage(string view)
        {
            RouteHelper.Goto(regionManager, typeof(MyWalletViewModel), view);
        }
    }
}
