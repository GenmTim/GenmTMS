using Prism.Events;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Event.Notification;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
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
        }

        private void NotificationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView list)
            {
                if (list.SelectedValue is NotificationItemEntity data)
                {
                    eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Publish(new ChatBoxContext { User = data.User });
                }
            }
            e.Handled = true;
        }
    }
}
