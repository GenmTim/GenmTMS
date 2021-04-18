using Prism.Events;
using Prism.Regions;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Base;

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
            //RegisterDefaultRegionView(RegionToken.PerformanceDataEnteringContent, nameof(EnteringDataView));
            this.eventAggregator = eventAggregator;

            this.Loaded += Event_Loaded;
            this.Unloaded += Event_Unloaded;
        }

        private void Event_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.eventAggregator.GetEvent<NextStepEvent>().Subscribe(NextStep);
            this.eventAggregator.GetEvent<PrevStepEvent>().Subscribe(LastStep);
        }

        private void Event_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.eventAggregator.GetEvent<NextStepEvent>().Unsubscribe(NextStep);
            this.eventAggregator.GetEvent<PrevStepEvent>().Unsubscribe(LastStep);
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
                //RegionHelper.RequestNavigate(regionManager, RegionToken.PerformanceDataEnteringContent, typeof(EnteringDataView));
            }
            else if (stepBar.StepIndex == 1)
            {
                //RegionHelper.RequestNavigate(regionManager, RegionToken.PerformanceDataEnteringContent, typeof(CheckDataView));
            }
            else if (stepBar.StepIndex == 2)
            {

            }
        }
    }
}
