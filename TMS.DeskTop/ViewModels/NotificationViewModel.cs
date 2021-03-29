using Prism.Commands;
using Prism.Events;
using System.Collections.Generic;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels
{
    class NotificationViewModel
    {
        public class ConnectionEvent : PubSubEvent<NotificationItemEntity> { }

        private List<NotificationItemEntity> testList;

        public List<NotificationItemEntity> TestList { get => testList; set => testList = value; }

        public NotificationViewModel(IEventAggregator eventAggregator)
        {
            testList = new List<NotificationItemEntity>
            {
                new NotificationItemEntity{ Id=43, ImgName="img1", Content="登录操作通知", Title="SuperGame团队", Date="1月24日" },
                new NotificationItemEntity{ Id=234, ImgName= "img2",Content= "文件夹共享提醒", Title="云文档助手",Date= "1月21日"},
                new NotificationItemEntity{ Id =12, ImgName="image3", Content="写汇报提醒", Title="汇报", Date="14:13" },
                new NotificationItemEntity{ Id=34, ImgName="image4", Content="消息惺惺惜惺惺", Title="SuperGame", Date="10:34" }
            };
            //GoConnectionCmd = new DelegateCommand<NotificationItemEntity>((data) =>
            //{
            //    eventAggregator.GetEvent<ConnectionEvent>().Publish(data);
            //});
        }

        //public DelegateCommand<NotificationItemEntity> GoConnectionCmd { get; private set; }

    }
}
