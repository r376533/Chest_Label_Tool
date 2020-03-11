using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace Chest_Label_Tool.Lib
{
    public static class Image_Func
    {
        /// <summary>
        /// 將Dcm檔案轉成jpg
        /// </summary>
        /// <param name="DcmPath">Dcm的檔案路徑</param>
        /// <param name="TargetPath">存檔路徑</param>
        /// /// <param name="TargetFileName">轉換後的檔案名稱，若放null或空字元，則與Dcm檔案同名稱</param>
        public static void DcmToJPG(string DcmPath,string TargetPath,string TargetFileName) 
        {
        
        }

    }
}
