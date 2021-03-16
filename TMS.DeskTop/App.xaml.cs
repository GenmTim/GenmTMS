using Prism.Ioc;
using System.Windows;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Dialogs.ViewModels;
using TMS.DeskTop.UserControls.Dialogs.Views;
using TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions;
using TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions.BasicInfo;
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

            RouteHelper.RegisterToContainer(containerRegistry);

            containerRegistry.RegisterForNavigation<NewUserQuestionDialog, NewUserQuestionDialogModel>();
            containerRegistry.RegisterForNavigation<QuestionMainPage, QuestionMainPage>();
            containerRegistry.RegisterForNavigation<Question1Page, Question1Page>();
        }

        protected override void OnInitialized()
        {
            var login = Container.Resolve<LoginView>();
            var result = login.ShowDialog();

            if (result.Value)
            {
                var registerInfoEntry = Container.Resolve<NewUserQuestion>();
                result = registerInfoEntry.ShowDialog();
                if (result.Value)
                {
                    base.OnInitialized();
                }
                else
                    Application.Current.Shutdown();
            }
        }
    }
}
