using System.Windows;
using System.Windows.Controls;

namespace TMS.DeskTop.UserControls.Views
{
    /// <summary>
    /// SettingItemBox.xaml 的交互逻辑
    /// </summary>
    public partial class SettingItemBox : UserControl
    {
        public SettingItemBox()
        {
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SettingItemBox));



    }
}
