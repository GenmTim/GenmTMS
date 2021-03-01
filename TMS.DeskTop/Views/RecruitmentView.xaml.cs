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
using TMS.DeskTop.Resources.Styles.Views.Recruitment;
using TMS.DeskTop.Tools.Base;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// RecruitmentView.xaml 的交互逻辑
    /// </summary>
    public partial class RecruitmentView : RegionManagerControl
    {
        public RecruitmentView(IRegionManager regionManager) : base(regionManager)
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.RecruitmentContent, nameof(RecruitmentNavigationView));
        }
    }
}
