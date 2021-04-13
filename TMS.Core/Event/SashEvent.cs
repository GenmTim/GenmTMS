using Prism.Events;

namespace TMS.Core.Event
{
    public class CloseSashEvent : PubSubEvent
    {
    }

    public class SashEvent : PubSubEvent<object>
    {
    }
}
