using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Views.WorkPlace.AttendanceData
{
    /// <summary>
    /// AttendanceDataEnteringView.xaml 的交互逻辑
    /// </summary>
    public partial class AttendanceDataEnteringView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;

        public AttendanceDataEnteringView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(AttendanceDataEnteringView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.AttendaceDataEnteringContent, typeof(EmptyContentView));
        }
    }
}
