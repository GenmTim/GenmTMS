using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using TMS.Core.Event;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering.Step
{
    class CompleteEntryDataViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public CompleteEntryDataViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.PrevStepCmd = new DelegateCommand(PrevStep);
            this.CompleteStepCmd = new DelegateCommand(CompleteStep);
        }

        public DelegateCommand CompleteStepCmd { get; private set; }
        public DelegateCommand PrevStepCmd { get; private set; }
        private void PrevStep()
        {
            eventAggregator.GetEvent<PrevStepEvent>().Publish();
        }

        private void CompleteStep()
        {
            this.eventAggregator.GetEvent<CompleteStepEvent>().Publish();
        }
    }
}
