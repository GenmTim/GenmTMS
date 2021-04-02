using Prism.Events;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO;
using TMS.Core.Event.Notification;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;
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
                if (list.SelectedValue is MsgObjVO data)
                {
                    eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Publish(data.ObjectId);
                }
            }
            e.Handled = true;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NotificationData JzqNotificationData = new NotificationData
            {
                Sender = new User
                {
                    UserId = 10002,
                    Name = "jzq",
                    Avatar = "http://47.101.157.194:8081/static/avatar/target2.jpg",
                },
                Data = "你好，我是Jzq",
                Receiver = SessionService.User
            };

            NotificationData CclNotificationData = new NotificationData
            {
                Sender = new User
                {
                    UserId = 10001,
                    Name = "ccl",
                    Avatar = "http://47.101.157.194:8081/static/avatar/target4.jpg",
                },
                Data = "你好，我是Ccl",
                Receiver = SessionService.User
            };


            if (SessionService.User.UserId == CclNotificationData.Sender.UserId)
            {
                this.eventAggregator.GetEvent<WebSocketRecvEvent>().Publish(JzqNotificationData);
            }
            else
            {
                this.eventAggregator.GetEvent<WebSocketRecvEvent>().Publish(CclNotificationData);
            }
            e.Handled = true;
        }



        #region SimulationData

        #endregion

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            menuPopup.IsOpen = false;
            e.Handled = true;
        }
    }
}
