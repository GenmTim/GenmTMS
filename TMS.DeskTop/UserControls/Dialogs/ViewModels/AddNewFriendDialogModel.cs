using HandyControl.Controls;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using TMS.Core.Event;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Card.Views;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    class AddNewFriendDialogModel : BindableBase, IDialogHostAware
    {
        public string IdentifierName { get; set; }
        private readonly IContainerExtension container;
        private PopupWindow popupWindow;
        private IEventAggregator eventAggregator;

        public AddNewFriendDialogModel(IContainerExtension container, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator; 
            this.SaveCmd = new DelegateCommand(Searcher);
            this.CancelCmd = new DelegateCommand(Cancel);
            this.container = container;
        }

        public DelegateCommand SaveCmd { get; set; }

        public DelegateCommand CancelCmd { get; set; }

        private string input;
        public string Input
        {
            get => input;
            set
            {
                input = value;
                RaisePropertyChanged();
            }
        }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            return Task.FromResult(true);
        }

        private void Searcher()
        {
            if (SessionService.User.Tel == Input)
            {
                eventAggregator.GetEvent<ToastShowEvent>().Publish("不能添加自己为好友！");
                return;
            }
            if (popupWindow != null)
            {
                popupWindow.Close();
            }
            popupWindow = NameCard.Show(container, Input);
        }

        private void Cancel()
        {
            DialogHost.Close(IdentifierName);
        }
    }
}
