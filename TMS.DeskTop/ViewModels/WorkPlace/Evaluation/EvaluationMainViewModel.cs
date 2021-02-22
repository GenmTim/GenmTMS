using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;

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
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

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

        private void NavigationPage(string obj)
        {
            regionManager.Regions[RegionToken.EvaluationMainContent].RequestNavigate(obj);
        }
    }
}
