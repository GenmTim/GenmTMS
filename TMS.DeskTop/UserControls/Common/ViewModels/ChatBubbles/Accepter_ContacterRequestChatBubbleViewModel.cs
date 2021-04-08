using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Data.VO.Notification;
using TMS.Core.Event;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Common.ViewModels.ChatBubbles
{
    public class Accepter_ContacterRequestChatBubbleViewModel : BindableBase
    {
        private IEventAggregator eventAggregator;

        public ContactRequestState State
        {
            get
            {
                if (contactRequest == null) return ContactRequestState.Pending;
                return contactRequest.State;
            }
            set
            {
                contactRequest.State = value;
                RaisePropertyChanged();
            }
        }

        private ContactRequest contactRequest;
        public ContactRequest ContactRequest 
        {
            get => contactRequest;
            set
            {
                contactRequest = value;
                State = value.State;
                Task.Run(async() => 
                {
                    var result = await HttpService.GetConn().GetUserInfo((long)contactRequest.RequesterId);
                    if (result.StatusCode == 200)
                    {
                        Requester = (User)result.Data;
                    }
                });
                RaisePropertyChanged();
            }
        }

        public long MessageId { get; set; }
        private User requester;
        public User Requester
        {
            get => requester;
            set
            { 
                requester = value;
                RaisePropertyChanged();
            }
        }

        public Accepter_ContacterRequestChatBubbleViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.AcceptRequestCmd = new DelegateCommand(AcceptRequest);
            this.RefuseRequestCmd = new DelegateCommand(RefuseRequest);

        }
        public DelegateCommand AcceptRequestCmd { get; private set; }
        public DelegateCommand RefuseRequestCmd { get; private set; }

        private void AcceptRequest()
        {
            State = ContactRequestState.Accept;
            NotificationData notificationData = new NotificationData()
            {
                Sender = SessionService.User,
                Receiver = new Core.Data.Entity.User { UserId = ContactRequest.RequesterId },
                Type = 1,
                SubType = 0,
                Id = MessageId,
                Data = JsonConvert.SerializeObject(ContactRequest),
            };
            Task.Run(async() => 
            {
                var result = await HttpService.GetConn().AddNewContacterV2(contactRequest.RequesterId);
                if (result.StatusCode == 200)
                {
                    Application.Current.Dispatcher.Invoke(new System.Action(() => 
                    {
                        eventAggregator.GetEvent<ToastShowEvent>().Publish("成功添加联系人");
                    }));
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(new System.Action(() =>
                    {
                        eventAggregator.GetEvent<ToastShowEvent>().Publish("添加联系人失败");
                    }));
                }
            });
            eventAggregator.GetEvent<WebSocketSendEvent>().Publish(notificationData);
        }

        private void RefuseRequest()
        {
            State = ContactRequestState.Refuse;
            NotificationData notificationData = new NotificationData()
            {
                Sender = SessionService.User,
                Receiver = new Core.Data.Entity.User { UserId = ContactRequest.RequesterId },
                Type = 1,
                SubType = 0,
                Id = MessageId,
                Data = JsonConvert.SerializeObject(ContactRequest),
            };
            eventAggregator.GetEvent<WebSocketSendEvent>().Publish(notificationData);
        }
    }
}
