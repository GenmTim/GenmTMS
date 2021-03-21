using Prism.Commands;
using Prism.Mvvm;

namespace TMS.DeskTop.ViewModels.WorkPlace.Auth.Subitem
{
    public class ApplyForViewModel : BindableBase
    {

        private string subject = "我发起的";
        public string Subject { get => subject; set { SetProperty(ref subject, value); } }

        public ApplyForViewModel()
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
