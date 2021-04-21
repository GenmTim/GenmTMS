using System.Collections.ObjectModel;

namespace TMS.DeskTop.ViewModels.WorkPlace.Recruitment.Requirements.Subitem
{
    public class Talent
    {
        public string Name { get; set; }
        public string Readme { get; set; }
        public string Tag { get; set; }
        public string Position { get; set; }
    }

    class TalentPoolViewModel
    {
        private ObservableCollection<Talent> talentList = new ObservableCollection<Talent>();

        public ObservableCollection<Talent> TalentList { get => talentList; set => talentList = value; }

        public TalentPoolViewModel()
        {
            talentList.Add(new Talent { Name = "周乐", Position = "Golang", Tag = "1年·专科·5-9K", Readme = "乐于学习，敢于挑战，懂得交际" });
            talentList.Add(new Talent { Name = "TomSail", Position = "Golang", Tag = "2年·本科·4-5K", Readme = "善于沟通" });
            talentList.Add(new Talent { Name = "叶旭峰", Position = "Golang", Tag = "2年·本科·面议", Readme = "本人热爱程序网页开发 喜欢接触新事务 新技术 学习过程中遇到问题会先自己解决 实在解决不了再..." });
        }
    }
}
