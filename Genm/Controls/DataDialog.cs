using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Genm.Controls
{
    public class DataDialog : ContentControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DataDialog), new PropertyMetadata(default(string)));



        public string PositiveText
        {
            get { return (string)GetValue(PositiveTextProperty); }
            set { SetValue(PositiveTextProperty, value); }
        }

        public static readonly DependencyProperty PositiveTextProperty =
            DependencyProperty.Register("PositiveText", typeof(string), typeof(DataDialog), new PropertyMetadata(default(string)));



        public ICommand PositiveCmd
        {
            get { return (ICommand)GetValue(PositiveCmdProperty); }
            set { SetValue(PositiveCmdProperty, value); }
        }

        public static readonly DependencyProperty PositiveCmdProperty =
            DependencyProperty.Register("PositiveCmd", typeof(ICommand), typeof(DataDialog));


        public ICommand NegativeCmd
        {
            get { return (ICommand)GetValue(NegativeCmdProperty); }
            set { SetValue(NegativeCmdProperty, value); }
        }

        public static readonly DependencyProperty NegativeCmdProperty =
            DependencyProperty.Register("NegativeCmd", typeof(ICommand), typeof(DataDialog));




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
