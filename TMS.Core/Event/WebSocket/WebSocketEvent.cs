using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
