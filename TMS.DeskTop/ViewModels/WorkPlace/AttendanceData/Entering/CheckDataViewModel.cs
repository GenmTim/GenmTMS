using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using TMS.Core.Event;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering
{


    public class CheckDataViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public CheckDataViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NextStepCmd = new DelegateCommand(NextStep);
            this.PrevStepCmd = new DelegateCommand(PrevStep);
        }

        public DelegateCommand NextStepCmd { get; private set; }

        private void NextStep()
        {
            eventAggregator.GetEvent<NextStepEvent>().Publish();
        }

        public DelegateCommand PrevStepCmd { get; private set; }

        private void PrevStep()
        {
            eventAggregator.GetEvent<PrevStepEvent>().Publish();
        }
    }
}
