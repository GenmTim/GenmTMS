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
        private ViewInfo viewInfo = new ViewInfo { Title = "考勤", IconFont = "\xe6fd" };
        public ViewInfo ViewInfo
        {
            get { return this.viewInfo; }
            set { SetProperty(ref viewInfo, value); }
        }


        public AttendanceViewModel()
        {
        }
    }
}
