using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;
using TMS.DeskTop.Views.Recruitment.Requirements.Subitem;

namespace TMS.DeskTop.ViewModels.Recruitment.Requirements.Subitem
{


    public class ActivitiesRequirementsViewModel
    {
        public ObservableCollection<String> EvaluationRuleList { get; set; } = new ObservableCollection<String>();

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        private string selectedItem;
        public string SelectedItem { get => selectedItem;

            set
            {
                selectedItem = value;
                jumpPage(selectedItem);
            }
        }

        private void jumpPage(String selectedItem)
        {
            Console.WriteLine(selectedItem);
        }

        public ActivitiesRequirementsViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.regionManager = regionManager;
            this.moduleCatalog = moduleCatalog;

            this.EvaluationRuleList.Add("你好1");
            this.EvaluationRuleList.Add("你好2");
            this.EvaluationRuleList.Add("你好3");
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
            BackNavigationCommand = new DelegateCommand<string>(BackNavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string obj)
        {
            regionManager.Regions[RegionToken.RecruitmentContent].RequestNavigate(obj);
        }

        public DelegateCommand<string> BackNavigationCommand { get; private set; }

        private void BackNavigationPage(string title)
        {
            var param = new NavigationParameters();
            param.Add("title", title);
            param.Add("obj", typeof(TalentPoolView));
            regionManager.RequestNavigate(RegionToken.RecruitmentContent, "BackNavigationView", param);
        }

    }
}
