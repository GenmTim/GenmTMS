using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.PersonalFile.Subitem;

namespace TMS.DeskTop.Views.PersonalFile
{
    /// <summary>
    /// PersonalFileIndexView.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalFileView : RegionManagerControl
    {
        public PersonalFileView(IRegionManager regionManager) : base(regionManager, typeof(PersonalFileView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.PersonalFileContent, nameof(CommonFileView));
        }
    }
}
