using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data.Entity;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;
using static TMS.DeskTop.UserControls.Card.ViewModels.NameCardModel;
using static TMS.DeskTop.UserControls.Card.Views.NameCard;

namespace TMS.DeskTop.UserControls.Card.ViewModels
{
    public class FriendCardViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand GoCommunicationCmd { get; private set; }
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

        public FriendCardViewModel(IRegionManager reigonManager, IEventAggregator eventAggregator)
        {
            this.regionManager = reigonManager;
            this.GoCommunicationCmd = new DelegateCommand(GoCommunication);
            this.eventAggregator = eventAggregator;
            this.CloseNameCardCmd = new DelegateCommand(() =>
            {
                this.eventAggregator.GetEvent<CloseNameCardEvent>().Publish();
            });
            this.eventAggregator.GetEvent<UpdateNameCardContentEvent>().Subscribe((user) =>
            {
                User = user;
            });
        }

        private void GoCommunication()
        {
            // 跳转到通知界面
            var param = new NavigationParameters
            {
                { "User", user }
            };
            RouteHelper.Goto(regionManager, typeof(MainWindow), typeof(NotificationView), param);
            eventAggregator.GetEvent<CloseNameCardEvent>().Publish();
        }
    }
}
