using Prism.Commands;
using Prism.Regions;
using System.Collections.ObjectModel;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.ViewModels
{
    public class User
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }

    public class ContactsViewModel
    {
        private IRegionManager regionManager;
        private ObservableCollection<User> userList = new ObservableCollection<User>();
        public ObservableCollection<User> UserList { get { return userList; } set { userList = value; } }


        public ContactsViewModel(IRegionManager regionManager)
        {
            initUserList();
            this.regionManager = regionManager;
            this.NavigationCommand = new DelegateCommand<string>(NavigationPage);
        }

        public DelegateCommand<string> NavigationCommand { get; private set; }

        private void NavigationPage(string view)
        {
            if (view != null && !view.Equals(""))
            {
                RegionHelper.RequestNavigate(regionManager, RegionToken.ContactsContent, view);
            }
        }

        public bool ToggleBtnIsChecked { get; set; }

        private void initUserList()
        {
            UserList.Add(new User
            {
                Name = "蔡承龙",
                Icon = "/Resources/Images/Assets/image1.jpg"
            });
            UserList.Add(new User
            {
                Name = "金泽权",
                Icon = "/Resources/Images/Assets/image2.jpg"
            });
            UserList.Add(new User
            {
                Name = "鲁佳栋",
                Icon = "/Resources/Images/Assets/image3.jpg"
            });
            UserList.Add(new User
            {
                Name = "余浩臻",
                Icon = "/Resources/Images/Assets/image4.jpg"
            });
            UserList.Add(new User
            {
                Name = "何升鸿",
                Icon = "/Resources/Images/Assets/image5.jpg"
            });
        }
    }
}
