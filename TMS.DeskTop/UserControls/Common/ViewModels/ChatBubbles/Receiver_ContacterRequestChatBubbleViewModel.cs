using Prism.Commands;
using Prism.Events;
using TMS.Core.Data;
using TMS.Core.Data.VO.Notification;
using TMS.Core.Event.WebSocket;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Common.ViewModels.ChatBubbles
{
    public class Receiver_ContacterRequestChatBubbleViewModel
    {
        private IEventAggregator eventAggregator;
        public ContactRequest ContactRequest;

        public Receiver_ContacterRequestChatBubbleViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.AcceptRequestCmd = new DelegateCommand(AcceptRequest);
            this.RefuseRequestCmd = new DelegateCommand(RefuseRequest);

        }
        public DelegateCommand AcceptRequestCmd { get; private set; }
        public DelegateCommand RefuseRequestCmd { get; private set; }


        private void AcceptRequest()
        {
            ContactRequest.State = ContactRequestState.Accept;
            NotificationData notificationData = new NotificationData()
            {
                Data = ContactRequest,
            };
            eventAggregator.GetEvent<WebSocketSendEvent>().Publish(notificationData);
        }

        private void RefuseRequest()
        {
            ContactRequest.State = ContactRequestState.Refuse;
            NotificationData notificationData = new NotificationData()
            {
                Data = ContactRequest,
            };
            eventAggregator.GetEvent<WebSocketSendEvent>().Publish(notificationData);
        }
    }
}
