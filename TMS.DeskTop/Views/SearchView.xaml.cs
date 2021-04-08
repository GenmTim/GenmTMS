using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.Search;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// SearchView.xaml 的交互逻辑
    /// </summary>
    public partial class SearchView : RegionManagerControl
    {
        public SearchView(IRegionManager regionManager) : base(regionManager, typeof(SearchView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.SearchContent, nameof(SearchMainView));
        }
    }
}
