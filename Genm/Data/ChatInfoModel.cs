using Genm.Data.Enums;
using System;

namespace Genm.Data
{
    public struct ChatInfoModel
    {
        public object Message { get; set; }

        public long SenderId { get; set; }

        public ChatRoleType Role { get; set; }

        public ChatMessageType Type { get; set; }

        public object Enclosure { get; set; }

        public long Timestamp { get; set; }

        public Uri Avatar { get; set; }
    }
}
