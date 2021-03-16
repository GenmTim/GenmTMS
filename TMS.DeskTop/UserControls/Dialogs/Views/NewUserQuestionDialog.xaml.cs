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
using TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions;

namespace TMS.DeskTop.UserControls.Dialogs.Views
{
    /// <summary>
    /// Question.xaml 的交互逻辑
    /// </summary>
    public partial class NewUserQuestionDialog : UserControl
    {
        private readonly IRegionManager regionManager;

        public NewUserQuestionDialog(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            //RegisterDefaultRegionView(RegionToken.QuestionContent, nameof(Question.BasicInfo.Question1Page));
            this.regionManager = regionManager;
            //eventAggregator.GetEvent<JumpEvent>().Subscribe(CompleteInfoEntry);
            //regionManager.RegisterViewWithRegion(RegionToken.QuestionContent, typeof(QuestionMainPage));
            this.Loaded += NewUserQuestionDialog_Loaded;
        }

        private void CompleteInfoEntry(string str)
        {
            regionManager.RegisterViewWithRegion(RegionToken.QuestionContent, typeof(NewUserQuestions.BasicInfo.Question1Page));
        }

        private void NewUserQuestionDialog_Loaded(object sender, RoutedEventArgs e)
        {
            //regionManager.RequestNavigate(RegionToken.QuestionContent, "Question1Page");
            regionManager.RequestNavigate(RegionToken.QuestionContent, "QuestionMainPage");
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.panel.Focus();
        }
    }
}
