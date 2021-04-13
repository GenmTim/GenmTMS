using Prism.Commands;
using Prism.Services.Dialogs;
using System.Threading.Tasks;

namespace TMS.Core.Service
{
    public interface IDialogHostAware
    {
        string IdentifierName { get; set; }

        Task OnDialogOpenedAsync(IDialogParameters parameters);

        //event Action<IDialogResult> RequestClose;

        DelegateCommand SaveCmd { get; }

        DelegateCommand CancelCmd { get; }
    }
}
