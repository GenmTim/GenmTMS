using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using TMS.Core.Event;

namespace TMS.DeskTop.ViewModels
{
    public class BaseDialogViewModel : BindableBase
    {
        protected readonly IEventAggregator eventAggregator;

        public BaseDialogViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            ExitCommand = new DelegateCommand(Exit);
        }

        public DelegateCommand ExitCommand { get; private set; }

        /// <summary>
        /// 传递True代表需要确认用户是否关闭,你可以选择传递false强制关闭
        /// </summary>
        public virtual void Exit()
        {
            eventAggregator.GetEvent<ExitEvent>().Publish();
        }

        private bool isOpen;

        /// <summary>
        /// 窗口是否显示
        /// </summary>
        public bool DialogIsOpen
        {
            get { return isOpen; }
            set { isOpen = value; RaisePropertyChanged(); }
        }
    }
}
