using System.Windows;
using System.Windows.Controls;

namespace Genm.Controls
{
    public class TitleControlBox : ContentControl
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TitleControlBox));
    }
}
