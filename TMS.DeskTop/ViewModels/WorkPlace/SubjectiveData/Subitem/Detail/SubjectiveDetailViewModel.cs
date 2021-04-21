using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Token;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.WorkPlace.SubjectiveData.Subitem.Detail;

namespace TMS.DeskTop.ViewModels.WorkPlace.SubjectiveData.Subitem.Detail
{
    class SubjectiveDetailViewModel : BindableBase
    {
        public class CloseSubjectiveDetailPopupEvent : PubSubEvent { }

        public List<ActivityCardEntity> ActivityCardEntitieList { get; set; } = new List<ActivityCardEntity>()
        {
            new ActivityCardEntity() {Name="江益川",DateTime="                               35分钟前",Content="添加评价：有他带着我们，就没有解决不了\n的难题"},
            new ActivityCardEntity() {Name="蔡承龙",DateTime="                                  6小时前",Content="添加评价：平时工作很认真"},
            new ActivityCardEntity() {Name="蔡承龙",DateTime="                                  6小时前",Content="审核通过"},
            new ActivityCardEntity() {Name="金泽权",DateTime="                                    1天前",Content="发起评价审核"}
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

        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        public SubjectiveDetailViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.ShowDetailCmd = new DelegateCommand(ShowDetail);
            this.regionManager = regionManager;
            this.JumpCmd = new DelegateCommand(Jump);
            this.eventAggregator = eventAggregator;
            this.ClosePopupCmd = new DelegateCommand(ClosePopup);
        }

        public DelegateCommand ShowDetailCmd { get; private set; }
        public DelegateCommand JumpCmd { get; private set; }
        public DelegateCommand ClosePopupCmd { get; private set; }

        private void ShowDetail()
        {
            DetailDrawerIsOpen = true;
        }

        private void ClosePopup()
        {
            this.eventAggregator.GetEvent<CloseSubjectiveDetailPopupEvent>().Publish();
        }

        private void Jump()
        {
            RegionHelper.RegisterViewWithRegion(regionManager, RegionToken.SubjectiveDetailContent, typeof(SubjectiveDetailView));
        }
        

    }
}
