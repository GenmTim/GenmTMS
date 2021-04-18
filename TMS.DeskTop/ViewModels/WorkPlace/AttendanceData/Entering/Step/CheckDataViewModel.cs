using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Data;
using System.IO;
using TMS.Core.Event;
using TMS.Core.Tools.Execl;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering.Step
{
    public class CheckDataViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;

        private FileInfo entryFileInfo;
        public FileInfo EntryFileInfo
        {
            get => entryFileInfo;
            set
            {
                entryFileInfo = value;
                if (eventAggregator != null)
                {
                    UpdateData();
                }
            }
        }

        public CheckDataViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NextStepCmd = new DelegateCommand(NextStep);
            this.PrevStepCmd = new DelegateCommand(PrevStep);
        }

        public DelegateCommand NextStepCmd { get; private set; }

        private void NextStep()
        {
            eventAggregator.GetEvent<NextStepEvent>().Publish();
        }

        public DelegateCommand PrevStepCmd { get; private set; }

        private void PrevStep()
        {
            eventAggregator.GetEvent<PrevStepEvent>().Publish();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            bool isHasParam = navigationContext.Parameters.TryGetValue("entry_file", out FileInfo newFileInfo);
            EntryFileInfo = newFileInfo;
            if (entryFileInfo == null)
            {
                eventAggregator.GetEvent<ToastShowEvent>().Publish("错误的导向");
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private DataTable dataList;
        public DataTable DataList
        {
            get => dataList;
            set
            {
                dataList = value;
                RaisePropertyChanged();
            }
        }


        private void UpdateData()
        {
            if (entryFileInfo == null)
            {
                return;
            }
            string filePath = entryFileInfo.FullName;
            if (!File.Exists(filePath))
            {
                //Console.WriteLine("目录下文件不存在");
            }
            else
            {
                var ext = Path.GetExtension(filePath).ToLower();
                if (ext != ".xls" && ext != ".xlsx")
                    throw new Exception(string.Format("无法识别的文件扩展名 {0}", ext));

                TableExcelReadResult result = TableExcelReader.loadFromExcelAll(filePath);
                if (result.IsRight)
                {
                    //内容正确
                    TableExcelData tableExcelData = result.tableExcelData;
                    DataTable dataTable = new DataTable();
                    foreach (var item in tableExcelData.Headers)
                    {
                        dataTable.Columns.Add(item.FieldName);
                    }
                    for (int i = 0; i < tableExcelData.Rows.Count; i++)
                    {
                        dataTable.Rows.Add(tableExcelData.Rows[i].StrList.ToArray());
                    }
                    DataList = dataTable;
                }
                else
                {
                    //内容错误
                    //using (FileStream file = new FileStream("D:/=开发项目/2020服务外包/Excel/cscsaa.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    //{
                    //	file.Write(result.ErrorExcel);
                    //	file.Close();
                    //}
                }
            }
        }
    }
}
