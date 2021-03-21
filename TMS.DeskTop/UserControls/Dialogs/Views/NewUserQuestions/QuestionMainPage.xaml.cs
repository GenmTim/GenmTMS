
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System.Windows.Controls;

namespace TMS.DeskTop.UserControls.Dialogs.Views.NewUserQuestions
{
    /// <summary>
    /// QuestionMainPage.xaml 的交互逻辑
    /// </summary>
    public partial class QuestionMainPage : UserControl
    {
        IRegionManager regionManager;
        IEventAggregator eventAggregator;
        public QuestionMainPage(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            InitializeComponent();
            this.DataContext = this;
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NextNavigateCmd = new DelegateCommand<string>(GoNext);
        }


        public DelegateCommand<string> NextNavigateCmd { get; set; }

        private void GoNext(string view)
        {
            //if (view.Equals("Next"))
            //    regionManager.RegisterViewWithRegion(RegionToken.QuestionContent, typeof(QuestionEndPage));
            //else
            //{
            //    if (view == "BasicInfo")
            //    {
            //        regionManager.RegisterViewWithRegion(RegionToken.QuestionContent, typeof(BasicInfo.Question1Page));
            //    }
            //    else if (view == "EducationExperience")
            //    {
            //        regionManager.RegisterViewWithRegion(RegionToken.QuestionContent, typeof(EducationExperience.Question1Page));
            //    }
            //    else if (view == "WorkExperience")
            //    {
            //        regionManager.RegisterViewWithRegion(RegionToken.QuestionContent, typeof(WorkExperience.Question1Page));
            //    }
            //}
            //eventAggregator.GetEvent<JumpEvent>().Publish("测试");
        }
    }
}
