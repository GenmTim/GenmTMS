using HandyControl.Tools;
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
using TMS.DeskTop.UserControls.ViewModels;

namespace TMS.DeskTop.UserControls.Views
{
    /// <summary>
    /// ChatBox.xaml 的交互逻辑
    /// </summary>
    public partial class ChatBox : UserControl
    {
        private ScrollViewer _scrollViewer;

        public ChatBox()
        {
            DataContext = new ChatBoxViewModel();
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
