using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.UserControls.Dialogs.Views;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData.Subitem.Detail;
using static TMS.DeskTop.ViewModels.WorkPlace.SubjectiveData.Subitem.Detail.SubjectiveDetailViewModel;

namespace TMS.DeskTop.ViewModels.WorkPlace.SubjectiveData.Subitem
{
    public class SubjectiveVO
    {
        public string Title { get; set; }
        public string Date { get; set; }
    }

    class SubjectiveDataMainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;


        private readonly IDialogHostService dialogHostService;
        private readonly IEventAggregator eventAggregator;

        private ObservableCollection<SubjectiveVO> subjectiveVOList;
        public ObservableCollection<SubjectiveVO> SubjectiveVOList
        {
            get => subjectiveVOList;
            set
            {
                subjectiveVOList = value;
                RaisePropertyChanged();
            }
        }

        private Boolean detailDrawerIsOpen = false;
        public Boolean DetailDrawerIsOpen
        {
            get => detailDrawerIsOpen;
            set
            {
                SetProperty(ref detailDrawerIsOpen, value);
            }
        }

        public SubjectiveDataMainViewModel(IRegionManager regionManager, IDialogHostService dialogHostService, IEventAggregator eventAggregator)
        {
            this.ShowDetailCmd = new DelegateCommand(ShowDetail);
            this.regionManager = regionManager;
            this.NavigationCmd = new DelegateCommand<string>(NavigationPage);
            this.dialogHostService = dialogHostService;
            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<CloseSubjectiveDetailPopupEvent>().Subscribe(() => 
            {
                DetailDrawerIsOpen = false;
            });
            SubjectiveVOList = new ObservableCollection<SubjectiveVO>()
            {
                new SubjectiveVO { Title = "公司每周常规评价", Date="6月24号  18 : 00" },
                new SubjectiveVO { Title = "公司项目结项评价", Date="6月28日  18 : 00" },
            };
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
