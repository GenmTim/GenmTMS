using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
    class EvaluationMainViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;
        private IRegionNavigationJournal journal;

        private ObservableCollection<QuestionnaireVO> questionnaireVOList;
        public ObservableCollection<QuestionnaireVO> QuestionnaireVOList
        {
            get => questionnaireVOList;
            set
            {
                questionnaireVOList = value;
                RaisePropertyChanged();
            }
        }


        public EvaluationMainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCmd = new DelegateCommand<string>(NavigationPage);
            this.QuestionnaireVOList = new ObservableCollection<QuestionnaireVO>()
            {
                new QuestionnaireVO { Name="李立清", ContentList=new List<string>{ "sdsd" }, Date="sdsd", Time="", Title=""  }
            };
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
