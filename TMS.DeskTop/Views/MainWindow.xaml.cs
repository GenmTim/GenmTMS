using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IRegionManager regionManager;
        private static int i = 0;

        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.MainContent, typeof(WorkPlaceView));


            //this.MouseMove += (s, e) =>
            //    {
            //        if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            //            this.DragMove();
            //    };
        }

        private void InitDefaultData()
        {
            //mainContent.Content = new ApplicationView();
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
    }
}
