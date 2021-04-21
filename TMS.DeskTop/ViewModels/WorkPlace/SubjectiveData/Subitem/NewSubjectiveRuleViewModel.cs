using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using TMS.Core.Data.Enums;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Common.ViewModels;

namespace TMS.DeskTop.ViewModels.WorkPlace.SubjectiveData.Subitem
{
    class NewSubjectiveRuleViewModel : BindableBase
    {
        private readonly IDialogHostService dialogHost;
        private readonly IEventAggregator eventAggregator;

        #region 视图属性
        private ObservableCollection<FieldTypeCheckBoxModel> fieldDataList;
        public ObservableCollection<FieldTypeCheckBoxModel> FieldDataList
        {
            get => fieldDataList;
            set
            {
                SetProperty(ref fieldDataList, value);
            }
        }
        #endregion

        public NewSubjectiveRuleViewModel(IDialogHostService dialogHost, IEventAggregator eventAggregator)
        {
            this.dialogHost = dialogHost;
            this.eventAggregator = eventAggregator;
            this.ExecuteCommand = new DelegateCommand<string>(Execute);


            this.eventAggregator.GetEvent<FieldTypeCheckBoxModel.RemoveSelfEvent>().Subscribe(RemoveOneField);
            this.eventAggregator.GetEvent<FieldTypeCheckBoxModel.AppendNewFieldEvent>().Subscribe(AppendOneField);

            fieldDataList = new ObservableCollection<FieldTypeCheckBoxModel>
            {
                new FieldTypeCheckBoxModel(dialogHost, eventAggregator){ Key="", Type=FieldType.文本 },
            };
        }

        private void AppendOneField(FieldTypeCheckBoxModel data)
        {
            FieldDataList.Insert(FieldDataList.IndexOf(data) + 1, new FieldTypeCheckBoxModel(dialogHost, eventAggregator));
        }

        private void RemoveOneField(FieldTypeCheckBoxModel data)
        {
            if (FieldDataList.Count <= 1) return;

            FieldDataList.Remove(data);
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Save": NavigationPage("SelectUserDialog"); break;
            }
        }

        void NavigationPage(string pageName)
        {
            dialogHost.ShowDialog(pageName);
        }
    }
}
