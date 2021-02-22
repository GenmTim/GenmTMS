using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace TMS.DeskTop.UserControls
{
    public class User
    {
        public String Name { get; set; }
        public String Color { get; set; }

    }

    public class AddTagMenuItem
    {
        public String Name { get; set; }
    }

    /// <summary>
    /// VariableListBox.xaml 的交互逻辑
    /// </summary>
    public partial class VariableListBox : UserControl
    {
        private ObservableCollection<User> userList = new ObservableCollection<User>();
        public ObservableCollection<User> UserList { get => userList; set => userList = value; }

        public VariableListBox()
        {

            InitializeComponent();
            DataContext = this;
            userList.Add(new User
            {
                Name = "蔡承龙",
                Color = "#FF00C4A8"
            });
            userList.Add(new User
            {
                Name = "金泽权",
                Color = "#FF8142E6"
            });
            userList.Add(new User
            {
                Name = "何升鸿",
                Color = "#FF2F68F3"
            });
        }

    }
}
