using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.UserControls.Common.ViewModels;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class WorkPlaceView : RegionManagerControl
    {
        //private IRegionManager regionManager;

        private readonly IEventAggregator eventAggregator;

        public WorkPlaceView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(WorkPlaceView))
        {
            InitializeComponent();
            //this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            RegisterDefaultRegionView(RegionToken.WorkPlaceTabContent, nameof(EmptyContentView));
        }

        private void ClassifyRadioBtnCheck(object sender, System.Windows.RoutedEventArgs e)
        {
            //eventAggregator.GetEvent<>();
        }
    }
}
