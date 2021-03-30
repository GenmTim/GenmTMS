using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data
{
    public class NotificationData
    {
        public long SenderId;
        public long ReceiveId;
        public int Type;
        public int SubType;
        public object Data;
        public long Timestamp;
    }

}
