using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data.Entity;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;

namespace TMS.DeskTop.ViewModels.Contacts
{
    class CustomerServiceViewModel : BindableBase
    {
        public DelegateCommand GoCustomerServiceCmd { get; private set; }
        private readonly IRegionManager regionManager;
        public CustomerServiceViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            GoCustomerServiceCmd = new DelegateCommand(() =>
            {
                Task.Factory.StartNew(async () =>
                {
                    var result = await HttpService.GetConn().GetUserInfo(10006);
                    if (result.StatusCode == 200)
                    {
                        var user = (User)result.Data;
                        var param = new NavigationParameters
                        {
                            { "User", user }
                        };
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            RouteHelper.Goto(regionManager, typeof(CustomerServiceViewModel), typeof(NotificationView), param);
                        });
                    }

                });
            });
        }
    }
}
