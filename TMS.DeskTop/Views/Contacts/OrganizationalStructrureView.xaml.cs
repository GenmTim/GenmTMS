using Prism.Events;
using System.Windows.Controls;
using TMS.Core.Data;
using TMS.Core.Event.Update;

namespace TMS.DeskTop.Views.Contacts
{
    /// <summary>
    /// OrganizationalStructrureView.xaml 的交互逻辑
    /// </summary>
    public partial class OrganizationalStructrureView : UserControl
    {
        private readonly IEventAggregator eventAggregator;
        public OrganizationalStructrureView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            this.Loaded += OrganizationalStructrureView_Loaded;
        }

        private void OrganizationalStructrureView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            eventAggregator.GetEvent<UpdateCompanyOrganizationEvent>().Publish();
        }

        private void TreeView_SelectedItemChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender is TreeView treeView)
            {
                if (treeView.SelectedItem is DeptTreeNodeItemVO treeNodeItem)
                {
                    eventAggregator.GetEvent<UpdateShowDeptInfo>().Publish(treeNodeItem);
                }
            }
        }
    }
}
