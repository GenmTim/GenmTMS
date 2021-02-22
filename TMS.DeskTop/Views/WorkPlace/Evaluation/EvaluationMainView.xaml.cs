using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMS.Core.Data;

namespace TMS.DeskTop.Views.WorkPlace.Evaluation
{
    /// <summary>
    /// EvaluationMainView.xaml 的交互逻辑
    /// </summary>
    public partial class EvaluationMainView : UserControl, INavigationAware
    {
        private IRegionManager regionManager;

        public EvaluationMainView(IRegionManager regionManager)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.Loaded += EvaluationMainView_Loaded;
        }

        private void EvaluationMainView_Loaded(object sender, RoutedEventArgs e)
        {
            this.regionManager.RequestNavigate(RegionToken.EvaluationMainContent, nameof(ViewEvaluationView));

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
