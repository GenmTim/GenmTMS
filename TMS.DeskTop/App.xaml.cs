using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Dialogs.ViewModels;
using TMS.DeskTop.UserControls.Dialogs.Views;
using TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions;
using TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions.BasicInfo;
using TMS.DeskTop.UserControls.ViewModels;
using TMS.DeskTop.UserControls.Views;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.Register;

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
            moduleCatalog.AddModule<ImportData.ImportDataModule>();
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<LoginView>();
            var result = login.ShowDialog();

            //if (result.Value)
            //{
            //    var registerInfoEntry = Container.Resolve<NewUserQuestion>();
            //    result = registerInfoEntry.ShowDialog();
                if (result.Value)
                {
                    base.OnInitialized();
                }
                else
                    Application.Current.Shutdown();
            //}
        }
    }
}
