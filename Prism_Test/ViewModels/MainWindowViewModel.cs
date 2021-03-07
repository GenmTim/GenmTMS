using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism_Test.Views;
using TMS.Core.Api;

namespace Prism_Test.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string LogString { get; set; } = "";

		public MainWindowViewModel(IRegionManager regionManager)
		{
			this.regionManager = regionManager;
			LogString = "测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串测试字符串";
			HttpClient serviceApi = new HttpClient();

			int v = serviceApi.LoginUser("jjj","11101");
            LogString = v.ToString();

            //this.NaviagationCommand = new DelegateCommand<string>(NavigationPage);
        }

        //public DelegateCommand<string> NaviagationCommand { get; set; }

        //public void NavigationPage(string view)
        //{
        //    string go_url = Router.Instance[view];

        //    string now_url = Router.Instance[nameof(MainWindow)];
        //    int next_index = go_url.IndexOf('/', now_url.Length);
        //    string next_view = go_url.Substring(0, next_index + 1);

        //    NavigationParameters param = new NavigationParameters();
        //    param.Add("url", go_url);

        //    this.regionManager.RequestNavigate("ContentRegion", next_view, param);
        //}
    }
}
