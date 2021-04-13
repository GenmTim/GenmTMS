using System;
using TMS.Core.Data.Entity;

namespace TMS.Core.Data
{
    public class NotificationItemEntity
    {
        public User User { get; set; }
        public Uri ImgUrl { get; set; }
        public string NewMessage { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }

        public override int GetHashCode()
        {
            return (int)User.UserId;
        }
    }
}
