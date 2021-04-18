using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.Contacts;

namespace TMS.DeskTop.ViewModels.Contacts
{
    class MyGroupViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public MyGroupViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string view)
        {
            RouteHelper.Goto(regionManager, typeof(MyGroupView), view);
        }
    }
}
