using Genm.Controls;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TMS.Core.Service;

namespace TMS.DeskTop.UserControls.Dialogs.ViewModels
{
    public class Item
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }


    class SelectUserDialogModel : BindableBase, IDialogHostAware
    {
        public string IdentifierName { get; set; }

        public class TreeNodeItem : CheckTreeView { }


        private ObservableCollection<Item> checkedList = new ObservableCollection<Item>();
        public ObservableCollection<Item> CheckedList { get => checkedList; set => checkedList = value; }

        private ObservableCollection<TreeNodeItem> treeNodeList;
        public ObservableCollection<TreeNodeItem> TreeNodeList { get => treeNodeList; set => treeNodeList = value; }

        public DelegateCommand SaveCmd { get; private set; }
        public DelegateCommand CancelCmd { get; private set; }

        public SelectUserDialogModel()
        {
            ShowTreeView();

            this.SaveCmd = new DelegateCommand(Save);
            this.CancelCmd = new DelegateCommand(Cancel);
        }


        private void Save()
        {
            List<string> data = new List<string>();
            foreach (var item in CheckedList)
            {
                data.Add(item.Name);
            }
            var param = new DialogParameters
            {
                { "DataList", data },
            };
            DialogHost.Close(IdentifierName, new DialogResult(ButtonResult.OK, param));
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
                ContentData = new Item { Name = "研发部", Type = "部门" },
                StateChange = StateChange
            };
            node1.Add(new TreeNodeItem()
            {
                ContentData = new Item { Name = "蔡承龙", Type = "员工" },
                StateChange = StateChange
            });
            TreeNodeItem node1tag1 = new TreeNodeItem()
            {
                ContentData = new Item { Name = "研发一部", Type = "部门" },
                StateChange = StateChange
            };
            node1.Add(node1tag1);

            TreeNodeItem node2 = new TreeNodeItem()
            {
                ContentData = new Item { Name = "财政部", Type = "部门" },
                StateChange = StateChange
            };
            TreeNodeItem node2tag1 = new TreeNodeItem()
            {
                ContentData = new Item { Name = "财政一部", Type = "部门" },
                StateChange = StateChange
            };
            node2.Add(node2tag1);

            TreeNodeItem node3 = new TreeNodeItem()
            {
                ContentData = new Item { Name = "客服部", Type = "部门" },
                StateChange = StateChange
            };
            TreeNodeItem node3tag1 = new TreeNodeItem()
            {
                ContentData = new Item { Name = "客服一部", Type = "部门" },
                StateChange = StateChange
            };
            TreeNodeItem node3tag2 = new TreeNodeItem()
            {
                ContentData = new Item { Name = "客服二部", Type = "部门" },
                StateChange = StateChange
            };
            node3.Add(node3tag1);
            node3.Add(node3tag2);
            node3.Add(new TreeNodeItem()
            {
                ContentData = new Item { Name = "蔡承龙", Type = "员工" },
                StateChange = StateChange
            });

            treeNodeList.Add(node1);
            treeNodeList.Add(node2);
            treeNodeList.Add(node3);
        }

        private void StateChange(CheckTreeView node)
        {
            var data = node.ContentData as Item;
            if (node.IsChecked != null && (bool)node.IsChecked)
            {
                if (data.Type.Equals("员工"))
                {
                    CheckedList.Add(data);
                }
            }
            else
            {
                CheckedList.Remove(data);
            }
        }

        public Task OnDialogOpenedAsync(IDialogParameters parameters)
        {
            return Task.FromResult(true);
        }
    }
}
