using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.Recruitment.Requirements.Subitem;

namespace TMS.DeskTop.Views.WorkPlace.Recruitment.Requirements
{
    /// <summary>
    /// RequirementsMainView.xaml 的交互逻辑
    /// </summary>
    public partial class RequirementsMainView : RegionManagerControl
    {
        public RequirementsMainView(IRegionManager regionManager) : base(regionManager, typeof(RequirementsMainView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.RecruitmentRequirementsMainContent, nameof(ViewRequirementsView));
        }
    }
}
