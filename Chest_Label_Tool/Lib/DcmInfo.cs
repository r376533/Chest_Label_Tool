using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chest_Label_Tool.Lib
{
    public class DcmInfo
    {
        /// <summary>
        /// 影像寬度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 影像高度
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// 影像縮放比例
        /// </summary>
        public double scale = 1.0;

    }
}
