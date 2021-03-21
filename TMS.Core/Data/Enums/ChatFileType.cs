using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Attributes;

namespace TMS.Core.Data.Enums
{
    public enum ChatFileType
    {
        [IconPath("/Resources/Images/Icon/FileType/PDF.png")]
        PDF,
        [IconPath("/Resources/Images/Icon/FileTpye/Excel.png")]
        Excel,
        [IconPath("/Resources/Images/Icon/FileTpye/Exe.png")]
        Exe,
        [IconPath("/Resources/Images/Icon/FileTpye/Word.png")]
        Word,
        [IconPath("/Resources/Images/Icon/FileTpye/PPT.png")]
        PPT,
        [IconPath("/Resources/Images/Icon/FileTpye/Other.png")]
        Other,
    }
}
