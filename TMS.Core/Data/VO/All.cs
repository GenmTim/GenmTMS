using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.VO
{
    public class RequirementVO
    {
        public string Job { get; set; }
        public string NeedNumber { get; set; }
        public string Require { get; set; }
        public string ArrivalTime { get; set; }
        public string Approver { get; set; }
        public string WorkAge { get; set; }
    }

    public class QuestionnaireVO
    { 
        public string Name { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string ContentList { get; set; }
    }


    public class GroupVO
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Uri { get; set; }
    }
}
