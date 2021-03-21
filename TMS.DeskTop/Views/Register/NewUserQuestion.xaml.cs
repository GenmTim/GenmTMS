using Prism.Events;
using Prism.Regions;
using System.Windows;
using System.Windows.Input;
using TMS.Core.Event;

namespace TMS.DeskTop.Views.Register
{
    /// <summary>
    /// Question.xaml 的交互逻辑
    /// </summary>
    public partial class NewUserQuestion : Window
    {
        IRegionManager regionManager;
        IEventAggregator eventAggregator;

        public NewUserQuestion(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            content.Content = new Question.BasicInfo.Question1Page(eventAggregator);
            eventAggregator.GetEvent<JumpEvent>().Subscribe(JumpTo);
        }

        private void NewUserQuestionDialog_Loaded(object sender, RoutedEventArgs e)
        {
            var tmp = this.regionManager;
        }

        private void JumpTo(UIElement uiElement)
        {
            if (uiElement is null)
            {
                DialogResult = true;
            }
            else
            {
                content.Content = uiElement;
            }
        }

        private void Buff_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.panel.Focus();
        }
    }
}
