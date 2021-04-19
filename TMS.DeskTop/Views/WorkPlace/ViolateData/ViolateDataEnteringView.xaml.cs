using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Views.WorkPlace.ViolateData
{
    /// <summary>
    /// AttendanceDataEnteringView.xaml 的交互逻辑
    /// </summary>
    public partial class ViolateDataEnteringView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;


        public ViolateDataEnteringView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(ViolateDataEnteringView))
        {
            InitializeComponent();
            //RegisterDefaultRegionView(RegionToken.ViolateDataEnteringContent, nameof(EnteringDataView));

            this.eventAggregator = eventAggregator;
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.ViolateDataEnteringContent, typeof(EmptyContentView));
        }
    }
}
