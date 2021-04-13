using Newtonsoft.Json;
using TMS.Core.Data.Entity;

namespace TMS.Core.Data
{
    public class NotificationData
    {
        [JsonProperty("id")]
        public long Id;

        [JsonProperty("sender")]
        public User Sender;

        [JsonProperty("receiver")]
        public User Receiver;

        [JsonProperty("type")]
        public int Type;

        [JsonProperty("subType")]
        public int SubType;

        [JsonProperty("data")]
        public object Data;

        [JsonProperty("timestamp")]
        public long Timestamp;

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
