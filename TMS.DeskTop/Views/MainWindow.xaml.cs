using Prism.Events;
using Prism.Regions;
using System;
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
        private static int i = 0;

        public MainWindow(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            InitSubscribeEvent();
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.MainContent, typeof(NotificationView));
        }

        private void InitSubscribeEvent()
        {
            eventAggregator.GetEvent<SashEvent>().Subscribe((data) => 
            {
                RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.SashRegion, typeof(PersonalFileView));
                //drawer.IsOpen = true;
            });
            //eventAggregator.GetEvent<CloseSashEvent>().Subscribe(() =>
            //{
            //    drawer.IsOpen = false;
            //});
        }

        /// <summary>
        /// 窗口最小化
        /// </summary>
        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //设置窗口最小化
        }

        /// <summary>
        /// 窗口最大化与还原
        /// </summary>
        private void btn_max_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal; //设置窗口还原
            }
            else
            {
                this.WindowState = WindowState.Maximized; //设置窗口最大化
            }
        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        /// <summary>
        /// 标题栏双击事件
        /// </summary>
        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            i += 1;
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            timer.Tick += (s, e1) => { timer.IsEnabled = false; i = 0; };
            timer.IsEnabled = true;

            if (i % 2 == 0)
            {
                timer.IsEnabled = false;
                i = 0;
                this.WindowState = this.WindowState == WindowState.Maximized ?
                              WindowState.Normal : WindowState.Maximized;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.panel.Focus();
        }
    }
}
