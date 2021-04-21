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
    public class AttendanceDataVO : BindableBase
    {
        private int total;
        public int Total 
        {
            get => total;
            set
            {
                total = value;
                Rate = Real * 100 / Total;
                RaisePropertyChanged();
            }
        }

        private int real;
        public int Real
        {
            get => real;
            set
            {
                real = value;
                Rate = Real * 100 / Total;
                RaisePropertyChanged();
            }
        }

        private double rate;
        public double Rate 
        { 
            get
            {
                return rate;
            }
            set
            {
                rate = value;
                RaisePropertyChanged();
            }
        }
    }

    public class FollowStateVO
    {
        public string State { get; set; }
        public string Color { get; set; }
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

    public class LabelDataVO
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
    }


    public class StaffDataVO : BindableBase
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string CommentNumber { get; set; }
        public string CommonNumber { get; set; }
        public string FollowNumber { get; set; }
        public string Grade { get; set; }
        private ObservableCollection<LabelDataVO> labelDataVOList;
        public ObservableCollection<LabelDataVO> LabelDataVOList
        {
            get => labelDataVOList;
            set
            {
                labelDataVOList = value;
                RaisePropertyChanged();
            }
        }

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

        private FollowStateVO followState;
        public FollowStateVO FollowState
        {
            get => followState;
            set
            {
                followState = value;
                RaisePropertyChanged();
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
            FollowState ??= new FollowStateVO()
            {
                State = "关注",
                Color = "#757575",
            };
            Attendance = new AttendanceDataVO()
            {
                Total = 123,
                Real = 102,
            };
            this.FollowCmd = new DelegateCommand(() =>
            {
                if (FollowState.State.Equals("关注"))
                {
                    FollowState = new FollowStateVO
                    {
                        State = "已关注",
                        Color = "#ff577c",
                    };
                }
                else
                {
                    FollowState = new FollowStateVO
                    {
                        State = "关注",
                        Color = "#757575",
                    };
                }

            });
            this.CompanyDataVOList = new ObservableCollection<CompanyDataVO>()
            {
                new CompanyDataVO { Name="腾讯", Job="游戏原画设计师", Uri="http://47.101.157.194:8081/static/avatar/c1.png" },
                new CompanyDataVO { Name="网易", Job="游戏数值策划", Uri="http://47.101.157.194:8081/static/avatar/c3.png" },
                new CompanyDataVO { Name="暴雪", Job="Golang游戏服务端工程师", Uri="http://47.101.157.194:8081/static/avatar/c2.png" },
                new CompanyDataVO { Name="米哈游", Job="Golang游戏服务端工程师", Uri="http://47.101.157.194:8081/static/avatar/c4.png" },
            };

            this.StaffDataVOList = new ObservableCollection<StaffDataVO>()
            {
                new StaffDataVO { Name="金泽权", Avatar="http://47.101.157.194:8081/static/avatar/target6.jpg", CommentNumber="53", CommonNumber="67", FollowNumber="13", Grade="A+",
                LabelDataVOList = new ObservableCollection<LabelDataVO>()
                {
                    new LabelDataVO { Name="知名游戏评测员", Color="#1890ff", Icon="\xe7a1"  },
                } },
                new StaffDataVO { Name="柳依依", Avatar="http://47.101.157.194:8081/static/avatar/target7.jpg", CommentNumber="61", CommonNumber="52", FollowNumber="23", Grade="A-" ,
                     LabelDataVOList = new ObservableCollection<LabelDataVO>()
                {
                         new LabelDataVO { Name="知名游戏设计师", Color="#722ed1", Icon="\xe758"  },
                }},
                                new StaffDataVO { Name="李东富", Avatar="http://47.101.157.194:8081/static/avatar/target5.jpg", CommentNumber="47", CommonNumber="71", FollowNumber="8", Grade="A" ,
                     LabelDataVOList = new ObservableCollection<LabelDataVO>()
                {
                    new LabelDataVO { Name="牛人", Color="#e9af20", Icon="\xe7a1" },
                    new LabelDataVO { Name="B站百大Up主", Color="#eb2f96", Icon="\xe75e"  },
                }},
            };
        }

        public DelegateCommand FollowCmd { get; private set; }

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

        private ObservableCollection<CompanyDataVO> companyDataVOList;
        public ObservableCollection<CompanyDataVO> CompanyDataVOList
        {
            get => companyDataVOList;
            set
            {
                companyDataVOList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<StaffDataVO> staffDataVOList;
        public ObservableCollection<StaffDataVO> StaffDataVOList
        {
            get => staffDataVOList;
            set
            {
                staffDataVOList = value;
                RaisePropertyChanged();
            }
        }

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
