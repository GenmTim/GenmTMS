using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using TMS.Core.Data.VO.CloudFile;
using TMS.Core.Event;

namespace TMS.DeskTop.UserControls.Popup.ViewModels
{

    public class UploadInfoPopupViewModel : BindableBase
    {
        private readonly IEventAggregator eventAggregator;
        public UploadInfoPopupViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<UploadFileEvent>().Subscribe(UploadFile);
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



        private ObservableCollection<UploadFileItemVO> uploadFileItemList;
        public ObservableCollection<UploadFileItemVO> UploadFileItemList
        {
            get => uploadFileItemList;
            set
            {
                uploadFileItemList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        private void UploadFile(UploadFileItemVO fileItem)
        {
            // 开始上传准备
            FileInfo info = new FileInfo(fileItem.FullName);

            long fileSize = info.Length;

            fileItem.Size = fileSize;
            fileItem.Name = info.Name;
            fileItem.State = UploadFileState.上传中;
            // 添加至上传项到列表
            UploadFileItemList ??= new ObservableCollection<UploadFileItemVO>();
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
                    fileItem.State = UploadFileState.上传完成;
                    this.eventAggregator.GetEvent<UploadedFileEvent>().Publish(fileItem);
                }));
                fs.Close();
            });
        }
    }
}
