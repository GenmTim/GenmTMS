using System;
using System.Collections.Generic;
using TMS.Core.Data.Token;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.CloudFile;
using TMS.DeskTop.Views.Contacts;
using TMS.DeskTop.Views.PersonalFile;
using TMS.DeskTop.Views.PersonalFile.Subitem;
using TMS.DeskTop.Views.Search;
using TMS.DeskTop.Views.WorkPlace;
using TMS.DeskTop.Views.WorkPlace.Activity;
using TMS.DeskTop.Views.WorkPlace.AttendanceData;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering;
using TMS.DeskTop.Views.WorkPlace.Auth;
using TMS.DeskTop.Views.WorkPlace.Auth.Subitem;
using TMS.DeskTop.Views.WorkPlace.Evaluation;
using TMS.DeskTop.Views.WorkPlace.PerformanceData;
using TMS.DeskTop.Views.WorkPlace.PerformanceData.Entering;
using TMS.DeskTop.Views.WorkPlace.Recommend;
using TMS.DeskTop.Views.WorkPlace.Report;
using TMS.DeskTop.Views.WorkPlace.StaffCare;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData.Subitem;
using TMS.DeskTop.Views.WorkPlace.ViolateData;
using TMS.DeskTop.Views.WorkPlace.ViolateData.Entering;

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
            foreach (Type type in routeMap.Keys)
            {
                viewTypeMap[type.Name] = type;
            }
        }

        private void InitBackNavigationViewRegedit()
        {
            backPageViewRegedit = new Dictionary<Type, BackPageViewInfo>
            {
                [typeof(NewEvaluationRuleView)] = new BackPageViewInfo { Title = NewEvaluationRuleView.Title, View = typeof(NewEvaluationRuleView) },
            };
        }

        private void InitNavigationRegionRegedit()
        {
            navigationRegionRegedit = new Dictionary<Type, string>
            {
                [typeof(MainWindow)] = RegionToken.MainContent,
                [typeof(WorkPlaceView)] = RegionToken.WorkPlaceTabContent,
                [typeof(ContactsView)] = RegionToken.ContactsContent,
                [typeof(AuthView)] = RegionToken.AuthContent,
                [typeof(AuthMainView)] = RegionToken.AuthMainContent,
                [typeof(EvaluationView)] = RegionToken.EvaluationContent,
                [typeof(EvaluationMainView)] = RegionToken.EvaluationMainContent,
                [typeof(CommunityView)] = RegionToken.ReportContent,
                [typeof(SearchView)] = RegionToken.SearchContent,
                [typeof(PersonalFileView)] = RegionToken.PersonalFileContent,
                [typeof(CloudFileView)] = RegionToken.CloudFileContent,
            };
        }

        private void InitRouteMap()
        {
            routeMap = new Dictionary<Type, string>();

            Root = typeof(MainWindow);
            RootPath = "";
            routeMap[Root] = RootPath;

            routeMap[typeof(NotificationView)] = "notification/";
            {
                routeMap[typeof(ChatBox)] = routeMap[typeof(NotificationView)] + "chatBox/";
            }
            routeMap[typeof(ContactsView)] = "contacts/";
            {
                routeMap[typeof(OrganizationalStructrureView)] = routeMap[typeof(ContactsView)] + "organizational/";
                routeMap[typeof(PersonalInfoView)] = routeMap[typeof(ContactsView)] + "personal/";
                routeMap[typeof(MyGroupView)] = routeMap[typeof(ContactsView)] + "myGroup/";
                routeMap[typeof(LinkManView)] = routeMap[typeof(ContactsView)] + "linkMan/";
                routeMap[typeof(MyWalletView)] = routeMap[typeof(ContactsView)] + "myWallet/";
                routeMap[typeof(CustomerServiceView)] = routeMap[typeof(ContactsView)] + "customer_service/";
                routeMap[typeof(MyFavoriteView)] = routeMap[typeof(ContactsView)] + "myFavorite/";
            }
            routeMap[typeof(CloudFileView)] = "cloudfile/";
            {
                routeMap[typeof(CloudFileMainView)] = routeMap[typeof(CloudFileView)] + "main/";
            }
            routeMap[typeof(SearchView)] = "search/";
            {
                routeMap[typeof(SearchMainView)] = routeMap[typeof(SearchView)] + "main/";
                routeMap[typeof(PersonalFileView)] = routeMap[typeof(SearchView)] + "personal_file/";
                {
                    routeMap[typeof(CommonFileView)] = routeMap[typeof(PersonalFileView)] + "common/";
                    routeMap[typeof(HRFileView)] = routeMap[typeof(PersonalFileView)] + "hr/";
                    routeMap[typeof(CustomFileView)] = routeMap[typeof(PersonalFileView)] + "custom/";
                }
            }

            routeMap[typeof(WorkPlaceView)] = "workplace/";
            {
                routeMap[typeof(WorkPlaceMainView)] = routeMap[typeof(WorkPlaceView)] + "main/";
                routeMap[typeof(StaffCareView)] = routeMap[typeof(WorkPlaceView)] + "staff_care/";
                routeMap[typeof(SubjectiveDataView)] = routeMap[typeof(WorkPlaceView)] + "subjective_data/";
                {
                    routeMap[typeof(SubjectiveDataMainView)] = routeMap[typeof(SubjectiveDataView)] + "main/";
                }
                routeMap[typeof(AttendanceDataEnteringView)] = routeMap[typeof(WorkPlaceView)] + "attendanceDataEntering/";
                {
                    routeMap[typeof(CheckDataView)] = routeMap[typeof(AttendanceDataEnteringView)] + "checkData/";
                    routeMap[typeof(EnteringDataView)] = routeMap[typeof(AttendanceDataEnteringView)] + "enteringData/";
                }
                routeMap[typeof(PerformanceDataEnteringView)] = routeMap[typeof(WorkPlaceView)] + "performanceDataEntering/";
                {
                    routeMap[typeof(PerformanceDataEnteringDataView)] = routeMap[typeof(PerformanceDataEnteringView)] + "checkData/";
                    routeMap[typeof(PerformanceDataCheckView)] = routeMap[typeof(PerformanceDataEnteringView)] + "enteringData/";
                }
                routeMap[typeof(ViolateDataEnteringView)] = routeMap[typeof(WorkPlaceView)] + "violateDataEnteringView/";
                {
                    routeMap[typeof(ViolateDataCheckView)] = routeMap[typeof(ViolateDataEnteringView)] + "checkData/";
                    routeMap[typeof(ViolateDataEnteringDataView)] = routeMap[typeof(ViolateDataEnteringView)] + "enteringData/";
                }
                routeMap[typeof(AuthView)] = routeMap[typeof(WorkPlaceView)] + "auth/";
                {
                    routeMap[typeof(AuthMainView)] = routeMap[typeof(AuthView)] + "main/";
                    {
                        routeMap[typeof(ApplyForView)] = routeMap[typeof(AuthMainView)] + "applyfor/";
                        routeMap[typeof(AuthorisedView)] = routeMap[typeof(AuthMainView)] + "authorised/";
                    }
                }
                routeMap[typeof(EvaluationView)] = routeMap[typeof(WorkPlaceView)] + "evaluation/";
                {
                    routeMap[typeof(EvaluationMainView)] = routeMap[typeof(EvaluationView)] + "main/";
                    routeMap[typeof(NewEvaluationRuleView)] = routeMap[typeof(EvaluationView)] + "new/";
                    routeMap[typeof(ViewEvaluationView)] = routeMap[typeof(EvaluationView)] + "view/";
                    routeMap[typeof(FullInEvaluationView)] = routeMap[typeof(EvaluationView)] + "fullIn/";
                    routeMap[typeof(ManageEvaluationView)] = routeMap[typeof(EvaluationView)] + "manage/";
                }
                routeMap[typeof(CommunityView)] = routeMap[typeof(WorkPlaceView)] + "community/";
                routeMap[typeof(ActivityView)] = routeMap[typeof(WorkPlaceView)] + "activity/";
                routeMap[typeof(RecommendView)] = routeMap[typeof(WorkPlaceView)] + "recommend/";
            }

            routeMap[typeof(BackNavigationView)] = nameof(BackNavigationView);
            routeMap[typeof(EmptyContentView)] = nameof(EmptyContentView);
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
