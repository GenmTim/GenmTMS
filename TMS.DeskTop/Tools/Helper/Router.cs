using System;
using System.Collections.Generic;
using TMS.Core.Data.Token;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.Views;
using TMS.DeskTop.Views.CloudFile;
using TMS.DeskTop.Views.Contacts;
using TMS.DeskTop.Views.Contacts.Group;
using TMS.DeskTop.Views.Contacts.Personal;
using TMS.DeskTop.Views.PersonalFile;
using TMS.DeskTop.Views.PersonalFile.Subitem;
using TMS.DeskTop.Views.Search;
using TMS.DeskTop.Views.WorkPlace;
using TMS.DeskTop.Views.WorkPlace.Activity;
using TMS.DeskTop.Views.WorkPlace.AttendanceData;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Rule;
using TMS.DeskTop.Views.WorkPlace.Auth;
using TMS.DeskTop.Views.WorkPlace.Auth.Subitem;
using TMS.DeskTop.Views.WorkPlace.Evaluation;
using TMS.DeskTop.Views.WorkPlace.GloryData;
using TMS.DeskTop.Views.WorkPlace.PerformanceData;
using TMS.DeskTop.Views.WorkPlace.Recommend;
using TMS.DeskTop.Views.WorkPlace.Recruitment;
using TMS.DeskTop.Views.WorkPlace.Recruitment.Requirements;
using TMS.DeskTop.Views.WorkPlace.Recruitment.Requirements.Subitem;
using TMS.DeskTop.Views.WorkPlace.StaffCare;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData.Subitem;
using TMS.DeskTop.Views.WorkPlace.ViolateData;

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
                [typeof(AddNewAttendanceRuleView)] = new BackPageViewInfo { Title = AddNewAttendanceRuleView.Title, View = typeof(AddNewAttendanceRuleView) },
                [typeof(NewSubjectiveRuleView)] = new BackPageViewInfo { Title = NewSubjectiveRuleView.Title, View = typeof(NewSubjectiveRuleView) },
                [typeof(Views.WorkPlace.ViolateData.Entering.EnteringStepView)] = new BackPageViewInfo { Title = Views.WorkPlace.ViolateData.Entering.EnteringStepView.Title, View = typeof(Views.WorkPlace.ViolateData.Entering.EnteringStepView) },
                [typeof(Views.WorkPlace.GloryData.Entering.EnteringStepView)] = new BackPageViewInfo { Title = Views.WorkPlace.GloryData.Entering.EnteringStepView.Title, View = typeof(Views.WorkPlace.GloryData.Entering.EnteringStepView) },
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
                [typeof(ContactsView)] = RegionToken.ContactsContent,
                [typeof(AuthView)] = RegionToken.AuthContent,
                [typeof(AuthMainView)] = RegionToken.AuthMainContent,
                [typeof(EvaluationView)] = RegionToken.EvaluationContent,
                [typeof(EvaluationMainView)] = RegionToken.EvaluationMainContent,
                [typeof(ReportView)] = RegionToken.ReportContent,
                [typeof(SearchView)] = RegionToken.SearchContent,
                [typeof(PersonalFileView)] = RegionToken.PersonalFileContent,
                [typeof(CloudFileView)] = RegionToken.CloudFileContent,
                [typeof(MyGroupView)] = RegionToken.MyGroupContent,
                [typeof(RequirementsMainView)] = RegionToken.RecruitmentRequirementsMainContent,
                [typeof(RecruitmentView)] = RegionToken.RecruitmentContent,
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
                {
                    routeMap[typeof(BasicInfoView)] = routeMap[typeof(PersonalInfoView)] + "basic/";
                    routeMap[typeof(ExtendInfoView)] = routeMap[typeof(PersonalInfoView)] + "extend/";

                }
                routeMap[typeof(MyGroupView)] = routeMap[typeof(ContactsView)] + "myGroup/";
                {
                    routeMap[typeof(ICreateView)] = routeMap[typeof(MyGroupView)] + "my_create/";
                    routeMap[typeof(IJoinedView)] = routeMap[typeof(MyGroupView)] + "my_joined/";
                }
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
                routeMap[typeof(RecruitmentView)] = routeMap[typeof(WorkPlaceView)] + "recruitment/";
                {
                    routeMap[typeof(RecruitmentNavigationView)] = routeMap[typeof(RecruitmentView)] + "navigation/";
                    routeMap[typeof(RequirementsMainView)] = routeMap[typeof(RecruitmentView)] + "requirement/";
                    {
                        routeMap[typeof(ActivitiesRequirementsView)] = routeMap[typeof(RequirementsMainView)] + "activities/";
                        routeMap[typeof(ManageRequirementsView)] = routeMap[typeof(RequirementsMainView)] + "manage/";
                        routeMap[typeof(NewRequirementView)] = routeMap[typeof(RequirementsMainView)] + "newRequirement/";
                        routeMap[typeof(TalentPoolView)] = routeMap[typeof(RequirementsMainView)] + "talentpool/";
                        routeMap[typeof(ViewRequirementsView)] = routeMap[typeof(RequirementsMainView)] + "viewRequire/";
                    }
                }
                routeMap[typeof(StaffCareView)] = routeMap[typeof(WorkPlaceView)] + "staff_care/";
                routeMap[typeof(SubjectiveDataView)] = routeMap[typeof(WorkPlaceView)] + "subjective_data/";
                {
                    routeMap[typeof(SubjectiveDataMainView)] = routeMap[typeof(SubjectiveDataView)] + "main/";
                    routeMap[typeof(NewSubjectiveRuleView)] = routeMap[typeof(SubjectiveDataView)] + "new/";
                }
                routeMap[typeof(AttendanceDataEnteringView)] = routeMap[typeof(WorkPlaceView)] + "attendanceDataEntering/";
                {
                    routeMap[typeof(Views.WorkPlace.AttendanceData.Manager.ManageDataView)] = routeMap[typeof(AttendanceDataEnteringView)] + "manageData/";
                    routeMap[typeof(AttendanceRuleView)] = routeMap[typeof(AttendanceDataEnteringView)] + "rule/";
                    routeMap[typeof(AddNewAttendanceRuleView)] = routeMap[typeof(AttendanceDataEnteringView)] + "newRule/";
                    routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.EnteringStepView)] = routeMap[typeof(AttendanceDataEnteringView)] + "enteringStep/";
                    {
                        routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.Step.CheckDataView)] = routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.EnteringStepView)] + "checkData/";
                        routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.Step.EnteringDataView)] = routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.EnteringStepView)] + "enteringData/";
                        routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.Step.CompleteEntryDataView)] = routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.EnteringStepView)] + "complete/";
                    }
                }
                routeMap[typeof(GloryDataEnteringView)] = routeMap[typeof(WorkPlaceView)] + "gloryDataEntering/";
                {
                    routeMap[typeof(Views.WorkPlace.GloryData.Manager.ManageDataView)] = routeMap[typeof(GloryDataEnteringView)] + "manageData/";
                    routeMap[typeof(Views.WorkPlace.GloryData.Entering.EnteringStepView)] = routeMap[typeof(GloryDataEnteringView)] + "enteringStep/";
                    {
                        routeMap[typeof(Views.WorkPlace.GloryData.Entering.Step.CheckDataView)] = routeMap[typeof(Views.WorkPlace.GloryData.Entering.EnteringStepView)] + "checkData/";
                        routeMap[typeof(Views.WorkPlace.GloryData.Entering.Step.EnteringDataView)] = routeMap[typeof(Views.WorkPlace.GloryData.Entering.EnteringStepView)] + "enteringData/";
                    }
                    //routeMap[typeof(PerformanceDataEnteringDataView)] = routeMap[typeof(PerformanceDataEnteringView)] + "checkData/";
                    //routeMap[typeof(PerformanceDataCheckView)] = routeMap[typeof(PerformanceDataEnteringView)] + "enteringData/";
                }
                routeMap[typeof(PerformanceDataEnteringView)] = routeMap[typeof(WorkPlaceView)] + "performanceDataEntering/";
                {
                    routeMap[typeof(Views.WorkPlace.PerformanceData.Manager.ManageDataView)] = routeMap[typeof(PerformanceDataEnteringView)] + "manageData/";
                    routeMap[typeof(Views.WorkPlace.PerformanceData.Entering.EnteringStepView)] = routeMap[typeof(PerformanceDataEnteringView)] + "enteringStep/";
                    {
                        routeMap[typeof(Views.WorkPlace.PerformanceData.Entering.Step.CheckDataView)] = routeMap[typeof(Views.WorkPlace.PerformanceData.Entering.EnteringStepView)] + "checkData/";
                        routeMap[typeof(Views.WorkPlace.PerformanceData.Entering.Step.EnteringDataView)] = routeMap[typeof(Views.WorkPlace.PerformanceData.Entering.EnteringStepView)] + "enteringData/";
                    }
                    //routeMap[typeof(PerformanceDataEnteringDataView)] = routeMap[typeof(PerformanceDataEnteringView)] + "checkData/";
                    //routeMap[typeof(PerformanceDataCheckView)] = routeMap[typeof(PerformanceDataEnteringView)] + "enteringData/";
                }
                routeMap[typeof(ViolateDataEnteringView)] = routeMap[typeof(WorkPlaceView)] + "violateDataEnteringView/";
                {
                    routeMap[typeof(Views.WorkPlace.ViolateData.Manager.ManageDataView)] = routeMap[typeof(ViolateDataEnteringView)] + "manageData/";
                    routeMap[typeof(Views.WorkPlace.ViolateData.Entering.EnteringStepView)] = routeMap[typeof(ViolateDataEnteringView)] + "enteringStep/";
                    {
                        routeMap[typeof(Views.WorkPlace.ViolateData.Entering.Step.CheckDataView)] = routeMap[typeof(Views.WorkPlace.ViolateData.Entering.EnteringStepView)] + "checkData/";
                        routeMap[typeof(Views.WorkPlace.ViolateData.Entering.Step.EnteringDataView)] = routeMap[typeof(Views.WorkPlace.ViolateData.Entering.EnteringStepView)] + "enteringData/";
                    }
                    //routeMap[typeof(Views.WorkPlace.AttendanceData.Entering.Step.ManageDataView)] = routeMap[typeof(ViolateDataEnteringView)] + "manageData/";
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
                routeMap[typeof(ReportView)] = routeMap[typeof(WorkPlaceView)] + "report/";
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
