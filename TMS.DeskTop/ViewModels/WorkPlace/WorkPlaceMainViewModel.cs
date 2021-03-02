using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    class WorkPlaceMainViewModel : BindableBase
    {
        private ViewInfo viewInfo = new ViewInfo { Title = "工作台", IconFont = "\xe79f" };
        public ViewInfo ViewInfo
        {
            get { return this.viewInfo; }
            set { SetProperty(ref viewInfo, value); }
        }

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public WorkPlaceMainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string obj)
        {
            regionManager.Regions[RegionToken.WorkPlaceTabContent].RequestNavigate(obj);
        }
    }
}
