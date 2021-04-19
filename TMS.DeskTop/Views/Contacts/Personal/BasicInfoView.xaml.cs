using Prism.Events;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using static TMS.DeskTop.ViewModels.Contacts.PersonalInfoViewModel;

namespace TMS.DeskTop.Views.Contacts.Personal
{
    /// <summary>
    /// BasicInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class BasicInfoView : UserControl
    {
        private readonly IEventAggregator eventAggregator;

        public BasicInfoView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
        }

        private void SimplePanel_Drop(object sender, System.Windows.DragEventArgs e)
        {

            var files = e.Data.GetData(DataFormats.FileDrop) as Array;
            foreach (string fileFullName in files)
            {
                eventAggregator.GetEvent<UpdateResumeEvent>().Publish(new FileInfo(fileFullName));
                break;
            }
            e.Handled = true;
        }

        private void OnDragOver(object sender, System.Windows.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

    }
}
