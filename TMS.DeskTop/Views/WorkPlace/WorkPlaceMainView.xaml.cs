using System;
using System.Windows.Controls;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// WorkPlaceMainView.xaml 的交互逻辑
    /// </summary>
    public partial class WorkPlaceMainView : UserControl, IDisposable
    {
        public WorkPlaceMainView()
        {
            InitializeComponent();
            displayBorder.Uri = new Uri(@"/TMS.DeskTop;component/Resources/Images/designer_and_client_2__dribbble__1.gif", UriKind.Relative);
        }

        public void Dispose()
        {
            displayBorder.Dispose();
        }
    }
}
