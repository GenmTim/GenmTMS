using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.Recruitment;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// RecruitmentView.xaml 的交互逻辑
    /// </summary>
    public partial class RecruitmentView : RegionManagerControl
    {
        public RecruitmentView(IRegionManager regionManager) : base(regionManager, typeof(RecruitmentView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.RecruitmentContent, nameof(RecruitmentNavigationView));
        }
    }
}
