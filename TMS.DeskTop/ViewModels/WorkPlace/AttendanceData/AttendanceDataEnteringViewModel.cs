using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData
{
    public class AttendanceDataEnteringViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public AttendanceDataEnteringViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.WorkPlaceTabContent, obj);
        }
    }
}
