using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using TMS.Core.Data.Entity;

namespace TMS.DeskTop.ViewModels.WorkPlace.SubjectiveData.Subitem
{
    class SubjectiveDataMainViewModel : BindableBase
    {
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

        public SubjectiveDataMainViewModel()
        {
            this.ShowDetailCmd = new DelegateCommand(ShowDetail);
        }

        public DelegateCommand ShowDetailCmd { get; private set; }

        private void ShowDetail()
        {
            DetailDrawerIsOpen = true;
        }

    }
}
