using System.Windows.Controls;
using TMS_PC.ViewModel;

namespace TMS_PC.View
{
    /// <summary>
    /// NotificationView.xaml 的交互逻辑
    /// </summary>
    public partial class NotificationView : UserControl
    {
        public NotificationView()
        {
            InitializeComponent();
            NotificationViewModel wm = new NotificationViewModel();
            DataContext = wm;
        }
    }
}
