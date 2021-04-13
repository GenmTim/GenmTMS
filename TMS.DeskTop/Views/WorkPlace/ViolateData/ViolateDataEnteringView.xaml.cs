using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering;

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
            RegisterDefaultRegionView(RegionToken.ViolateDataEnteringContent, nameof(EnteringDataView));
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
                RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringContent, typeof(EnteringDataView));
            }
            else if (stepBar.StepIndex == 1)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringContent, typeof(CheckDataView));
            }
            else if (stepBar.StepIndex == 1)
            {

            }
        }
    }
}
