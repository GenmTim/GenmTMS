using Prism.Events;
using System.Windows;
using TMS.Core.Event;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly IEventAggregator eventAggregator;

        public LoginView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<LoginedEvent>().Subscribe(Logined);
            this.eventAggregator.GetEvent<ExitEvent>().Subscribe(Exit);
            this.eventAggregator.GetEvent<ToastShowEvent>().Subscribe(ToastShow, ThreadOption.UIThread);
        }

        private void ToastShow(string message)
        {
            myToast.Show(message);
        }

        private void Logined()
        {
            this.DialogResult = true;
        }

        private void Exit()
        {
            this.Close();
        }
    }
}
