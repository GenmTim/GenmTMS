using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Service
{
    public interface IDialogHostAware
    {
        string IdentifierName { get; set; }

        Task OnDialogOpenedAsync(IDialogParameters parameters);

        DelegateCommand SaveCommand { get; }
        
        DelegateCommand CancelCommand { get; }
    }
}
