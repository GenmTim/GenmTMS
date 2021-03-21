using System.Windows.Controls;

namespace TMS.DeskTop.UserControls.Common.Views
{
    /// <summary>
    /// MenuRadioButton.xaml 的交互逻辑
    /// </summary>
    public partial class MenuRadioButton : RadioButton
    {
        private string hintText;
        public string HintText { get => hintText; set => hintText = value; }

        private string icon;
        public string Icon { get => icon; set => icon = value; }



        public MenuRadioButton()
        {
            InitializeComponent();
            //DataContext = this.Parent;
            //iconTextBlock.Text = Icon;
            //hitTextBlock.Text = HintText;
            //icon.Source = Source;
        }

    }
}
