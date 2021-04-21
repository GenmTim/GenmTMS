using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.Contacts.Group;

namespace TMS.DeskTop.Views.Contacts
{
    /// <summary>
    /// MyGroupView.xaml 的交互逻辑
    /// </summary>
    public partial class MyGroupView : RegionManagerControl
    {
        public MyGroupView(IRegionManager regionManager) : base(regionManager, typeof(MyGroupView))
        {
            InitializeComponent();
            //RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.MyGroupContent, typeof(EmptyView));
            RegisterDefaultRegionView(RegionToken.MyGroupContent, nameof(IJoinedView));
        }
    }
}
