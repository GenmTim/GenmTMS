using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace TMS.DeskTop.Views.Contacts
{
    /// <summary>
    /// FIconRadioButton.xaml 的交互逻辑
    /// </summary>
    public partial class FIconRadioButton : UserControl
    {
        public FIconRadioButton()
        {
            InitializeComponent();
        }

        public Brush IconColor
        {
            get
            {
                return buttonImage.Foreground;
            }
            set
            {
                buttonImage.Foreground = value;
            }
        }

        public String Icon
        {
            get
            {
                return buttonImage.Text;
            }
            set
            {
                buttonImage.Text = value;
            }
        }

        public string Text
        {
            get
            {
                return Text1.Text;
            }
            set
            {
                Text1.Text = value;
            }
        }
    }
}
