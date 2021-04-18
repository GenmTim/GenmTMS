using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TMS.Core.Data.Entity;
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

		public DataTable DataList { get; set; }

		//public List<Payroll> DataList { get; set; } = new List<Payroll>() {
		//	new Payroll{ Name="234", Month="2021-02",Number=2,Money=2813734.37,
		//		Currency="CNY",Unpublished=0,Published=2,Withdrawn=1,CreateTime="2021-01-19"},
		//	new Payroll{ Name="ghk", Month="2020-02",Number=26,Money=435734.37,
		//		Currency="USD",Unpublished=2,Published=5,Withdrawn=0,CreateTime="2021-02-22"},
		//	new Payroll{ Name="876g", Month="2021-01",Number=12,Money=2898734.37,
		//		Currency="USD",Unpublished=3,Published=3,Withdrawn=2,CreateTime="2021-03-02"},
		//	new Payroll{ Name="909k", Month="2020-12",Number=9,Money=993734.37,
		//		Currency="CNY",Unpublished=1,Published=1,Withdrawn=2,CreateTime="2021-02-07"},
		//	new Payroll{ Name="bg5h", Month="2020-11",Number=15,Money=1234734.37,
		//		Currency="CNY",Unpublished=1,Published=4,Withdrawn=0,CreateTime="2021-01-31"}
		//};
	}
}
