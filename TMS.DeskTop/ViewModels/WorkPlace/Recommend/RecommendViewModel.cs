using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DeskTop.ViewModels.WorkPlace.Recommend
{
    public class RecommendPeopleVO
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string WorkAge { get; set; }
        public string City { get; set; }
        public string GZNum { get; set; }
        public string Avatar { get; set; }
        public string BackgroundUrl { get; set; }
    }


    public class RecommendViewModel : BindableBase
    {
        private ObservableCollection<RecommendPeopleVO> recommendPeopleVOList;
        public ObservableCollection<RecommendPeopleVO> RecommendPeopleVOList
        {
            get => recommendPeopleVOList;
            set
            {
                recommendPeopleVOList = value;
                RaisePropertyChanged();
            }
        }
        
        public RecommendViewModel()
        {
            RecommendPeopleVOList ??= new ObservableCollection<RecommendPeopleVO>()
            {
                new RecommendPeopleVO { Name="夏晓瑜", Job="原画设计师", WorkAge="3年", City="上海", GZNum="43", Avatar="http://47.101.157.194:8081/static/avatar/target1.jpg", BackgroundUrl="http://47.101.157.194:8081/static/Illustrated/line1.jpg"},
                new RecommendPeopleVO { Name="薛云峰", Job="Golang游戏服务端工程师", WorkAge="5年", City="上海", GZNum="43", Avatar="http://47.101.157.194:8081/static/avatar/target5.jpg", BackgroundUrl="http://47.101.157.194:8081/static/Illustrated/line2.jpg"},
                new RecommendPeopleVO { Name="金泽权", Job="游戏设计师", WorkAge="2年", City="杭州", GZNum="67", Avatar="http://47.101.157.194:8081/static/avatar/target6.jpg", BackgroundUrl="http://47.101.157.194:8081/static/Illustrated/line3.jpg"},
                new RecommendPeopleVO { Name="李新添", Job="3D动画师", WorkAge="1年", City="杭州", GZNum="99", Avatar="http://47.101.157.194:8081/static/avatar/target7.jpg", BackgroundUrl="http://47.101.157.194:8081/static/Illustrated/line4.jpg"},
                new RecommendPeopleVO { Name="黄军达", Job="嵌入式软件工程师", WorkAge="5年", City="北京", GZNum="57", Avatar="http://47.101.157.194:8081/static/avatar/target8.jpg", BackgroundUrl="http://47.101.157.194:8081/static/Illustrated/line5.jpg"},
                new RecommendPeopleVO { Name="曹亦歆", Job="3D动画师", WorkAge="2年", City="北京", GZNum="57", Avatar="http://47.101.157.194:8081/static/avatar/target9.jpg", BackgroundUrl="http://47.101.157.194:8081/static/Illustrated/line6.jpg"},
            };

        }
    }
}
