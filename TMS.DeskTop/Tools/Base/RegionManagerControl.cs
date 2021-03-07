using Prism.Regions;
using System.Collections.Generic;
using System.Windows.Controls;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.Tools.Base
{
    public class RegionManagerControl : UserControl
    {
        protected IRegionManager regionManager;
        private Dictionary<string, string> regionsDefaultView;
        private readonly string viewName;

        public RegionManagerControl(IRegionManager regionManager, string viewName)
        {
            this.regionManager = regionManager;
            this.Loaded += LoadDefaultRegionView;
            this.viewName = viewName;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string now_view = viewName;
            bool needRoute = navigationContext.Parameters.TryGetValue<string>("target_view", out string target_view);
            if (needRoute)
            {
                RouteHelper.Route(regionManager, now_view, target_view);
            }

        }

        protected void RegisterDefaultRegionView(string regionName, string viewName)
        {
            if (regionsDefaultView == null)
            {
                regionsDefaultView = new Dictionary<string, string>();
            }
            regionsDefaultView[regionName] = viewName;
        }

        private void LoadDefaultRegionView(object sender, System.Windows.RoutedEventArgs e)
        {
            if (regionsDefaultView != null)
            {
                foreach (KeyValuePair<string, string> kvp in regionsDefaultView)
                {
                    RegionHelper.RequestNavigate(regionManager, regionName: kvp.Key, view: kvp.Value);
                }
            }
            this.Loaded -= LoadDefaultRegionView;
        }

    }
}
