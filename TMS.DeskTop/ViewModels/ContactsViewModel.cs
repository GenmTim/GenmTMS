using Prism.Commands;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels
{
    public class ContactsViewModel
    {
        private IRegionManager regionManager;



        public ContactsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string view)
        {
            if (view != null && !view.Equals(""))
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.ContactsContent, view);
            }
        }

        public bool ToggleBtnIsChecked { get; set; }
    }
}
