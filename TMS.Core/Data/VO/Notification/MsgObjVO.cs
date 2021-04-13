using System;

namespace TMS.Core.Data.VO
{
    public class MsgObjVO
    {
        public long ObjectId { get; set; }
        public Uri Avatar { get; set; }
        public string NewMessage { get; set; }
        public string ObjectName { get; set; }
        public long NewMessageTimestamp { get; set; }
        public int BadgeNumber { get; set; }

        public override int GetHashCode()
        {
            return (int)ObjectId;
        }
    }
}
