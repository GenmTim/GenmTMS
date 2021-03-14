using Prism.Ioc;
using System.Windows;
using TMS.Core.Service;
using TMS.DeskTop.Resources.Styles.Views.Recruitment;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Dialogs.ViewModels;
using TMS.DeskTop.UserControls.Dialogs.Views;
using TMS.DeskTop.UserControls.Views;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.Contacts;
using TMS.DeskTop.Views.Recruitment.Requirements;
using TMS.DeskTop.Views.Recruitment.Requirements.Subitem;
using TMS.DeskTop.Views.WorkPlace;
using TMS.DeskTop.Views.WorkPlace.Approval;
using TMS.DeskTop.Views.WorkPlace.Attendance;
using TMS.DeskTop.Views.WorkPlace.Attendance.Subitem;
using TMS.DeskTop.Views.WorkPlace.Evaluation;

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

            RouteHelper.RegisterToContainer(containerRegistry);
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<LoginView>();
            var result = login.ShowDialog();

            if (result.Value)
                base.OnInitialized();
            else
                Application.Current.Shutdown();
        }
    }
}
