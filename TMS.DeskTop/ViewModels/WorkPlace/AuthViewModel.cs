using Prism.Mvvm;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    public class AuthViewModel : BindableBase
    {
        private ViewInfo viewInfo = new ViewInfo { Title = "考勤", IconFont = "\xe6fd" };
        public ViewInfo ViewInfo
        {
            get { return this.viewInfo; }
            set { SetProperty(ref viewInfo, value); }
        }
    }
}
