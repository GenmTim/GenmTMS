using Prism.Events;
using System.Windows;
using System.Windows.Controls;
using static TMS.DeskTop.ViewModels.Contacts.LinkManViewModel;

namespace TMS.DeskTop.Views.Contacts
{
    /// <summary>
    /// LinkManView.xaml 的交互逻辑
    /// </summary>
    public partial class LinkManView : UserControl
    {
        private IEventAggregator eventAggregator;
        public LinkManView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            this.Loaded += LinkManView_Loaded;
        }

        private void LinkManView_Loaded(object sender, RoutedEventArgs e)
        {
            eventAggregator.GetEvent<UpdateContacterListEvent>().Publish();
        }
    }
}
