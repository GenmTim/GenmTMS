using Newtonsoft.Json;

namespace TMS.Core.Data.VO.Notification
{
    public enum ContactRequestState
    {
        [JsonProperty("pending")]
        Pending,

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
        public ContactRequestState State { get; set; }
    }
}
