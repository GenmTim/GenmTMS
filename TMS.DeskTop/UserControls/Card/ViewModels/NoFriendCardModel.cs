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
    public class NoFriendCardModel
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public DelegateCommand<User> GoCommunicationCmd;

        public NoFriendCardModel(IRegionManager reigonManager, IEventAggregator eventAggregator)
        {
            this.regionManager = reigonManager;
            this.GoCommunicationCmd = new DelegateCommand<User>(GoGetNewContacter);
        }

        private void GoGetNewContacter(User user)
        {
            // 跳转到通知界面，并发送联系人添加申请
            var param = new NavigationParameters
            {
                { "User", user },
                { "NotificationData", user }
            };
            RouteHelper.Goto(regionManager, typeof(MainWindow), typeof(NotificationView), param);
            eventAggregator.GetEvent<CloseNameCardEvent>().Publish();
        }
    }
}
