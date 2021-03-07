using Prism.Ioc;
using System.Windows;
using TMS.Core.Service;
using TMS.DeskTop.Resources.Styles.Views.Recruitment;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Views;
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

        private string GetRoutePath(string view)
        {
            return RouteHelper.GetViewPath(view);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IDialogHostService, DialogHostService>();

            containerRegistry.RegisterForNavigation<WorkPlaceView>(GetRoutePath(nameof(WorkPlaceView)));
            containerRegistry.RegisterForNavigation<WorkPlaceMainView>(GetRoutePath(nameof(WorkPlaceMainView)));

            containerRegistry.RegisterForNavigation<EvaluationView>(GetRoutePath(nameof(EvaluationView)));
            containerRegistry.RegisterForNavigation<EvaluationMainView>(GetRoutePath(nameof(EvaluationMainView)));
            containerRegistry.RegisterForNavigation<FullInEvaluationView>(GetRoutePath(nameof(FullInEvaluationView)));
            containerRegistry.RegisterForNavigation<ManageEvaluationView>(GetRoutePath(nameof(ManageEvaluationView)));
            containerRegistry.RegisterForNavigation<ViewEvaluationView>(GetRoutePath(nameof(ViewEvaluationView)));
            containerRegistry.RegisterForNavigation<NewEvaluationRuleView>(GetRoutePath(nameof(NewEvaluationRuleView)));

            containerRegistry.RegisterForNavigation<ContactsView>(GetRoutePath(nameof(ContactsView)));

            containerRegistry.RegisterForNavigation<NotificationView>(GetRoutePath(nameof(NotificationView)));

            containerRegistry.RegisterForNavigation<AttendanceView>(GetRoutePath(nameof(AttendanceView)));
            containerRegistry.RegisterForNavigation<AttendanceMainView>(GetRoutePath(nameof(AttendanceMainView)));
            containerRegistry.RegisterForNavigation<AddAttendanceGroupView>(GetRoutePath(nameof(AddAttendanceGroupView)));
            containerRegistry.RegisterForNavigation<AdminSettingView>(GetRoutePath(nameof(AdminSettingView)));
            containerRegistry.RegisterForNavigation<AttendanceGroupSettingView>(GetRoutePath(nameof(AttendanceGroupSettingView)));
            containerRegistry.RegisterForNavigation<DailyStatisticsView>(GetRoutePath(nameof(DailyStatisticsView)));
            containerRegistry.RegisterForNavigation<FaceRecognitionView>(GetRoutePath(nameof(FaceRecognitionView)));
            containerRegistry.RegisterForNavigation<ShiftSettingView>(GetRoutePath(nameof(ShiftSettingView)));

            containerRegistry.RegisterForNavigation<RecruitmentView>(GetRoutePath(nameof(RecruitmentView)));
            containerRegistry.RegisterForNavigation<ManageRequirementsView>(GetRoutePath(nameof(ManageRequirementsView)));
            containerRegistry.RegisterForNavigation<RecruitmentNavigationView>(GetRoutePath(nameof(RecruitmentNavigationView)));
            containerRegistry.RegisterForNavigation<ViewRequirementsView>(GetRoutePath(nameof(ViewRequirementsView)));
            containerRegistry.RegisterForNavigation<ActivitiesRequirementsView>(GetRoutePath(nameof(ActivitiesRequirementsView)));
            containerRegistry.RegisterForNavigation<RequirementsMainView>(GetRoutePath(nameof(RequirementsMainView)));
            containerRegistry.RegisterForNavigation<NewRequirementView>(GetRoutePath(nameof(NewRequirementView)));
            containerRegistry.RegisterForNavigation<TalentPoolView>(GetRoutePath(nameof(TalentPoolView)));


            containerRegistry.RegisterForNavigation<CloudFileView>(GetRoutePath(nameof(CloudFileView)));



            containerRegistry.RegisterForNavigation<MajorEventView>(GetRoutePath(nameof(MajorEventView)));
            containerRegistry.RegisterForNavigation<HonourView>(GetRoutePath(nameof(HonourView)));
            containerRegistry.RegisterForNavigation<DisciplineView>(GetRoutePath(nameof(DisciplineView)));

            containerRegistry.RegisterForNavigation<BackNavigationView>();

            containerRegistry.RegisterDialog<CheckItemDialog>();
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
