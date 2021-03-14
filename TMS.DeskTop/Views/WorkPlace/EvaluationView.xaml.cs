using Prism.Regions;
using System;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// EvaluationView.xaml 的交互逻辑
    /// </summary>
    public partial class EvaluationView : RegionManagerControl, IDisposable
    {
        //private IRegionNavigationJournal journal;

        public EvaluationView(IRegionManager regionManager) : base(regionManager, typeof(EvaluationView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.EvaluationContent, "EvaluationMainView");
        }

        public void Dispose()
        {
            this.regionManager.Regions[RegionToken.EvaluationContent].RemoveAll();
        }
    }
}
