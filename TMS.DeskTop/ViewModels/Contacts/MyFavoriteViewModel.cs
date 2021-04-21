using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DeskTop.ViewModels.Contacts
{
    public class FavoriteVO
    {
        public string Name { get; set; }
        public string Uri { get; set; }
    }


    class MyFavoriteViewModel : BindableBase
    {
        private ObservableCollection<FavoriteVO> favoriteVOList;

        public ObservableCollection<FavoriteVO> FavoriteVOList
        {
            get => favoriteVOList;
            set
            {
                favoriteVOList = value;
                RaisePropertyChanged();
            }
        }

        public MyFavoriteViewModel()
        {
            FavoriteVOList ??= new ObservableCollection<FavoriteVO>()
            {
                new FavoriteVO { Name="黄军达", Uri="http://47.101.157.194:8081/static/avatar/target9.jpg" },
                new FavoriteVO { Name="金泽权", Uri="http://47.101.157.194:8081/static/avatar/target8.jpg" },
                new FavoriteVO { Name="李新添", Uri="http://47.101.157.194:8081/static/avatar/target7.jpg" },
                new FavoriteVO { Name="张风", Uri="http://47.101.157.194:8081/static/avatar/target7.jpg" },
                new FavoriteVO { Name="夏晓瑜", Uri="http://47.101.157.194:8081/static/avatar/target6.jpg" },
                new FavoriteVO { Name="江益川", Uri="http://47.101.157.194:8081/static/avatar/target5.jpg" },
                new FavoriteVO { Name="柳依依", Uri="http://47.101.157.194:8081/static/avatar/target9.jpg" },
                new FavoriteVO { Name="萧筱默", Uri="http://47.101.157.194:8081/static/avatar/target5.jpg" },
                new FavoriteVO { Name="席应天", Uri="http://47.101.157.194:8081/static/avatar/target7.jpg" },
            };
        }
    }
}
