using HandyControl.Tools;
using Prism.Events;
using System.Windows.Controls;
using TMS.DeskTop.UserControls.ViewModels;

namespace TMS.DeskTop.UserControls.Views
{
    /// <summary>
    /// ChatBox.xaml 的交互逻辑
    /// </summary>
    public partial class ChatBox : UserControl
    {
        private ScrollViewer _scrollViewer;

        public ChatBox(IEventAggregator eventaggrator)
        {
            InitializeComponent();
            ListBoxChat.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
        }

        private void ItemContainerGenerator_ItemsChanged(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
        {
            _scrollViewer ??= VisualHelper.GetChild<ScrollViewer>(ListBoxChat);
            _scrollViewer?.ScrollToBottom();
        }
    }
}
