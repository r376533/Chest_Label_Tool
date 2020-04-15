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
using System.Drawing.Imaging;

namespace Chest_Label_Tool.Lib
{
    public static class Image_Func
    {
        /// <summary>
        /// 抓出dcm的細節資料
        /// </summary>
        /// <param name="DcmPath"></param>
        public static DcmInfo DcmDetailData(string DcmPath) 
        {
            DicomImage dcmimage = new DicomImage(DcmPath);
            string Spacing = "";
            try
            {
                Spacing = dcmimage.Dataset.GetValue<string>(DicomTag.PixelSpacing, 0);
            }
            catch 
            {
                Spacing = "0.139";
            }
            DcmInfo info = new DcmInfo() 
            {
                Height = dcmimage.Height,
                Width = dcmimage.Width,
                scale = Convert.ToDouble(Spacing)
        };
            return info;
        }

        /// <summary>
        /// 將Dcm檔案轉成jpg
        /// </summary>
        /// <param name="DcmPath">Dcm的檔案路徑</param>
        /// <param name="TargetPath">存檔路徑</param>
        /// <param name="TargetFileName">轉換後的檔案名稱，若放null或空字元，則與Dcm檔案同名稱</param>
        /// <returns>檔案存檔後的絕對位址，如果回傳空字串則表示存檔失敗</returns>
        public static string DcmToPNG(string DcmPath,string TargetPath,string TargetFileName="") 
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
                    resultfilename = FileName+".png";
                }
                string finalpath = Path.Combine(TargetPath, resultfilename);
                //檔案名稱不為異常才可以轉換
                DicomImage dcmimage = new DicomImage(DcmPath);
                dcmimage.RenderImage().AsClonedBitmap().Save(finalpath, ImageFormat.Png);
                Result = finalpath;
            }
            return Result;
        }

        /// <summary>
        /// 把Click的點轉成圖像中的像素點
        /// </summary>
        /// <param name="imageBox"></param>
        /// <param name="MousePoint"></param>
        /// <returns></returns>
        public static Point GetImagePointFromImageBox(ImageBox imageBox, Point MousePoint) 
        {
            double zoom = imageBox.ZoomScale;
            Point Result = new Point(0,0);
            //點位跟縮放比例有關西，所以畫面上的點位就是目前滑鼠點位除縮放即可得到大概位置
            Result.X = (int)(MousePoint.X / zoom);
            Result.Y = (int)(MousePoint.Y / zoom);
            //要考慮到如果有ScrollBar就要針對對子去做位移
            int horizontalScrollBarValue = imageBox.HorizontalScrollBar.Visible ? (int)imageBox.HorizontalScrollBar.Value : 0;
            int verticalScrollBarValue = imageBox.VerticalScrollBar.Visible ? (int)imageBox.VerticalScrollBar.Value : 0;
            Result.X += horizontalScrollBarValue;
            Result.Y += verticalScrollBarValue;
            return Result;
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
            //Level為-100~100，所以要映射到0~2之間
            double reallevel = ((ContrastLevel) + 100) * 0.01;
            Image<Bgr, Byte> tempimage = Image.Copy();
            //調整對比度
            tempimage = tempimage * reallevel;
            //調整亮度
            tempimage = tempimage + BrightnessLevel;
            return tempimage;
        }

        /// <summary>
        /// 畫點
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Image<Bgr, Byte> DrawPoint(ref Image<Bgr, Byte> Image, Point point,Bgr DrawColor) 
        {
            //打點是pixel的，對於圖片太小，所以要以要打的點為中心，向外畫框框，即是打點
            //Shift是擴散pixel量
            int Shift = 15;
            //擴散後的實際左上角的點
            int LeftTop_X = point.X - Shift;
            int LeftTop_Y = point.Y - Shift;
            Point LeftTop = new Point(LeftTop_X > 0 ? LeftTop_X : 0, LeftTop_Y > 0 ? LeftTop_Y : 0);
            Image<Bgr, Byte> img = Image;

            Rectangle rect = new Rectangle(LeftTop.X, LeftTop_Y, Shift * 2, Shift * 2 );
            img.Draw(rect, DrawColor, -1);
            return img;
        }

        /// <summary>
        /// 畫線
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="DrawColor"></param>
        /// <returns></returns>
        public static Image<Bgr, Byte> DrawLine(ref Image<Bgr, Byte> Image, Point point1, Point point2, Bgr DrawColor) 
        {
            Image<Bgr, Byte> img = Image;
            LineSegment2D line = new LineSegment2D(point1, point2);
            img.Draw(line, DrawColor,10);
            return img;
        }

        /// <summary>
        /// 取得倆的點的直線距離
        /// </summary>
        /// <param name="P1"></param>
        /// <param name="P2"></param>
        /// <returns></returns>
        public static double GetDistance(Point P1, Point P2)
        {
            double x_diff = Math.Pow(P1.X - P2.X, 2);
            double y_diff = Math.Pow(P1.Y - P2.Y, 2);
            double dis = Math.Pow(x_diff + y_diff, 0.5);
            return dis;
        }
    }
}
