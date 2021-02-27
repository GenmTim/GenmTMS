using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TMS.DeskTop.Tools.Base
{
    public class RegionManagerControl : UserControl
    {
        protected IRegionManager regionManager;
        private Dictionary<string, string> regionsDefaultView;

        public RegionManagerControl(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.Loaded += LoadDefaultRegionView;
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
            foreach (KeyValuePair<string, string> kvp in regionsDefaultView)
            {
                    this.regionManager.RequestNavigate(kvp.Key, kvp.Value);
            }
            this.Loaded -= LoadDefaultRegionView;
        }

    }
}
