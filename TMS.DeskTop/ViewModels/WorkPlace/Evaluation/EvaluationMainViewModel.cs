using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
    class EvaluationMainViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;
        private IRegionNavigationJournal journal;

        public EvaluationMainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            journal = navigationContext.NavigationService.Journal;
        }

        private void NavigationPage(string view)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.EvaluationMainContent, view);
        }
    }
}
