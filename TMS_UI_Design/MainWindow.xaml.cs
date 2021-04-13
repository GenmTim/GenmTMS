using Prism.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace TMS_UI_Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Log { get; set; } = new ObservableCollection<string>();

        public MainWindow(IContainerExtension container)
        {
            InitializeComponent();
            DataContext = container.Resolve<MainWindowViewModel>();

        }

        private void OnDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effects = DragDropEffects.Copy;
            else
                e.Effects = DragDropEffects.None;

            e.Handled = true;
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var files = e.Data.GetData(DataFormats.FileDrop) as Array;
            foreach (string fileFullName in files)
            {
                if (this.DataContext is MainWindowViewModel vm)
                {
                    vm.UploadFileCmd.Execute(new UploadFileItem
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = fileFullName,
                        Rate = 0,
                    });
                }
            }

            e.Handled = true;
        }

        private void OnDragLeave(object sender, DragEventArgs e)
        {

            e.Handled = true;
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Handled = false;
        }



    }
}
