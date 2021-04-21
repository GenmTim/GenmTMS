using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using TMS.Core.Data.VO;

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

        public Boolean IsHasEvaluationItem
        {
            get
            {
                return questionnaireVOList != null && questionnaireVOList.Count != 0;
            }
        }

        public ViewEvaluationViewModel()
        {
            Simulation_Data();
        }


        public void Simulation_Data()
        {
            //evaluationList.Add(new EvaluationItem
            //{
            //    Name = "蔡承龙",
            //    LastUpdateTime = "01月15日 20:13",
            //    Content = "员工姓名：蔡承龙 业绩: 1111 做得好的具体..."
            //});
            //evaluationList.Add(new EvaluationItem
            //{
            //    Name = "金泽权",
            //    LastUpdateTime = "01月14日 12:23",
            //    Content = "员工姓名：蔡承龙 业绩: 2222 做得好的具体..."
            //});
            //evaluationList.Add(new EvaluationItem
            //{
            //    Name = "余浩臻",
            //    LastUpdateTime = "01月16日 14:10",
            //    Content = "员工姓名：蔡承龙 业绩: 3333 做得好的具体..."
            //});
            //evaluationList.Add(new EvaluationItem
            //{
            //    Name = "鲁佳栋",
            //    LastUpdateTime = "01月12日 12:17",
            //    Content = "员工姓名：蔡承龙 业绩: 4444 做得好的具体..."
            //});
            //evaluationList.Add(new EvaluationItem
            //{
            //    Name = "何升鸿",
            //    LastUpdateTime = "01月17日 10:19",
            //    Content = "员工姓名：蔡承龙 业绩: 5555 做得好的具体..."
            //});

            QuestionnaireVOList ??= new ObservableCollection<QuestionnaireVO>()
            {
                new QuestionnaireVO { Title="每周工作汇报", Name="李冬富", ContentList="完成良好，难度适合，安排合理", Date="5月30日 12 : 42" },
                new QuestionnaireVO { Title="员工工作状态调查", Name="安小雪", ContentList="工作稳定，有升职欲望，对公司有成就感", Date="5月30日 13 : 11" },
                new QuestionnaireVO { Title="每周工作汇报", Name="李添新", ContentList="完成不足，难度较大，缺少培养", Date="5月30日 14 : 00" },
                new QuestionnaireVO { Title="SCL-90", Name="蔡承龙", ContentList="略微躯体化，无焦虑，无抑郁", Date="5月30日 15 : 22" },
                new QuestionnaireVO { Title="SCL-90", Name="金泽权", ContentList="轻度强迫症，无躯体化，无焦虑", Date="5月30日 16 : 13" },
            };
        }
    }
}
