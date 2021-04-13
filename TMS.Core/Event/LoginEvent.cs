using Prism.Events;

namespace TMS.Core.Event
{
    public class LoginData
    {
        public string Username;
        public string Password;
    }

    public class LoginEvent : PubSubEvent<LoginData>
    {

    }

    public class LoginedEvent : PubSubEvent { }

}
