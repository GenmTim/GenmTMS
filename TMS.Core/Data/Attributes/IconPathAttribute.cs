using System;

namespace TMS.Core.Data.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IconPathAttribute : Attribute
    {
        public string Path { get; set; }

        public IconPathAttribute(string path)
        {
            this.Path = path;
        }
    }

}
