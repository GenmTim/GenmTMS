using System.Windows.Controls;

namespace TMS.DeskTop.UserControls.Popup.Views
{
    /// <summary>
    /// UploadInfoPopup.xaml 的交互逻辑
    /// </summary>
    public partial class UploadInfoPopup : UserControl
    {
        public UploadInfoPopup()
        {
            InitializeComponent();
            listsControl.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
        }

        private void ItemContainerGenerator_ItemsChanged(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
        {
            scrollViewer?.ScrollToBottom();
        }
    }
}
