using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data;
using TMS.Core.Data.Entity;
using TMS.Core.Event.Update;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Dialogs.Views;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class OrganizationalStructrureViewModel : BindableBase
    {
        private ObservableCollection<DeptTreeNodeItemVO> treeViewData;
        public ObservableCollection<DeptTreeNodeItemVO> TreeViewData
        {
            get
            {
                return treeViewData;
            }
            set
            {
                treeViewData = value;
                RaisePropertyChanged();
            }
        }

        private string nowDeptName;
        public string NowDeptName
        {
            get => nowDeptName;
            set
            {
                nowDeptName = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<User> userList;
        public ObservableCollection<User> UserList
        {
            get => userList;
            set
            {
                userList = value;
                RaisePropertyChanged();
            }
        }

        private readonly IDialogHostService dialogHost;
        private readonly IEventAggregator eventAggregator;

        private void GetTreeData(ObservableCollection<DeptTreeNodeItemVO> newTreeViewList, List<TreeDept> treeDeptList)
        {
            foreach (var nodeItem in treeDeptList)
            {
                DeptTreeNodeItemVO newTreeViewNodeItem = new DeptTreeNodeItemVO
                {
                    Name = nodeItem.Name,
                    Id = (long)nodeItem.DeptId,
                };
                if (nodeItem.ChildDepts != null)
                {
                    newTreeViewNodeItem.Children = new ObservableCollection<DeptTreeNodeItemVO>();
                    GetTreeData(newTreeViewNodeItem.Children, nodeItem.ChildDepts);
                }
                newTreeViewList.Add(newTreeViewNodeItem);
            }
        }

        public OrganizationalStructrureViewModel(IDialogHostService dialogHost, IEventAggregator eventAggregator)
        {
            this.dialogHost = dialogHost;
            this.AddNewOrganizationMemberCmd = new DelegateCommand(AddNewOrganizationMember);
            eventAggregator.GetEvent<UpdateCompanyOrganizationEvent>().Subscribe(() =>
            {
                Task.Factory.StartNew(async () =>
                {
                    var result = await HttpService.GetConn().GetCompanyTreeDept(SessionService.Instance.NowCompanyInfo.Id);
                    if (result.StatusCode == 200)
                    {
                        List<TreeDept> treeDeptList = (List<TreeDept>)result.Data;
                        ObservableCollection<DeptTreeNodeItemVO> newTreeViewList = new ObservableCollection<DeptTreeNodeItemVO>();
                        GetTreeData(newTreeViewList, treeDeptList);
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            TreeViewData = newTreeViewList;
                        });
                    }
                });
            });
            eventAggregator.GetEvent<UpdateShowDeptInfo>().Subscribe((dept) =>
            {
                Task.Factory.StartNew(async () =>
                {
                    var result = await HttpService.GetConn().GetDeptUserInfoList(dept.Id);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        NowDeptName = dept.Name;
                        if (result.StatusCode == 200)
                        {
                            List<User> newUserList = (List<User>)result.Data;
                            UserList ??= new ObservableCollection<User>();
                            UserList.Clear();
                            newUserList.ForEach((user) =>
                            {
                                UserList.Add(user);
                            });
                        }
                    });

                });

            });
        }

        public DelegateCommand AddNewOrganizationMemberCmd { get; private set; }

        private void AddNewOrganizationMember()
        {
            dialogHost.ShowDialog(nameof(AddNewOrganizationMemberDialog), null, "ContactRoot");
        }

        private void SimulationUserList()
        {
            UserList.Add(new User
            {
                Name = "蔡承龙",
                Avatar = "/Resources/Images/Assets/image1.jpg"
            });
            UserList.Add(new User
            {
                Name = "金泽权",
                Avatar = "/Resources/Images/Assets/image2.jpg"
            });
            UserList.Add(new User
            {
                Name = "鲁佳栋",
                Avatar = "/Resources/Images/Assets/image3.jpg"
            });
            UserList.Add(new User
            {
                Name = "余浩臻",
                Avatar = "/Resources/Images/Assets/image4.jpg"
            });
            UserList.Add(new User
            {
                Name = "何升鸿",
                Avatar = "/Resources/Images/Assets/image5.jpg"
            });
        }

        private void SimulationData()
        {
            DeptTreeNodeItemVO node1 = new DeptTreeNodeItemVO()
            {
                Name = "研发部"
            };
            DeptTreeNodeItemVO node1tag1 = new DeptTreeNodeItemVO()
            {
                Name = "研发一部"
            };
            node1.Children.Add(node1tag1);

            DeptTreeNodeItemVO node2 = new DeptTreeNodeItemVO()
            {
                Name = "财政部"
            };
            DeptTreeNodeItemVO node2tag1 = new DeptTreeNodeItemVO()
            {
                Name = "财政一部"
            };
            node2.Children.Add(node2tag1);

            DeptTreeNodeItemVO node3 = new DeptTreeNodeItemVO()
            {
                Name = "客服部"
            };
            DeptTreeNodeItemVO node3tag1 = new DeptTreeNodeItemVO()
            {
                Name = "客服一部"
            };
            DeptTreeNodeItemVO node3tag2 = new DeptTreeNodeItemVO()
            {
                Name = "客服二部"
            };
            node3.Children.Add(node3tag1);
            node3.Children.Add(node3tag2);


            TreeViewData.Add(node1);
            TreeViewData.Add(node2);
            TreeViewData.Add(node3);
        }

    }
}
