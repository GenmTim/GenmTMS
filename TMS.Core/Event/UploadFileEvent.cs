using Prism.Events;
using TMS.Core.Data.VO.CloudFile;

namespace TMS.Core.Event
{
    public class UploadFileEvent : PubSubEvent<UploadFileItemVO>
    {
    }
}
