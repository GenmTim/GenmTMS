using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;

namespace TMS.DeskTop.ViewModels
{
    public class MainWindowViewModel : BaseDialogViewModel
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private double windowWidth = 1224;
        public double WindowWidth { get => windowWidth; set { SetProperty(ref windowWidth, value);  } }

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IModuleCatalog moduleCatalog) : base(eventAggregator)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCmd = new DelegateCommand<string>(NavigationPage);

        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string viewName)
        {
            RouteHelper.Route(regionManager, typeof(MainWindow), Router.Instance.ConverterViewNameToType(viewName));
        }
    }
}
