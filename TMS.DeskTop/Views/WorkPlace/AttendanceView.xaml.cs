using Prism.Regions;
using System;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.Attendance;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// AttendanceView.xaml 的交互逻辑
    /// </summary>
    public partial class AttendanceView : RegionManagerControl, IDisposable
    {
        public AttendanceView(IRegionManager regionManager) : base(regionManager, nameof(AttendanceView))
        {
            InitializeComponent();
            this.regionManager = regionManager;
            RegisterDefaultRegionView(RegionToken.AttendanceContent, nameof(AttendanceMainView));
        }

        public void Dispose()
        {
            this.regionManager.Regions[RegionToken.AttendanceContent].RemoveAll();
        }
    }
}
