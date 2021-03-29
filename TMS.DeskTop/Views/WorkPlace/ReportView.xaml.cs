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
