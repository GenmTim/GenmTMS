using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Event;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering
{
    public class EnteringDataViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        private EnteringDataViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NextStepCmd = new DelegateCommand(NextStep);
        }


        public DelegateCommand NextStepCmd { get; private set; }
        private void NextStep()
        {
            eventAggregator.GetEvent<NextStepEvent>().Publish();
        }
    }
}
