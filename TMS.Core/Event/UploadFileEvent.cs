using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Core.Data.VO.CloudFile;

namespace TMS.Core.Event
{
    public class UploadFileEvent : PubSubEvent<UploadFileItemVO>
    {
    }
}
