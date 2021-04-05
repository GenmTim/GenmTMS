using System.Collections.ObjectModel;
using TMS.Core.Data;
using TMS.Core.Data.VO.CloudFile;

namespace TMS.DeskTop.ViewModels
{
    public class CloudFileViewModel
    {
        public ObservableCollection<TreeNodeItem> TreeViewData { get; set; } = new ObservableCollection<TreeNodeItem>();
        public ObservableCollection<FileItemVO> FileItemList { get; set; } = new ObservableCollection<FileItemVO>();

        public CloudFileViewModel()
        {
            SimulationData();
        }

        private void SimulationData()
        {
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
            node3tag2.Children.Add(new TreeNodeItem()
            {
                Name = "客服子部"
            });
            node3.Children.Add(node3tag1);
            node3.Children.Add(node3tag2);


            TreeViewData.Add(node1);
            TreeViewData.Add(node2);
            TreeViewData.Add(node3);

            FileItemList.Add(new FileItemVO
            {
                Name = "Test.ppt",
                Owner = new Core.Data.Entity.User 
                {
                    Name="蔡承龙"
                },
                FileSize = 12515325,
                LastUpdateTimestamp = 1646634634643
            });

            FileItemList.Add(new FileItemVO
            {
                Name = "VSBS.mp4",
                Owner = new Core.Data.Entity.User
                {
                    Name = "蔡承龙"
                },
                FileSize = 124145,
                LastUpdateTimestamp = 1635255235235
            });

            FileItemList.Add(new FileItemVO
            {
                Name = "AGGW.ppt",
                Owner = new Core.Data.Entity.User
                {
                    Name = "蔡承龙"
                },
                FileSize = 153,
                LastUpdateTimestamp = 1646346646323
            });

            FileItemList.Add(new FileItemVO
            {
                Name = "ASFS.exe",
                Owner = new Core.Data.Entity.User
                {
                    Name = "蔡承龙"
                },
                FileSize = 153,
                LastUpdateTimestamp = 1646346646323
            });


        }
    }
}
