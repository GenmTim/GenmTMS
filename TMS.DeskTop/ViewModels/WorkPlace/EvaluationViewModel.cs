using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using TMS.Core.Data;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    class EvaluationViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;

        private TabItemInfo tabItemInfo = new TabItemInfo { Title="考勤", IconFont= "\xe631" };
        public TabItemInfo TabItemInfo
        {
            get { return this.tabItemInfo; }
            set { this.SetProperty(ref this.tabItemInfo, value); }
        }


        public EvaluationViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
        }

    }
}
