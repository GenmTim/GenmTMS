using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Entity;

namespace TMS.Core.Data.VO
{
    public class MsgObjVO
    {
        public long ObjectId { get; set; }
        public Uri Avatar { get; set; }
        public string NewMessage { get; set; }
        public string ObjectName { get; set; }
        public string NewMessageDate { get; set; }
        public int BadgeNumber { get; set; }

        public override int GetHashCode()
        {
            return (int)ObjectId;
        }
    }
}
