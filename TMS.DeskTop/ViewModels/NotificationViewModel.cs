using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Collections.Generic;
using TMS.Core.Data;
using TMS.Core.Data.Dto;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Event.Notification;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.ViewModels
{
    class NotificationViewModel
    {
        public class ConnectionEvent : PubSubEvent<NotificationItemEntity> { }

        private List<NotificationItemEntity> testList;

        public List<NotificationItemEntity> TestList { get => testList; set => testList = value; }

        private Dictionary<NotificationItemEntity, List<NotificationData>> notificationMap;
        public Dictionary<NotificationItemEntity, List<NotificationData>> NotificationMap { get => notificationMap; set => notificationMap = value; }


        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public NotificationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.notificationMap = new Dictionary<NotificationItemEntity, List<NotificationData>>();

            var key1 = new NotificationItemEntity
            {
                User = new UserDto
                {
                    UserId = 10000,
                    Name = "ljd",
                },
                ImgUrl = "img1",
                NewMessage = "登录操作通知",
                Date = "1月24日"
            };
            var key2 = new NotificationItemEntity
            {
                User = new UserDto
                {
                    UserId = 10002,
                    Name = "string",
                },
                ImgUrl = "image3",
                NewMessage = "写汇报提醒",
                Date = "14:13"
            };

            var value1 = new List<NotificationData>() { new NotificationData { Receiver = new UserDto
                {
                    UserId=10000,
                    Name="ljd",
                }}};

            var value2 = new List<NotificationData>() { new NotificationData { Receiver = new UserDto
                {
                    UserId=10002,
                    Name="string",
                }}};

            notificationMap.Add(key1, value1);
            notificationMap.Add(key2, value2);


            this.eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Subscribe(UpdateChatBoxContext);
        }

        private void UpdateChatBoxContext(ChatBoxContext chatBoxContext)
        {
            var param = new NavigationParameters
                    {
                        {
                            "ChatBoxContext",
                            chatBoxContext
                        }
                    };
            RegionHelper.RequestNavigate(regionManager, RegionToken.ChatRegion, typeof(ChatBox), param);
        }
    }
}
