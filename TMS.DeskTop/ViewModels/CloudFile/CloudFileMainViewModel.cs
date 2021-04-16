using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;
using TMS.Core.Api;
using TMS.Core.Data.VO.CloudFile;
using TMS.Core.Event;
using TMS.Core.Service;
using TMS.DeskTop.UserControls.Dialogs.Views;
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


        public CloudFileMainViewModel(IEventAggregator eventAggregator, IDialogHostService dialogHost)
        {
            this.dialogHost = dialogHost;
            this.eventAggregator = eventAggregator;
            this.AddNewFolderCmd = new DelegateCommand(async() =>
            {
                var param = new DialogParameters();
                param.Add("title", "添加新文件夹");
                param.Add("positive_text", "添加");
                param.Add("negative_text", "取消");
                param.Add("input_hint", "请输入新的文件夹名字");
                var result = await this.dialogHost.ShowDialog(nameof(TextBoxDialog), param, "CloudFileRoot");
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
                    foreach (var name in dlg.FileNames )
                    {
                        LoggerService.Info(name);
                    }
                }
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
