using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.PersonalFile;

namespace TMS.DeskTop.ViewModels.Search
{
    public class SearchMainViewModel
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;

        public SearchMainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.GoAuthCmd = new DelegateCommand(GoAuth);
            this.regionManager = regionManager;
        }

        public DelegateCommand GoAuthCmd { get; set; }
        private void GoAuth()
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.SearchContent, typeof(PersonalFileView));
        }
    }
}
