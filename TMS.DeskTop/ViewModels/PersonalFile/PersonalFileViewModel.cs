using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Common.Views;
using TMS.DeskTop.Views.PersonalFile;

namespace TMS.DeskTop.ViewModels.PersonalFile
{
    public class PersonalFileViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;

        private Boolean detailDrawerIsOpen = false;
        public Boolean DetailDrawerIsOpen 
        {
            get => detailDrawerIsOpen;
            set
            {
                SetProperty(ref detailDrawerIsOpen, value);
            }
        }

        public PersonalFileViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.regionManager = regionManager;
            this.GoBackCmd = new DelegateCommand(GoBack);
            this.ShowDetailCommand = new DelegateCommand(ShowDetail);
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand GoBackCmd { get; private set; }
        private void GoBack()
        {
            eventAggregator.GetEvent<CloseSashEvent>().Publish();
        }

        public DelegateCommand ShowDetailCommand { get; private set; }
        private void ShowDetail()
        {
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.PersonalFileDetailRegion, typeof(CVTemplate));
            DetailDrawerIsOpen = true;
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string view)
        {
            RouteHelper.Goto(regionManager, typeof(PersonalFileView), view);
        }

    }
}
