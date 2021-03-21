using System.Windows.Controls;
using System.Windows.Media;

namespace FileManagerUI
{
    /// <summary>
    /// Interaction logic for mediumSizeButtons.xaml
    /// </summary>
    public partial class mediumSizeButtons : UserControl
    {
        public mediumSizeButtons()
        {
            InitializeComponent();
        }
        public ImageSource imageSource
        {
            get
            {
                return buttonImage.Source;
            }
            set
            {
                buttonImage.Source = value;
            }
        }
        public string text1
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
        public string text2
        {
            get
            {
                return Text2.Text;
            }
            set
            {
                Text2.Text = value;
            }
        }
    }
}
