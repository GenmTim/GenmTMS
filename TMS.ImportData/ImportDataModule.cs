using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace TMS.ImportData
{
    public class ImportDataModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}