using System.Windows;
using System.Windows.Controls;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// CloudFileView.xaml 的交互逻辑
    /// </summary>
    public partial class CloudFileView : UserControl
    {
        public CloudFileView()
        {
            InitializeComponent();
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            fileDragMask.Visibility = Visibility.Visible;
            e.Handled = true;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            fileDragMask.Visibility = Visibility.Collapsed;
            e.Handled = true;
        }

        private void OnDragLeave(object sender, DragEventArgs e)
        {
            fileDragMask.Visibility = Visibility.Collapsed;
            e.Handled = true;
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            fileDragMask.Visibility = Visibility.Visible;

            e.Handled = false;
        }
    }
}
