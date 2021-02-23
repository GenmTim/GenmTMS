using Prism.Regions;
using System.Windows;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;

namespace TMS.DeskTop.Views.WorkPlace.Evaluation
{
    /// <summary>
    /// EvaluationMainView.xaml 的交互逻辑
    /// </summary>
    public partial class EvaluationMainView : RegionManagerControl, INavigationAware
    {

        public EvaluationMainView(IRegionManager regionManager) : base(regionManager)
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.EvaluationMainContent, nameof(ViewEvaluationView));
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

        }
    }
}
