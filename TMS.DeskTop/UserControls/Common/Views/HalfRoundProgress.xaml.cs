using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace TMS.DeskTop.UserControls.Common.Views
{
    internal class HalfValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return 0.0f;
            Double oldValue = (Double)value;
            return oldValue / 2;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    /// <summary>
    /// HalfRoundProgress.xaml 的交互逻辑
    /// </summary>
    public partial class HalfRoundProgress : UserControl
    {

        public HalfRoundProgress()
        {

            InitializeComponent();
            // 进行内部高度调整，即 宽度一半 + StrokeThickness的一半
            Double iHeight = Width / 2 + StrokeThickness / 2;
            container.Height = iHeight;
            chasiss.StrokeDashArray = CalculateProgress(50, chasiss.RadiusX, chasiss.StrokeThickness);
        }

        DoubleCollection CalculateProgress(double pro, double radius, double thickness)
        {
            double r = radius - thickness / 2;
            double p = 2 * Math.PI * r / thickness;
            double step = pro / 100 * p;
            return new DoubleCollection() { step, 10000 };
        }

        private Double rate;
        public Double Rate
        {
            get { return rate; }
            set
            {
                value = Math.Max(value, 0);
                value = Math.Min(value, 100);
                rate = value;
                if (rate == 0)
                {
                    progressBar.Visibility = Visibility.Hidden;
                }
                else
                {
                    progressBar.Visibility = Visibility.Visible;
                    progressBar.StrokeDashArray = CalculateProgress(rate / 2, progressBar.RadiusX, progressBar.StrokeThickness);
                }
            }
        }

        public Double StrokeThickness
        {
            get { return (Double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(Double), typeof(HalfRoundProgress), new PropertyMetadata(default(Double)));
    }
}
