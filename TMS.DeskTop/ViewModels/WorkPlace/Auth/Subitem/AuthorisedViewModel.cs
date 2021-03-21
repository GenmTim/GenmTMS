using Prism.Commands;
using Prism.Mvvm;

namespace TMS.DeskTop.ViewModels.WorkPlace.Auth.Subitem
{
    public class AuthorisedViewModel : BindableBase
    {
        private string subject = "待授权";
        public string Subject { get => subject; set { SetProperty(ref subject, value); } }

        public AuthorisedViewModel()
        {
            this.ChangeSubjectCmd = new DelegateCommand<string>(ChangeSubject);
        }

        public DelegateCommand<string> ChangeSubjectCmd { get; set; }

        private void ChangeSubject(string newSubject)
        {
            Subject = newSubject;
        }
    }
}
