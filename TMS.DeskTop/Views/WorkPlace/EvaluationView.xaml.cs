using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.DeskTop.Views.WorkPlace.Evaluation;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// EvaluationView.xaml 的交互逻辑
    /// </summary>
    public partial class EvaluationView : UserControl
    {
        private IRegionManager regionManager;
        private IRegionNavigationJournal journal;

        public EvaluationView(IRegionManager regionManager)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.Loaded += EvaluationView_Loaded;
        }

        private void EvaluationView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionToken.EvaluationContent, "EvaluationMainView");
            e.Handled = true;
        }
    }
}
