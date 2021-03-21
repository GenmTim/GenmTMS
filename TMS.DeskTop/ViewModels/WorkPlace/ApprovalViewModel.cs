using Prism.Mvvm;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    public class ApprovalViewModel : BindableBase
    {
        private ViewInfo viewInfo = new ViewInfo { Title = "审批", IconFont = "\xe751" };
        public ViewInfo ViewInfo
        {
            get { return this.viewInfo; }
            set { SetProperty(ref viewInfo, value); }
        }
    }
}
