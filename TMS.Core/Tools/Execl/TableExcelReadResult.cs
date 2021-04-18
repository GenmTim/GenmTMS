namespace TMS.Core.Tools.Execl
{
    public class TableExcelReadResult
    {
        public TableExcelReadResult()
        {
        }

        public TableExcelReadResult(bool isRight, TableExcelData tableExcelData)
        {
            IsRight = isRight;
            this.tableExcelData = tableExcelData;
        }

        public TableExcelReadResult(bool isRight, byte[] errorExcel)
        {
            IsRight = isRight;
            ErrorExcel = errorExcel;
        }

        public bool IsRight { get; set; }

        public TableExcelData tableExcelData { get; set; }

        public byte[] ErrorExcel { get; set; }
    }
}
