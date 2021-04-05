using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

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
