using Prism.Events;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO;
using TMS.Core.Event.Notification;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Cmd;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.UserControls.Dialogs.Views;
using static TMS.DeskTop.ViewModels.NotificationViewModel;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// NotificationView.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IDialogHostService dialogHost;
        public NotificationView(IRegionManager regionManager, IDialogHostService dialogHost, IEventAggregator eventAggregator) : base(regionManager, typeof(NotificationView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            this.dialogHost = dialogHost;

            RegisterDefaultRegionView(RegionToken.ChatRegion, nameof(EmptyContentView));

            CommandBindings.Add(new CommandBinding(ControlCommands.CompleteCheckCmd, (s, e) =>
            {
                if (e.OriginalSource is Button btn)
                {
                    var id = (long)btn.Tag;
                    eventAggregator.GetEvent<CheckCompleteEvent>().Publish(id);
                }
            }));
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
                Timestamp = TimeHelper.GetNowTimeStamp(),
                Receiver = SessionService.Instance.User
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
                Timestamp = TimeHelper.GetNowTimeStamp(),
                Receiver = SessionService.Instance.User
            };


            if (SessionService.Instance.User.UserId == CclNotificationData.Sender.UserId)
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
            if (sender is MenuItem menuItem)
            {
                if ((menuItem.Tag != null) && menuItem.Tag.Equals("AddNewContacter"))
                {
                    dialogHost.ShowDialog(nameof(AddNewFriendDialog), null, "NotificationRoot");
                }
            }
            menuPopup.IsOpen = false;
            e.Handled = true;
        }

        private void classifyGridToggleBtn_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            Storyboard st = new Storyboard();
            DoubleAnimation height = new DoubleAnimation(33, 110, new Duration(TimeSpan.FromSeconds(0.3)));
            Storyboard.SetTarget(height, classifyGrid);
            Storyboard.SetTargetProperty(height, new PropertyPath(HeightProperty.Name));
            st.Children.Add(height);
            st.Begin();
            //classifyGrid.
            e.Handled = true;
        }

        private void classifyGridToggleBtn_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            Storyboard st = new Storyboard();
            DoubleAnimation height = new DoubleAnimation(110, 33, new Duration(TimeSpan.FromSeconds(0.3)));
            Storyboard.SetTarget(height, classifyGrid);
            Storyboard.SetTargetProperty(height, new PropertyPath(HeightProperty.Name));
            st.Children.Add(height);
            st.Begin();
            e.Handled = true;
        }
    }
}
