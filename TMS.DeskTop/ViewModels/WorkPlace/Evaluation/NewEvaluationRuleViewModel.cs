using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using TMS.Core.Data.Enums;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Common.Views;

namespace TMS.DeskTop.ViewModels.WorkPlace.Evaluation
{


    class NewEvaluationRuleViewModel : BindableBase
    {
        private readonly IDialogHostService dialogHost;
        private readonly IEventAggregator aggregator;

        public NewEvaluationRuleViewModel(IDialogHostService dialogHost, IEventAggregator aggregator)
        {
            this.dialogHost = dialogHost;
            this.aggregator = aggregator;
            this.ExecuteCommand = new DelegateCommand<string>(Execute);
            this.RemoveItemCmd = new DelegateCommand<FieldData>(RemoveItem);
            this.AppendNewFieldItemCmd = new DelegateCommand<FieldData>(AppendNewFieldItem);

            fieldDataList = new ObservableCollection<FieldData>
            {
                new FieldData{Key= "测试", Type=FieldType.文本, RemoveSelfCmd=RemoveItemCmd, AppendNewFieldCmd=AppendNewFieldItemCmd},
                new FieldData{Key= "发布", Type=FieldType.单选, IsMust=true, RemoveSelfCmd=RemoveItemCmd, AppendNewFieldCmd=AppendNewFieldItemCmd},
            };
        }



        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private ObservableCollection<FieldData> fieldDataList;
        public ObservableCollection<FieldData> FieldDataList 
        { 
            get => fieldDataList;
            set
            {
                SetProperty(ref fieldDataList, value);
            }  
        }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Save": NavigationPage("CheckItemDialog"); break;
            }
        }


        void NavigationPage(string pageName)
        {
            dialogHost.ShowDialog(pageName);
        }

        public DelegateCommand<FieldData> RemoveItemCmd { get; private set; }

        private void RemoveItem(FieldData data)
        {
            FieldDataList.Remove(data);
        }

        public DelegateCommand<FieldData> AppendNewFieldItemCmd { get; private set; }

        private void AppendNewFieldItem(FieldData data)
        {
            FieldDataList.Insert(FieldDataList.IndexOf(data), new FieldData { RemoveSelfCmd = RemoveItemCmd, AppendNewFieldCmd = AppendNewFieldItemCmd });
        }
    }
}
