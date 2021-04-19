using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using TMS.DeskTop.Tools.Base;

namespace TMS.DeskTop.UserControls.Popup.Views
{
    /// <summary>
    /// UploadInfoPopup.xaml 的交互逻辑
    /// </summary>
    public partial class UploadInfoPopup : UserControl
    {
        private bool isFold { get; set; }

        public UploadInfoPopup()
        {
            InitializeComponent();
            listsControl.ItemContainerGenerator.ItemsChanged += ItemContainerGenerator_ItemsChanged;
        }

        private void ItemContainerGenerator_ItemsChanged(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
        {
            scrollViewer?.ScrollToBottom();
        }

        private void FlodClick(object sender, System.Windows.RoutedEventArgs e)
        {
            isFold = !isFold;
            if (isFold)
            {
                Storyboard st = new Storyboard();
                GridLengthAnimation d = new GridLengthAnimation
                {
                    From = new GridLength(260, GridUnitType.Pixel),
                    To = new GridLength(0, GridUnitType.Pixel),
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                grid.RowDefinitions[1].BeginAnimation(RowDefinition.HeightProperty, d);
            }
            else 
            {
                Storyboard st = new Storyboard();
                GridLengthAnimation d = new GridLengthAnimation
                {
                    From = new GridLength(0, GridUnitType.Pixel),
                    To = new GridLength(260, GridUnitType.Pixel),
                    Duration = TimeSpan.FromSeconds(0.2)
                };
                grid.RowDefinitions[1].BeginAnimation(RowDefinition.HeightProperty, d);
            }
            e.Handled = true;
        }
    }
}
