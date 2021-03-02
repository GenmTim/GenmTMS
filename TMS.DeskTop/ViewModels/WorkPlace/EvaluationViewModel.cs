using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    class EvaluationViewModel : BindableBase
    {
        private ViewInfo viewInfo = new ViewInfo { Title = "考评", IconFont = "\xe6f7" };
        public ViewInfo ViewInfo
        {
            get { return this.viewInfo; }
            set { SetProperty(ref viewInfo, value); }
        }



        public EvaluationViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {

        }

    }
}
