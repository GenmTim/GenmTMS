using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Event
{
    public class WindowEvent
    {
        public class MinWindowEvent : PubSubEvent { }
        public class MaxWindowEvent : PubSubEvent { }
        public class CloseWindowEvent : PubSubEvent { }
    }
}
