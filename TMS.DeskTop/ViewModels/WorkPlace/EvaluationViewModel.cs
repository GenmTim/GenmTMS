using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    class EvaluationViewModel : BindableBase
    {
        private TabItemInfo tabItemInfo = new TabItemInfo { Title = "考评", IconFont = "\xe631" };
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
