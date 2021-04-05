using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    public class StringItemsDialogModel : BindableBase, IDialogHostAware
    {
        public string IdentifierName { get; set; }

        //public event Action<IDialogResult> RequestClose;

        public StringItemsDialogModel()
        {
            this.AddOneItemCmd = new DelegateCommand<StringBox>(AddOneItem);
            this.RemoveOneItemCmd = new DelegateCommand<StringBox>(RemoveOneItem);
            //this.RemoveOneItemCmd = new DelegateCommand<object>();
        }

        private ObservableCollection<StringBox> stringDataList;
        public ObservableCollection<StringBox> StringDataList
        {
            get => stringDataList;
            set => stringDataList = value;
        }

        public DelegateCommand SaveCmd => new DelegateCommand(() =>
        {
            for (int i = StringDataList.Count - 1; i >= 0; --i)
            {
                var stringBox = StringDataList[i];
                if (stringBox.Value == null || stringBox.Value.Equals(""))
                {
                    StringDataList.Remove(stringBox);
                }
            }

            DialogParameters param = new DialogParameters
            {
                { "StringDataList", StringDataList }
            };

            DialogHost.Close(IdentifierName, new DialogResult(ButtonResult.OK, param));
        });

        public DelegateCommand CancelCmd => new DelegateCommand(() =>
        {
            DialogHost.Close(IdentifierName);
        });

        private void AddOneItem(StringBox val)
        {
            StringDataList.Insert(StringDataList.IndexOf(val) + 1, new StringBox());
        }

        private void RemoveOneItem(StringBox val)
        {
            StringDataList.Remove(val);
        }

        public DelegateCommand<StringBox> AddOneItemCmd { get; private set; }

        public DelegateCommand<StringBox> RemoveOneItemCmd { get; private set; }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            var oldDataList = parameters.GetValue<ObservableCollection<StringBox>>("StringDataList");
            stringDataList = new ObservableCollection<StringBox>();
            foreach (var value in oldDataList)
            {
                stringDataList.Add(value);
            }
            return Task.FromResult(true);
        }
    }
}
