using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;

namespace TMS.Core.Data.VO.Notification
{
    public enum ContactRequestState
    {
        Requesting,
        Refuse,
        Accept,
    }

    public class ContactRequest
    {
        public User RequestId { get; set; }
        public User AccepterId { get; set; }
        public ContactRequestState State { get; set;}
    }
}
