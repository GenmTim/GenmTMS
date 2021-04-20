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
        public List<Attendance> DataList { get; set; } = new List<Attendance>() {
            new Attendance{ Name="金泽权", AttendanceNumber=10, ActualAttendance=9, Late=1
                ,LeaveEarly=4,Absent=6,Repair=5,Leave=10},
            new Attendance{ Name="黄军达", AttendanceNumber=12, ActualAttendance=8, Late=2
                ,LeaveEarly=3,Absent=4,Repair=7,Leave=6},
            new Attendance{ Name="李新添", AttendanceNumber=11, ActualAttendance=7, Late=3
                ,LeaveEarly=2,Absent=2,Repair=6,Leave=4},
            new Attendance{ Name="张风", AttendanceNumber=17, ActualAttendance=5, Late=4
                ,LeaveEarly=1,Absent=3,Repair=4,Leave=5},
            new Attendance{ Name="蔡承龙", AttendanceNumber=11, ActualAttendance=6, Late=5
                ,LeaveEarly=2,Absent=5,Repair=5,Leave=7}
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
