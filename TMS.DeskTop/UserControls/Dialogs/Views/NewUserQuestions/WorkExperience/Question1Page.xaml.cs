using Prism.Commands;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data;

namespace TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions.WorkExperience
{
    /// <summary>
    /// Question1Page.xaml 的交互逻辑
    /// </summary>
    public partial class Question1Page : UserControl
    {
        public Question1Page(IRegionManager regionManager)
        {
            InitializeComponent();

            this.NextNavigateCmd = new DelegateCommand(() =>
            {
                regionManager.RequestNavigate(RegionToken.QuestionContent, nameof(Question2Page));
            });
        }

        public DelegateCommand NextNavigateCmd { get; set; }
    }
}
