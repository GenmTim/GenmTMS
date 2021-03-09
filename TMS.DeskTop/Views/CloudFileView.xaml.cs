using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
