using Prism.Commands;
using Prism.Events;
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
        public class UpdateContacterListEvent : PubSubEvent { }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public LinkManViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            UpdateContacterList();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.GoCommunicationCmd = new DelegateCommand<User>(GoCommunication);
            this.DeleteContacterCmd = new DelegateCommand<User>(DeleteContacter);
            this.eventAggregator.GetEvent<UpdateContacterListEvent>().Subscribe(() => 
            {
                UpdateContacterList();
            });
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
        public DelegateCommand<User> DeleteContacterCmd { get; private set; }

        private void GoCommunication(User user)
        {
            var param = new NavigationParameters
            {
                { "User", user }
            };
            RouteHelper.Goto(regionManager, typeof(LinkManView), typeof(NotificationView), param);
        }

        private void DeleteContacter(User user)
        {
            Task.Factory.StartNew(async() => 
            {
                var result = await HttpService.GetConn().DeleteContacter((long)SessionService.User.UserId ,(long)user.UserId);
                if (result.StatusCode == 200)
                {
                    eventAggregator.GetEvent<UpdateContacterListEvent>().Publish();
                }
            });
        }
        #endregion
    }
}
