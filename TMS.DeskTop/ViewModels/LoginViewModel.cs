using Newtonsoft.Json;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using TMS.Core.Api;
using TMS.Core.Data.Dto;
using TMS.Core.Data.Entity;
using TMS.Core.Event;
using TMS.Core.Service;
using static TMS.DeskTop.Views.LoginView;

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
        private string userName;
        private string passWord;

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
                SessionService.User = user;
                eventAggregator.GetEvent<LoginedEvent>().Publish();
            }
        }

        #endregion

        public override void Exit()
        {
            eventAggregator.GetEvent<ExitEvent>().Publish();
        }
    }
}
