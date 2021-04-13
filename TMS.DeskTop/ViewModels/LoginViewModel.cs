using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using TMS.Core.Api;
using TMS.Core.Data.Entity;
using TMS.Core.Event;
using TMS.Core.Service;

namespace TMS.DeskTop.ViewModels
{
    public class LoginViewModel : BaseDialogViewModel
    {
        public LoginViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(eventAggregator)
        {
            LoginCmd = new DelegateCommand(Login);
            ExitCmd = new DelegateCommand(Exit);
        }

        #region Property
        private string userName = "18401200122";
        private string passWord = "123456";

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; RaisePropertyChanged(); }
        }
        #endregion


        #region Command
        public DelegateCommand LoginCmd { get; private set; }
        public DelegateCommand ExitCmd { get; private set; }

        private async void Login()
        {
            var result = await HttpService.GetConn().LoginUserTel(UserName, PassWord);
            if (result.StatusCode == 200)
            {
                User user = (User)result.Data;
                SessionService.Instance.User = user;
                eventAggregator.GetEvent<LoginedEvent>().Publish();
            }
            else
            {
                eventAggregator.GetEvent<ToastShowEvent>().Publish("号码或密码错误！");
            }
        }

        #endregion

        public override void Exit()
        {
            eventAggregator.GetEvent<ExitEvent>().Publish();
        }
    }
}
