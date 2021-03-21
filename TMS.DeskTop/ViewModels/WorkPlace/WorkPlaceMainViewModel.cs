using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMS.Core.Data;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    public class AppItem
    {
        public string Name { get; set; }
        public string IconFont { get; set; }
        public string Url { get; set; }
    }

    public class AppGroup
    {
        public string Name { get; set; }

        private ObservableCollection<AppItem> appList;

        public ObservableCollection<AppItem> AppList { get => appList; set => appList = value; }
    }

    class WorkPlaceMainViewModel : BindableBase
    {
        private ViewInfo viewInfo = new ViewInfo { Title = "工作台", IconFont = "\xe79f" };
        public ViewInfo ViewInfo
        {
            get { return this.viewInfo; }
            set { SetProperty(ref viewInfo, value); }
        }

        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        private Dictionary<string, ObservableCollection<AppItem>> appGroupMap = new Dictionary<string, ObservableCollection<AppItem>>();


        private ObservableCollection<AppGroup> appGroupList = new ObservableCollection<AppGroup>();
        public ObservableCollection<AppGroup> AppGroupList { get => appGroupList; set => appGroupList = value; }

        private ObservableCollection<AppItem> commonAppList = new ObservableCollection<AppItem>();
        public ObservableCollection<AppItem> CommonAppList { get => commonAppList; set => commonAppList = value; }




        public WorkPlaceMainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCmd = new DelegateCommand<string>(NavigationPage);

            appGroupMap["人事管理"] = new ObservableCollection<AppItem>
            {
                new AppItem { Name = "考勤打卡", IconFont = "\xe6fd", Url = "AttendanceView" },
                new AppItem { Name = "考评管理", IconFont = "\xe6f7", Url = "EvaluationView" },
                new AppItem { Name = "重大事件", IconFont = "\xe6e7", Url = "MajorEventView" },
                new AppItem { Name = "招聘流程", IconFont = "\xe7bc", Url = "RecruitmentView" },
                new AppItem { Name = "招聘需求", IconFont = "\xe7bc", Url = "RecruitmentView" },
                new AppItem { Name = "违纪处分", IconFont = "\xe7bc", Url = "DisciplineView"  },
                new AppItem { Name = "荣耀记录", IconFont = "\xe7bc", Url = "HonourView" }
            };

            appGroupMap["行政办公"] = new ObservableCollection<AppItem>
            {
                new AppItem { Name = "物品领用", IconFont = "\xe703", Url = "ApprovalView" },
                new AppItem { Name = "用章申请", IconFont = "\xe70a", Url = "" },
                new AppItem { Name = "名片申请", IconFont = "\xe70b", Url = "" },
                new AppItem { Name = "礼品申请", IconFont = "\xe722", Url = "" },
                new AppItem { Name = "用车申请", IconFont = "\xe740", Url = "" },
            };

            appGroupMap["流程中心"] = new ObservableCollection<AppItem>
            {
                new AppItem { Name = "请假", IconFont = "\xe703", Url = "" },
                new AppItem { Name = "报销", IconFont = "\xe70a", Url = "" },
                new AppItem { Name = "客户管理", IconFont = "\xe70b", Url = "" },
                new AppItem { Name = "考勤打卡", IconFont = "\xe722", Url = "" },
                new AppItem { Name = "办公电话", IconFont = "\xe740", Url = "" },
                new AppItem { Name = "复工申报", IconFont = "\xe740", Url = "" },
            };

            appGroupList.Add(new AppGroup { Name = "人事管理", AppList = appGroupMap["人事管理"] });
            appGroupList.Add(new AppGroup { Name = "行政办公", AppList = appGroupMap["行政办公"] });
            appGroupList.Add(new AppGroup { Name = "流程中心", AppList = appGroupMap["流程中心"] });

            commonAppList.Clear();
            //foreach(var appItem in appGroupMap["人事管理"])
            //{
            //    commonAppList.Add(appItem);
            //}
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.WorkPlaceTabContent, obj);
        }

    }
}
