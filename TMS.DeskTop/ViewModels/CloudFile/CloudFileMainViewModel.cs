using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using TMS.Core.Api;
using TMS.Core.Data.VO.CloudFile;
using TMS.Core.Event;
using TMS.Core.Service;
using TMS.DeskTop.Tools.Helper;
using static TMS.DeskTop.ViewModels.CloudFileViewModel;

namespace TMS.DeskTop.ViewModels.CloudFile
{
    public class CloudFileMainViewModel : BindableBase, INavigationAware
    {
        private FolderTreeNodeItemVO context;

        public FolderTreeNodeItemVO Context
        {
            get => context;
            set
            {
                context = value;
                RaisePropertyChanged();
            }
        }

        private readonly IDialogHostService dialogHost;
        private readonly IEventAggregator eventAggregator;

        public DelegateCommand AddNewFolderCmd { get; private set; }
        public DelegateCommand OpenFileCmd { get; private set; }

        private ObservableCollection<FileItemVO> fileItemVOList;
        public ObservableCollection<FileItemVO> FileItemVOList
        {
            get => fileItemVOList;
            set
            {
                fileItemVOList = value;
                RaisePropertyChanged();
            }
        }



        public CloudFileMainViewModel(IEventAggregator eventAggregator, IDialogHostService dialogHost)
        {
            this.dialogHost = dialogHost;
            this.eventAggregator = eventAggregator;
            this.AddNewFolderCmd = new DelegateCommand(async () =>
            {
                var result = await DialogHelper.ShowTextBoxDialog(dialogHost, "CloudFileRoot", "添加新文件夹", "添加", "取消", "请输入新的文件夹名字");
                if (result != null && result.Result == ButtonResult.OK)
                {
                    string folderName = result.Parameters.GetValue<string>("value");
                    AddNewFolderToServer(folderName);
                }
            });
            this.OpenFileCmd = new DelegateCommand(() =>
            {
                //打开文件对话框              
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.FileName = "Document"; // Default file name              
                dlg.DefaultExt = ".txt"; // Default file extension              
                dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension                
                                                            // Show open file dialog box             
                dlg.Multiselect = true;
                Nullable<bool> result = dlg.ShowDialog();
                // Process open file dialog box results              
                if (result == true)
                {
                    foreach (var name in dlg.FileNames)
                    {
                        LoggerService.Info(name);
                    }
                }
            });
            this.eventAggregator.GetEvent<UploadedFileEvent>().Subscribe((item) =>
            {
                FileItemVOList ??= new ObservableCollection<FileItemVO>();
                FileItemVOList.Add(new FileItemVO
                {
                    Name = item.Name,
                    Owner = SessionService.Instance.User,
                    LastUpdateTimestamp = TimeHelper.GetNowTimeStamp(),
                    FileSize = item.Size
                });
            });
        }

        private async void AddNewFolderToServer(string name)
        {
            var result = await HttpService.GetConn().PostFolder(new Core.Data.Dto.FolderDto
            {
                Name = name,
                ParentFolder = (long)Context.Id,
            });
            if (result.StatusCode == 200)
            {
                this.eventAggregator.GetEvent<ToastShowEvent>().Publish("新文件夹创建成功");
                this.eventAggregator.GetEvent<UpdateFolderTreeEvent>().Publish();
            }
            else
            {
                this.eventAggregator.GetEvent<ToastShowEvent>().Publish("新文件夹创建失败");
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Context = navigationContext.Parameters.GetValue<FolderTreeNodeItemVO>("Context");
        }
    }
}
