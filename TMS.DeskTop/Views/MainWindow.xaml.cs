using Prism.Events;
using Prism.Regions;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.PersonalFile;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public MainWindow(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            InitSubscribeEvent();
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.MainContent, typeof(NotificationView));
            eventAggregator.GetEvent<ToastShowEvent>().Subscribe(ToastShow, ThreadOption.UIThread);
        }

        private void InitSubscribeEvent()
        {
            eventAggregator.GetEvent<SashEvent>().Subscribe((data) =>
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.MainContent, typeof(PersonalFileView));
            });
        }

        private void ToastShow(string message)
        {
            toast.Show(message);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.panel.Focus();
        }
    }
}
