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
            routeMap[typeof(SearchView)] = "search/";

            routeMap[typeof(WorkPlaceView)] = "workplace/";
            {
                routeMap[typeof(WorkPlaceMainView)] = routeMap[typeof(WorkPlaceView)] + "main/";
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
