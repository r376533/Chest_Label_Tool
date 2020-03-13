using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using Emgu.CV.UI;

using Dicom;
using Dicom.Imaging;
using System.Windows.Forms;

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

        /// <summary>
        /// 把Click的點轉成圖像中的像素點
        /// </summary>
        /// <param name="imageBox"></param>
        /// <param name="mouseEventArgs"></param>
        /// <returns></returns>
        public static Point GetImagePointFromImageBox(ImageBox imageBox, MouseEventArgs mouseEventArgs) 
        {
            double zoom = imageBox.ZoomScale;
            Point Result = new Point(0,0);
            //點位跟縮放比例有關西，所以畫面上的點位就是目前滑鼠點位除縮放即可得到大概位置
            Result.X = (int)(mouseEventArgs.Location.X / zoom);
            Result.Y = (int)(mouseEventArgs.Location.Y / zoom);
            //要考慮到如果有ScrollBar就要針對對子去做位移
            int horizontalScrollBarValue = imageBox.HorizontalScrollBar.Visible ? (int)imageBox.HorizontalScrollBar.Value : 0;
            int verticalScrollBarValue = imageBox.VerticalScrollBar.Visible ? (int)imageBox.VerticalScrollBar.Value : 0;
            Result.X += horizontalScrollBarValue;
            Result.Y += verticalScrollBarValue;
            return Result;
        }

        /// <summary>
        /// 調整亮度
        /// </summary>
        /// <param name="Image">影像</param>
        /// <param name="Level">-100~100之間的整數</param>
        /// <returns></returns>
        public static Image<Bgr, Byte> BrightnessLevel(Image<Bgr, Byte> Image, int Level) 
        {
            Image<Bgr,Byte> tempimage = Image.Copy();
            tempimage += Level;
            return tempimage;
        }
        /// <summary>
        /// 調整對比
        /// </summary>
        /// <param name="Image">影像</param>
        /// <param name="Level">-100~100之間的整數</param>
        /// <returns></returns>
        public static Image<Bgr, Byte> ContrastLevel(Image<Bgr, Byte> Image, int Level) 
        {
            //Level為-100~100，所以要映射到0~2之間
            double reallevel = ((Level * -1) + 100) * 0.01;
            Image<Bgr, Byte> tempimage = Image.Copy();
            tempimage._GammaCorrect(reallevel);
            return tempimage;
        }

        /// <summary>
        /// 調整亮度跟暗度
        /// </summary>
        /// <param name="Image">原始圖像</param>
        /// <param name="BrightnessLevel">亮度調整值，-100~100之間</param>
        /// <param name="ContrastLevel">對比度調整值，-100~100之間</param>
        /// <returns>調整後的影像</returns>
        public static Image<Bgr, Byte> BrightnessAndContrast(Image<Bgr, Byte> Image, int BrightnessLevel, int ContrastLevel) 
        {
            throw new NotImplementedException();
        }
    }
}
