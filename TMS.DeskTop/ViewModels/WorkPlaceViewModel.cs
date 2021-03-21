using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels
{
    class WorkPlaceViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IModuleCatalog moduleCatalog;


        public WorkPlaceViewModel(IRegionManager regionManager, IModuleCatalog moduleCatalog)
        {
            this.moduleCatalog = moduleCatalog;
            this.regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(NavigationPage);
            TabClosedCommand = new DelegateCommand<RoutedEventArgs>(CloseTabItem);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string view)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.WorkPlaceTabContent, view);
        }

        public DelegateCommand<RoutedEventArgs> TabClosedCommand { get; private set; }

        public void CloseTabItem(RoutedEventArgs e)
        {
            var arg = e as RoutedEventArgs;
            if (arg != null)
            {
                var content = arg.OriginalSource as ContentControl;
                if (content != null)
                {
                    var tabRegion = this.regionManager.Regions[RegionToken.WorkPlaceTabContent];
                    var viewToClose = tabRegion.Views.Cast<FrameworkElement>().Where(v => v == content).FirstOrDefault();
                    if (viewToClose != null)
                    {
                        var disposableViewToClose = viewToClose as IDisposable;
                        if (disposableViewToClose != null)
                        {
                            disposableViewToClose.Dispose();
                        }

                        tabRegion.Remove(viewToClose);
                    }
                }
            }
        }
    }
}
