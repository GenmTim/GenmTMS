using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class WorkPlaceView : RegionManagerControl
    {
        //private IRegionManager regionManager;

        public WorkPlaceView(IRegionManager regionManager) : base(regionManager, typeof(WorkPlaceView))
        {
            InitializeComponent();
            //this.regionManager = regionManager;
            RegisterDefaultRegionView(RegionToken.WorkPlaceTabContent, nameof(EmptyContentView));
        }
    }
}
