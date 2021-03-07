using Prism.Regions;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class WorkPlaceView : RegionManagerControl
    {
        //private IRegionManager regionManager;

        public WorkPlaceView(IRegionManager regionManager) : base(regionManager, nameof(WorkPlaceView))
        {
            InitializeComponent();
            //this.regionManager = regionManager;
            RegisterDefaultRegionView(RegionToken.WorkPlaceTabContent, nameof(WorkPlaceMainView));
        }
    }
}
