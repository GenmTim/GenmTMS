using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data.Entity;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.Contacts;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class LinkManViewModel : BindableBase
    {
        private IRegionManager regionManager;

        public LinkManViewModel(IRegionManager regionManager)
        {
            UpdateContacterList();
            this.regionManager = regionManager;
            this.GoCommunicationCmd = new DelegateCommand<User>(GoCommunication);
        }

        private void UpdateContacterList()
        {
            Task.Factory.StartNew(async() => 
            {
                var result = await HttpService.GetConn().GetContacterList((long)SessionService.User.UserId);
                if (result.StatusCode == 200)
                {
                    List<User> users = (List<User>)result.Data;
                    Application.Current.Dispatcher.Invoke(() => 
                    {
                        contacterList.Clear();
                        users.ForEach((user) => { contacterList.Add(user); });
                    });
                    
                }
            });
        }

        #region Property
        private ObservableCollection<User> contacterList = new ObservableCollection<User>();
        public ObservableCollection<User> ContacterList 
        { 
            get => contacterList;
            set
            {
                contacterList = value;
                RaisePropertyChanged();
            }
        }

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
