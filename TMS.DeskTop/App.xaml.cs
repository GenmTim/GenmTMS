using Prism.Ioc;
using System.Windows;
using TMS.Core.Service;
using TMS.DeskTop.Resources.Styles.Views.Recruitment;
using TMS.DeskTop.UserControls.ViewModels;
using TMS.DeskTop.UserControls.Views;
using TMS.DeskTop.ViewModels;
using TMS.DeskTop.ViewModels.Recruitment;
using TMS.DeskTop.ViewModels.Recruitment.Requirements.Subitem;
using TMS.DeskTop.ViewModels.WorkPlace;
using TMS.DeskTop.ViewModels.WorkPlace.Attendance;
using TMS.DeskTop.ViewModels.WorkPlace.Attendance.Subitem;
using TMS.DeskTop.ViewModels.WorkPlace.Evaluation;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.Recruitment.Requirements;
using TMS.DeskTop.Views.Recruitment.Requirements.Subitem;
using TMS.DeskTop.Views.WorkPlace;
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
            containerRegistry.RegisterForNavigation<BackNavigationView, BackNavigationView>();
            containerRegistry.RegisterForNavigation<NewEvaluationRuleView, NewEvaluationRuleViewModel>();
            containerRegistry.RegisterForNavigation<CheckItemDialog, CheckItemDialogModel>();
            containerRegistry.RegisterForNavigation<ContactsView, ContactsViewModel>();
            containerRegistry.RegisterForNavigation<NotificationView, NotificationViewModel>();
            containerRegistry.RegisterForNavigation<AttendanceView>();
            containerRegistry.RegisterForNavigation<AttendanceMainView, AttendanceMainViewModel>();
            containerRegistry.RegisterForNavigation<AddAttendanceGroupView>();
            containerRegistry.RegisterForNavigation<AdminSettingView>();
            containerRegistry.RegisterForNavigation<AttendanceGroupSettingView, AttendanceGroupSettingViewModel>();
            containerRegistry.RegisterForNavigation<DailyStatisticsView>();
            containerRegistry.RegisterForNavigation<FaceRecognitionView>();
            containerRegistry.RegisterForNavigation<ShiftSettingView>();
            containerRegistry.RegisterForNavigation<RecruitmentView, RecruitmentViewModel>();
            containerRegistry.RegisterForNavigation<ManageRequirementsView, ManageRequirementsViewModel>();
            containerRegistry.RegisterForNavigation<RecruitmentNavigationView, RecruitmentNavigationViewModel>();
            containerRegistry.RegisterForNavigation<ViewRequirementsView, ViewRequirementsViewModel>();
            containerRegistry.RegisterForNavigation<ActivitiesRequirementsView, ActivitiesRequirementsViewModel>();
            containerRegistry.RegisterForNavigation<RequirementsMainView>();
            containerRegistry.RegisterForNavigation<NewRequirementView>();
            containerRegistry.RegisterForNavigation<TalentPoolView, TalentPoolViewModel>();
            //containerRegistry.RegisterDialog<CheckItemDialog, CheckItemDialogModel>();
            //containerRegistry.Register<EvaluationViewModel>();
        }
    }
}
