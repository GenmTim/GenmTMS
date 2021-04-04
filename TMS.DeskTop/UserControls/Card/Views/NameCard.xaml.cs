using HandyControl.Controls;
using HandyControl.Tools;
using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMS.Core.Api;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
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

        public static void Show(IContainerExtension container, string tel)
        {
            var nameCard = container.Resolve<NameCard>();
            var window = new PopupWindow
            {
                PopupElement = nameCard,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                AllowsTransparency = true,
                WindowStyle = WindowStyle.None,
                MinWidth = 0,
                MinHeight = 0,
                Title = "NameCard"
            };
            nameCard.Closed += delegate { window.Close(); };
            nameCard.Tel = tel;
            window.Show();
        }

        public NameCard(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<CloseNameCardEvent>().Subscribe(Close);
        }

        private void UpdateUser()
        {
            Task.Factory.StartNew(async() => 
            {
                var result = await HttpService.GetConn().GetUserInfo(10005);
                if (result.StatusCode == 200)
                {
                    User user = (User)result.Data;
                    // 判断是否为好友，然后进行相应卡片的注入
                    Application.Current.Dispatcher.Invoke(() => 
                    {
                        if (true)
                        {
                            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.NameCardContent, typeof(NoFriendCard));
                        }
                        else
                        {
                            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.NameCardContent, typeof(FriendCard));
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
