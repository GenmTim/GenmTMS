using System.Windows;
using System.Windows.Controls;

namespace Genm.Controls
{
    public class DataDialog : ContentControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DataDialog), new PropertyMetadata(default(string)));



        public string PositiveText
        {
            get { return (string)GetValue(PositiveTextProperty); }
            set { SetValue(PositiveTextProperty, value); }
        }

        public static readonly DependencyProperty PositiveTextProperty =
            DependencyProperty.Register("PositiveText", typeof(string), typeof(DataDialog), new PropertyMetadata(default(string)));


        public string NegativeText
        {
            get { return (string)GetValue(NegativeTextProperty); }
            set { SetValue(NegativeTextProperty, value); }
        }

        public static readonly DependencyProperty NegativeTextProperty =
            DependencyProperty.Register("NegativeText", typeof(string), typeof(DataDialog), new PropertyMetadata(default(string)));



        public DataDialog()
        {

        }
    }
}
