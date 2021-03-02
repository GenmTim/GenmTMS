using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.UserControls.Views
{
    /// <summary>
    /// BackNavigationView.xaml 的交互逻辑
    /// </summary>
    public partial class BackNavigationView : UserControl, INavigationAware
    {
        private string _title = "";
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string timestampStr;


        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;

        public BackNavigationView(IRegionManager regionManager)
        {
            InitializeComponent();

            this.regionManager = regionManager;
            this.GoBackCommand = new DelegateCommand(GoBack);
            timestampStr = TimeHelper.GetNowTimeStamp().ToString();
            RegionManager.SetRegionName(backNavigationView, RegionToken.BackNavigationContent + timestampStr);
        }


        public DelegateCommand GoBackCommand { get; private set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Title = navigationContext.Parameters.GetValue<string>("title");
            var obj = navigationContext.Parameters.GetValue<System.Type>("obj");
            regionManager.RegisterViewWithRegion(RegionToken.BackNavigationContent + timestampStr, obj);
            journal = navigationContext.NavigationService.Journal;
        }

        private void GoBack()
        {
            journal?.GoBack();
        }
    }
}
