using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;
using TMS.Core.Service;
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
        private readonly IDialogHostService dialogHostService;

        public MainWindowViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog, IDialogHostService dialogHostService)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            this.dialogHostService = dialogHostService;
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
   
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string viewName)
        {
            RouteHelper.Route(regionManager, typeof(MainWindow), Router.Instance.ConverterViewNameToType(viewName));
            if (true)
            {
                this.dialogHostService.ShowDialog("NewUserQuestionDialog");
            }
        }
    }
}
