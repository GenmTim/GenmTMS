using System.Collections.Generic;

namespace TMS.Core.Tools.Execl
{
    public class TableExcelRow
    {
        public List<string> StrList { get; set; }

        public TableExcelRow()
        {
            StrList = new List<string>();
        }
    }
}
