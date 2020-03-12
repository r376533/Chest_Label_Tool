using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;

using Dicom;
using Dicom.Imaging;

namespace Chest_Label_Tool.Lib
{
    public static class Image_Func
    {
        /// <summary>
        /// 將Dcm檔案轉成jpg
        /// </summary>
        /// <param name="DcmPath">Dcm的檔案路徑</param>
        /// <param name="TargetPath">存檔路徑</param>
        /// <param name="TargetFileName">轉換後的檔案名稱，若放null或空字元，則與Dcm檔案同名稱</param>
        /// <returns>檔案存檔後的絕對位址，如果回傳空字串則表示存檔失敗</returns>
        public static string DcmToJPG(string DcmPath,string TargetPath,string TargetFileName="") 
        {
            string Result = String.Empty;
            string FileName = Path.GetFileNameWithoutExtension(DcmPath);
            if (!String.IsNullOrEmpty(FileName)) 
            {
                //處理結果檔案路經及名稱
                Func.CheckDirExist(TargetPath);
                string resultfilename = TargetFileName;
                if (String.IsNullOrEmpty(resultfilename)) 
                {
                    //如果沒有指定輸出名稱，則輸出檔名則用輸入檔名
                    resultfilename = FileName+".jpg";
                }
                string finalpath = Path.Combine(TargetPath, resultfilename);
                //檔案名稱不為異常才可以轉換
                DicomImage dcmimage = new DicomImage(DcmPath);
                dcmimage.RenderImage().AsClonedBitmap().Save(finalpath);
                Result = finalpath;
            }
            return Result;
        }

    }
}
