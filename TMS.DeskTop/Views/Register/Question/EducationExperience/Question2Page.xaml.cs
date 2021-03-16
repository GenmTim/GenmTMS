using Prism.Commands;
using Prism.Events;
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

namespace TMS.DeskTop.Views.Register.Question.EducationExperience
{
    /// <summary>
    /// Question2Page.xaml 的交互逻辑
    /// </summary>
    public partial class Question2Page : UserControl
    {
        private readonly IEventAggregator eventAggregator;
        public Question2Page(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.DataContext = this;
            this.eventAggregator = eventAggregator;
            this.NextNavigateCmd = new DelegateCommand(GoNext);
            this.BackCmd = new DelegateCommand(GoBack);
        }

        public DelegateCommand NextNavigateCmd { get; set; }

        private void GoNext()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(new QuestionMainPage(eventAggregator));
        }

        public DelegateCommand BackCmd { get; private set; }

        private void GoBack()
        {
            eventAggregator.GetEvent<JumpEvent>().Publish(new Question1Page(eventAggregator));
        }
    }
}
