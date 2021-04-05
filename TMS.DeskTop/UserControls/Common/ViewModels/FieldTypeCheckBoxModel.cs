using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;
using TMS.Core.Data.Enums;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Dialogs.Views;

namespace TMS.DeskTop.UserControls.Common.ViewModels
{
    public class FieldTypeCheckBoxModel : BindableBase
    {
        /// <summary>
        /// 声明相关事件
        /// </summary>
        public class RemoveSelfEvent : PubSubEvent<FieldTypeCheckBoxModel> { }
        public class AppendNewFieldEvent : PubSubEvent<FieldTypeCheckBoxModel> { }

        private readonly IEventAggregator eventAggregator;
        private readonly IDialogHostService dialogHost;

        #region 显示属性
        private string key;
        public string Key { get => key; set { SetProperty(ref key, value); } }

        private FieldType type = FieldType.文本;
        public FieldType Type { get => type; set { SetProperty(ref type, value); } }

        private bool isMust = false;
        public bool IsMust { get => isMust; set { SetProperty(ref isMust, value); } }


        private ObservableCollection<StringBox> tabDataList = new ObservableCollection<StringBox>() { new StringBox { Value = "测试" }, new StringBox { Value = "再测试" } };
        public ObservableCollection<StringBox> TabDataList
        {
            get => tabDataList;
            set
            {
                SetProperty(ref tabDataList, value);
            }
        }

        #endregion

        public FieldTypeCheckBoxModel(IDialogHostService dialogHostService, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.dialogHost = dialogHostService;
            RemoveSelfCmd = new DelegateCommand(() => this.eventAggregator.GetEvent<RemoveSelfEvent>().Publish(this));
            AppendNewFieldCmd = new DelegateCommand(() => this.eventAggregator.GetEvent<AppendNewFieldEvent>().Publish(this));
            this.AddNewTabsCmd = new DelegateCommand(async () => { await AddNewTabsAsync(); });
        }

        public DelegateCommand RemoveSelfCmd { get; private set; }
        public DelegateCommand AppendNewFieldCmd { get; private set; }
        public DelegateCommand AddNewTabsCmd { get; private set; }

        private async Task AddNewTabsAsync()
        {
            var param = new DialogParameters
            {
                { "StringDataList", TabDataList }
            };
            var result = await dialogHost.ShowDialog(nameof(StringItemsDialog), param);
            if (result != null && result.Result == ButtonResult.OK)
            {
                var dataList = result.Parameters.GetValue<ObservableCollection<StringBox>>("StringDataList");
                TabDataList = dataList;
            }
        }
    }
}
