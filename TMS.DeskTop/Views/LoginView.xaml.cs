using Prism.Events;
using Prism.Ioc;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Api;
using TMS.Core.Data.Dto;
using TMS.Core.Event;
using TMS.DeskTop.Cache;
using TMS.DeskTop.Tools.Helper;

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
        }

        private void Logined()
        {
            this.DialogResult = true;
        }
    }
}
