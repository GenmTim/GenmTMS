using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.VO;

namespace TMS.DeskTop.ViewModels.Contacts.Group
{
    class IJoinedViewModel : BindableBase
    {
        private ObservableCollection<GroupVO> groupList;

        public ObservableCollection<GroupVO> GroupList 
        { 
            get => groupList;
            set
            {
                groupList = value;
                RaisePropertyChanged();
            }
        }

        public IJoinedViewModel()
        {
            this.GroupList ??= new ObservableCollection<GroupVO>()
            {
                new GroupVO { Name="快存项目组", Number="23", Uri="http://47.101.157.194:8081/static/group_icon/1.jpg" },
                new GroupVO { Name="技术总群", Number="52", Uri="http://47.101.157.194:8081/static/group_icon/2.jpg" },
                new GroupVO { Name="Golang", Number="135", Uri="http://47.101.157.194:8081/static/group_icon/3.jpg" },
                new GroupVO { Name="HR交流群", Number="2350", Uri="http://47.101.157.194:8081/static/group_icon/4.jpg" },
                new GroupVO { Name="后勤组", Number="35", Uri="http://47.101.157.194:8081/static/group_icon/5.jpg" },
                new GroupVO { Name="没有BUG小组", Number="66", Uri="http://47.101.157.194:8081/static/group_icon/6.jpg" },
            };
        }
    }
}
