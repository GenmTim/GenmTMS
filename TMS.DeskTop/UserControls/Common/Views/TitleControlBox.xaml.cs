using System.Windows;
using System.Windows.Controls;

namespace TMS.DeskTop.UserControls.Common.Views
{
    /// <summary>
    /// TitleControlBox.xaml 的交互逻辑
    /// </summary>
    public partial class TitleControlBox : UserControl
    {
        public TitleControlBox()
        {
            InitializeComponent();
        }



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TitleControlBox));



        public ContentControl RightControl
        {
            get { return (ContentControl)GetValue(RightControlProperty); }
            set { SetValue(RightControlProperty, value); }
        }

        public static readonly DependencyProperty RightControlProperty =
            DependencyProperty.Register("RightControl", typeof(ContentControl), typeof(TitleControlBox));


    }
}
