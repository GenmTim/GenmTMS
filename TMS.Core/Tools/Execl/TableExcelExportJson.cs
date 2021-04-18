using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TMS.Core.Tools.Execl
{
    public static class TableExcelExportJson
    {
        public static string exportExcelFile(TableExcelData data, string filePath)
        {
            List<Dictionary<string, object>> lst = data.Rows.Select(a =>
            {
                var r = new Dictionary<string, object>();
                for (int i = 0; i < data.Headers.Count; i++)//有几列
                {
                    TableExcelHeader hdr = data.Headers[i];//标题
                    string val = a.StrList[i];//内容
                    object obj = val;
                    r[hdr.FieldName] = obj;
                }
                return r;
            }).ToList();

            string output = JsonConvert.SerializeObject(lst, Formatting.Indented);
            File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(output));
            return output;
        }
    }
}
