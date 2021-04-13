using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    class TextBoxDialogModel : BindableBase, IDialogHostAware
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

        private string inputHint;
        public string InputHint
        {
            get => inputHint;
            set
            {
                inputHint = value;
                RaisePropertyChanged();
            }
        }


        private string inputValue;
        public string InputValue
        {
            get => inputValue;
            set
            {
                inputValue = value;
                RaisePropertyChanged();
            }
        }




        public TextBoxDialogModel()
        {
            this.SaveCmd = new DelegateCommand(() =>
            {
                if (string.IsNullOrEmpty(InputValue))
                {
                    DialogHost.Close(IdentifierName);
                }
                else
                {
                    DialogParameters param = new DialogParameters
                    {
                        { "value", InputValue }
                    };

                    DialogHost.Close(IdentifierName, new DialogResult(ButtonResult.OK, param));
                }
            });

            this.CancelCmd = new DelegateCommand(() =>
            {
                DialogHost.Close(IdentifierName);
            });
        }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("title");
            PositiveText = parameters.GetValue<string>("positive_text");
            NegativeText = parameters.GetValue<string>("negative_text");
            InputHint = parameters.GetValue<string>("input_hint");

            return Task.FromResult(true);
        }
    }
}
