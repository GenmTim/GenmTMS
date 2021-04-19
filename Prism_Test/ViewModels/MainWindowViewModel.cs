using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using TMS.Core.Data.Entity;

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

        public List<Payroll> DataList { get; set; } = new List<Payroll>() {
            new Payroll{ Name="234", Month="2021-02",Number=2,Money=2813734.37,
                Currency="CNY",Unpublished=0,Published=2,Withdrawn=1,CreateTime="2021-01-19"},
            new Payroll{ Name="ghk", Month="2020-02",Number=26,Money=435734.37,
                Currency="USD",Unpublished=2,Published=5,Withdrawn=0,CreateTime="2021-02-22"},
            new Payroll{ Name="876g", Month="2021-01",Number=12,Money=2898734.37,
                Currency="USD",Unpublished=3,Published=3,Withdrawn=2,CreateTime="2021-03-02"},
            new Payroll{ Name="909k", Month="2020-12",Number=9,Money=993734.37,
                Currency="CNY",Unpublished=1,Published=1,Withdrawn=2,CreateTime="2021-02-07"},
            new Payroll{ Name="bg5h", Month="2020-11",Number=15,Money=1234734.37,
                Currency="CNY",Unpublished=1,Published=4,Withdrawn=0,CreateTime="2021-01-31"}
        };

        public string LogString { get; set; } = "";

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;



            //CancellationTokenSource tokenSource = new CancellationTokenSource();//取消令牌
            //ManualResetEvent resetEvent = new ManualResetEvent(true);//暂停接口

            //Task task = new Task(async () =>
            //{
            //	FileService fileService = new FileService(resetEvent);//传入
            //	fileService.OnSendingProgress += OnSendingProgress;//进度返回
            //	await fileService.FileUploadAsync("E:\\文件\\临时\\Hailar.wld",tokenSource);
            //});
            //task.Start();

            //resetEvent.Reset();//暂停任务

            //resetEvent.Set();//继续任务

            //tokenSource.Cancel();//终止任务

            //void OnSendingProgress(double progress)
            //{
            //	//进度更新
            //}


            //string data = "[{\"companyId\":100,\"ChildDepartments\":[{\"companyId\":100,\"ChildDepartments\":[{\"companyId\":100,\"deptId\":6,\"name\":\"网络安全\",\"updateAt\":\"2021-04-08T08:00:10\",\"parentDept\":3,\"createAt\":\"2021-04-08T08:00:10\"}],\"deptId\":3,\"name\":\"网络\",\"updateAt\":\"2021-04-08T07:59:40\",\"parentDept\":1,\"createAt\":\"2021-02-03T14:01:23\"},{\"companyId\":100,\"deptId\":5,\"name\":\"计科\",\"updateAt\":\"2021-04-08T08:04:13\",\"parentDept\":1,\"createAt\":\"2021-04-08T07:59:01\"}],\"deptId\":1,\"name\":\"电信\",\"updateAt\":\"2021-04-08T07:59:31\",\"createAt\":\"2021-02-03T14:00:36\"},{\"companyId\":100,\"deptId\":4,\"name\":\"材化\",\"updateAt\":\"2021-04-08T07:59:53\",\"createAt\":\"2021-04-08T07:58:40\"}]";
            //List<TreeDept> treeDepts = JsonConvert.DeserializeObject<List<TreeDept>>(data);
            //LogString = "dfdh：asdsadsadsad";
            //LoggerService.Debug("这是一次Debug");
            //LoggerService.Debug("这是一次Debug");
            //LoggerService.Info("这是一次Info");
            //LoggerService.Debug("这是一次Debug");
            //LoggerService.Info("这是一次Info");
            //LoggerService.Error("这是一次Error");
            //LoggerService.Debug("这是一次Debug");

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
