using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Views.WorkPlace.GloryData
{
    /// <summary>
    /// AttendanceDataEnteringView.xaml 的交互逻辑
    /// </summary>
    public partial class GloryDataEnteringView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;


        public GloryDataEnteringView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(GloryDataEnteringView))
        {
            InitializeComponent();
            //RegisterDefaultRegionView(RegionToken.ViolateDataEnteringContent, nameof(EnteringDataView));

            this.eventAggregator = eventAggregator;
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.GloryDataEnteringContent, typeof(EmptyContentView));
        }
    }
}
