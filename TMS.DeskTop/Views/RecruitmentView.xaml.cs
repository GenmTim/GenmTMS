using Prism.Regions;
using TMS.Core.Data;
using TMS.DeskTop.Resources.Styles.Views.Recruitment;
using TMS.DeskTop.Tools.Base;

namespace TMS.DeskTop.Views
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
