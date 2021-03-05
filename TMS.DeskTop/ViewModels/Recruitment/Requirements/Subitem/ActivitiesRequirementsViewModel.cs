using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.Recruitment.Requirements.Subitem
{


    public class ActivitiesRequirementsViewModel
    {
        public ObservableCollection<String> EvaluationRuleList { get; set; } = new ObservableCollection<String>();

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        private string selectedItem;
        public string SelectedItem
        {
            get => selectedItem;

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
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string view)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.RecruitmentContent, view);
        }
    }
}
