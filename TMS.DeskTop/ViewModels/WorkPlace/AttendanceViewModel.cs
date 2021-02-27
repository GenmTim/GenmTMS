using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    class AttendanceViewModel : BindableBase
    {
        private TabItemInfo tabItemInfo = new TabItemInfo { Title = "考勤", IconFont = "\xe631" };
        public TabItemInfo TabItemInfo
        {
            get { return this.tabItemInfo; }
            set { this.SetProperty(ref this.tabItemInfo, value); }
        }


        public AttendanceViewModel()
        {
        }
    }
}
