using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.PerformanceData.Entering.Step;

namespace TMS.DeskTop.Views.WorkPlace.PerformanceData.Entering
{
    /// <summary>
    /// EnteringStepView.xaml 的交互逻辑
    /// </summary>
    public partial class EnteringStepView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;

        public EnteringStepView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(EnteringStepView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            RegisterDefaultRegionView(RegionToken.PerformanceDataEnteringStepContent, typeof(EnteringDataView));
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
                RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringStepContent, typeof(EnteringDataView));
            }
            else if (stepBar.StepIndex == 1)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringStepContent, typeof(CheckDataView));
            }
            else if (stepBar.StepIndex == 2)
            {

            }
        }
    }
}
