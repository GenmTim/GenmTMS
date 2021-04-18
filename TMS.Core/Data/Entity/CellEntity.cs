using System;
using System.Text.RegularExpressions;

namespace TMS.Core.Data.Entity
{
    public class CellEntity
    {
        public int Row { get; set; }
        public int Column { get; set; }

        private string columnLetter;
        private string rowLetter;

        public CellEntity(string pos)
        {

        }

        public CellEntity(string columnLetter, string row)
        {
            this.columnLetter = columnLetter;
            rowLetter = row;
            if (columnLetter == null || !Regex.IsMatch(columnLetter, "[a-zA-Z]+"))
            {
                throw new Exception(string.Format("列存在无法识别的字符"));
            }
            columnLetter = columnLetter.ToUpper();
            int columnIndex = 0;
            char[] letters = columnLetter.ToCharArray();
            foreach (char let in letters)
            {
                columnIndex = let - 64 + columnIndex * 26;
            }
            Column = columnIndex - 1;
            Row = int.Parse(row) - 1;
        }

        public override string ToString()
        {
            return columnLetter + rowLetter;
        }
    }
}
