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
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.Attendance;

namespace TMS.DeskTop.Views.WorkPlace
{
    /// <summary>
    /// AttendanceView.xaml 的交互逻辑
    /// </summary>
    public partial class AttendanceView : RegionManagerControl, IDisposable
    {

        public AttendanceView(IRegionManager regionManager) : base(regionManager)
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
