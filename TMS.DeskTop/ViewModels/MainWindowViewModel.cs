using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;

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

        private void NavigationPage(string view)
        {
            string go_url = RouteHelper.GetViewPath(view);
            string now_url = RouteHelper.GetViewPath(nameof(MainWindow));
            string next_url = RouteHelper.GetNextRoute(now_url, go_url);

            if (!next_url.Equals(""))
            {
                NavigationParameters param = new NavigationParameters();
                param.Add("url", go_url);
                RegionHelper.RequestNavigate(regionManager, RegionToken.MainContent, view, param);
            }
        }
    }
}
