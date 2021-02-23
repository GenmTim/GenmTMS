using Prism.Regions;
using System.Windows.Controls;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class WorkPlaceView : UserControl
    {
        private IRegionManager regionManager;

        public WorkPlaceView(IRegionManager regionManager)
        {
            InitializeComponent();
            this.regionManager = regionManager;
        }
    }
}
