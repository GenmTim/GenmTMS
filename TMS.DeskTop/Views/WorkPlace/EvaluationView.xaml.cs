using Prism.Regions;
using System;
using System.Windows.Controls;
using TMS.Core.Data;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// EvaluationView.xaml 的交互逻辑
    /// </summary>
    public partial class EvaluationView : UserControl, IDisposable
    {
        private IRegionManager regionManager;
        //private IRegionNavigationJournal journal;

        public EvaluationView(IRegionManager regionManager)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.Loaded += EvaluationView_Loaded;
        }

        public void Dispose()
        {
            this.regionManager.Regions[RegionToken.EvaluationContent].RemoveAll();
        }

        private void EvaluationView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionToken.EvaluationContent, "EvaluationMainView");
            e.Handled = true;
        }
    }
}
