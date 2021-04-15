using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO;
using TMS.Core.Event;
using TMS.Core.Tools.Execl;

namespace TMS.DeskTop.ViewModels.WorkPlace.AttendanceData.Entering
{


    public class CheckDataViewModel
    {
        private readonly IRegionManager regionManager;
        private readonly IEventAggregator eventAggregator;
        public CheckDataViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            this.NextStepCmd = new DelegateCommand(NextStep);
            this.PrevStepCmd = new DelegateCommand(PrevStep);

			string filePath = "E:\\=项目开发\\2021服务外包\\Execl\\工资单.xlsx";
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
					DataList = tableExcelData.Rows;
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

		public List<TableExcelRow> DataList { get; set; }
	}
}
