using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    class AttendanceViewModel
    {
        private TabItemInfo tabItemInfo = new TabItemInfo { Title = "考勤", IconFont = "\xe631" };
        public TabItemInfo TabItemInfo
        {
            get { return this.tabItemInfo; }
            set { this.SetProperty(ref this.tabItemInfo, value); }
        }


        public EvaluationViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
        }
    }
}
