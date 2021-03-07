using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using TMS.DeskTop.Tools.Helper;

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

        private string timestampStr;


        public BackNavigationViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.GoBackCommand = new DelegateCommand(GoBack);
            timestampStr = TimeHelper.GetNowTimeStamp().ToString();
        }

        public DelegateCommand GoBackCommand { get; private set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Title = navigationContext.Parameters.GetValue<string>("title");
            journal = navigationContext.NavigationService.Journal;
        }

        private void GoBack()
        {
            journal?.GoBack();
        }
    }
}
