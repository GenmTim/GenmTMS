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
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.AttendanceData.Entering;

namespace TMS.DeskTop.Views.WorkPlace.AttendanceData
{
    /// <summary>
    /// AttendanceDataEnteringView.xaml 的交互逻辑
    /// </summary>
    public partial class AttendanceDataEnteringView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;


        public AttendanceDataEnteringView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(AttendanceDataEnteringView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.AttendaceDataEnteringContent, nameof(EnteringDataView));
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<NextStepEvent>().Subscribe(NextStep);
            this.eventAggregator.GetEvent<PrevStepEvent>().Subscribe(LastStep);
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

        private void JumpToView()
        {
            if (stepBar.StepIndex == 0)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendaceDataEnteringContent ,typeof(EnteringDataView));
            }
            else if (stepBar.StepIndex == 1)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.AttendaceDataEnteringContent, typeof(CheckDataView));
            }
            else if (stepBar.StepIndex == 1)
            {

            }
        }
    }
}
