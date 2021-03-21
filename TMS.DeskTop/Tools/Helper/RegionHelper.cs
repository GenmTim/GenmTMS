using Prism.Regions;
using System;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.Tools.Helper
{
    public static class RegionHelper
    {
        public static void RequestNavigate(IRegionManager regionManager, string regionName, Type view)
        {
            RequestNavigate(regionManager, regionName, view, null);
        }

        public static void RequestNavigate(IRegionManager regionManager, string regionName, string viewName)
        {
            RequestNavigate(regionManager, regionName, Router.Instance.ConverterViewNameToType(viewName));
        }

        /// <summary>
        /// 在目标区域进行视图注入
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="regionName"></param>
        /// <param name="viewUrl"></param>
        /// <param name="param"></param>
        public static void RequestNavigate(IRegionManager regionManager, string regionName, Type view, NavigationParameters param)
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
                view = typeof(BackNavigationView);
            }
            regionManager.RequestNavigate(regionName, RouteHelper.GetViewPath(view), param);
        }

        public static void RegisterViewWithRegion(IRegionManager regionManager, string regionName, Type viewType)
        {
            regionManager.RegisterViewWithRegion(regionName, viewType);
        }
    }
}
