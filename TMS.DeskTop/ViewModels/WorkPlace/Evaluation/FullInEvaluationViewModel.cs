using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using TMS.Core.Data.VO;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{
    class FullInEvaluationViewModel : BindableBase
    {
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

        public FullInEvaluationViewModel()
        {
            this.QuestionnaireVOList = new ObservableCollection<QuestionnaireVO>()
            {
                new QuestionnaireVO { Name="人事部", ContentList="企业竞争优势、未来前景、制度是否健全、是否愿意长期工作", Date="6月24日 18 : 00", Title="入职前员工调查问卷"  },
                new QuestionnaireVO { Name="直属上级", ContentList="公司情况、工作成就感、工作强度、工作计划", Date="6月23日 19 : 00", Title="员工工作状态调查"  },
                new QuestionnaireVO { Name="直属上级", ContentList="工作完成情况、安排是否合理、工作内容", Date="6月26日 20 : 00", Title="每周工作汇报"  },
                new QuestionnaireVO { Name="人事部", ContentList="躯体化、强迫症状、焦虑、抑郁，", Date="6月29日 18 : 00", Title="SCL-90心理测试"  },
            };
        }


    }
}
