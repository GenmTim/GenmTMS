using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
