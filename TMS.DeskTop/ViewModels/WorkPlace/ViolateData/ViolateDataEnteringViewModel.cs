using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.ViolateData.Entering;
using TMS.DeskTop.Views.WorkPlace.ViolateData.Manager;

namespace TMS.DeskTop.ViewModels.WorkPlace.ViolateData
{
    public class ViolateDataEnteringViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public ViolateDataEnteringViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            this.eventAggregator = eventAggregator;
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            if (obj == null)
            {
                return;
            }
            if (obj.Equals("EnteringStepView"))
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringContent, typeof(EnteringStepView));
            }
            else if (obj.Equals("ManageDataView"))
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.ViolateDataEnteringContent, typeof(ManageDataView));
            }
        }
    }
}
