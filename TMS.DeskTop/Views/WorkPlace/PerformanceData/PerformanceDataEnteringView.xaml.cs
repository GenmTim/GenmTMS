using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Views.WorkPlace.PerformanceData
{
    /// <summary>
    /// AttendanceDataEnteringView.xaml 的交互逻辑
    /// </summary>
    public partial class PerformanceDataEnteringView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;


        public PerformanceDataEnteringView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(PerformanceDataEnteringView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.PerformanceDataEnteringContent, typeof(EmptyContentView));
        }
    }
}
