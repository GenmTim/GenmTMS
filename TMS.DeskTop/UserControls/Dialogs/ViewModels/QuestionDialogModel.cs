using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    class QuestionDialogModel : BindableBase, IDialogHostAware
    {
        public string IdentifierName { get; set; }

        public DelegateCommand SaveCmd { get; private set; }

        public DelegateCommand CancelCmd { get; private set; }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                RaisePropertyChanged();
            }
        }

        private string positiveText;
        public string PositiveText
        {
            get => positiveText;
            set
            {
                positiveText = value;
                RaisePropertyChanged();
            }
        }

        private string negativeText;
        public string NegativeText
        {
            get => negativeText;
            set
            {
                negativeText = value;
                RaisePropertyChanged();
            }
        }


        private string question;
        public string Question
        {
            get => question;
            set
            {
                question = value;
                RaisePropertyChanged();
            }
        }

        public QuestionDialogModel()
        {
            this.SaveCmd = new DelegateCommand(() =>
            {
                DialogHost.Close(IdentifierName, new DialogResult(ButtonResult.OK));
            });

            this.CancelCmd = new DelegateCommand(() =>
            {
                DialogHost.Close(IdentifierName, new DialogResult(ButtonResult.Cancel));

            });
        }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("title");
            PositiveText = parameters.GetValue<string>("positive_text");
            NegativeText = parameters.GetValue<string>("negative_text");
            Question = parameters.GetValue<string>("question");

            return Task.FromResult(true);
        }
    }
}
