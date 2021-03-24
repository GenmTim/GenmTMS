using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.ViewModels;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.Views;

namespace TMS.DeskTop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
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
            containerRegistry.Register<IDialogHostService, DialogHostService>();
            containerRegistry.RegisterForNavigation<ChatBox, ChatBoxViewModel>();

            RouteHelper.RegisterToContainer(containerRegistry);

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<LoginView>();
            var result = login.ShowDialog();

            //if (result.Value)
            //{
            //    var registerInfoEntry = Container.Resolve<NewUserQuestion>();
            //    result = registerInfoEntry.ShowDialog();
            //    if (result.Value)
            //{
                base.OnInitialized();
            //}
            //else
            //    Application.Current.Shutdown();
            //}
        }
    }
}
