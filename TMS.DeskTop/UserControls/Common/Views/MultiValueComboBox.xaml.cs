using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TMS.DeskTop.UserControls.Common.Views
{
    public class ContentConverter : IMultiValueConverter
    {
        //源属性传给目标属性时，调用此方法ConvertBack
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentNullException("values can not be null");

            string s = "";
            for (int i = 0; i < values.Length; ++i)
            {
                if (i != 0)
                { 
                    s += " ";
                }
                s += System.Convert.ToString(values[i]);
            }

            return s;
        }

        //目标属性传给源属性时，调用此方法ConvertBack
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// MultiValueComboBox.xaml 的交互逻辑
    /// </summary>
    public partial class MultiValueComboBox : UserControl
    {


        public MultiValueComboBox()
        {
            InitializeComponent();
            //DataContext = new MultiValueComboBoxModel();
        }
    }
}
