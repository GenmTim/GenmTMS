using Prism.Events;

namespace TMS.Core.Event
{
    public class WindowEvent
    {
        public class MinWindowEvent : PubSubEvent { }
        public class MaxWindowEvent : PubSubEvent { }
        public class CloseWindowEvent : PubSubEvent { }
    }
}
