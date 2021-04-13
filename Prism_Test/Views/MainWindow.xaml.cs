using Prism.Regions;
using System.Windows;

namespace Prism_Test.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager regionManager;
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            this.regionManager = regionManager;

            //this.NaviagationCommand = new DelegateCommand<string>(NavigationPage);
        }

        //public DelegateCommand<string> NaviagationCommand { get; set; }

        //public void NavigationPage(string view)
        //{
        //    var str = this.GetType().Name;
        //    string now_url = Router.Instance[this.GetType().Name];
        //    string go_url = Router.Instance[view];
        //    int next_index = go_url.IndexOf('/', now_url.Length);
        //    string next_view = go_url.Substring(0, next_index + 1);
        //    Console.WriteLine(next_view);
        //    //this.regionManager.RequestNavigate("ContentRegion", url);
        //}
    }
}
