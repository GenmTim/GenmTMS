using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels.WorkPlace.SubjectiveData.Subitem
{
    class SubjectiveDataMainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public List<ActivityCardEntity> ActivityCardEntitieList { get; set; } = new List<ActivityCardEntity>()
        {
            new ActivityCardEntity() { },
            new ActivityCardEntity() { },
            new ActivityCardEntity() { },
            new ActivityCardEntity() { },
        };


        private Boolean detailDrawerIsOpen = false;
        public Boolean DetailDrawerIsOpen
        {
            get => detailDrawerIsOpen;
            set
            {
                SetProperty(ref detailDrawerIsOpen, value);
            }
        }

        public SubjectiveDataMainViewModel(IRegionManager regionManager)
        {
            this.ShowDetailCmd = new DelegateCommand(ShowDetail);
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand ShowDetailCmd { get; private set; }

        private void ShowDetail()
        {
            DetailDrawerIsOpen = true;
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private void NavigationPage(string obj)
        {
            RegionHelper.RequestNavigate(regionManager, RegionToken.SubjectiveDataContent, obj);
        }

    }
}
