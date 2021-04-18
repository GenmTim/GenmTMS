using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using TMS.Core.Data.Token;
using TMS.Core.Event;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.PersonalFile;

namespace TMS.DeskTop.ViewModels.Search
{
    public class SearchMainViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        private readonly IRegionManager regionManager;
        private readonly IDialogHostService dialogService;

        private bool isLock = true;
        public bool IsLock
        {
            get => isLock;
            set
            {
                isLock = value;
                RaisePropertyChanged();
            }
        }

        private bool exchanged = false;
        public bool Exchanged
        {
            get => exchanged;
            set
            {
                exchanged = value;
                RaisePropertyChanged();
            }
        }

        private bool isHasSearchResult = false;
        public bool IsHasSearchResult
        {
            get => isHasSearchResult;
            set
            {
                isHasSearchResult = value;
                RaisePropertyChanged();
            }
        }




        public DelegateCommand LookTalentFileCmd { get; private set; }
        public DelegateCommand ExchangeTalentFileCmd { get; private set; }
        public DelegateCommand SearchCmd { get; private set; }

        public SearchMainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IDialogHostService dialogService)
        {
            this.eventAggregator = eventAggregator;
            this.GoAuthCmd = new DelegateCommand(GoAuth);
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            this.LookTalentFileCmd = new DelegateCommand(() =>
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.SearchContent, typeof(PersonalFileView));
            });
            this.ExchangeTalentFileCmd = new DelegateCommand(async () =>
            {
                var result = await DialogHelper.ShowQuestionDialog(dialogService, "SearchViewRoot", "兑换请求", "兑换", "取消", "你将兑换 蔡承龙 的人才档案");
                this.eventAggregator.GetEvent<ToastShowEvent>().Publish("成功兑换 蔡承龙 的人才档案");
                if (result.Result == ButtonResult.OK)
                {
                    Exchanged = true;
                }
            });
            this.SearchCmd = new DelegateCommand(() =>
            {
                IsHasSearchResult = true;
            });
        }

        public DelegateCommand GoAuthCmd { get; set; }

        private async void GoAuth()
        {
            var result = await DialogHelper.ShowQuestionDialog(dialogService, "SearchViewRoot", "授权申请", "发送", "取消", "你将向 蔡承龙 发送授权请求");
            if (result.Result == ButtonResult.OK)
            {
                IsLock = false;
            }
        }
    }
}
