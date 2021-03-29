using Prism.Commands;
using Prism.Mvvm;
using TMS.Core.Api;
using TMS.Core.Data.Dto;

namespace TMS.DeskTop.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";

        public DelegateCommand LoginCmd { get; private set; }

        public LoginViewModel()
        {
            this.LoginCmd = new DelegateCommand(async() =>
            {
                var result = await HttpService.GetConn().LoginUserTel("", "");
                if (result.StatusCode == 200)
                {
                    var userData = (UserDto)result.Data;
                    
                }
            });
        }
    }
}
