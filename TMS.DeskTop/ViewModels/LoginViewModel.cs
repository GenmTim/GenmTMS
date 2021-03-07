using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
