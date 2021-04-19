using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Rule
{
    public class AttendanceRule : BindableBase
    {
        public string Name { get; set; }
        public string NumberOfPeople { get; set; }
        public string Type { get; set; }
        public string AttendanceTime { get; set; }
        public string Principal { get; set; }
        public string LastUpdateTime { get; set; }
    }


    class AttendanceRuleViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public ObservableCollection<AttendanceRule> ruleList;
        public ObservableCollection<AttendanceRule> RuleList
        {
            get => ruleList;
            set
            {
                ruleList = value;
                RaisePropertyChanged();
            }
        }


        public AttendanceRuleViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            RuleList ??= new ObservableCollection<AttendanceRule>();
            RuleList.Add(new AttendanceRule
            {
                Name = "123",
                NumberOfPeople = "1",
                Type = "固定班制",
                AttendanceTime = "默认班次:09:00-18:00;",
                Principal = "蔡承龙",
                LastUpdateTime = "23/02/2021 22:23",
            });
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.AttendaceDataEnteringContent, obj);
        }
    }


}
