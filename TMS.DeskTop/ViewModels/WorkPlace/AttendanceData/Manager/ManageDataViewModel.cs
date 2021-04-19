using Prism.Commands;
using Prism.Regions;
using System.Collections.Generic;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Manager;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Manager
{
    class ManageDataViewModel
    {
        public List<Payroll> DataList { get; set; } = new List<Payroll>() {
            new Payroll{ Name="234", Month="2021-02",Number=2,Money=2813734.37,
                Currency="CNY",Unpublished=0,Published=2,Withdrawn=1,CreateTime="2021-01-19"},
            new Payroll{ Name="ghk", Month="2020-02",Number=26,Money=435734.37,
                Currency="USD",Unpublished=2,Published=5,Withdrawn=0,CreateTime="2021-02-22"},
            new Payroll{ Name="876g", Month="2021-01",Number=12,Money=2898734.37,
                Currency="USD",Unpublished=3,Published=3,Withdrawn=2,CreateTime="2021-03-02"},
            new Payroll{ Name="909k", Month="2020-12",Number=9,Money=993734.37,
                Currency="CNY",Unpublished=1,Published=1,Withdrawn=2,CreateTime="2021-02-07"},
            new Payroll{ Name="bg5h", Month="2020-11",Number=15,Money=1234734.37,
                Currency="CNY",Unpublished=1,Published=4,Withdrawn=0,CreateTime="2021-01-31"}
        };

        private readonly IRegionManager regionManager;
        public ManageDataViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }


        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            if (obj == null)
            {
                return;
            }
            if (obj.Equals("EnteringStepView"))
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendaceDataEnteringContent, typeof(EnteringStepView));
            }
            else if (obj.Equals("ManageDataView"))
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendaceDataEnteringContent, typeof(ManageDataView));
            }
            else
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendaceDataEnteringContent, obj);
            }
        }
    }
}
