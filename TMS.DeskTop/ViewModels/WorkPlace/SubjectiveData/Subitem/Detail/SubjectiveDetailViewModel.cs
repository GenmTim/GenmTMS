using Prism.Commands;
using Prism.Mvvm;
using System;

namespace TMS.DeskTop.ViewModels.WorkPlace.SubjectiveData.Subitem.Detail
{
    class SubjectiveDetailViewModel : BindableBase
    {
        private Boolean detailDrawerIsOpen = false;
        public Boolean DetailDrawerIsOpen
        {
            get => detailDrawerIsOpen;
            set
            {
                SetProperty(ref detailDrawerIsOpen, value);
            }
        }

        public SubjectiveDetailViewModel()
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
