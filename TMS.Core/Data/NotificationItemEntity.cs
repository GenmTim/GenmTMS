namespace TMS.Core.Data
{
    public class NotificationItemEntity
    {
        public string ImgName { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }

        public NotificationItemEntity(string imgName, string content, string title, string date)
        {
            this.ImgName = imgName;
            this.Content = content;
            this.Title = title;
            this.Date = date;
        }
    }
}
