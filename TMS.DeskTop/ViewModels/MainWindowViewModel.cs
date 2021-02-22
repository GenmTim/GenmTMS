using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public MainWindowViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string obj)
        {
            regionManager.Regions[RegionToken.MainContent].RequestNavigate(obj);
        }
    }
}
