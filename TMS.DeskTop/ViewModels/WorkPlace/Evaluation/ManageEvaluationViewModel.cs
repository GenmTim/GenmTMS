using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
    public class EvaluationRule
    {
        public String Icon { get; set; }
        public String Name { get; set; }
        public String Auditor { get; set; }
        public String Examiner { get; set; }
        public String Examinee { get; set; }
        public String Time { get; set; }
        public String Content { get; set; }
        public String FIcon { get; set; }
        public String FIconColor { get; set; }
    }


    class ManageEvaluationViewModel : BindableBase
    {
        private ObservableCollection<EvaluationRule> evaluationRuleList = new ObservableCollection<EvaluationRule>();

        public ObservableCollection<EvaluationRule> EvaluationRuleList
        {
            get
            {
                return evaluationRuleList;
            }
            set
            {
                evaluationRuleList = value;
            }
        }

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;
        private IRegionNavigationJournal journal;


        public ManageEvaluationViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
            BackNavigationCommand = new DelegateCommand<string>(BackNavigationPage);

            evaluationRuleList.Add(new EvaluationRule
            {
                Name = "每日健康情况上报",
                Examiner = "直属上级",
                Time = "次日\n00:00",
                Content = "本人体温。。。。",
                FIcon = "\xe6f0",
                FIconColor = "#FF34C724",
            });
            evaluationRuleList.Add(new EvaluationRule
            {
                Name = "工作月报",
                Examiner = "直属上级",
                Time = "次月\n1日 00:00",
                Content = "本月目标、进展同步、下月计划、感想抒发...",
                FIcon = "\xe65b",
                FIconColor = "#FF7F3BF5",
            });
            evaluationRuleList.Add(new EvaluationRule
            {
                Name = "每日健康情况上报",
                Examiner = "直属上级",
                Time = "当月\n19日 00:00",
                Content = "员工姓名、业绩、做得好的具体事例、待改...",
                FIcon = "\xe622",
                FIconColor = "#FF00D6B9",
            });
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string obj)
        {
            regionManager.RequestNavigate(RegionToken.EvaluationMainContent, obj, arg =>
            {
                journal = arg.Context.NavigationService.Journal;
            });
            regionManager.Regions[RegionToken.EvaluationMainContent].RequestNavigate(obj);
        }

        public DelegateCommand<string> BackNavigationCommand { get; private set; }

        private void BackNavigationPage(string obj)
        {
            var param = new NavigationParameters();
            param.Add("title", "新建考评规则");
            param.Add("obj", "NewEvaluationRuleView");
            regionManager.RequestNavigate(RegionToken.EvaluationMainContent, "BackNavigationView", arg =>
            {
                journal = arg.Context.NavigationService.Journal;
            }, param);
        }



    }
}
