using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Dialogs.Views;

namespace TMS.DeskTop.UserControls.Common.ViewModels
{
    public class VariableListBoxModel : BindableBase
    {
        private readonly IDialogHostService dialogHost;

        private ObservableCollection<string> tagList = new ObservableCollection<string>();
        public ObservableCollection<string> TagList { get => tagList; set => tagList = value; }

        public VariableListBoxModel(IDialogHostService dialogHost)
        {
            this.dialogHost = dialogHost;
            this.AddUserCmd = new DelegateCommand(async () =>
            {
                var result = await dialogHost.ShowDialog(nameof(SelectUserDialog));
                if (result != null && result.Result == ButtonResult.OK)
                {
                    var dataList = result.Parameters.GetValue<List<string>>("DataList");
                    TagList.Clear();
                    foreach (string name in dataList)
                    {
                        TagList.Add(name);
                    }
                }
            });
        }

        public DelegateCommand AddUserCmd { get; private set; }
    }
}
