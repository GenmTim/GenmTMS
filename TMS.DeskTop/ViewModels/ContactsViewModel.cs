using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels
{
    public class User
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class ContactsViewModel
    {
        private IRegionManager regionManager;



        public ContactsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

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
