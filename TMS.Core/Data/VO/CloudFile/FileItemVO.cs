using Prism.Mvvm;
using System.Collections.ObjectModel;
using TMS.Core.Data.Entity;

namespace TMS.Core.Data.VO.CloudFile
{
    public class FolderTreeNodeItemVO : BindableBase
    {
        private long id;
        public long Id
        {
            get => id;
            set
            {
                id = value;
                RaisePropertyChanged();
            }
        }

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<FolderTreeNodeItemVO> children;
        public ObservableCollection<FolderTreeNodeItemVO> Children
        {
            get => children;
            set
            {
                children = value;
                RaisePropertyChanged();
            }
        }
    }

    public class FileItemVO
    {
        public string Name { get; set; }
        public User Owner { get; set; }
        public long LastUpdateTimestamp { get; set; }
        public long FileSize { get; set; }
    }
}
