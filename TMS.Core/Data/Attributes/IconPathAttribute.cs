using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class IconPathAttribute : Attribute
    {
        public string Path { get; set; }

        public IconPathAttribute(string path)
        {
            this.Path = path;
        }
    }

}
