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
using TMS_PC.Common.Helper;
using TMS_PC.View;

namespace TMS_PC
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            content.Children.Clear();
            content.Children.Add(new NotificationView());

        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            IconHelper.RemoveIcon(this);
        }
    }
}
