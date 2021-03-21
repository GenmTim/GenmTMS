using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TMS.Core.Data;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    class SelectUserDialogModel : BindableBase, IDialogHostAware
    {

        private ObservableCollection<TreeNodeItem> checkedList;
        public ObservableCollection<TreeNodeItem> CheckedList { get => checkedList; set => checkedList = value; }

        private ObservableCollection<TreeNodeItem> treeNodeList;
        public ObservableCollection<TreeNodeItem> TreeNodeList { get => treeNodeList; set => treeNodeList = value; }
        public string IdentifierName { get; set; } = "Root";

        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public SelectUserDialogModel()
        {
            ShowTreeView();
            checkedList = new ObservableCollection<TreeNodeItem>();
            checkedList.Add(new TreeNodeItem
            {
                Name = "蔡承龙"
            });
            checkedList.Add(new TreeNodeItem
            {
                Name = "金泽权"
            });
            this.SaveCommand = new DelegateCommand(Save);
            this.CancelCommand = new DelegateCommand(Cancel);
        }


        private void Save()
        {
            DialogHost.Close(IdentifierName);
        }

        private void Cancel()
        {
            DialogHost.Close(IdentifierName);
        }

        private void ShowTreeView()
        {
            treeNodeList = new ObservableCollection<TreeNodeItem>();
            TreeNodeItem node1 = new TreeNodeItem()
            {
                Name = "研发部"
            };
            TreeNodeItem node1tag1 = new TreeNodeItem()
            {
                Name = "研发一部"
            };
            node1.Children.Add(node1tag1);

            TreeNodeItem node2 = new TreeNodeItem()
            {
                Name = "财政部"
            };
            TreeNodeItem node2tag1 = new TreeNodeItem()
            {
                Name = "财政一部"
            };
            node2.Children.Add(node2tag1);

            TreeNodeItem node3 = new TreeNodeItem()
            {
                Name = "客服部"
            };
            TreeNodeItem node3tag1 = new TreeNodeItem()
            {
                Name = "客服一部"
            };
            TreeNodeItem node3tag2 = new TreeNodeItem()
            {
                Name = "客服二部"
            };
            node3.Children.Add(node3tag1);
            node3.Children.Add(node3tag2);


            treeNodeList.Add(node1);
            treeNodeList.Add(node2);
            treeNodeList.Add(node3);
        }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            return Task.FromResult(true);
        }
    }
}
