using System;
using System.ComponentModel;
using System.Reflection;
using TMS.Core.Data.Attributes;

namespace TMS.Core.Tools.Helper
{
    public static class EnumHelper
    {
        public static string GetEnumDescription(Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0)
                return "";
            DescriptionAttribute descriptionAttribute = (DescriptionAttribute)objs[0];
            return descriptionAttribute.Description;
        }

        public static string GetIconPath(Type type, Enum enumValue)
        {
            string value = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(value);
            object[] objs = field.GetCustomAttributes(typeof(IconPathAttribute), false);
            if (objs == null || objs.Length == 0)
                return "";
            IconPathAttribute iconPathsAttribute = (IconPathAttribute)objs[0];
            return iconPathsAttribute.Path;
        }
    }
}
