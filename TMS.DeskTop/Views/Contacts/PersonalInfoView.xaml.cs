using Prism.Events;
using Prism.Regions;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.Views.Contacts.Personal;

namespace TMS.DeskTop.Views.Contacts
{
    /// <summary>
    /// PersonalInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalInfoView : RegionManagerControl
    {
        private readonly IEventAggregator eventAggregator;
        public PersonalInfoView(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, typeof(PersonalInfoView))
        {
            InitializeComponent();
            this.eventAggregator = eventAggregator;
            RegisterDefaultRegionView(RegionToken.PersonalInfoContent, nameof(BasicInfoView));
        }

    }
}
