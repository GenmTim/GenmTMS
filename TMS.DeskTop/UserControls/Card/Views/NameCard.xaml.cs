using HandyControl.Controls;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TMS.Core.Api;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Helper;
using static TMS.DeskTop.UserControls.Card.ViewModels.NameCardModel;

namespace TMS.DeskTop.UserControls.Card.Views
{
    /// <summary>
    /// NameCard.xaml 的交互逻辑
    /// 
    /// 验证是否为当前用户的好友，分为好友和非好友，从而进行对应名片的装载
    /// </summary>
    public partial class NameCard : UserControl
    {
        public class UpdateNameCardContentEvent : PubSubEvent<User> { }

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        private readonly IContainerProvider container;

        public Action Closed;

        public bool CanDispose => true;

        private string tel;
        public string Tel
        {
            get => tel;
            set
            {
                tel = value;
                UpdateUser();
            }
        }

        public static PopupWindow Show(IContainerExtension container, string tel)
        {
            var nameCard = container.Resolve<NameCard>();
            var window = new PopupWindow
            {
                PopupElement = nameCard,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                MinWidth = 0,
                ShowTitle = false,
                ShowBorder = false,
                MinHeight = 0,
            };
            nameCard.Closed += delegate { window.Close(); };
            nameCard.Tel = tel;
            window.Show();
            return window;
        }

        public NameCard(IRegionManager regionManager, IContainerProvider container, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.container = container;
            this.eventAggregator.GetEvent<CloseNameCardEvent>().Subscribe(Close);
        }

        private void UpdateUser()
        {
            Task.Factory.StartNew(async () =>
            {
                var result = await HttpService.GetConn().GetUserInfoByTel(Tel);
                if (result.StatusCode == 200)
                {
                    User user = (User)result.Data;
                    if (user == null || user.UserId == null)
                    {
                        eventAggregator.GetEvent<ToastShowEvent>().Publish("查无此联系人");
                        return;
                    }
                    result = await HttpService.GetConn().IsContact((long)user.UserId);
                    bool isContacter = (result.StatusCode == 200);
                    // 判断是否为好友，然后进行相应卡片的注入
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        if (isContacter)
                        {
                            _cardContent.Content = container.Resolve<FriendCard>();
                        }
                        else
                        {
                            _cardContent.Content = container.Resolve<NoFriendCard>();
                        }
                        eventAggregator.GetEvent<UpdateNameCardContentEvent>().Publish(user);
                    });
                }
            });

        }

        private void Close()
        {
            Closed.Invoke();
        }
    }
}
