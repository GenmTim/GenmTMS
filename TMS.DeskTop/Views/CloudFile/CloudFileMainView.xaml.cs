using Prism.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using TMS.Core.Data.VO.CloudFile;
using TMS.Core.Event;

namespace TMS.DeskTop.Views.CloudFile
{
    /// <summary>
    /// CloudFileMainView.xaml 的交互逻辑
    /// </summary>
    public partial class CloudFileMainView : UserControl
    {
        private readonly IEventAggregator eventAggregator;

        public CloudFileMainView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            fileDragMask.Visibility = Visibility.Collapsed;

            var files = e.Data.GetData(DataFormats.FileDrop) as Array;
            foreach (string fileFullName in files)
            {
                var uploadFileItem = new UploadFileItemVO
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = fileFullName,
                    Rate = 0,
                };
                eventAggregator.GetEvent<UploadFileEvent>().Publish(uploadFileItem);
            }
            e.Handled = true;
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
