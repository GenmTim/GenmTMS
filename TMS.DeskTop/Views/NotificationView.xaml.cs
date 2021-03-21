using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.UserControls.Views;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// NotificationView.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationView : RegionManagerControl
    {

        public NotificationView(IRegionManager regionManager) : base(regionManager, typeof(NotificationView))
        {
            InitializeComponent();
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            regionManager.RequestNavigate(RegionToken.ChatRegion, "ChatBox");
            e.Handled = true;
        }
    }
}
