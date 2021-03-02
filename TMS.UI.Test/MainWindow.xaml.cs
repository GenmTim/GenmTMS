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

namespace TMS.UI.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class DataT
        {
            public string Title { get; set; }
        }

        private string title = "标题";
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TabItem tab = new TabItem();
            tab.DataContext = new DataT { Title = "标题" };
            tabcontrol.Items.Add(tab);
        }
    }
}
