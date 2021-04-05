using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace TMS_UI_Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<String> dataList = new ObservableCollection<string>(){ "二十", "大受打击" };
        public ObservableCollection<string> DataList { get => dataList; set => dataList = value; }

        private Notifier notifier;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            dayComponent.DataContext = new MultiValueComboBoxModel
            {
                OneValueList = new List<string> { "sadsd", "asdasd" }
            };

            //notifier = new Notifier(cfg =>
            //{
            //    cfg.PositionProvider = new WindowPositionProvider(
            //        parentWindow: Application.Current.MainWindow,
            //        corner: Corner.TopCenter,
            //        offsetX: 0,
            //        offsetY: 0);

            //    cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            //        notificationLifetime: TimeSpan.FromSeconds(3),
            //        maximumNotificationCount: MaximumNotificationCount.FromCount(5));

            //    cfg.Dispatcher = Application.Current.Dispatcher;
            //});
        }

        public void NotificationToast_Show(object sender, RoutedEventArgs args)
        {
            notifier.ShowInformation("测试");
        }

    }
}
