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
                new CommunityVO { Avatar="http://47.101.157.194:8081/static/avatar/target6.jpg", Name="李立清", Time="15分钟前", Classify="天禅集团", Tab="#求职",
                    Content="找工作时,请牢记这十条,带你看透这场面试值不值得去:1.工资6-8k,实际上工资也就是3-4k。2.工资上不封顶,意味着底薪不高,主要得靠提成。3.工资面议,代表工资非常低,说不出口,说出来怕你不去面试。4.扁平化管理,代表着公司不超过10人。5.公司提供住宿,代表公司地理位置极其偏僻。6.公司氛围好,年轻化,说明你的同事都是刚毕业的大学生。7.要去抗压能力强,说明钱少事多责任重,说不定还有扣钱机制。8.前景好,发展空间大,九成是个小型创业公司。9.弹性工作制,弹得只是你的下班时间,上班你还是得准点来,且没有加班费。10.公司有期权奖励,你就是合伙人,关键是……你确定公司能上市?", BackgroundUri="http://47.101.157.194:8081/static/background/i2.jpg" },
                new CommunityVO { Avatar="http://47.101.157.194:8081/static/avatar/target7.jpg", Name="萧筱默", Time="1小时前", Classify="金源智胜", Tab="#Tisp", 
                    Content="应届生找工作常犯的七个错误!误区一:轻视求职准备。都觉得找工作是一件很重要的事情，但几乎没有人给予对等的准备;误区二:追捧高级感。什么高级投什么,什么热门选什么。只要岗位够热门,我就能觉得自己是合适的;误区三:不想浪费了自己的专业。好的决策应该尽力排除沉没成本的干扰;误区四:对岗位有想当然的刻板认知,粗浅片面甚至错到离谱;误区五:盲从经验主义,不深入本质,不体察变化;误区六:我还没有准备好，机会确实是留给有准备的人的,但不是留着等你准备的;误区七:过分理想化，有一个高一点的理想和目标肯定不是错误,但要充分预估困难和挑战,问问自己在理想范围内的底线是什么,及时启动 plan B 。", BackgroundUri="http://47.101.157.194:8081/static/background/i1.jpg" },
            };
        }

        public DelegateCommand OpenDetailCmd;
        

    }
}
