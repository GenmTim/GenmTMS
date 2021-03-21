using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.Auth;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// AuthView.xaml 的交互逻辑
    /// </summary>
    public partial class AuthView : RegionManagerControl
    {


        public AuthView(IRegionManager regionManager) : base(regionManager, typeof(AuthView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.AuthContent, nameof(AuthMainView));
        }
    }
}
