using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.Report;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class ReportView : RegionManagerControl
    {
        public ReportView(IRegionManager regionManager) : base(regionManager, typeof(ReportView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.ReportContent, nameof(ReportMainView));
        }
    }
}
