using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering;

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
            RegisterDefaultRegionView(RegionToken.PerformanceDataEnteringContent, nameof(EnteringDataView));
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<NextStepEvent>().Subscribe(NextStep);
            this.eventAggregator.GetEvent<PrevStepEvent>().Subscribe(LastStep);
        }

        private void NextStep()
        {
            stepBar.Next();
            JumpToView();

        }

        private void LastStep()
        {
            stepBar.Prev();
            JumpToView();
        }

        private void JumpToView()
        {
            if (stepBar.StepIndex == 0)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.PerformanceDataEnteringContent, typeof(EnteringDataView));
            }
            else if (stepBar.StepIndex == 1)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.PerformanceDataEnteringContent, typeof(CheckDataView));
            }
            else if (stepBar.StepIndex == 1)
            {

            }
        }
    }
}
