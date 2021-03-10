using System.Collections.Generic;
using TMS.Core.Data;
using TMS.DeskTop.Resources.Styles.Views.Recruitment;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.Recruitment.Requirements;
using TMS.DeskTop.Views.Recruitment.Requirements.Subitem;
using TMS.DeskTop.Views.WorkPlace;
using TMS.DeskTop.Views.WorkPlace.Approval;
using TMS.DeskTop.Views.WorkPlace.Attendance;
using TMS.DeskTop.Views.WorkPlace.Attendance.Subitem;
using TMS.DeskTop.Views.WorkPlace.Evaluation;

namespace TMS.DeskTop.Tools.Helper
{
    public class BackPageViewInfo
    {
        public string Title;
        public System.Type View;
    };

    public class Router
    {
        private static Router instance = null;
        public static Router Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Router();
                }
                return instance;
            }
        }

        public string Root { get; set; } = "";
        private Dictionary<string, string> routeMap;
        private Dictionary<string, string> routeReMap;
        private Dictionary<string, string> navigationRegionRegedit;
        private Dictionary<string, BackPageViewInfo> backPageViewRegedit;

        private Router()
        {
            InitRouteMap();
            InitRouteReMap();
            InitNavigationRegionRegedit();
            InitBackNavigationViewRegedit();
        }

        private void InitRouteReMap()
        {
            routeReMap = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in routeMap)
            {
                routeReMap.Add(kvp.Value, kvp.Key);
            }
        }

        private void InitBackNavigationViewRegedit()
        {
            backPageViewRegedit = new Dictionary<string, BackPageViewInfo>
            {
                [nameof(NewEvaluationRuleView)] = new BackPageViewInfo { Title = NewEvaluationRuleView.Title, View = typeof(NewEvaluationRuleView) },
                [nameof(TalentPoolView)] = new BackPageViewInfo { Title = TalentPoolView.Title, View = typeof(TalentPoolView) },
                [nameof(NewRequirementView)] = new BackPageViewInfo { Title = NewRequirementView.Title, View = typeof(NewRequirementView) },
            };
        }

        private void InitNavigationRegionRegedit()
        {
            navigationRegionRegedit = new Dictionary<string, string>
            {
                [nameof(MainWindow)] = RegionToken.MainContent,
                [nameof(WorkPlaceView)] = RegionToken.WorkPlaceTabContent,
                [nameof(RecruitmentView)] = RegionToken.RecruitmentContent,
                [nameof(RequirementsMainView)] = RegionToken.RecruitmentRequirementsMainContent,
                [nameof(AttendanceView)] = RegionToken.AttendanceContent,
                [nameof(AttendanceMainView)] = RegionToken.AttendanceMainContent,
                [nameof(EvaluationView)] = RegionToken.EvaluationContent,
                [nameof(EvaluationMainView)] = RegionToken.EvaluationMainContent
            };
        }

        private void InitRouteMap()
        {
            routeMap = new Dictionary<string, string>();
            Root = "";
            routeMap[nameof(MainWindow)] = Root;
            routeMap[nameof(NotificationView)] = "notification/";
            routeMap[nameof(ContactsView)] = "contacts/";
            routeMap[nameof(CloudFileView)] = "cloudfile/";
            routeMap[nameof(KalendarView)] = "kalendar/";
            routeMap[nameof(WorkPlaceView)] = "workplace/";
            {
                routeMap[nameof(WorkPlaceMainView)] = routeMap[nameof(WorkPlaceView)] + "main/";
                routeMap[nameof(MajorEventView)] = routeMap[nameof(WorkPlaceView)] + "major_event/";
                routeMap[nameof(RecruitmentView)] = routeMap[nameof(WorkPlaceView)] + "recruitment/";
                {
                    routeMap[nameof(RequirementsMainView)] = routeMap[nameof(RecruitmentView)] + "main/";
                    {
                        routeMap[nameof(ManageRequirementsView)] = routeMap[nameof(RequirementsMainView)] + "manage/";
                        routeMap[nameof(RecruitmentNavigationView)] = routeMap[nameof(RequirementsMainView)] + "navigation/";
                        routeMap[nameof(ViewRequirementsView)] = routeMap[nameof(RequirementsMainView)] + "view/";
                        routeMap[nameof(ActivitiesRequirementsView)] = routeMap[nameof(RequirementsMainView)] + "activities/";
                        routeMap[nameof(NewRequirementView)] = routeMap[nameof(RequirementsMainView)] + "new/";
                        routeMap[nameof(TalentPoolView)] = routeMap[nameof(RequirementsMainView)] + "talent_pool/";
                    }
                }
                routeMap[nameof(AttendanceView)] = routeMap[nameof(WorkPlaceView)] + "attendance/";
                {
                    routeMap[nameof(AttendanceMainView)] = routeMap[nameof(AttendanceView)] + "main/";
                    {
                        routeMap[nameof(AddAttendanceGroupView)] = routeMap[nameof(AttendanceMainView)] + "new/";
                        routeMap[nameof(AdminSettingView)] = routeMap[nameof(AttendanceMainView)] + "admin_setting/";
                        routeMap[nameof(AttendanceGroupSettingView)] = routeMap[nameof(AttendanceMainView)] + "group_setting/";
                        routeMap[nameof(DailyStatisticsView)] = routeMap[nameof(AttendanceMainView)] + "daily_statistics/";
                        routeMap[nameof(FaceRecognitionView)] = routeMap[nameof(AttendanceMainView)] + "face_recognition/";
                        routeMap[nameof(ShiftSettingView)] = routeMap[nameof(AttendanceMainView)] + "shift_setting/";
                    }
                }
                routeMap[nameof(EvaluationView)] = routeMap[nameof(WorkPlaceView)] + "evaluation/";
                {
                    routeMap[nameof(NewEvaluationRuleView)] = routeMap[nameof(EvaluationView)] + "new/";
                    routeMap[nameof(EvaluationMainView)] = routeMap[nameof(EvaluationView)] + "main/";
                    {
                        routeMap[nameof(FullInEvaluationView)] = routeMap[nameof(EvaluationMainView)] + "fullIn/";
                        routeMap[nameof(ViewEvaluationView)] = routeMap[nameof(EvaluationMainView)] + "view/";
                        routeMap[nameof(ManageEvaluationView)] = routeMap[nameof(EvaluationMainView)] + "manage/";
                    }
                }

                routeMap[nameof(MajorEventView)] = routeMap[nameof(WorkPlaceView)] + "major_event/";
                //{
                //    routeMap[nameof(HonourView)] = routeMap[nameof(MajorEventView)] + "honour/";
                //    routeMap[nameof(DisciplineView)] = routeMap[nameof(MajorEventView)] + "discipline/";
                //}

                routeMap[nameof(ApprovalView)] = routeMap[nameof(WorkPlaceView)] + "approval/";
                {
                    routeMap[nameof(HonourView)] = routeMap[nameof(ApprovalView)] + "honour/";
                    routeMap[nameof(DisciplineView)] = routeMap[nameof(ApprovalView)] + "discipline/";
                }
            }
        }

        public string GetRegionName(string view)
        {
            return navigationRegionRegedit[view];
        }

        public string GetViewName(string vewiPath)
        {
            return routeReMap[vewiPath];
        }

        public string GetViewPath(string view)
        {
            bool isHas = routeMap.TryGetValue(view, out string viewPath);
            return isHas ? viewPath : view;
        }

        public bool IsBackPage(string view)
        {
            return backPageViewRegedit.ContainsKey(view);
        }

        public BackPageViewInfo GetBackPageViewInfo(string view)
        {
            return backPageViewRegedit[view];
        }
    }
}
