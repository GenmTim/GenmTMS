﻿using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using TMS.Core.Data;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Dialogs.Views;
using TMS.DeskTop.Views.WorkPlace.Evaluation;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
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
        private readonly IDialogHostService dialogHostService;
        //private IRegionNavigationJournal journal;


        public ManageEvaluationViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog, IDialogHostService dialogHostService)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            this.dialogHostService = dialogHostService;
            NavigationCmd = new DelegateCommand<string>(NavigationPage);

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

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private async void NavigationPage(string view)
        {
            var result = await dialogHostService.ShowDialog(nameof(CreateTemplateDialog), null, "EvaluationManageRoot");
            if (result != null && result.Result == Prism.Services.Dialogs.ButtonResult.OK)
            {
                RouteHelper.Goto(regionManager, typeof(ManageEvaluationView), view);
            }
        }
    }
}
