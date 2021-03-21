using Prism.Regions;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.Contacts;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// ContactsView.xaml 的交互逻辑
    /// </summary>
    public partial class ContactsView : RegionManagerControl
    {
        public ContactsView(IRegionManager regionManager) : base(regionManager, typeof(ContactsView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.ContactsContent, nameof(OrganizationalStructrureView));
        }
    }
}
