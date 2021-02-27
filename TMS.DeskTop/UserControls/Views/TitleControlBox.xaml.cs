using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TMS.DeskTop.UserControls.Views
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
