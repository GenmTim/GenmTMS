using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Dialogs.Views;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData.Subitem.Detail;

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

        private readonly IDialogHostService dialogHostService;

        private Boolean detailDrawerIsOpen = false;
        public Boolean DetailDrawerIsOpen
        {
            get => detailDrawerIsOpen;
            set
            {
                SetProperty(ref detailDrawerIsOpen, value);
            }
        }

        public SubjectiveDataMainViewModel(IRegionManager regionManager, IDialogHostService dialogHostService)
        {
            this.ShowDetailCmd = new DelegateCommand(ShowDetail);
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            this.dialogHostService = dialogHostService;
        }

        public DelegateCommand ShowDetailCmd { get; private set; }

        private void ShowDetail()
        {
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.SubjectiveDetailContent, typeof(SubjectiveDetailView));
            DetailDrawerIsOpen = true;
        }

        public DelegateCommand<string> NavigationCmd { get; private set; }

        private async void NavigationPage(string obj)
        {
            var result = await dialogHostService.ShowDialog(nameof(CreateSubjectiveTemplateDialog), null, "SubjectiveRoot");
            if (result != null && result.Result == ButtonResult.OK)
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.SubjectiveDataContent, obj);
            }
        }

    }
}
