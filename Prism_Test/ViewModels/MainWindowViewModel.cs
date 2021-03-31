using Newtonsoft.Json.Linq;
using Prism.Mvvm;
using Prism.Regions;
using System;
using TMS.Core.Api;
using TMS.Core.Data.Dto;
using WebSocketSharp;

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

            LoggerService.Debug("这是一次Debug");
            LoggerService.Debug("这是一次Debug");
            LoggerService.Info("这是一次Info");
            LoggerService.Debug("这是一次Debug");
            LoggerService.Info("这是一次Info");
            LoggerService.Error("这是一次Error");
            LoggerService.Debug("这是一次Debug");

            //         WebSocket ws = new WebSocket("ws://121.40.165.18:8800");
            //         ws.OnMessage += (sender, e) =>
            //         {
            //             Console.WriteLine("Laputa says: " + e.Data);
            //	LogString = "dfdh：" + e.Data;
            //};
            //         ws.OnOpen += (sender, e) => {

            //             Console.WriteLine("lianjiechengg");
            //             ws.Send("BALUS");
            //         };
            //         ws.Connect();

            //HttpService serviceApi = HttpService.Instance;
            //HttpService serviceApi2 = HttpService.GetInstance();

            //EvaluationGroupDto evaluationGroupDto = new EvaluationGroupDto();
            //evaluationGroupDto.ExaminerId = 122;
            //evaluationGroupDto.Subject = "asdsad";
            //JObject jObject = JObject.FromObject(evaluationGroupDto);
            //string v = jObject.ToString();
            //JObject jObject1 = new JObject();
            //ApiResponse apiResponse = serviceApi2.PostEvaluationGroup(evaluationGroupDto);

            //         ApiResponse apiResponse = serviceApi.LoginUserEmail("123@qq.com", "qzj");
            //if (apiResponse.StatusCode!=200)
            //{
            //             LogString = apiResponse.Message;
            //         }

            //         apiResponse = await serviceApi.LoginUserTel("111011", "qzj");
            //         if (apiResponse.StatusCode != 200)
            //         {
            //             LogString = apiResponse.Message;
            //         }

            //apiResponse = await serviceApi.ChangeUserPassword(((UserDto)apiResponse.Data).UserId, "jjj");
            //if (apiResponse.StatusCode != 200)
            //{
            //    LogString = apiResponse.Message;
            //}


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
