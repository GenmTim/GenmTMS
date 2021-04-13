using Prism.Events;
using TMS.Core.Data;

namespace TMS.Core.Event.WebSocket
{
    public class WebSocketSendEvent : PubSubEvent<NotificationData>
    {
    }

    public class WebSocketRecvEvent : PubSubEvent<NotificationData>
    {
    }
}
