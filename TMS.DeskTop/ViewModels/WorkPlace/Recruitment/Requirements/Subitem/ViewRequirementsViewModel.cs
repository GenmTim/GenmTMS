using Prism.Mvvm;
using System.Collections.ObjectModel;
using TMS.Core.Data.VO;

namespace TMS.DeskTop.ViewModels.WorkPlace.Recruitment.Requirements.Subitem
{
    class ViewRequirementsViewModel : BindableBase
    {
        private ObservableCollection<RequirementVO> requirementVOList;
        public ObservableCollection<RequirementVO> RequirementVOList
        {
            get => requirementVOList;
            set
            {
                requirementVOList = value;
                RaisePropertyChanged();
            }
        }

        public ViewRequirementsViewModel()
        {

            this.RequirementVOList ??= new ObservableCollection<RequirementVO>()
            {
                new RequirementVO { Job="Golang游戏服务端工程师", ArrivalTime="2年", NeedNumber="次月 10日", WorkAge="3年",Require="根据游戏策划需求，独立设计开发相应的游戏模块。游戏逻辑和 mongodb ,redis数据库方面的开发。服务器性能优化。了解整个游戏服务器系统，维护相应模块，解决服务器问题。" },
                new RequirementVO { Job="游戏原画设计师", ArrivalTime="1年", NeedNumber="当月 29日", WorkAge="4年",Require="按时保质地完成2D角色/场景资源制作，如：主角，NPC，怪物，骑宠，套装，头像半身像等；画风主流时尚，有良好的设计感，且了解一定的游戏美术制作流程；具备扎实的美术基础和良好的动漫绘画能力；" },
                new RequirementVO { Job="3D动画师", ArrivalTime="2年", NeedNumber="当月 29日", WorkAge="1-3年",Require="掌握任一主流3D软件基础操作，对于 nCloth/Qualoth/毛发系统或其他布料模拟插件了解者优先；了解Modeling、Rigging、Animation基础知识；需要掌握1-2种渲染器。能使用c4d或maya完成建模，材质灯光渲染，简单动画。" },
            };
        }
    }
}
