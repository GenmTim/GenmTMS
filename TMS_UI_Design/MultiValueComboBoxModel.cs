using System.Collections.Generic;

namespace TMS_UI_Design
{
    public class MultiValueComboBoxModel
    {
        private string oneValue;
        public string OneValue { get => oneValue; set => oneValue = value; }

        private string twoValue;
        public string TwoValue { get => twoValue; set => twoValue = value; }


        private string threeValue;
        public string ThreeValue { get => threeValue; set => threeValue = value; }

        public List<string> OneValueList { get; set; } = new List<string>() { "周一", "周二", "周三", "周四", "周五", "周六", "周日" };

        public List<string> TwoValueList { get; set; } = new List<string>() { "0时", "1时", "2时", "3时", "4时", "5时", "6时", "7时", "8时", "9时", "10时", "11时" };

        public List<string> ThreeValueList { get; set; } = new List<string>() { "0分", "15分", "30分", "45分" };
    }
}
