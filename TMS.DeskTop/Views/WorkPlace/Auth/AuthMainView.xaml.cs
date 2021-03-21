using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.Auth.Subitem;

namespace TMS.DeskTop.Views.WorkPlace.Auth
{
    /// <summary>
    /// EvaluationMainView.xaml 的交互逻辑
    /// </summary>
    public partial class AuthMainView : RegionManagerControl, INavigationAware
    {

        public AuthMainView(IRegionManager regionManager) : base(regionManager, typeof(AuthMainView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.AuthMainContent, nameof(AuthorisedView));
        }


    }
}
