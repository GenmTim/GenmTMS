using Prism.Ioc;
using System.Windows;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.ViewModels;
using TMS.DeskTop.UserControls.Views;
using TMS.DeskTop.ViewModels;
using TMS.DeskTop.ViewModels.WorkPlace;
using TMS.DeskTop.ViewModels.WorkPlace.Evaluation;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.WorkPlace;
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogHostService, DialogHostService>();

            containerRegistry.RegisterForNavigation<WorkPlaceView, WorkPlaceViewModel>();
            containerRegistry.RegisterForNavigation<WorkPlaceMainView, WorkPlaceMainViewModel>();
            containerRegistry.RegisterForNavigation<EvaluationView, EvaluationViewModel>();
            containerRegistry.RegisterForNavigation<EvaluationMainView, EvaluationMainViewModel>();
            containerRegistry.RegisterForNavigation<FullInEvaluationView, FullInEvaluationViewModel>();
            containerRegistry.RegisterForNavigation<ManageEvaluationView, ManageEvaluationViewModel>();
            containerRegistry.RegisterForNavigation<ViewEvaluationView, ViewEvaluationViewModel>();
            containerRegistry.RegisterForNavigation<BackNavigationView, BackNavigationViewModel>();
            containerRegistry.RegisterForNavigation<NewEvaluationRuleView, NewEvaluationRuleViewModel>();
            containerRegistry.RegisterForNavigation<CheckItemDialog, CheckItemDialogModel>();
            containerRegistry.RegisterForNavigation<ContactsView, ContactsViewModel>();
            containerRegistry.RegisterForNavigation<NotificationView, NotificationViewModel>();
            containerRegistry.RegisterForNavigation<AttendanceView>();
            //containerRegistry.RegisterDialog<CheckItemDialog, CheckItemDialogModel>();
            //containerRegistry.Register<EvaluationViewModel>();
        }
    }
}
