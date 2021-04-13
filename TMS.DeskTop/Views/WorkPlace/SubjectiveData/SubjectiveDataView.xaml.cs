using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData.Subitem;

namespace TMS.DeskTop.Views.WorkPlace.SubjectiveData
{
    /// <summary>
    /// SubjectiveDataView.xaml 的交互逻辑
    /// </summary>
    public partial class SubjectiveDataView : RegionManagerControl
    {
        public SubjectiveDataView(IRegionManager reigonManager) : base(reigonManager, typeof(SubjectiveDataView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.SubjectiveDataContent, nameof(SubjectiveDataMainView));
        }
    }
}
