using Genm.Data;
using System.Collections.ObjectModel;

namespace TMS.Core.Data.Entity
{
    public class ChatBoxContext
    {
        public User User { get; set; }
        public ObservableCollection<ChatInfoModel> ChatInfoList { get; set; }
    }
}
