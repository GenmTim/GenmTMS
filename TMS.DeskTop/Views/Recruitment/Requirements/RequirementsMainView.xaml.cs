using Prism.Regions;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.Recruitment.Requirements.Subitem;

namespace TMS.DeskTop.Views.Recruitment.Requirements
{
    /// <summary>
    /// RequirementsMainView.xaml 的交互逻辑
    /// </summary>
    public partial class RequirementsMainView : RegionManagerControl
    {
        public RequirementsMainView(IRegionManager regionManager) : base(regionManager, nameof(RequirementsMainView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.RecruitmentRequirementsMainContent, nameof(ViewRequirementsView));
        }
    }
}
