using System;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using TMS.Core.Data.Entity;

namespace TMS.Core.Tools.Execl
{
	public static class TableExcelReader
	{
		public static TableExcelData loadFromExcel(string filePath)
		{
			if (!File.Exists(filePath))
				throw new Exception(string.Format("{0} 文件不存在！", filePath));

			var ext = Path.GetExtension(filePath).ToLower();
			if (ext != ".xls" && ext != ".xlsx")
				throw new Exception(string.Format("无法识别的文件扩展名 {0}", ext));

			var headers = new List<TableExcelHeader>();
			var rows = new List<TableExcelRow>();

			var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage(fs))
			{
				ExcelWorkbook workbook1 = package.Workbook;

				//IWorkbook workbook = ext == ".xls" ? new HSSFWorkbook(fs) : (IWorkbook)new XSSFWorkbook(fs);
				ExcelWorksheets workbook = workbook1.Worksheets;
				fs.Close();

				_readDataFromWorkbookOfSheetName(workbook, "def", headers, rows);

				return new TableExcelData(headers, rows);
			}
		}

		public static TableExcelData loadFromExcel(string filePath, string sheetName, List<CellEntity> cells)
		{
			if (!File.Exists(filePath))
				throw new Exception(string.Format("{0} 文件不存在！", filePath));

			var ext = Path.GetExtension(filePath).ToLower();
			if (ext != ".xls" && ext != ".xlsx")
				throw new Exception(string.Format("无法识别的文件扩展名 {0}", ext));

			var headers = new List<TableExcelHeader>();//debug使用cells生成headers
			foreach (var cell in cells)
			{
				headers.Add(new TableExcelHeader() { FieldName = cell.ToString() });
			}
			var rows = new List<TableExcelRow>();

			var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage(fs))
			{
				ExcelWorkbook workbook1 = package.Workbook;

				//IWorkbook workbook = ext == ".xls" ? new HSSFWorkbook(fs) : (IWorkbook)new XSSFWorkbook(fs);
				ExcelWorksheets workbook = workbook1.Worksheets;

				fs.Close();

				_readDataFromWorkbookOfSheetName(workbook, sheetName, cells, rows);

				return new TableExcelData(headers, rows);
			}

		}

		public static TableExcelData loadFromExcel(string filePath, List<CellEntity> cells)
		{
			if (!File.Exists(filePath))
				throw new Exception(string.Format("{0} 文件不存在！", filePath));

			var ext = Path.GetExtension(filePath).ToLower();
			if (ext != ".xls" && ext != ".xlsx")
				throw new Exception(string.Format("无法识别的文件扩展名 {0}", ext));

			var headers = new List<TableExcelHeader>();
			foreach (var cell in cells)
			{
				headers.Add(new TableExcelHeader() { FieldName = cell.ToString() });
			}
			var rows = new List<TableExcelRow>();

			var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage(fs))
			{
				ExcelWorkbook workbook1 = package.Workbook;

				//IWorkbook workbook = ext == ".xls" ? new HSSFWorkbook(fs) : (IWorkbook)new XSSFWorkbook(fs);
				ExcelWorksheets workbook = workbook1.Worksheets;

				fs.Close();

				ExcelWorksheet excelWorksheet = workbook[0];
				_readDataFromWorkbookOfSheetName(workbook, excelWorksheet.Name, cells, rows);

				return new TableExcelData(headers, rows);
			}

		}

		public static TableExcelReadResult loadFromExcel(string filePath, int num)
		{
			if (!File.Exists(filePath))
				throw new Exception(string.Format("{0} 文件不存在！", filePath));

			var ext = Path.GetExtension(filePath).ToLower();
			if (ext != ".xls" && ext != ".xlsx")
				throw new Exception(string.Format("无法识别的文件扩展名 {0}", ext));

			var headers = new List<TableExcelHeader>();
			var rows = new List<TableExcelRow>();

			var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage(fs))
			{

				ExcelWorksheets workbook = package.Workbook.Worksheets;

				fs.Close();

				//_readHeadersFromDefSheet(excelWorksheet, headers);
				bool v = _readDataFromWorkbookDefSheet(workbook, headers, rows);
				TableExcelReadResult result;
				if (v)
				{
					return result = new TableExcelReadResult(v, new TableExcelData(headers, rows));
				}
				else
				{
					using (MemoryStream file = new MemoryStream())
					{
						package.SaveAs(file);
						result = new TableExcelReadResult(v, file.ToArray());
						file.Close();
					}
				}
				return result;
			}

		}

		public static TableExcelReadResult loadFromExcelAll(string filePath)
		{
			if (!File.Exists(filePath))
				throw new Exception(string.Format("{0} 文件不存在！", filePath));

			var ext = Path.GetExtension(filePath).ToLower();
			if (ext != ".xls" && ext != ".xlsx")
				throw new Exception(string.Format("无法识别的文件扩展名 {0}", ext));

			var headers = new List<TableExcelHeader>();
			var rows = new List<TableExcelRow>();

			var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage(fs))
			{

				ExcelWorksheets workbook = package.Workbook.Worksheets;

				fs.Close();

				//_readHeadersFromDefSheet(excelWorksheet, headers);
				bool v = _readDataFromWorkbookDefSheetAll(workbook, headers, rows);
				TableExcelReadResult result;
				if (v)
				{
					return result = new TableExcelReadResult(v, new TableExcelData(headers, rows));
				}
				else
				{
					using (MemoryStream file = new MemoryStream())
					{
						package.SaveAs(file);
						result = new TableExcelReadResult(v, file.ToArray());
						file.Close();
					}
				}
				return result;
			}

		}

		public static void loadFromExcelAndWrite(string filePath, List<CellEntity> cells)
		{
			if (!File.Exists(filePath))
				throw new Exception(string.Format("{0} 文件不存在！", filePath));

			var ext = Path.GetExtension(filePath).ToLower();
			if (ext != ".xls" && ext != ".xlsx")
				throw new Exception(string.Format("无法识别的文件扩展名 {0}", ext));

			var headers = new List<TableExcelHeader>();
			foreach (var cell in cells)
			{
				headers.Add(new TableExcelHeader() { FieldName = cell.ToString() });
			}
			var rows = new List<TableExcelRow>();

			var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			using (ExcelPackage package = new ExcelPackage(fs))
			{
				ExcelWorkbook workbook1 = package.Workbook;

				//IWorkbook workbook = ext == ".xls" ? new HSSFWorkbook(fs) : (IWorkbook)new XSSFWorkbook(fs);
				ExcelWorksheets workbook = workbook1.Worksheets;

				fs.Close();

				ExcelWorksheet sheet = workbook[0];
				ExcelRange excelRanges = sheet.Cells[3, 3];
				excelRanges.Value = "str";
				excelRanges.Style.Fill.PatternType = ExcelFillStyle.Solid;
				excelRanges.Style.Fill.BackgroundColor.SetColor(Color.Red);

				using (FileStream fs1 = new FileStream("D:/=开发项目/2020服务外包/Excel/测试.xlsx", FileMode.Create, FileAccess.ReadWrite))
				{
					package.SaveAs(fs1);//向打开的这个xls文件中写入数据  
					fs1.Close();

				}
			}

		}

		private static void _readDataFromWorkbookOfSheetName(ExcelWorksheets wb, string sheetName, List<CellEntity> cells, List<TableExcelRow> rows)
		{
			//IEnumerator<ISheet> enumerator = wb.GetEnumerator();
			//string sheetName = enumerator.Current.SheetName;
			var sheet1 = wb[sheetName];
			if (sheet1 == null)
				throw new Exception(string.Format("'{0}'工作簿不存在", sheetName));

			foreach (var ds in _readDataFromDataSheetOfPortion(sheet1, cells))
			{
				var rowData = new List<string>();
				for (int i = 0; i < cells.Count; i++)
				{
					rowData.Add(ds[i]);
				}
				rows.Add(new TableExcelRow() { StrList = rowData });
			}
		}

		private static void _readDataFromWorkbookOfSheetName(ExcelWorksheets wb, string sheetName, List<TableExcelHeader> headers, List<TableExcelRow> rows)
		{
			//IEnumerator<ISheet> enumerator = wb.GetEnumerator();
			//string sheetName = enumerator.Current.SheetName;
			var sheet1 = wb[sheetName];
			if (sheet1 == null)
				throw new Exception(string.Format("'{0}'工作簿不存在", sheetName));


			//加载字段
			_readHeadersFromDefSheet(sheet1, headers);

			//加载数据
			//List<string> headers2 = _readHeadersFromDataSheet(sheet1);//表第一行的字符串列表
			//var headerIndexes = new int[headers.Count];
			//_checkFieldsSame(headers, headers2, headerIndexes);//检查2表的键是否一致

			foreach (var ds in _readDataFromDataSheet(sheet1, headers.Count))
			{
				var rowData = new List<string>();
				for (int i = 0; i < headers.Count; i++)
				{
					//var idx = headerIndexes[i];
					rowData.Add(ds[i]);
				}
				rows.Add(new TableExcelRow() { StrList = rowData });
			}
		}

		private static bool _readDataFromWorkbookDefSheet(ExcelWorksheets wb, List<TableExcelHeader> headers, List<TableExcelRow> rows)
		{
			//IEnumerator<ISheet> enumerator = wb.GetEnumerator();
			//string sheetName = enumerator.Current.SheetName;
			var sheet1 = wb[0];
			if (sheet1 == null)
				throw new Exception(string.Format("默认工作簿不存在"));

			int num = 0;
			//加载字段
			_readHeadersFromDefSheet(sheet1, headers);

			IEnumerable<List<string>> enumerable = _readDataFromDataSheet(sheet1, headers.Count);
			foreach (var ds in enumerable)
			{
				if (ds == null || ds.Count != headers.Count)
				{
					num++;
					continue;
				}
				var rowData = new List<string>();
				for (int i = 0; i < headers.Count; i++)
				{
					//var idx = headerIndexes[i];
					rowData.Add(ds[i]);
				}
				rows.Add(new TableExcelRow() { StrList = rowData });
			}
			if (num > 0)
			{
				return false;
			}
			return true;
		}

		private static bool _readDataFromWorkbookDefSheetAll(ExcelWorksheets wb, List<TableExcelHeader> headers, List<TableExcelRow> rows)
		{
			//IEnumerator<ISheet> enumerator = wb.GetEnumerator();
			//string sheetName = enumerator.Current.SheetName;
			var sheet1 = wb[0];
			if (sheet1 == null)
				throw new Exception(string.Format("默认工作簿不存在"));

			int num = 0;
			//加载字段
			_readHeadersFromDefSheet(sheet1, headers);

			IEnumerable<List<string>> enumerable = _readDataFromDataSheet(sheet1);
			foreach (var ds in enumerable)
			{
				if (ds == null || ds.Count != headers.Count)
				{
					num++;
					continue;
				}
				var rowData = new List<string>();
				for (int i = 0; i < headers.Count; i++)
				{
					//var idx = headerIndexes[i];
					rowData.Add(ds[i]);
				}
				rows.Add(new TableExcelRow() { StrList = rowData });
			}
			if (num > 0)
			{
				return false;
			}
			return true;
		}

		private static void _readDataFromWorkbook(ExcelWorksheets wb, List<TableExcelHeader> headers, List<TableExcelRow> rows)
		{
			return;
			string defSheetName = "def";
			string dataSheetName = "data";
			//IEnumerator<ISheet> enumerator = wb.GetEnumerator();
			//string sheetName = enumerator.Current.SheetName;
			var sheet1 = wb[defSheetName];
			if (sheet1 == null)
				throw new Exception(string.Format("'{0}'工作簿不存在", defSheetName));

			var sheet2 = wb[dataSheetName];
			if (sheet2 == null)
				throw new Exception(string.Format("'{0}'工作簿不存在", dataSheetName));

			//加载字段
			_readHeadersFromDefSheet(sheet1, headers);

			var h1 = headers.Find(a => a.FieldName == "Id");
			if (h1 == null)
				throw new Exception(string.Format("'{0}'工作簿中不存在Id字段！", defSheetName));

			var h2 = headers.Find(a => a.FieldName == "KeyName");
			if (h2 == null)
				throw new Exception(string.Format("'{0}'工作簿中不存在KeyName字段！", defSheetName));

			//加载数据
			var headers2 = _readHeadersFromDataSheet(sheet2);
			var headerIndexes = new int[headers.Count];
			_checkFieldsSame(headers, headers2, headerIndexes);

			foreach (var ds in _readDataFromDataSheet(sheet2, headers2.Count))
			{
				var rowData = new List<string>();
				for (int i = 0; i < headers.Count; i++)
				{
					var idx = headerIndexes[i];
					rowData.Add(ds[idx]);
				}
				rows.Add(new TableExcelRow() { StrList = rowData });
			}
		}

		private static string _convertCellToString(ExcelRange cell)
		{
			//Type type = cell.Value.GetType();
			string r = string.Empty;
			if (cell.Value != null)
			{
				r = cell.Value.ToString();
				//	switch (cell.Value.GetType())
				//	{
				//		case CellType.Boolean:
				//			r = cell.BooleanCellValue.ToString();
				//			break;
				//		case CellType.Numeric:
				//			r = cell.NumericCellValue.ToString();
				//			break;
				//		default:
				//			r = cell.StringCellValue;
				//			break;
				//	}
			}
			return r;
		}

		private static void _readHeadersFromDefSheet(ExcelWorksheet sheet, List<TableExcelHeader> headers)
		{
			ExcelCellAddress end = sheet.Dimension.End;
			for (int col = 1; col <= end.Column; col++)
			{
				string v = _convertCellToString(sheet.Cells[1, col]);
				if (!string.IsNullOrEmpty(v))
				{
					headers.Add(new TableExcelHeader()
					{
						FieldName = v,
					});
					continue;
				}
				throw new Exception(string.Format(
					"'{0}'工作簿中第1行第{1}列数据异常，有缺失！", sheet.Name, col));

			}
			sheet.Cells[1, end.Column + 1].Value = "错误原因";
			sheet.Cells[1, end.Column + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
			sheet.Cells[1, end.Column + 1].Style.Fill.BackgroundColor.SetColor(1, 247, 105, 100);

		}

		private static List<string> _readHeadersFromDataSheet(ExcelWorksheet sheet)
		{
			ExcelCellAddress start = sheet.Dimension.Start;
			ExcelCellAddress end = sheet.Dimension.End;
			var r = new List<string>();
			var rd = sheet.Row(1);
			for (int i = 0; i < end.Column; i++)
			{
				var cell = sheet.Cells[1, i];
				r.Add(cell != null ? cell.Value.ToString() : string.Empty);
			}
			for (int i = r.Count - 1; i >= 0; i--)
			{
				if (string.IsNullOrEmpty(r[i]))
					r.RemoveAt(i);
				else
					break;
			}
			int idx = r.IndexOf(string.Empty);
			if (idx >= 0)
				throw new Exception(string.Format(
					"'{0}'工作簿中第1行第{1}列字段名称非法", "data", idx + 1));
			return r;
		}

		private static void _checkFieldsSame(List<TableExcelHeader> headers1, List<string> headers2, int[] indexes)
		{
			for (int i = 0; i < headers1.Count; i++)
			{
				var hd = headers1[i];
				var idx = headers2.IndexOf(hd.FieldName);
				if (idx < 0)
					throw new Exception(string.Format("'{0}'工作簿中不存在字段'{1}'所对应的列", "data", hd.FieldName));
				indexes[i] = idx;
			}
			if (headers1.Count < headers2.Count)
			{
				foreach (var s in headers2)
				{
					if (headers1.Find(a => a.FieldName == s) == null)
						throw new Exception(string.Format("'{0}'工作簿中的包含多余的数据列'{1}'", "data", s));
				}
			}
		}

		private static IEnumerable<List<string>> _readDataFromDataSheet(ExcelWorksheet sheet, int columns)
		{
			ExcelCellAddress end = sheet.Dimension.End;
			for (int i = 2; i <= end.Row; i++)
			{
				var ds = new List<string>();
				bool is_all_empty = true;
				bool flag = false;
				string name = _convertCellToString(sheet.Cells[i, 1]);
				if (string.IsNullOrEmpty(name))
				{
					//sheet.Cells[i, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
					//sheet.Cells[i, 1].Style.Fill.BackgroundColor.SetColor(1, 255, 182, 193);

					sheet.Cells[i, end.Column].Value = sheet.Cells[i, end.Column + 1].Value + "缺少姓名字段 ";
					//sheet.Cells[i, end.Column].Style.Fill.PatternType = ExcelFillStyle.Solid;
					sheet.Cells[i, end.Column].Style.Font.Color.SetColor(1, 245, 74, 69);
					//sheet.Cells[i, end.Column].Style.Fill.BackgroundColor.SetColor(1, 245, 74, 69);
					//throw new Exception(string.Format("工作簿中第{0}行的姓名为空", i));
					yield return null;
				}
				else
					ds.Add(name);
				string tel = _convertCellToString(sheet.Cells[i, 2]);
				string email = _convertCellToString(sheet.Cells[i, 3]);
				string cradId = _convertCellToString(sheet.Cells[i, 4]);
				if (!string.IsNullOrEmpty(tel))
				{
					ds.Add(tel);
					ds.Add("");
					ds.Add("");
					//这边可以写函数替代例如if (XXX.IsNameOfTel(name,tel))
					if (name == "asdas" || tel == "10086")
					{
						sheet.Cells[i, end.Column].Value = sheet.Cells[i, end.Column + 1].Value + "手机号与姓名不匹配，请核对该员工的手机号 ";
						//sheet.Cells[i, end.Column].Style.Fill.PatternType = ExcelFillStyle.Solid;
						sheet.Cells[i, end.Column].Style.Font.Color.SetColor(1, 245, 74, 69);
						yield return null;
					}
				}
				else if (!string.IsNullOrEmpty(email))
				{
					ds.Add("");
					ds.Add(email);
					ds.Add("");
					if (name == "asdas" || email == "10086")
					{
						sheet.Cells[i, end.Column].Value = sheet.Cells[i, end.Column + 1].Value + "邮箱与姓名不匹配，请核对该员工的邮箱 ";
						//sheet.Cells[i, end.Column].Style.Fill.PatternType = ExcelFillStyle.Solid;
						sheet.Cells[i, end.Column].Style.Font.Color.SetColor(1, 245, 74, 69);
						yield return null;
					}
				}
				else if (!string.IsNullOrEmpty(cradId))
				{
					ds.Add("");
					ds.Add("");
					ds.Add(cradId);
					if (name == "rte" || cradId == "987654321")
					{
						sheet.Cells[i, end.Column].Value = sheet.Cells[i, end.Column + 1].Value + "身份证号与姓名不匹配，请核对该员工的身份证号 ";
						//sheet.Cells[i, end.Column].Style.Fill.PatternType = ExcelFillStyle.Solid;
						sheet.Cells[i, end.Column].Style.Font.Color.SetColor(1, 245, 74, 69);
						yield return null;
					}
				}
				else
				{
					//3个都为空

					sheet.Cells[i, end.Column].Value = sheet.Cells[i, end.Column + 1].Value + "手机号、邮箱、身份证号至少需要一个 ";
					//sheet.Cells[i, end.Column].Style.Fill.PatternType = ExcelFillStyle.Solid;
					sheet.Cells[i, end.Column].Style.Font.Color.SetColor(1, 245, 74, 69);
					//throw new Exception(string.Format("工作簿中第{0}行的id为空", i));
					yield return null;
				}
				//从第5列开始
				for (int c = 5; c <= end.Column - 1; c++)
				{
					string val = _convertCellToString(sheet.Cells[i, c]);
					if (string.IsNullOrEmpty(val))
					{
						//sheet.Cells[i, c].Style.Fill.PatternType = ExcelFillStyle.Solid;
						//sheet.Cells[i, c].Style.Fill.BackgroundColor.SetColor(1, 255, 182, 193);
						flag = true;

						yield return null;
					}
					if (!string.IsNullOrEmpty(val))
						is_all_empty = false;
					ds.Add(val);
				}
				//if (flag)
				//{
				//	sheet.Cells[i, end.Column + 1].Value = sheet.Cells[i, end.Column + 1].Value + "缺少数据 ";
				//	sheet.Cells[i, end.Column + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
				//	sheet.Cells[i, end.Column + 1].Style.Fill.BackgroundColor.SetColor(1, 245, 74, 69);
				//}

				if (!is_all_empty)
					yield return ds;
			}
		}

		private static IEnumerable<List<string>> _readDataFromDataSheet(ExcelWorksheet sheet)
		{
			ExcelCellAddress end = sheet.Dimension.End;
			//int row = cells[0].Row + 1;
			for (int i = 2; i <= end.Row; i++)
			{
				//var rd = sheet.GetRow(i);
				//if (rd == null)
				//	continue;

				var ds = new List<string>();
				bool is_all_empty = true;
				for (int c = 1; c <= end.Column - 1; c++)
				{
					string val = _convertCellToString(sheet.Cells[i, c]);
					if (string.IsNullOrEmpty(val))
					{
						sheet.Cells[i, c].Style.Fill.PatternType = ExcelFillStyle.Solid;
						sheet.Cells[i, c].Style.Fill.BackgroundColor.SetColor(1, 255, 182, 193);
						//flag = true;

						yield return null;
					}
					if (!string.IsNullOrEmpty(val))
						is_all_empty = false;
					ds.Add(val);
				}
				//foreach (CellEntity cell in cells)
				//{
				//	//var val = _convertCellToString(rd.GetCell(cell.Column));
				//	string val = _convertCellToString(sheet.Cells[i, cell.Column + 1]);
				//	if (!string.IsNullOrEmpty(val))
				//		is_all_empty = false;
				//	ds.Add(val);
				//}

				if (!is_all_empty)
					yield return ds;
			}
		}

		private static IEnumerable<List<string>> _readDataFromDataSheetOfPortion(ExcelWorksheet sheet, List<CellEntity> cells)
		{
			ExcelCellAddress end = sheet.Dimension.End;
			int row = cells[0].Row + 1;
			for (int i = row; i <= end.Row; i++)
			{
				//var rd = sheet.GetRow(i);
				//if (rd == null)
				//	continue;

				var ds = new List<string>();
				bool is_all_empty = true;
				foreach (CellEntity cell in cells)
				{
					//var val = _convertCellToString(rd.GetCell(cell.Column));
					string val = _convertCellToString(sheet.Cells[i, cell.Column + 1]);
					if (!string.IsNullOrEmpty(val))
						is_all_empty = false;
					ds.Add(val);
				}

				if (!is_all_empty)
					yield return ds;
			}
		}
	}
}
