using Prism.Regions;
using TMS.Core.Data;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;

namespace TMS.DeskTop.Views.WorkPlace.Auth
{
    /// <summary>
    /// EvaluationMainView.xaml 的交互逻辑
    /// </summary>
    public partial class EvaluationMainView : RegionManagerControl, INavigationAware
    {

        public EvaluationMainView(IRegionManager regionManager) : base(regionManager, typeof(EvaluationMainView))
        {
            InitializeComponent();
            //RegisterDefaultRegionView(RegionToken.EvaluationMainContent, nameof(ViewEvaluationView));
        }
    }
}
