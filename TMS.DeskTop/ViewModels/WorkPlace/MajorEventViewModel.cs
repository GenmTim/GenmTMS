using Prism.Mvvm;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    class MajorEventViewModel : BindableBase
    {
        private ViewInfo viewInfo = new ViewInfo { Title = "重大事件", IconFont = "\xe79f" };
        public ViewInfo ViewInfo
        {
            get { return this.viewInfo; }
            set { SetProperty(ref viewInfo, value); }
        }
    }
}
