using System.Collections.ObjectModel;
using TMS.Core.Data;
using TMS.Core.Data.Entity;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class OrganizationalStructrureViewModel
    {
        public ObservableCollection<TreeNodeItem> TreeViewData { get; set; } = new ObservableCollection<TreeNodeItem>();
        public ObservableCollection<User> UserList { get; set; } = new ObservableCollection<User>();



        public OrganizationalStructrureViewModel()
        {
            SimulationData();
            SimulationUserList();
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


            TreeViewData.Add(node1);
            TreeViewData.Add(node2);
            TreeViewData.Add(node3);
        }

    }
}
