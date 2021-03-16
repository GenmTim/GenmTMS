using Microsoft.Web.WebView2.Core;
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

namespace TMS_UI_Design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(CheckWebView().ToString());

        }

        private static bool CheckWebView()
        {
            try
            {
                var str = CoreWebView2Environment.GetAvailableBrowserVersionString();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

    }
}
