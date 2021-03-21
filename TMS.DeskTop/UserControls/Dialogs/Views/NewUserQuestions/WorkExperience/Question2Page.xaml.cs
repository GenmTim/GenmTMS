using Prism.Commands;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;

namespace TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions.WorkExperience
{
    /// <summary>
    /// Question2Page.xaml 的交互逻辑
    /// </summary>
    public partial class Question2Page : UserControl
    {
        public Question2Page(IRegionManager regionManager)
        {
            InitializeComponent();

            this.NextNavigateCmd = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate(RegionToken.QuestionContent, nameof(QuestionMainPage));
            });
        }

        public DelegateCommand NextNavigateCmd { get; set; }
    }
}
