using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels
{
    class WorkPlaceViewModel : BindableBase
    {
        public class AppItem
        {
            public string Name { get; set; }
            public string IconFont { get; set; }
            public string Url { get; set; }
            public string Tag { get; set; }
            public DelegateCommand<string> Command { get; set; }
        }

        public class ClassifyItem
        {
            public string Name { get; set; }
            public DelegateCommand<string> Command { get; set; }
        }

        private readonly IRegionManager regionManager;


        public WorkPlaceViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.ClassifyCmd = new DelegateCommand<string>(ClassifyViewAppList);
            NavigationCmd = new DelegateCommand<string>(NavigationPage);
            TabClosedCommand = new DelegateCommand<RoutedEventArgs>(CloseTabItem);
            SimulationData();
        }

        private string appName = "";
        public string AppName { get => appName; set { SetProperty(ref appName, value); } }

        private List<AppItem> allAppDataList;
        private Dictionary<string, List<AppItem>> appGroupMap;


        public DelegateCommand<string> NavigationCmd { get; private set; }
        public DelegateCommand<RoutedEventArgs> TabClosedCommand { get; private set; }

        /// <summary>
        /// 常用应用列表
        /// </summary>
        private ObservableCollection<AppItem> oftenUseAppList = new ObservableCollection<AppItem>();
        public ObservableCollection<AppItem> OftenUseAppList
        {
            get => oftenUseAppList;
            set
            {
                SetProperty(ref oftenUseAppList, value);
            }
        }

        /// <summary>
        /// 当前分类显示列表
        /// </summary>
        private ObservableCollection<AppItem> viewAppList = new ObservableCollection<AppItem>();
        public ObservableCollection<AppItem> ViewAppList 
        { 
            get => viewAppList;
            set
            {
                SetProperty(ref viewAppList, value);
            }
        }

        /// <summary>
        /// 标签列表
        /// </summary>
        private ObservableCollection<ClassifyItem> classifyItemList = new ObservableCollection<ClassifyItem>();
        public ObservableCollection<ClassifyItem> ClassifyItemList 
        { 
            get => classifyItemList; 
            set
            {
                SetProperty(ref classifyItemList, value);
            }
        }

        private void NavigationPage(string view)
        {
            if (view == null || view == "") return;
            RegionHelper.RequestNavigate(regionManager, RegionToken.WorkPlaceTabContent, view);
        }

        public void CloseTabItem(RoutedEventArgs e)
        {
            var arg = e as RoutedEventArgs;
            if (arg != null)
            {
                var content = arg.OriginalSource as ContentControl;
                if (content != null)
                {
                    var tabRegion = this.regionManager.Regions[RegionToken.WorkPlaceTabContent];
                    var viewToClose = tabRegion.Views.Cast<FrameworkElement>().Where(v => v == content).FirstOrDefault();
                    if (viewToClose != null)
                    {
                        if (viewToClose is IDisposable disposableViewToClose)
                        {
                            disposableViewToClose.Dispose();
                        }
                        tabRegion.Remove(viewToClose);
                    }
                }
            }
        }

        public DelegateCommand<string> ClassifyCmd { get; private set; }
        private void ClassifyViewAppList(string classify)
        {
            if (classify == null) return;
            viewAppList.Clear();
            if (classify == "全部")
            {
                allAppDataList.ForEach((appItem => viewAppList.Add(appItem)));
            }
            else
            {
                appGroupMap[classify].ForEach((appItem => viewAppList.Add(appItem)));
            }
        }

        private void SimulationData()
        {
            appGroupMap = new Dictionary<string, List<AppItem>>();

            allAppDataList = new List<AppItem>()
            {
                new AppItem { Tag="数据农场", Name = "考勤数据", IconFont = "\xe6fd", Url = "AttendanceDataEnteringView", Command=NavigationCmd },
                new AppItem { Tag="数据农场", Name = "违纪数据", IconFont = "\xe6f7", Url = "", Command=NavigationCmd },
                new AppItem { Tag="数据农场", Name = "绩效数据", IconFont = "\xe6e7", Url = "", Command=NavigationCmd },
                new AppItem { Tag="数据农场", Name = "主观评价", IconFont = "\xe6e7", Url = "", Command=NavigationCmd },
                new AppItem { Tag="特别工具", Name = "授权", IconFont = "\xe703", Url = "AuthMainView", Command=NavigationCmd },
                new AppItem { Tag="特别工具", Name = "调查问券", IconFont = "\xe703", Url = "EvaluationView", Command=NavigationCmd },
                new AppItem { Tag="特别工具", Name = "汇报", IconFont = "\xe703", Url = "ReportView", Command=NavigationCmd },
                new AppItem { Tag="心灵驿站", Name = "员工关怀", IconFont = "\xe703", Url = "EvaluationView", Command=NavigationCmd },
            };

            foreach(var appItem in allAppDataList)
            {
                if (!appGroupMap.ContainsKey(appItem.Tag))
                {
                    ClassifyItemList.Add(new ClassifyItem { Name = appItem.Tag, Command = ClassifyCmd });
                    appGroupMap[appItem.Tag] = new List<AppItem>();
                }
                appGroupMap[appItem.Tag].Add(appItem);
            }

            allAppDataList.ForEach(appItem => viewAppList.Add(appItem));
            allAppDataList.ForEach(appItem => oftenUseAppList.Add(appItem));
        }
    }
}
