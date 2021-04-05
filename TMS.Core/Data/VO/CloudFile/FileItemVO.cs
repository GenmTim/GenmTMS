using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;

namespace TMS.Core.Data.VO.CloudFile
{
    public class FileItemVO
    {
        public string Name { get; set; }
        public User Owner { get; set; }
        public long LastUpdateTimestamp { get; set; }
        public long FileSize { get; set; }
    }
}
