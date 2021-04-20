using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TMS.DeskTop.UserControls.Popup.Views
{
    /// <summary>
    /// ProfilePopup.xaml 的交互逻辑
    /// </summary>
    public partial class ProfilePopup : UserControl
    {
        public ProfilePopup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Hyperlink link = new Hyperlink
            {
                NavigateUri = new System.Uri("www.baidu.com"),
            };
            Process.Start(new ProcessStartInfo(link.NavigateUri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
