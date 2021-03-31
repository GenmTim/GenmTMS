using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using TMS.Core.Api;
using TMS.Core.Data.Dto;
using TMS.Core.Event;
using static TMS.DeskTop.Views.LoginView;

namespace TMS.DeskTop.ViewModels
{
    public class LoginViewModel : BaseDialogViewModel
    {
        private WebSocketService webSocket;

        public LoginViewModel(IContainerExtension container, IEventAggregator eventAggregator) : base(eventAggregator)
        {
            LoginCmd = new DelegateCommand(Login);
            webSocket = container.Resolve<WebSocketService>();
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

        private void Login()
        {
            eventAggregator.GetEvent<LoginedEvent>().Publish();
        }

        #endregion

        public override void Exit()
        {
            eventAggregator.GetEvent<ExitEvent>().Publish();
        }
    }
}
