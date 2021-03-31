using TMS.Core.Data.Dto;

namespace TMS.Core.Data
{
    public class NotificationItemEntity
    {
        public UserDto User {get; set;}
        public string ImgUrl { get; set; }
        public string NewMessage { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }

        public override int GetHashCode()
        {
            return (int)User.UserId;
        }
    }
}
