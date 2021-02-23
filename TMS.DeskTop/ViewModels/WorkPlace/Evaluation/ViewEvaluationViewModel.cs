using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
    public class EvaluationItem
    {
        public String Name { get; set; }
        public String Icon { get; set; }
        public String LastUpdateTime { get; set; }
        public String Content { get; set; }
    }

    class ViewEvaluationViewModel : BindableBase
    {
        //private readonly IRegionManager regionManager;
        //private readonly IModuleCatalog moduleCatalog;

        private ObservableCollection<EvaluationItem> evaluationList = new ObservableCollection<EvaluationItem>();

        public ObservableCollection<EvaluationItem> EvaluationList
        {
            get
            {
                return evaluationList;
            }
            set
            {
                evaluationList = value;
            }
        }

        public Boolean IsHasEvaluationItem
        {
            get
            {
                return evaluationList != null && evaluationList.Count != 0;
            }
        }

        public ViewEvaluationViewModel()
        {
            Simulation_Data();
        }


        public void Simulation_Data()
        {
            evaluationList.Add(new EvaluationItem
            {
                Name = "蔡承龙",
                LastUpdateTime = "01月15日 20:13",
                Content = "员工姓名：蔡承龙 业绩: 1111 做得好的具体..."
            });
            evaluationList.Add(new EvaluationItem
            {
                Name = "金泽权",
                LastUpdateTime = "01月14日 12:23",
                Content = "员工姓名：蔡承龙 业绩: 2222 做得好的具体..."
            });
            evaluationList.Add(new EvaluationItem
            {
                Name = "余浩臻",
                LastUpdateTime = "01月16日 14:10",
                Content = "员工姓名：蔡承龙 业绩: 3333 做得好的具体..."
            });
            evaluationList.Add(new EvaluationItem
            {
                Name = "鲁佳栋",
                LastUpdateTime = "01月12日 12:17",
                Content = "员工姓名：蔡承龙 业绩: 4444 做得好的具体..."
            });
            evaluationList.Add(new EvaluationItem
            {
                Name = "何升鸿",
                LastUpdateTime = "01月17日 10:19",
                Content = "员工姓名：蔡承龙 业绩: 5555 做得好的具体..."
            });
        }
    }
}
