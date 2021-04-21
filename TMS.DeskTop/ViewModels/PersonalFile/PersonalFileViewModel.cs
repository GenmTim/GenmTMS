using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.Views.PersonalFile;
using TMS.DeskTop.Views.Search;

namespace TMS.DeskTop.ViewModels.PersonalFile
{
    public class AttendanceDataVO
    {
        public string Total { get; set; }
        public string Real { get; set; }
    }

    public class ViolateDataVO
    { 
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class CompanyDataVO
    { 
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Job { get; set; }
    }

    public class GloryDataVO
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }

    public class ColleagueDataVO
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Date { get; set; }
    }

    public class TotalDataVO
    {

    }


    public class PersonalFileViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;




        private Boolean detailDrawerIsOpen = false;
        public Boolean DetailDrawerIsOpen
        {
            get => detailDrawerIsOpen;
            set
            {
                SetProperty(ref detailDrawerIsOpen, value);
            }
        }

        public PersonalFileViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.GoBackCmd = new DelegateCommand(GoBack);
            this.ShowDetailCommand = new DelegateCommand(ShowDetail);
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            this.GoHomeCmd = new DelegateCommand(GoHome);
            this.GloryDataVOList ??= new ObservableCollection<GloryDataVO>()
            {
                new GloryDataVO { Name="中国独立游戏大师二等奖", Uri="http://47.101.157.194:8081/static/avatar/p2.png" },
                new GloryDataVO { Name="腾讯高校游戏创意制作大赛一等奖", Uri="http://47.101.157.194:8081/static/avatar/p1.png" },
            };
            this.ColleagueList ??= new ObservableCollection<ColleagueDataVO>()
            {
                new ColleagueDataVO {Name ="席应天", Avatar="http://47.101.157.194:8081/static/avatar/target5.jpg", Date="2020.08.23"},
                new ColleagueDataVO {Name ="夏晓瑜", Avatar="http://47.101.157.194:8081/static/avatar/target7.jpg", Date="2020.06.23"},
                new ColleagueDataVO {Name ="岳云岚", Avatar="http://47.101.157.194:8081/static/avatar/target8.jpg", Date="2020.07.23"},
                new ColleagueDataVO {Name ="柳依依", Avatar="http://47.101.157.194:8081/static/avatar/target9.jpg", Date="2020.11.23"},
            };
        }

        public DelegateCommand GoBackCmd { get; private set; }
        private void GoBack()
        {
            eventAggregator.GetEvent<CloseSashEvent>().Publish();
        }

        public DelegateCommand ShowDetailCommand { get; private set; }
        private void ShowDetail()
        {
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.PersonalFileDetailRegion, typeof(CVTemplate));
            DetailDrawerIsOpen = true;
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string view)
        {
            RouteHelper.Goto(regionManager, typeof(PersonalFileView), view);
        }

        public DelegateCommand GoHomeCmd { get; private set; }

        private ObservableCollection<ColleagueDataVO> colleagueList;
        public ObservableCollection<ColleagueDataVO> ColleagueList 
        { 
            get => colleagueList;
            set
            {
                colleagueList = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<GloryDataVO> gloryDataVOList;
        public ObservableCollection<GloryDataVO> GloryDataVOList 
        { 
            get => gloryDataVOList;
            set
            {
                gloryDataVOList = value;
                RaisePropertyChanged();
            }
        }


        private AttendanceDataVO attendance;
        public AttendanceDataVO Attendance 
        {
            get => attendance;
            set
            {
                attendance = value;
                RaisePropertyChanged();
            }
        }


        private void GoHome()
        {
            RouteHelper.Goto(regionManager, typeof(PersonalFileView), typeof(SearchMainView));
        }



    }
}
