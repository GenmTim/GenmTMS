using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TMS.DeskTop.UserControls.Common.Views
{
    public class HalfValueConverter : IValueConverter
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

    public class RealHeigthConverter : IValueConverter
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
        private Rectangle rect;
        private Rectangle progressBar;
        private bool isInit = false;
        private bool isInitComponent;
        private RotateTransform rotateTransform;
        private Point progressBarPoint;

        public HalfRoundProgress()
        {

            InitializeComponent();

            this.Loaded += HalfRoundProgress_Loaded;

            //        < Rectangle x: Name = "progressBar"
            //Width = "{Binding ElementName=_halfRoundProgress, Path=Size}"
            //Height = "{Binding ElementName=_halfRoundProgress, Path=Size}"
            //Stroke = "#3370ff"
            //StrokeDashArray = "0, 1000"
            //RadiusX = "{Binding ElementName=_halfRoundProgress, Path=Width, Converter={StaticResource HalfValueConverter}}"
            //RadiusY = "{Binding ElementName=_halfRoundProgress, Path=Width, Converter={StaticResource HalfValueConverter}}"
            //StrokeThickness = "15"
            //StrokeDashCap = "Round" /> -->


            //        < !--< Rectangle x: Name = "chasiss"
            //Width = "{Binding ElementName=_halfRoundProgress, Path=Size}"
            //Height = "{Binding ElementName=_halfRoundProgress, Path=Size}"
            //Stroke = "#eff0f1"
            //StrokeThickness = "15"
            //StrokeDashCap = "Round"
            //RadiusX = "120"
            //RadiusY = "120" />

            // 进行内部高度调整，即 宽度一半 + StrokeThickness的一半
            //chasiss.StrokeDashArray = CalculateProgress(50, chasiss.RadiusX, chasiss.StrokeThickness);
        }

        private void HalfRoundProgress_Loaded(object sender, RoutedEventArgs e)
        {
            Rate = rate;
            Size = size;
            StrokeThickness = strokeThickness;
            ReDraw(isInitCommand: true);
            isInit = true;
        }


        private double size;
        public double Size
        {
            get { return size; }
            set
            {
                size = value;
                UpdateSize();
                ReDraw();
            }
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
                UpdateRate();
                ReDraw();
            }
        }

        private double strokeThickness = 15;
        public double StrokeThickness
        {
            get => strokeThickness;
            set
            {
                strokeThickness = value;
                UpdateStrokeThickness();
                ReDraw();
            }
        }

        private bool isHalf = false;
        public bool IsHalf
        {
            get => isHalf;
            set
            {
                isHalf = value;
                UpdateShape();
            }
        }

        private void UpdateShape()
        {
            InitComponent();
            rotateTransform.Angle = !isHalf ? 90 : 0;
            progressBarPoint = !isHalf ? new Point(0.5, 0.5) : new Point(0, 0);

            progressBar.RenderTransform = rotateTransform;
            progressBar.RenderTransformOrigin = progressBarPoint;
            UpdateSize();
        }

        private void UpdateRate()
        {
            if (progressBar == null)
            {
                InitComponent();
            }
            if (rate == 0)
            {
                progressBar.Visibility = Visibility.Hidden;
            }
            else
            {
                progressBar.Visibility = Visibility.Visible;
                UpdateProgressBarValue();
            }
        }

        private void UpdateSize()
        {
            if (rect == null || progressBar == null)
            {
                InitComponent();
            }

            this.container.Width = Size;
            this.container.Height = isHalf ? Size / 2 + StrokeThickness / 2 : Size;

            rect.Width = size;
            rect.Height = size;
            rect.RadiusX = size / 2;
            rect.RadiusY = size / 2;

            progressBar.Width = size;
            progressBar.Height = size;
            progressBar.RadiusX = size / 2;
            progressBar.RadiusY = size / 2;

            UpdateStrokeDashArray();
        }

        private void UpdateStrokeThickness()
        {
            if (rect == null || progressBar == null)
            {
                InitComponent();
            }

            this.container.Height = isHalf ? Size / 2 + StrokeThickness / 2 : Size;

            rect.StrokeThickness = strokeThickness;

            progressBar.StrokeThickness = strokeThickness;
            UpdateStrokeDashArray();
        }

        /// <summary>
        /// 更新形状，在更新Size和StrokeThickness的时候都需要进行更新
        /// </summary>
        private void UpdateStrokeDashArray()
        {
            UpdateProgressBarValue();
            UpdateRectShape();
        }

        /// <summary>
        /// 更新进度条的进度显示
        /// </summary>
        private void UpdateProgressBarValue()
        {
            progressBar.StrokeDashArray = CalculateProgress(rate, progressBar.RadiusX, progressBar.StrokeThickness);
        }

        /// <summary>
        /// 更新背板的形状
        /// </summary>
        private void UpdateRectShape()
        {
            rect.StrokeDashArray = CalculateProgress(100, rect.RadiusX, strokeThickness);
        }

        /// <summary>
        /// 重新进行绘画，在没有完成初始化数值之前，不会进行操作
        /// </summary>
        /// <param name="isInitCommand"></param>
        private void ReDraw(bool isInitCommand = false)
        {
            if (isInit || isInitCommand)
            {
                canvas.Children.Clear();
                canvas.Children.Add(rect);
                canvas.Children.Add(progressBar);
            }
        }

        private void InitComponent()
        {
            if (isInitComponent) return;

            rect = new Rectangle
            {
                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#eff0f1")),
                StrokeDashCap = PenLineCap.Round,
            };
            progressBar = new Rectangle
            {
                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3370ff")),
                StrokeDashArray = new DoubleCollection(new DoubleCollection() { 0, 1000 }),
                StrokeDashCap = PenLineCap.Round,
            };
            rotateTransform = new RotateTransform();

            isInitComponent = true;
        }

        DoubleCollection CalculateProgress(double pro, double radius, double thickness)
        {
            pro = isHalf ? pro / 2 : pro;
            double r = radius - thickness / 2;
            double p = 2 * Math.PI * r / thickness;
            double step = pro / 100 * p;
            return new DoubleCollection() { step, 10000 };
        }
    }
}
