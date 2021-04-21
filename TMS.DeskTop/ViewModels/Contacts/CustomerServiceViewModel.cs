using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data.Entity;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class CSQuestion
    {
        public string Content { get; set; }
    }
    class CustomerServiceViewModel : BindableBase
    {
        public DelegateCommand GoCustomerServiceCmd { get; private set; }

        private ObservableCollection<CSQuestion> cSQuestionList;
        public ObservableCollection<CSQuestion> CSQuestionList
        {
            get => cSQuestionList;
            set
            {
                cSQuestionList = value;
                RaisePropertyChanged();
            }
        }

        private readonly IRegionManager regionManager;
        public CustomerServiceViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            CSQuestionList ??= new ObservableCollection<CSQuestion>()
            {
                new CSQuestion { Content="如何创建自定义规则模板？" },
                new CSQuestion { Content="能导出规则模板吗？" },
                new CSQuestion { Content="为什么无法使用搜索功能？" },
                new CSQuestion { Content="我该怎么修改评价" },
                new CSQuestion { Content="积分如何获取" },
                new CSQuestion { Content="补充个人信息在哪？" },
                new CSQuestion { Content="能够通过充值获取积分吗？" },
                new CSQuestion { Content="被恶意评价了，该怎么办？" },
            };
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
