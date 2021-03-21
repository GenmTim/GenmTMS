using Microsoft.Web.WebView2.Core;
using System;
using System.Windows;

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
