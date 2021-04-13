using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace TMS.Core.Data
{
    public class DeptTreeNodeItemVO : BindableBase
    {
        public long Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public ObservableCollection<DeptTreeNodeItemVO> Children { get; set; }
    }
}
