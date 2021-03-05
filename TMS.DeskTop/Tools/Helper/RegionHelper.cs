using Prism.Regions;
using TMS.DeskTop.UserControls.Views;

namespace TMS.DeskTop.Tools.Helper
{
    public static class RegionHelper
    {
        public static void RequestNavigate(IRegionManager regionManager, string regionName, string view)
        {
            RequestNavigate(regionManager, regionName, view, null);
        }

        /// <summary>
        /// 在目标区域进行视图注入
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="regionName"></param>
        /// <param name="viewUrl"></param>
        /// <param name="param"></param>
        public static void RequestNavigate(IRegionManager regionManager, string regionName, string view, NavigationParameters param)
        {
            if (param == null)
            {
                param = new NavigationParameters();
            }

            if (RouteHelper.IsBackPage(view))
            {
                BackPageViewInfo viewInfo = Router.Instance.GetBackPageViewInfo(view);
                param.Add("title", viewInfo.Title);
                param.Add("view", viewInfo.View);
                view = nameof(BackNavigationView);
            }
            regionManager.RequestNavigate(regionName, RouteHelper.GetViewPath(view), param);
        }

        public static void RegisterViewWithRegion(IRegionManager regionManager, string regionName, System.Type viewType)
        {
            regionManager.RegisterViewWithRegion(regionName, viewType);
        }
    }
}
