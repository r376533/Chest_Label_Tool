using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Chest_Label_Tool.Lib
{
    static class Enums
    {

        public enum ProgramAction 
        {
            [Description("沒有選擇")]
            None=-1,
            [Description("縮放")]
            Zoom = 0,
            [Description("框選")]
            Select = 1,
            [Description("打點")]
            Point = 2
        }
        /// <summary>
        /// 抓列舉值的描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

    }
}
