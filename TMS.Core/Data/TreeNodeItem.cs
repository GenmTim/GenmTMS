using System.Collections.Generic;

namespace TMS.Core.Data
{
    public class TreeNodeItem
    {
        public string Icon { get; set; }
        public string Name { get; set; }

        public List<TreeNodeItem> Children { get; set; }
        public TreeNodeItem()
        {
            Children = new List<TreeNodeItem>();
        }
    }
}
