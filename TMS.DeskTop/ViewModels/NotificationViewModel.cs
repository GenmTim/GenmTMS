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
            testList = new List<NotificationItemEntity>
            {
                new NotificationItemEntity("img1", "登录操作通知", "SuperGame团队", "1月24日"),
                new NotificationItemEntity("img2", "文件夹共享提醒", "云文档助手", "1月21日"),
                new NotificationItemEntity("image3", "写汇报提醒", "汇报", "14:13"),
                new NotificationItemEntity("image4", "消息惺惺惜惺惺", "SuperGame", "10:34")
            };
        }
    }
}
