using System.Collections.Generic;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels
{
    class NotificationViewModel
    {
        private List<NotificationItemEntity> testList;

        public List<NotificationItemEntity> TestList { get => testList; set => testList = value; }

        public NotificationViewModel()
        {
            testList = new List<NotificationItemEntity>();
            testList.Add(new NotificationItemEntity("img1", "登录操作通知", "飞书团队", "1月24日"));
            testList.Add(new NotificationItemEntity("img2", "文件夹共享提醒", "云文档助手", "1月21日"));
            testList.Add(new NotificationItemEntity("image3", "写汇报提醒", "汇报", "14:13"));
            testList.Add(new NotificationItemEntity("image4", "消息惺惺惜惺惺", "SuperGame", "10:34"));
        }
    }
}
