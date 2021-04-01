using Genm.Data;
using Genm.Data.Enums;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data;
using TMS.Core.Data.Dto;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO;
using TMS.Core.Event.Notification;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Card.Views;
using TMS.DeskTop.UserControls.Common.ViewModels;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.ViewModels
{
    class NotificationViewModel : BindableBase, INavigationAware
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

        private MsgObjVO selectedValue;
        public MsgObjVO SelectedValue
        {
            get => selectedValue;
            set
            {
                selectedValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public NotificationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IContainerExtension container)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NotificationDataListMap = new Dictionary<long, ObservableCollection<ChatInfoModel>>();

            this.MsgObjList = new ObservableCollection<MsgObjVO>();

            this.eventAggregator.GetEvent<WebSocketRecvEvent>().Subscribe(NewMessage, ThreadOption.UIThread, false);

            this.eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Subscribe(UpdateChatBoxContext, ThreadOption.UIThread);

            this.SaveCommand = new DelegateCommand(() =>
            {
                NameCard.Show(container);
            });
        }

        private void UpdateChatBoxContext(long id)
        {
            // 附加上消息队列的数据
            var msgObj = MsgObjList.First(x => x.ObjectId == id);
            if (!NotificationDataListMap.ContainsKey(msgObj.ObjectId))
            {
                NotificationDataListMap[msgObj.ObjectId] = new ObservableCollection<ChatInfoModel>();
            }
            var chatBoxContext = new ChatBoxContext()
            {
                User = new User
                {
                    UserId = msgObj.ObjectId,
                    Name = msgObj.ObjectName,
                    Avatar = msgObj.Avatar.ToString()
                },
                ChatInfoList = NotificationDataListMap[msgObj.ObjectId],
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
            long id = (long)data.Sender.UserId;

            // 构建最新的消息对象数据
            var msgObj = new MsgObjVO
            {
                ObjectId = id,
                ObjectName = data.Sender.Name,
                Avatar = new Uri(data.Sender.Avatar),
                NewMessage = (string)data.Data,
                NewMessageTimestamp = 12312312,
            };

            // 删除旧的数据对象，并更新的数据对象
            try
            {
                MsgObjList.Remove(MsgObjList.First(x => x.ObjectId == msgObj.ObjectId));
            }
            catch (Exception) { }
            MsgObjList.Insert(0, msgObj);

            // 构建新的前端消息数据，并添加到对应Id的消息队列数据
            var chatInfo = new ChatInfoModel
            {
                Message = msgObj.NewMessage,
                SenderId = msgObj.ObjectId,
                Role = (msgObj.ObjectId == (long)SessionService.User.UserId ? ChatRoleType.Me : ChatRoleType.Other),
                Type = ChatMessageType.String,
                Avatar = msgObj.Avatar,
                Timestamp = msgObj.NewMessageTimestamp
            };

            if (!NotificationDataListMap.ContainsKey(msgObj.ObjectId))
            {
                NotificationDataListMap[msgObj.ObjectId] = new ObservableCollection<ChatInfoModel>();
            }
            NotificationDataListMap[msgObj.ObjectId].Add(chatInfo);

            msgObj.BadgeNumber = notificationDataListMap[msgObj.ObjectId].Count + 1;
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 获取传输的用户Id
            User user = navigationContext.Parameters.GetValue<User>("User");

            // 如果存在UserId的参数传入，则进行聊天室的导向
            if (user != null && user.UserId != 0)
            {
                // 获取用户基本信息
                Task.Factory.StartNew(async () =>
                {
                    var result = await HttpService.GetConn().GetUserInfo((long)user.UserId);
                    if (result.StatusCode == 200)
                    {
                        var data = (User)result.Data;
                        var msgObj = new MsgObjVO
                        {
                            ObjectId = (long)user.UserId,
                            ObjectName = data.Name,
                            Avatar = new Uri(data.Avatar),
                            NewMessage = "",
                            NewMessageTimestamp = 0,
                        };
                        Application.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            MsgObjList.Add(msgObj);
                            SelectedValue = msgObj;
                            // 进行导航
                            this.eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Publish((long)user.UserId);
                        }));
                    }
                });
            }

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public DelegateCommand SaveCommand { get; private set; }
    }
}
