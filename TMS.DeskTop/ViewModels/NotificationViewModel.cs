using Genm.Data;
using Genm.Data.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TMS.Core.Data;
using TMS.Core.Data.Dto;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO;
using TMS.Core.Event.Notification;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.ViewModels;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.ViewModels
{
    class NotificationViewModel : BindableBase
    {
        public class ConnectionEvent : PubSubEvent<NotificationItemEntity> { }


        #region Property
        //private List<NotificationItemEntity> testList;
        //public List<NotificationItemEntity> TestList { get => testList; set => testList = value; }

        //private Dictionary<MsgObjVO, List<NotificationData>> notificationMap;
        //public Dictionary<MsgObjVO, List<NotificationData>> NotificationMap { get => notificationMap; set => notificationMap = value; }

        //private List<MsgObjVO> topObjList;
        //public List<MsgObjVO> TopObjectList { get => topObjList; set => topObjList = value; }

        private Dictionary<long, ObservableCollection<ChatInfoModel>> notificationDataListMap;
        public Dictionary<long, ObservableCollection<ChatInfoModel>> NotificationDataListMap { get => notificationDataListMap; set => notificationDataListMap = value; }

        //private Dictionary<long, MsgObjVO> msgObjMap;
        //public Dictionary<long, MsgObjVO> MsgObjMap 
        //{ 
        //    get => msgObjMap;
        //    set
        //    {
        //        msgObjMap = value;
        //        RaisePropertyChanged();
        //    }
        //}


        private ObservableCollection<MsgObjVO> msgObjList;
        public ObservableCollection<MsgObjVO> MsgObjList 
        { 
            get => msgObjList;
            set
            {
                msgObjList = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;


        public NotificationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NotificationDataListMap = new Dictionary<long, ObservableCollection<ChatInfoModel>>();
            //this.MsgObjMap = new Dictionary<long, MsgObjVO>();
            this.MsgObjList = new ObservableCollection<MsgObjVO>();

            //this.MsgObjMap[23] = new MsgObjVO
            //{
            //    ObjectId = 23,
            //    ObjectName = "测试",
            //    Avatar = new Uri("http://47.101.157.194:8081/static/avatar/target4.jpg"),
            //    NewMessage = "测试数据",
            //    NewMessageDate = "1月24日",
            //};
            //this.notificationMap = new Dictionary<MsgObjVO, List<NotificationData>>();

            eventAggregator.GetEvent<WebSocketRecvEvent>().Subscribe(NewMessage, ThreadOption.UIThread, false);

            this.eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Subscribe(UpdateChatBoxContext);
        }

        private void UpdateChatBoxContext(long id)
        {
            // 附加上消息队列的数据

            var msgObj = MsgObjList.First(x => x.ObjectId == id);
            var chatBoxContext = new ChatBoxContext()
            {
                User = new User
                {
                    UserId = msgObj.ObjectId,
                    Name = msgObj.ObjectName,
                    Avatar = msgObj.Avatar.ToString()
                },
                ChatInfoList = NotificationDataListMap[id],
            };

            var param = new NavigationParameters
                    {
                        {
                            "ChatBoxContext",
                            chatBoxContext
                        }
                    };
            RegionHelper.RequestNavigate(regionManager, RegionToken.ChatRegion, typeof(ChatBox), param);
        }

        public void NewMessage(NotificationData data)
        {
            // 构建最新的消息对象数据
            var msgObj = new MsgObjVO
            {
                ObjectId = (long)data.Sender.UserId,
                ObjectName = data.Sender.Name,
                Avatar = new Uri(data.Sender.Avatar),
                NewMessage = (string)data.Data,
                NewMessageDate = "1月24日",
            };

            long id = msgObj.ObjectId;

            // 删除旧的数据对象，并更新的数据对象
            try
            {
                MsgObjList.Remove(MsgObjList.First(x => x.ObjectId == id));
            }
            catch(Exception){}
            MsgObjList.Insert(0, msgObj);

            // 构建新的前端消息数据，并添加到对应Id的消息队列数据
            var chatInfo = new ChatInfoModel
            {
                Message = (string)data.Data,
                SenderId = (long)data.Sender.UserId,
                Role = ((long)data.Sender.UserId == (long)SessionService.User.UserId ? ChatRoleType.Me : ChatRoleType.Other),
                Type = ChatMessageType.String,
                Avatar = msgObj.Avatar,
                Timestamp = data.Timestamp
            };

            if (!NotificationDataListMap.ContainsKey(id))
            {
                NotificationDataListMap[id] = new ObservableCollection<ChatInfoModel>();
            }
            NotificationDataListMap[id].Add(chatInfo);
        }
    }
}
