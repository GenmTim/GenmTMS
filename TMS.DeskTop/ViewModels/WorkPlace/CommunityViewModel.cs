using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DeskTop.ViewModels.WorkPlace
{
    public class CommunityVO
    {
        public string Avatar { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Classify { get; set; }
        public string Tab { get; set; }
        public string Content { get; set; }
        public string BackgroundUri { get; set; }
    }


    class CommunityViewModel : BindableBase
    {
        private ObservableCollection<CommunityVO> communityVOList;

        public ObservableCollection<CommunityVO> CommunityVOList 
        { 
            get => communityVOList;
            set
            { 
                communityVOList = value;
                RaisePropertyChanged();
            }
        }

        public CommunityViewModel()
        {
            CommunityVOList ??= new ObservableCollection<CommunityVO>()
            {
                new CommunityVO { Avatar="http://47.101.157.194:8081/static/avatar/target6.jpg", Name="李立清", Time="2 天前", Classify="天禅集团", Tab="鸽子", Content="无论是运营、产品经理还是许多相关岗位中，用户访谈和调查都是后期提高工作效率、更好地完成项目的基础和保证。而看似简单直白的设计问卷的过程，其实涉及到很多实用技巧和工作思路。那么，新手小白如何做出一份高质量的问卷和访谈设计？北京大学研究生Yinhe C. 同学就分享了自己在知乎做用户运营时的关于设计问卷的一些收获和感悟，快来看看能不能帮到你", BackgroundUri="http://47.101.157.194:8081/static/background/i2.jpg" },
                new CommunityVO { Avatar="http://47.101.157.194:8081/static/avatar/target7.jpg", Name="李立清", Time="2 天前", Classify="天禅集团", Tab="鸽子", Content="无论是运营、产品经理还是许多相关岗位中，用户访谈和调查都是后期提高工作效率、更好地完成项目的基础和保证。而看似简单直白的设计问卷的过程，其实涉及到很多实用技巧和工作思路。那么，新手小白如何做出一份高质量的问卷和访谈设计？北京大学研究生Yinhe C. 同学就分享了自己在知乎做用户运营时的关于设计问卷的一些收获和感悟，快来看看能不能帮到你", BackgroundUri="http://47.101.157.194:8081/static/background/i1.jpg" },
            };
        }

        public DelegateCommand OpenDetailCmd;
        

    }
}
