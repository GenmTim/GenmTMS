using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Dto;
using TMS.Core.Data.Entity;

namespace TMS.Core.Data
{
    public class NotificationData
    {
        [JsonProperty("sender")]
        public UserDto Sender;

        [JsonProperty("receiver")]
        public UserDto Receiver;

        [JsonProperty("type")]
        public int Type;

        [JsonProperty("subType")]
        public int SubType;

        [JsonProperty("data")]
        public object Data;

        [JsonProperty("timestamp")]
        public long Timestamp;
    }

}
