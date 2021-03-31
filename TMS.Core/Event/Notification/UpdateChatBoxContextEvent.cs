using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;
using TMS.Core.Data.Entity;

namespace TMS.Core.Event.Notification
{
    public class UpdateChatBoxContextEvent : PubSubEvent<ChatBoxContext>
    {
    }
}
