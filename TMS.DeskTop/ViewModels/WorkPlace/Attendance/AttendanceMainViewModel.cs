using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace.Attendance
{
    class AttendanceMainViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        public DelegateCommand<string> NavigationCommand { get; private set; }


        public AttendanceMainViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }


        private void NavigationPage(string obj)
        {
            regionManager.Regions[RegionToken.AttendanceMainContent].RequestNavigate(obj);
        }
    }
}
