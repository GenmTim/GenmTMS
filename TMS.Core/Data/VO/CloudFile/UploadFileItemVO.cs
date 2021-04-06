using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.VO.CloudFile
{
    public enum UploadFileState
    { 
        上传中,
        暂停,
        上传完成,
        上传失败,
    }

    public class UploadFileItemVO : BindableBase
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        private UploadFileState state;
        public UploadFileState State 
        { 
            get => state;
            set
            {
                state = value;
                RaisePropertyChanged();
            }
        }

        private double rate;
        public double Rate
        {
            get => rate;
            set
            {
                rate = value;
                RaisePropertyChanged();
            }
        }

    }
}
