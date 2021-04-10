using Genm.Data;
using Genm.Data.Enums;
using Newtonsoft.Json;
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
using System.Windows.Input;
using TMS.Core.Api;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO;
using TMS.Core.Event.Notification;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Cmd;
using TMS.DeskTop.UserControls.Common.ViewModels.ChatBubbles;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.UserControls.Common.Views.ChatBubbles;

namespace TMS.DeskTop.ViewModels
{
    class NotificationViewModel : BindableBase, INavigationAware
    {
        public class ConnectionEvent : PubSubEvent<NotificationItemEntity> { }
        public class CheckCompleteEvent : PubSubEvent<long> { }

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
        private readonly IContainerExtension container;

        public NotificationViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IContainerExtension container)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.container = container;
            this.NotificationDataListMap = new Dictionary<long, ObservableCollection<ChatInfoModel>>();

            this.MsgObjList = new ObservableCollection<MsgObjVO>();

            this.eventAggregator.GetEvent<WebSocketRecvEvent>().Subscribe(NewMessage, ThreadOption.UIThread, false);

            this.eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Subscribe(UpdateChatBoxContext, ThreadOption.UIThread);

            this.eventAggregator.GetEvent<CheckCompleteEvent>().Subscribe(CheckCompleteMsgObjVO);
        }

        private void CheckCompleteMsgObjVO(long id)
        {
            if (!NotificationDataListMap.ContainsKey(id))
            {
                NotificationDataListMap.Remove(id);
            }
            try
            {
                var msgObj = MsgObjList.First(x => x.ObjectId == id);
                if (SelectedValue == msgObj)
                {
                    RegionHelper.RequestNavigate(regionManager, RegionToken.ChatRegion, typeof(EmptyContentView));
                }
                MsgObjList.Remove(msgObj);
            }
            catch (Exception) { }
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
            // 处理NotificationData，转换为MsgObjVO和ChatInfoModel
            try
            {
                MakeNewMessage(data, out MsgObjVO msgObj, out ChatInfoModel chatInfo);
                // 删除旧的数据对象，并更新的数据对象
                try
                {
                    MsgObjList.Remove(MsgObjList.First(x => x.ObjectId == msgObj.ObjectId));
                }
                catch (Exception) { }
                MsgObjList.Insert(0, msgObj);

                if (!NotificationDataListMap.ContainsKey(msgObj.ObjectId))
                {
                    NotificationDataListMap[msgObj.ObjectId] = new ObservableCollection<ChatInfoModel>();
                }
                NotificationDataListMap[msgObj.ObjectId].Add(chatInfo);

                msgObj.BadgeNumber = notificationDataListMap[msgObj.ObjectId].Count + 1;
            }
            catch (Exception) 
            {
                LoggerService.Error("出现不匹配的消息" + JsonConvert.SerializeObject(data).ToString());
                return; 
            }
        }

        private void MakeNewMessage(NotificationData data, out MsgObjVO msgObj, out ChatInfoModel chatInfo)
        {
            long id;

            if ((long)data.Sender.UserId != SessionService.User.UserId)
            {
                id = (long)data.Sender.UserId;
                msgObj = new MsgObjVO
                {
                    ObjectId = id,
                    ObjectName = data.Sender.Name,
                    Avatar = new Uri(data.Sender.Avatar),
                    NewMessageTimestamp = data.Timestamp,
                };
            }
            else if ((long)data.Receiver.UserId != SessionService.User.UserId)
            {
                id = (long)data.Receiver.UserId;
                msgObj = new MsgObjVO
                {
                    ObjectId = id,
                    ObjectName = data.Receiver.Name,
                    Avatar = new Uri(data.Receiver.Avatar),
                    NewMessageTimestamp = data.Timestamp,
                };
            }
            else
            {
                throw (new Exception());
            }

            // 构建最新的消息对象数据
            if (data.Type == 0)
            {
                msgObj.NewMessage = (string)data.Data;
            }
            else if (data.Type == 1)
            {
                msgObj.NewMessage = "好友申请";
            }

            // 构建新的前端消息数据，并添加到对应Id的消息队列数据
            chatInfo = new ChatInfoModel
            {
                SenderId = msgObj.ObjectId,
                Role = (msgObj.ObjectId == (long)SessionService.User.UserId ? ChatRoleType.Me : ChatRoleType.Other),
                Avatar = msgObj.Avatar,
                Timestamp = msgObj.NewMessageTimestamp
            };

            if (data.Type == 0)
            {
                chatInfo.SenderId = (long)data.Sender.UserId;
                chatInfo.Role = (chatInfo.SenderId == SessionService.User.UserId ? ChatRoleType.Me : ChatRoleType.Other);
                ResolveCommonStringMsgInfo(data, ref msgObj, ref chatInfo);
            }
            else if (data.Type == 1)
            {
                ResolveContactRequest(data, ref msgObj, ref chatInfo);
            }
        }

        private void ResolveCommonStringMsgInfo(NotificationData data, ref MsgObjVO msgObj, ref ChatInfoModel chatInfo)
        {
            chatInfo.Message = msgObj.NewMessage;
            chatInfo.Type = ChatMessageType.String;
        }

        private void ResolveContactRequest(NotificationData data, ref MsgObjVO msgObj, ref ChatInfoModel chatInfo)
        {

            var contactRequest = JsonConvert.DeserializeObject<Core.Data.VO.Notification.ContactRequest>((string)data.Data);

            if (contactRequest.RequesterId == SessionService.User.UserId)
            {
                var requesterContacterRequestChatBubble = container.Resolve<Requester_ContacterRequestChatBubble>();
                var vm = requesterContacterRequestChatBubble.DataContext as Requester_ContacterRequestChatBubbleViewModel;
                vm.ContactRequest = contactRequest;

                chatInfo.Message = requesterContacterRequestChatBubble;
                chatInfo.Type = ChatMessageType.Custom;
            }
            else
            {
                var accepterContacterRequestChatBubble = container.Resolve<Accepter_ContacterRequestChatBubble>();
                var vm = accepterContacterRequestChatBubble.DataContext as Accepter_ContacterRequestChatBubbleViewModel;
                vm.ContactRequest = contactRequest;
                vm.MessageId = data.Id;

                chatInfo.Message = accepterContacterRequestChatBubble;
                chatInfo.Type = ChatMessageType.Custom;
            }

            chatInfo.SenderId = contactRequest.RequesterId;
            chatInfo.Role = (chatInfo.SenderId == SessionService.User.UserId ? ChatRoleType.Me : ChatRoleType.Other);
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
                        var user = (User)result.Data;
                        // 判断是纯跳转命令，还是数据携带命令
                        bool hasNotificationData = navigationContext.Parameters.TryGetValue<NotificationData>("NotificationData", out NotificationData notificationData);

                        // 如果不存在通知数据，则为纯跳转命令，构造简单MsgObjVO即可
                        if (!hasNotificationData)
                        {
                            long userId = (long)user.UserId;
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                if (!IsHasMsgObj(userId))
                                {
                                    var newMsgObjVO = new MsgObjVO
                                    {
                                        ObjectId = userId,
                                        ObjectName = user.Name,
                                        Avatar = new Uri(user.Avatar),
                                        NewMessage = "",
                                        NewMessageTimestamp = TimeHelper.GetNowTimeStamp(),
                                    };
                                    MsgObjList.Add(newMsgObjVO);
                                    SelectedValue = newMsgObjVO;
                                }
                                // 进行导航
                                this.eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Publish(userId);
                            });
                            return;
                        }

                        if (notificationData.Type == 1)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                long userId = (long)user.UserId;


                                //var newMsgObjVO = new MsgObjVO
                                //{
                                //    ObjectId = userId,
                                //    ObjectName = user.Name,
                                //    Avatar = new Uri(user.Avatar),
                                //    NewMessage = "好友申请",
                                //    NewMessageTimestamp = TimeHelper.GetNowTimeStamp(),
                                //};
                                //try
                                //{
                                //    MsgObjList.Remove(MsgObjList.First(x => x.ObjectId == newMsgObjVO.ObjectId));
                                //}
                                //catch (Exception) { }
                                //MsgObjList.Insert(0, newMsgObjVO);
                                //SelectedValue = newMsgObjVO;

                                //if (!NotificationDataListMap.ContainsKey(userId))
                                //{
                                //    NotificationDataListMap[userId] = new ObservableCollection<ChatInfoModel>();
                                //}
                                //var sendeContacterRequestChatBubble = container.Resolve<Requester_ContacterRequestChatBubble>();
                                //var vm = sendeContacterRequestChatBubble.DataContext as Requester_ContacterRequestChatBubbleViewModel;
                                //vm.ContactRequest = JsonConvert.DeserializeObject<Core.Data.VO.Notification.ContactRequest>((string)notificationData.Data);
                                //notificationDataListMap[userId].Add(new ChatInfoModel
                                //{
                                //    SenderId = (long)SessionService.User.UserId,
                                //    Avatar = new Uri(SessionService.User.Avatar),
                                //    Message = sendeContacterRequestChatBubble,
                                //    Type = ChatMessageType.Custom,
                                //    Role = ChatRoleType.Me,
                                //    Timestamp = TimeHelper.GetNowTimeStamp(),
                                //});
                                // websocket推送消息，并进行导航
                                this.eventAggregator.GetEvent<WebSocketRecvEvent>().Publish(notificationData);
                                this.eventAggregator.GetEvent<WebSocketSendEvent>().Publish(notificationData);
                                this.eventAggregator.GetEvent<UpdateChatBoxContextEvent>().Publish(userId);
                            });
                        }
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


        private void SendeAddNewContacterMessage()
        {

        }

        private bool IsHasMsgObj(long id)
        {
            foreach (var msg in MsgObjList)
            {
                if (msg.ObjectId == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
