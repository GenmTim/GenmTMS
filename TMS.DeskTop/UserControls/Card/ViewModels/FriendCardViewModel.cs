using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;
using static TMS.DeskTop.UserControls.Card.ViewModels.NameCardModel;

namespace TMS.DeskTop.UserControls.Card.ViewModels
{
    public class FriendCardViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand<User> GoCommunicationCmd { get; private set; }
       
        public FriendCardViewModel(IRegionManager reigonManager, IEventAggregator eventAggregator)
        {
            this.regionManager = reigonManager;
            this.GoCommunicationCmd = new DelegateCommand<User>(GoCommunication);
            this.eventAggregator = eventAggregator;
        }

        private void GoCommunication(User user)
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
