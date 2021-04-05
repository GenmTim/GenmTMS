using HandyControl.Tools;
using Prism.Events;
using Prism.Regions;
using System.Windows.Controls;

namespace TMS.DeskTop.UserControls.Card.Views
{
    /// <summary>
    /// FriendCard.xaml 的交互逻辑
    /// </summary>
    public partial class FriendCard : UserControl
    {
        //private FriendCardModel vm;
        public FriendCard(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            //vm = new FriendCardModel(regionManager, eventAggregator);
            //this.DataContext = vm;
            InitializeComponent();
        }

    }
}
