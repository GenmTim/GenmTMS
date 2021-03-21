using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.UserControls.Common.Views
{
    /// <summary>
    /// BackNavigationView.xaml 的交互逻辑
    /// </summary>
    public partial class BackNavigationView : UserControl, INavigationAware
    {
        private string timestampStr;


        private readonly IRegionManager regionManager;
        //private IRegionNavigationJournal journal;

        public BackNavigationView(IRegionManager regionManager)
        {
            InitializeComponent();

            this.regionManager = regionManager;
            timestampStr = TimeHelper.GetNowTimeStamp().ToString();
            RegionManager.SetRegionName(backNavigationView, RegionToken.BackNavigationContent + timestampStr);
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
            System.Type obj = navigationContext.Parameters.GetValue<System.Type>("view");
            regionManager.RegisterViewWithRegion(RegionToken.BackNavigationContent + timestampStr, obj);
        }
    }
}
