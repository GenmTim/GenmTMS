using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;

namespace TMS.DeskTop.ViewModels.WorkPlace.Activity
{
    public class ActivityVO
    {
        public string Title { get; set; }
        public string State { get; set; }
        public Brush StateColor { get; set; }
        public string Remark { get; set; }
        public string BackgroundUri { get; set; }
    }


    class ActivityViewModel : BindableBase
    {
        private ObservableCollection<ActivityVO> activityVOList;
        public ObservableCollection<ActivityVO> ActivityVOList
        {
            get => activityVOList;
            set
            {
                activityVOList = value;
                RaisePropertyChanged();
            }
        }

        public ActivityViewModel()
        {
            BrushConverter brushConverter = new BrushConverter();
            ActivityVOList = new ObservableCollection<ActivityVO>()
            { 
                new ActivityVO { Title="愚人节恶搞评价活动", State="活动进行中", StateColor=(Brush)brushConverter.ConvertFromString("#2db84d"), Remark="大家快来告诉别人一个“好消息”吧！", BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i5.jpg"},
                new ActivityVO { Title="H-AID 特别互动周", State="活动进行中", StateColor=(Brush)brushConverter.ConvertFromString("#2db84d"), Remark="全新的互动游戏，赚取大量积分！", BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i1.jpg"},
                new ActivityVO { Title="增值服务特价优惠活动", State="活动已结束", StateColor=(Brush)brushConverter.ConvertFromString("#db3340"), Remark="最低1折起，新用户更有免费体验！", BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i2.jpg"},
                new ActivityVO { Title="云存储容量扩容限时活动", State="活动已结束", StateColor=(Brush)brushConverter.ConvertFromString("#db3340"), Remark="存储容量扩充活动，限时限量，赶紧参加吧！", BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i3.jpg"},
            };

        }
    }
}
