using Prism.Mvvm;

namespace TMS.DeskTop.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public string UserName { get; set; } = "";
        public string PassWord { get; set; } = "";

        public LoginViewModel()
        {

        }
    }
}
