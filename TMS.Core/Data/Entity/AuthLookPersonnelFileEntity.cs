using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.Enums;

namespace TMS.Core.Data
{
    public enum AuthLookFilePersonnelStatus
    {
        ApplyFor,
        Authorized,
        Refused,
    }


    public class AuthLookPersonnelFileEntity
    {
        public AuthLookFilePersonnelStatus Status { get; set; }
        public long RequesterId { get; set; }
        public long ProcessorId { get; set; }
    }
}
