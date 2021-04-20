using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DeskTop.ViewModels.WorkPlace.StaffCare
{
    public class StaffCareVO
    {
        public string Name { get; set; }
        public string Birth { get; set; }
        public string Avatar { get; set; }
    }


    class StaffCareViewModel : BindableBase
    {
        private ObservableCollection<StaffCareVO> staffCareList;
        public ObservableCollection<StaffCareVO> StaffCareList
        {
            get => staffCareList;
            set
            {
                staffCareList = value;
                RaisePropertyChanged();
            }
        }

        public StaffCareViewModel()
        {
            StaffCareList ??= new ObservableCollection<StaffCareVO>()
            {
                new StaffCareVO {  Name="夏晓瑜", Birth="06-14", Avatar="http://47.101.157.194:8081/static/avatar/target5.jpg" },
                new StaffCareVO {  Name="徐长元", Birth="06-23", Avatar="http://47.101.157.194:8081/static/avatar/target6.jpg" },
                new StaffCareVO {  Name="苏明", Birth="06-24", Avatar="http://47.101.157.194:8081/static/avatar/target7.jpg" },
                new StaffCareVO {  Name="李新添", Birth="07-18", Avatar="http://47.101.157.194:8081/static/avatar/target8.jpg" },
                new StaffCareVO {  Name="李欣欣", Birth="08-18", Avatar="http://47.101.157.194:8081/static/avatar/target9.jpg" },
                new StaffCareVO {  Name="蔡承龙", Birth="10-26", Avatar="http://47.101.157.194:8081/static/avatar/target1.jpg" },
            };
        }
    }
}
