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
                new ActivityVO { Title="愚人节恶搞评价活动", State="活动进行中", StateColor=(Brush)brushConverter.ConvertFromString("#2db84d"), BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i5.jpg"},
                new ActivityVO { Title="H-AID 特别互动周", State="活动进行中", StateColor= (Brush)brushConverter.ConvertFromString("#2db84d"), BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i1.jpg"},
                new ActivityVO { Title="增值服务特价优惠活动", State="活动已结束", StateColor= (Brush)brushConverter.ConvertFromString("#db3340"), BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i2.jpg"},
                new ActivityVO { Title="云存储容量扩容限时活动", State="活动已结束", StateColor = (Brush)brushConverter.ConvertFromString("#db3340"), BackgroundUri="http://47.101.157.194:8081/static/Illustrated/i3.jpg"},
            };

        }
    }
}
