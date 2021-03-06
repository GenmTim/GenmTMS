using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Common;

namespace TMS.Core.Service
{
    public class DialogHostService : DialogService, IDialogHostService
    {
        private readonly IContainerExtension _containerExtension;

        public DialogHostService(IContainerExtension containerExtension) : base(containerExtension)
        {
            this._containerExtension = containerExtension;
        }

        public async Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters = null, string IdentifierName = "Root")
        {
            if (parameters == null)
                parameters = new DialogParameters();

            var content = _containerExtension.Resolve<object>(name);
            if (content is not FrameworkElement dialogContent)
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");

            if (dialogContent is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
                ViewModelLocator.SetAutoWireViewModel(view, true);

            if (dialogContent.DataContext is not IDialogHostAware viewModel)
                throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");

            viewModel.IdentifierName = IdentifierName;

            async void eventHandler(object sender, DialogOpenedEventArgs eventArgs)
            {
                var content = eventArgs.Session.Content;
                eventArgs.Session.UpdateContent(new ProgressDialog());
                if (viewModel is IDialogHostAware aware)
                    await aware.OnDialogOpenedAsync(parameters);
                eventArgs.Session.UpdateContent(content);
            }

            return (IDialogResult)await DialogHost.Show(dialogContent, viewModel.IdentifierName, eventHandler);
        }

    }
}
