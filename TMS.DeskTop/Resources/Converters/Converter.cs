using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TMS.DeskTop.Tools.Helper;

namespace TMS.DeskTop.Resources.Converters
{
    class LinearGradientConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            Color color = (Color)ColorConverter.ConvertFromString((string)value); ;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = new System.Windows.Point(0, 0.5);
            linearGradientBrush.EndPoint = new System.Windows.Point(8, 0.5);
            linearGradientBrush.GradientStops.Add(new GradientStop(color, 0));
            linearGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 1));
            return linearGradientBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class FetchFirstCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            String str = (String)value;
            return str.Length > 0 ? str.Substring(0, 1) : "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class String2UriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            String str = (String)value;
            return new Uri(str);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Uri uri = (Uri)value;
            return uri.ToString();
        }
    }

    class String2FileType : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            String aFile = (String)value;
            string aLastName = aFile.Substring(aFile.LastIndexOf(".") + 1, (aFile.Length - aFile.LastIndexOf(".") - 1));
            return aLastName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class FileSize2String : IValueConverter
    {
        private const Decimal OneKiloByte = 1024M;
        private const Decimal OneMegaByte = OneKiloByte * 1024M;
        private const Decimal OneGigaByte = OneMegaByte * 1024M;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            long fileSize = (long)value;

            Decimal size;
            string suffix;

            size = System.Convert.ToDecimal(fileSize);
            if (size > OneGigaByte)
            {
                size /= OneGigaByte;
                suffix = "GB";
            }
            else if (size > OneMegaByte)
            {
                size /= OneMegaByte;
                suffix = "MB";
            }
            else if (size > OneKiloByte)
            {
                size /= OneKiloByte;
                suffix = "KB";
            }
            else
            {
                suffix = "B";
            }
            return size.ToString("#0.0") + " " + suffix;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class String2FileTypeIconPath : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            String aFile = (String)value;
            string fileTypeName = aFile.Substring(aFile.LastIndexOf(".") + 1, (aFile.Length - aFile.LastIndexOf(".") - 1));
            string basePath = "pack://application:,,,/Resources/Images/Icon/FileType/";
            string path = basePath;

            switch (fileTypeName)
            {
                case "ppt":
                case "PPT":
                case "pptx":
                    path += "PPT.png";
                    break;
                case "exe":
                    path += "Exe.png";
                    break;
                case "doc":
                case "docx":
                    path += "Word.png";
                    break;
                case "pdf":
                    path += "PDF.png";
                    break;
                default:
                    path += "Other.png";
                    break;
            }
            return new BitmapImage(new Uri(path));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class String2FileName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            String aFile = (String)value;
            string aFirstName = aFile.Substring(aFile.LastIndexOf("\\") + 1, (aFile.LastIndexOf(".") - aFile.LastIndexOf("\\") - 1));
            return aFirstName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class Timestamp2String : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return "";
            long timestamp = (long)value;
            return TimeHelper.ToDateTime(timestamp).ToString("yyyy-MM-dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    //public class String2UriConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value is null) return "";
    //        string str = (string)value;

    //        return new Uri(str);
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class Number2PercentageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 2) return .0;

            var obj1 = values[0];
            var obj2 = values[1];

            if (obj1 == null || obj2 == null) return .0;

            var str1 = values[0].ToString();
            var str2 = values[1].ToString();

            var v1 = double.Parse(str1);
            var v2 = double.Parse(str2);

            if (Math.Abs(v2) < 1E-06) return 100.0;

            return Math.Round(v1 / v2 * 100, 0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
