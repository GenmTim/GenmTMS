using Prism.Events;
using TMS.Core.Data;

namespace TMS.Core.Event.Update
{
    public class UpdateCompanyOrganizationEvent : PubSubEvent
    {
    }

    public class UpdateShowDeptInfo : PubSubEvent<DeptTreeNodeItemVO> { }
}
