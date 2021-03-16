using Prism.Events;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMS.Core.Data;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.ViewModels.Register;
using TMS.DeskTop.Views.Register.Question;

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
