using System;
using System.Collections.Generic;
using TMS.Core.Data;
using TMS.DeskTop.Resources.Styles.Views.Recruitment;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.Contacts;
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

        public Type Root { get; set; }
        public string RootPath { get; set; } = "";
        private Dictionary<string, Type> viewTypeMap;
        private Dictionary<Type, string> routeMap;
        private Dictionary<string, Type> routeReMap;
        private Dictionary<Type, string> navigationRegionRegedit;
        private Dictionary<Type, BackPageViewInfo> backPageViewRegedit;

        private Router()
        {
            InitRouteMap();
            InitRouteReMap();
            InitNavigationRegionRegedit();
            InitBackNavigationViewRegedit();
            InitViewTypeMap();
        }

        public Dictionary<Type, string> GetRouteMap()
        {
            return routeMap;
        }

        private void InitRouteReMap()
        {
            routeReMap = new Dictionary<string, Type>();
            foreach (KeyValuePair<Type, string> kvp in routeMap)
            {
                routeReMap.Add(kvp.Value, kvp.Key);
            }
        }

        private void InitViewTypeMap()
        {
            viewTypeMap = new Dictionary<string, Type>();
            foreach(Type type in routeMap.Keys)
            {
                viewTypeMap[type.Name] = type;
            }
        }

        private void InitBackNavigationViewRegedit()
        {
            backPageViewRegedit = new Dictionary<Type, BackPageViewInfo>
            {
                [typeof(NewEvaluationRuleView)] = new BackPageViewInfo { Title = NewEvaluationRuleView.Title, View = typeof(NewEvaluationRuleView) },
                [typeof(TalentPoolView)] = new BackPageViewInfo { Title = TalentPoolView.Title, View = typeof(TalentPoolView) },
                [typeof(NewRequirementView)] = new BackPageViewInfo { Title = NewRequirementView.Title, View = typeof(NewRequirementView) },
            };
        }

        private void InitNavigationRegionRegedit()
        {
            navigationRegionRegedit = new Dictionary<Type, string>
            {
                [typeof(MainWindow)] = RegionToken.MainContent,
                [typeof(WorkPlaceView)] = RegionToken.WorkPlaceTabContent,
                [typeof(RecruitmentView)] = RegionToken.RecruitmentContent,
                [typeof(RequirementsMainView)] = RegionToken.RecruitmentRequirementsMainContent,
                [typeof(AttendanceView)] = RegionToken.AttendanceContent,
                [typeof(AttendanceMainView)] = RegionToken.AttendanceMainContent,
                [typeof(EvaluationView)] = RegionToken.EvaluationContent,
                [typeof(EvaluationMainView)] = RegionToken.EvaluationMainContent,
                [typeof(ContactsView)] = RegionToken.ContactsContent,
            };
        }

        private void InitRouteMap()
        {
            routeMap = new Dictionary<Type, string>();

            Root = typeof(MainWindow);
            RootPath = "";
            routeMap[Root] = RootPath;
            routeMap[typeof(NotificationView)] = "notification/";
            routeMap[typeof(ContactsView)] = "contacts/";
            {
                routeMap[typeof(OrganizationalStructrureView)] = routeMap[typeof(ContactsView)] + "organizational/";
                routeMap[typeof(PersonalInfoView)] = routeMap[typeof(ContactsView)] + "personal/";
            }
            routeMap[typeof(CloudFileView)] = "cloudfile/";
            //routeMap[nameof(KalendarView)] = "kalendar/";
            routeMap[typeof(WorkPlaceView)] = "workplace/";
            {
                routeMap[typeof(WorkPlaceMainView)] = routeMap[typeof(WorkPlaceView)] + "main/";

                //routeMap[nameof(RecruitmentView)] = routeMap[nameof(WorkPlaceView)] + "recruitment/";
                //{
                //    routeMap[nameof(RequirementsMainView)] = routeMap[nameof(RecruitmentView)] + "main/";
                //    {
                //        routeMap[nameof(ManageRequirementsView)] = routeMap[nameof(RequirementsMainView)] + "manage/";
                //        routeMap[nameof(RecruitmentNavigationView)] = routeMap[nameof(RequirementsMainView)] + "navigation/";
                //        routeMap[nameof(ViewRequirementsView)] = routeMap[nameof(RequirementsMainView)] + "view/";
                //        routeMap[nameof(ActivitiesRequirementsView)] = routeMap[nameof(RequirementsMainView)] + "activities/";
                //        routeMap[nameof(NewRequirementView)] = routeMap[nameof(RequirementsMainView)] + "new/";
                //        routeMap[nameof(TalentPoolView)] = routeMap[nameof(RequirementsMainView)] + "talent_pool/";
                //    }
                //}

                //routeMap[nameof(AttendanceView)] = routeMap[nameof(WorkPlaceView)] + "attendance/";
                //{
                //    routeMap[nameof(AttendanceMainView)] = routeMap[nameof(AttendanceView)] + "main/";
                //    {
                //        routeMap[nameof(AddAttendanceGroupView)] = routeMap[nameof(AttendanceMainView)] + "new/";
                //        routeMap[nameof(AdminSettingView)] = routeMap[nameof(AttendanceMainView)] + "admin_setting/";
                //        routeMap[nameof(AttendanceGroupSettingView)] = routeMap[nameof(AttendanceMainView)] + "group_setting/";
                //        routeMap[nameof(DailyStatisticsView)] = routeMap[nameof(AttendanceMainView)] + "daily_statistics/";
                //        routeMap[nameof(FaceRecognitionView)] = routeMap[nameof(AttendanceMainView)] + "face_recognition/";
                //        routeMap[nameof(ShiftSettingView)] = routeMap[nameof(AttendanceMainView)] + "shift_setting/";
                //    }
                //}

                //routeMap[nameof(EvaluationView)] = routeMap[nameof(WorkPlaceView)] + "evaluation/";
                //{
                //    routeMap[nameof(NewEvaluationRuleView)] = routeMap[nameof(EvaluationView)] + "new/";
                //    routeMap[nameof(EvaluationMainView)] = routeMap[nameof(EvaluationView)] + "main/";
                //    {
                //        routeMap[nameof(FullInEvaluationView)] = routeMap[nameof(EvaluationMainView)] + "fullIn/";
                //        routeMap[nameof(ViewEvaluationView)] = routeMap[nameof(EvaluationMainView)] + "view/";
                //        routeMap[nameof(ManageEvaluationView)] = routeMap[nameof(EvaluationMainView)] + "manage/";
                //    }
                //}

                //routeMap[nameof(MajorEventView)] = routeMap[nameof(WorkPlaceView)] + "major_event/";
                //{
                //    routeMap[nameof(HonourView)] = routeMap[nameof(MajorEventView)] + "honour/";
                //    routeMap[nameof(DisciplineView)] = routeMap[nameof(MajorEventView)] + "discipline/";
                //}

                //routeMap[nameof(ApprovalView)] = routeMap[nameof(WorkPlaceView)] + "approval/";
                //{
                //    routeMap[nameof(HonourView)] = routeMap[nameof(ApprovalView)] + "honour/";
                //    routeMap[nameof(DisciplineView)] = routeMap[nameof(ApprovalView)] + "discipline/";
                //}
            }
        }

        public string GetRegionName(Type view)
        {
            return navigationRegionRegedit[view];
        }

        public Type ConvertViewPathToType(string vewiPath)
        {
            return routeReMap[vewiPath];
        }

        public Type ConverterViewNameToType(string viewName)
        {
            return viewTypeMap[viewName];
        }

        public string GetViewPath(Type view)
        {
            bool isHas = routeMap.TryGetValue(view, out string viewPath);
            return isHas ? viewPath : view.Name;
        }

        public bool IsBackPage(Type view)
        {
            return backPageViewRegedit.ContainsKey(view);
        }

        public BackPageViewInfo GetBackPageViewInfo(Type view)
        {
            return backPageViewRegedit[view];
        }
    }
}
