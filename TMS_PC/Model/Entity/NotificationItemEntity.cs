namespace TMS_PC.Model.Entity
{
    class NotificationItemEntity
    {
        private string imgName;
        private string content;
        private string title;
        private string date;

        public NotificationItemEntity(string imgName, string content, string title, string date)
        {
            this.imgName = imgName;
            this.content = content;
            this.title = title;
            this.date = date;
        }

        public string Date { get => date; set => date = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string ImgName { get => imgName; set => imgName = value; }
    }
}
