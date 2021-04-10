using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Data.VO.Notification;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;
using static TMS.DeskTop.UserControls.Card.ViewModels.NameCardModel;
using static TMS.DeskTop.UserControls.Card.Views.NameCard;

namespace TMS.DeskTop.UserControls.Card.ViewModels
{
    public class NoFriendCardViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand GoGetNewContacterCmd { get; private set; }
        public DelegateCommand CloseNameCardCmd { get; private set; }

        private User user;
        public User User
        {
            get => user;
            set
            {
                user = value;
                RaisePropertyChanged();
            }
        }

        public NoFriendCardViewModel(IRegionManager reigonManager, IEventAggregator eventAggregator)
        {
            this.regionManager = reigonManager;
            this.eventAggregator = eventAggregator;
            this.GoGetNewContacterCmd = new DelegateCommand(GoGetNewContacter);
            this.CloseNameCardCmd = new DelegateCommand(() => 
            {
                this.eventAggregator.GetEvent<CloseNameCardEvent>().Publish();
            });
            this.eventAggregator.GetEvent<UpdateNameCardContentEvent>().Subscribe((user) =>
            {
                User = user;
            });
        }

        private void GoGetNewContacter()
        {
            var contactRequest = new Core.Data.VO.Notification.ContactRequest()
            {
                RequesterId = (long)SessionService.User.UserId,
                AccepterId = (long)user.UserId,
                State = ContactRequestState.Pending
            };
            NotificationData notificationData = new NotificationData
            {
                Sender = SessionService.User,
                Receiver = user,
                Type = 1,
                SubType = 0,
                Timestamp = TimeHelper.GetNowTimeStamp(),
                Data = JsonConvert.SerializeObject(contactRequest),
            };

            // 跳转到通知界面，并发送联系人添加申请
            var param = new NavigationParameters
            {
                { "User", user },
                { "NotificationData", notificationData }
            };
            RouteHelper.Goto(regionManager, typeof(MainWindow), typeof(NotificationView), param);

            eventAggregator.GetEvent<CloseNameCardEvent>().Publish();
        }
    }
}
