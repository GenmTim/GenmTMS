using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using TMS.Core.Api;
using TMS.Core.Data.Dto;
using TMS.Core.Data.Token;
using TMS.Core.Data.VO.CloudFile;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using TMS.DeskTop.Views.CloudFile;

namespace TMS.DeskTop.ViewModels
{
    public class CloudFileViewModel : BindableBase
    {
        public class UpdateFolderTreeEvent : PubSubEvent { }
        public class UpdateFolderViewEvent : PubSubEvent<FolderTreeNodeItemVO> { }

        private ObservableCollection<FileItemVO> fileItemList;
        public ObservableCollection<FileItemVO> FileItemList
        {
            get => fileItemList;
            set
            {
                fileItemList = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<FolderTreeNodeItemVO> fileTreeNodeItemList;
        public ObservableCollection<FolderTreeNodeItemVO> FileTreeNodeItemList
        {
            get => fileTreeNodeItemList;
            set
            {
                fileTreeNodeItemList = value;
                RaisePropertyChanged();
            }
        }

        private void GetTreeData(ObservableCollection<FolderTreeNodeItemVO> folderTreeList, List<TreeFolder> newTreeFolderList)
        {
            var newTreeFolders = newTreeFolderList.ToArray();


            for (int i = 0; i < newTreeFolders.Length; ++i)
            {
                if (i <= folderTreeList.Count - 1)
                {
                    folderTreeList[i].Id = (long)newTreeFolderList[i].FolderId;
                    folderTreeList[i].Name = newTreeFolderList[i].Name;
                }
                else
                {
                    folderTreeList.Add(new FolderTreeNodeItemVO
                    {
                        Name = newTreeFolders[i].Name,
                        Id = (long)newTreeFolders[i].FolderId,
                    });
                }

                if (newTreeFolderList[i].Childs != null)
                {
                    if (folderTreeList[i].Children == null)
                    {
                        folderTreeList[i].Children = new ObservableCollection<FolderTreeNodeItemVO>();
                    }
                    GetTreeData(folderTreeList[i].Children, newTreeFolderList[i].Childs);
                }
                else
                {
                    if (folderTreeList[i].Children != null)
                    {
                        folderTreeList[i].Children = null;
                    }
                }
            }

            for (int i = folderTreeList.Count - 1; i > newTreeFolders.Length - 1; --i)
            {
                folderTreeList.RemoveAt(i);
            }
        }
        public DelegateCommand<object> AddNewFolderCmd { get; private set; }


        private readonly IEventAggregator eventAggregator;
        private readonly IDialogHostService dialogHost;
        private readonly IRegionManager regionManager;


        public CloudFileViewModel(IRegionManager regionManager, IDialogHostService dialogHost, IEventAggregator eventAggregator)
        {
            SimulationData();
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.dialogHost = dialogHost;
            this.eventAggregator.GetEvent<UpdateFolderTreeEvent>().Subscribe(async () =>
            {
                var result = await HttpService.GetConn().GetMyFileTreeStruct();
                if (result.StatusCode == 200)
                {
                    List<TreeFolder> treeDeptList = (List<TreeFolder>)result.Data;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        if (treeDeptList == null)
                        {
                            FileTreeNodeItemList = null;
                            return;
                        }

                        if (treeDeptList != null && FileTreeNodeItemList == null)
                        {
                            FileTreeNodeItemList = new ObservableCollection<FolderTreeNodeItemVO>();
                        }
                        GetTreeData(FileTreeNodeItemList, treeDeptList);
                    });
                }
            });
            this.eventAggregator.GetEvent<UpdateFolderViewEvent>().Subscribe(UpdateFolderView);
        }

        private void UpdateFolderView(FolderTreeNodeItemVO folder)
        {
            var param = new NavigationParameters();
            param.Add("Context", folder);
            RegionHelper.RequestNavigate(regionManager, RegionToken.CloudFileContent, typeof(CloudFileMainView), param);
        }

        private void SimulationData()
        {

            //DeptTreeNodeItemVO node1 = new DeptTreeNodeItemVO()
            //{
            //    Name = "研发部"
            //};
            //DeptTreeNodeItemVO node1tag1 = new DeptTreeNodeItemVO()
            //{
            //    Name = "研发一部"
            //};
            //node1.Children.Add(node1tag1);

            //DeptTreeNodeItemVO node2 = new DeptTreeNodeItemVO()
            //{
            //    Name = "财政部"
            //};
            //DeptTreeNodeItemVO node2tag1 = new DeptTreeNodeItemVO()
            //{
            //    Name = "财政一部"
            //};
            //node2.Children.Add(node2tag1);

            //DeptTreeNodeItemVO node3 = new DeptTreeNodeItemVO()
            //{
            //    Name = "客服部"
            //};
            //DeptTreeNodeItemVO node3tag1 = new DeptTreeNodeItemVO()
            //{
            //    Name = "客服一部"
            //};
            //DeptTreeNodeItemVO node3tag2 = new DeptTreeNodeItemVO()
            //{
            //    Name = "客服二部"
            //};
            //node3tag2.Children.Add(new DeptTreeNodeItemVO()
            //{
            //    Name = "客服子部"
            //});
            //node3.Children.Add(node3tag1);
            //node3.Children.Add(node3tag2);


            //TreeViewData.Add(node1);
            //TreeViewData.Add(node2);
            //TreeViewData.Add(node3);

            //FileItemList.Add(new FileItemVO
            //{
            //    Name = "Test.ppt",
            //    Owner = new Core.Data.Entity.User 
            //    {
            //        Name="蔡承龙"
            //    },
            //    FileSize = 12515325,
            //    LastUpdateTimestamp = 1646634634643
            //});

            //FileItemList.Add(new FileItemVO
            //{
            //    Name = "VSBS.mp4",
            //    Owner = new Core.Data.Entity.User
            //    {
            //        Name = "蔡承龙"
            //    },
            //    FileSize = 124145,
            //    LastUpdateTimestamp = 1635255235235
            //});

            //FileItemList.Add(new FileItemVO
            //{
            //    Name = "AGGW.ppt",
            //    Owner = new Core.Data.Entity.User
            //    {
            //        Name = "蔡承龙"
            //    },
            //    FileSize = 153,
            //    LastUpdateTimestamp = 1646346646323
            //});

            //FileItemList.Add(new FileItemVO
            //{
            //    Name = "ASFS.exe",
            //    Owner = new Core.Data.Entity.User
            //    {
            //        Name = "蔡承龙"
            //    },
            //    FileSize = 153,
            //    LastUpdateTimestamp = 1646346646323
            //});
        }
    }
}
