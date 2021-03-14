using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.Tools.Base
{
    public class RegionManagerControl : UserControl
    {
        protected IRegionManager regionManager;
        private Dictionary<string, Type> regionsDefaultView;
        private readonly Type view;

        public RegionManagerControl(IRegionManager regionManager, Type view)
        {
            this.regionManager = regionManager;
            this.Loaded += LoadDefaultRegionView;
            this.view = view;
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
            Type now_view = view;
            bool needRoute = navigationContext.Parameters.TryGetValue<Type>("target_view", out Type target_view);
            if (needRoute)
            {
                RouteHelper.Route(regionManager, now_view, target_view);
            }

        }

        protected void RegisterDefaultRegionView(string regionName, string viewName)
        {
            if (regionsDefaultView == null)
            {
                regionsDefaultView = new Dictionary<string, Type>();
            }
            regionsDefaultView[regionName] = Router.Instance.ConverterViewNameToType(viewName);
        }

        private void LoadDefaultRegionView(object sender, System.Windows.RoutedEventArgs e)
        {
            if (regionsDefaultView != null)
            {
                foreach (KeyValuePair<string, Type> kvp in regionsDefaultView)
                {
                    RegionHelper.RequestNavigate(regionManager, regionName: kvp.Key, view: kvp.Value);
                }
            }
            this.Loaded -= LoadDefaultRegionView;
        }

    }
}
