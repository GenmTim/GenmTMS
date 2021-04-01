using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Api;
using TMS.Core.Data.Entity;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.Contacts;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class LinkManViewModel
    {
        private IRegionManager regionManager;

        public LinkManViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            friendList = new ObservableCollection<User>()
            {
                new User { UserId=10003 },
                new User { UserId=10004 }
            };
            this.GoCommunicationCmd = new DelegateCommand<User>(GoCommunication);
        }

        #region Property
        private ObservableCollection<User> friendList;
        public ObservableCollection<User> FriendList { get => friendList; set => friendList = value; }

        public DelegateCommand<User> GoCommunicationCmd { get; private set; }
        private void GoCommunication(User user)
        {
            var param = new NavigationParameters
            {
                { "User", user }
            };
            RouteHelper.Goto(regionManager, typeof(LinkManView), typeof(NotificationView), param);
        }
        #endregion
    }
}
