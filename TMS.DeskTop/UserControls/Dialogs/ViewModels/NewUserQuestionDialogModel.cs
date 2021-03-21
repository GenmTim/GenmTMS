using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    public class NewUserQuestionDialogModel : IDialogHostAware
    {
        public string IdentifierName { get; set; } = "Root";

        public NewUserQuestionDialogModel()
        {
            this.SaveCommand = new DelegateCommand(Save);
            this.CancelCommand = new DelegateCommand(Cancel);
        }

        public DelegateCommand SaveCommand { get; private set; }

        public DelegateCommand CancelCommand { get; private set; }


        private void Save()
        {
            DialogHost.Close(IdentifierName);
        }

        private void Cancel()
        {
            DialogHost.Close(IdentifierName);
        }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            return Task.FromResult(true);
        }
    }
}
