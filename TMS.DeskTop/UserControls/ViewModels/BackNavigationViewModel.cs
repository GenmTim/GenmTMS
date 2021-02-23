using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;

namespace TMS.DeskTop.UserControls.ViewModels
{
    class BackNavigationViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;


        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public BackNavigationViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.GoBackCommand = new DelegateCommand(GoBack);
        }

        public DelegateCommand GoBackCommand { get; private set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _title = navigationContext.Parameters.GetValue<string>("title");
            var obj = navigationContext.Parameters.GetValue<string>("obj");
            regionManager.RequestNavigate(RegionToken.BackNavigationContent, obj);
            journal = navigationContext.NavigationService.Journal;
        }

        private void GoBack()
        {
            journal?.GoBack();
        }
    }
}
