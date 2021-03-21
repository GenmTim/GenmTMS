using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
    class FullInEvaluationViewModel : BindableBase
    {

        public ObservableCollection<String> EvaluationRuleList { get; set; } = new ObservableCollection<String>();

        public FullInEvaluationViewModel()
        {
            this.EvaluationRuleList.Add("你好1");
            this.EvaluationRuleList.Add("你好2");
            this.EvaluationRuleList.Add("你好3");
        }


    }
}
