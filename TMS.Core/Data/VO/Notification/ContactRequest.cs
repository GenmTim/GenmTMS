using Newtonsoft.Json;
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
        [JsonProperty("refuse")]
        Refuse,

        [JsonProperty("accept")]
        Accept,
    }

    public class ContactRequest
    {
        [JsonProperty("requester_id")]
        public long RequesterId { get; set; }

        [JsonProperty("accepter_id")]
        public long AccepterId { get; set; }

        [JsonProperty("state")]
        public ContactRequestState State { get; set;}
    }
}
