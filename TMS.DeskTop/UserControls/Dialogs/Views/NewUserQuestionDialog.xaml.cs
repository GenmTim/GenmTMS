using Prism.Events;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TMS.Core.Data;

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
