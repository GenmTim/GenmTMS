using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Card.ViewModels;
using TMS.DeskTop.UserControls.Card.Views;
using TMS.DeskTop.UserControls.Common.ViewModels;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.UserControls.Common.Views.ChatBubbles;
using TMS.DeskTop.UserControls.Dialogs.ViewModels;
using TMS.DeskTop.UserControls.Dialogs.Views;
using TMS.DeskTop.Views;

namespace TMS.DeskTop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private IContainerRegistry containerRegistry;

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        //private string GetRoutePath(Type view)
        //{
        //    return RouteHelper.GetViewPath(view);
        //}

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            this.containerRegistry = containerRegistry;

            // 注册服务
            containerRegistry.Register<IDialogHostService, DialogHostService>();

            // 注册全局单例服务
            containerRegistry.RegisterSingleton<WebSocketService>();

            // 注册视图
            containerRegistry.Register<LoginView>();
            containerRegistry.Register<Sender_ContacterRequestChatBubble>();

            // 注册对话框视图
            containerRegistry.RegisterForNavigation<StringItemsDialog, StringItemsDialogModel>();
            containerRegistry.RegisterForNavigation<SelectUserDialog, SelectUserDialogModel>();
            containerRegistry.RegisterForNavigation<AddNewFriendDialog, AddNewFriendDialogModel>();

            // 注册卡片
            containerRegistry.Register<NameCard>();
            containerRegistry.RegisterForNavigation<FriendCard, FriendCardViewModel>();
            containerRegistry.RegisterForNavigation<NoFriendCard, NoFriendCardViewModel>();

            // 注册导航视图
            RouteHelper.RegisterToContainer(containerRegistry);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<LoginView>();
            var result = login.ShowDialog();

            // 判断是否是刚注册，如若刚注册，则需要填写相关问券


            // 记录Session



            // 初始化当前用户信息



            // 获取最新通知消息记录



            if (result.Value)
            {
                Container.Resolve<WebSocketService>();
                base.OnInitialized();
            }
            else
            {
                Application.Current.Shutdown();
            }
            //if (result.Value)
            //{
            //    var registerInfoEntry = Container.Resolve<NewUserQuestion>();
            //    result = registerInfoEntry.ShowDialog();
            //    if (result.Value)
            //{
            //}
            //else
            //    Application.Current.Shutdown();
            //}
        }
    }
}
