using Prism.Events;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.UserControls.Common.Views;
using static TMS.DeskTop.ViewModels.NotificationViewModel;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// NotificationView.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;
        public NotificationView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(NotificationView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            //eventAggregator.GetEvent<ConnectionEvent>().Subscribe((data) => 
            //{
            //    RegionManager.SetRegionName(chatRegion, "ChatBox" + data.Id);
            //regionManager.RequestNavigate(RegionToken.ChatRegion, "ChatBox");

            //});
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView list = sender as ListView;
            if (list != null)
            {
                var data= list.SelectedValue as NotificationItemEntity;
                //if (listView.SelectedValue )
                if (data != null)
                {
                    var param = new NavigationParameters();
                    param.Add("Data", data);
                    regionManager.RequestNavigate(RegionToken.ChatRegion, nameof(ChatBox), param);
                }
            }

            e.Handled = true;
        }
    }
}
