using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TMS_UI_Design
{
    public class UploadFileItem : BindableBase
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        private double rate;
        public double Rate
        {
            get => rate;
            set
            {
                rate = value;
                RaisePropertyChanged();
            }
        }
    }

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

    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            this.UploadFileCmd = new DelegateCommand<UploadFileItem>(UploadFile);
        }

        #region Property
        private int uploadFileItemNumber;
        public int UploadFileItemNumber
        {
            get => uploadFileItemNumber;
            set
            {
                uploadFileItemNumber = value;
                RaisePropertyChanged();
            }
        }


        private long uploadFileSumSize;
        public long UploadFileSumSize
        {
            get => uploadFileSumSize;
            set
            {
                uploadFileSumSize = value;
                RaisePropertyChanged();
            }
        }

        private long uploadedFileSumSize;
        public long UploadedFileSumSize
        {
            get => uploadedFileSumSize;
            set
            {
                uploadedFileSumSize = value;
                RaisePropertyChanged();
            }
        }



        private ObservableCollection<UploadFileItem> uploadFileItemList;
        public ObservableCollection<UploadFileItem> UploadFileItemList
        {
            get => uploadFileItemList;
            set
            {
                uploadFileItemList = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand<UploadFileItem> UploadFileCmd { get; private set; }
        #endregion

        private void UploadFile(UploadFileItem fileItem)
        {
            // 开始上传准备
            FileInfo info = new FileInfo(fileItem.FullName);

            long fileSize = info.Length;

            fileItem.Size = fileSize;
            fileItem.Name = info.Name;
            // 添加至上传项到列表
            UploadFileItemList ??= new ObservableCollection<UploadFileItem>();
            UploadFileItemList.Add(fileItem);
            UploadFileSumSize += fileItem.Size;
            UploadFileItemNumber += 1;


            Task.Run(() =>
            {
                FileStream fs = File.OpenRead(fileItem.FullName);
                long readedSize = 0;
                byte[] buffer = new byte[1024 * 1024];
                while (readedSize < fileSize)
                {
                    int readSize = fs.Read(buffer, 0, buffer.Length);
                    readedSize += readSize;

                    // 发送到服务端


                    // 计算上传比例，传递到UI上
                    long nowRate = readedSize * 100 / fileSize;
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        UploadedFileSumSize += readSize;
                        foreach (var item in UploadFileItemList)
                        {
                            if (item.Id == fileItem.Id)
                            {
                                item.Rate = nowRate;
                            }
                        }
                    }));
                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    UploadFileItemNumber -= 1;
                }));
                fs.Close();
            });
        }
    }
}
