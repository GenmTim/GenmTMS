using Prism.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using static TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering.Step.EnteringDataViewModel;

namespace TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering.Step
{
    /// <summary>
    /// EnteringDataView.xaml 的交互逻辑
    /// </summary>
    public partial class EnteringDataView : UserControl
    {
        private readonly IEventAggregator eventAggregator;
        public EnteringDataView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as Array;
            foreach (string fileFullName in files)
            {
                this.eventAggregator.GetEvent<InComingFileEvent>().Publish(fileFullName);
                break;
            }
            e.Handled = true;
        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            e.Handled = true;
        }
    }
}
