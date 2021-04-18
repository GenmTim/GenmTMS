using Prism.Events;
using Prism.Regions;
using System.Windows.Controls;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering.Step;

namespace TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering
{
    /// <summary>
    /// EnteringStepView.xaml 的交互逻辑
    /// </summary>
    public partial class EnteringStepView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;

        public EnteringStepView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(EnteringStepView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            RegisterDefaultRegionView(RegionToken.AttendanceEnteringStepContent, nameof(EnteringDataView));
            this.Loaded += Event_Loaded;
            this.Unloaded += Event_Unloaded;
        }

        private void Event_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.eventAggregator.GetEvent<NextStepEvent>().Subscribe(NextStep);
            this.eventAggregator.GetEvent<PrevStepEvent>().Subscribe(LastStep);
            this.eventAggregator.GetEvent<CompleteStepEvent>().Subscribe(CompleteStep);
        }

        private void Event_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.eventAggregator.GetEvent<NextStepEvent>().Unsubscribe(NextStep);
            this.eventAggregator.GetEvent<PrevStepEvent>().Unsubscribe(LastStep);
            this.eventAggregator.GetEvent<CompleteStepEvent>().Subscribe(CompleteStep);
        }

        private void NextStep()
        {
            stepBar.Next();
            JumpToView();

        }

        private void LastStep()
        {
            stepBar.Prev();
            JumpToView();
        }

        private void CompleteStep()
        {
            stepBar.StepIndex = 0;
            eventAggregator.GetEvent<ToastShowEvent>().Publish("考勤数据已经成功录入");
            JumpToView();
        }

        private void JumpToView()
        {
            if (stepBar.StepIndex == 0)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendanceEnteringStepContent, typeof(EnteringDataView));
            }
            else if (stepBar.StepIndex == 1)
            {
                NavigationParameters param = new NavigationParameters();
                if (this.DataContext is EnteringStepViewModel vm)
                {
                    param.Add("entry_file", vm.EntryFileInfo);
                }
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendanceEnteringStepContent, typeof(CheckDataView), param);
            }
            else if (stepBar.StepIndex == 2)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendanceEnteringStepContent, typeof(CompleteEntryDataView));
            }
        }
    }
}
