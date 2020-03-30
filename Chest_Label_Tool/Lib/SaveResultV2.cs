using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Chest_Label_Tool.Lib
{
    public class SaveResultV2
    {
        //記錄檔案版本
        public string ResultVersion = "2";
        //記錄檔生成時間
        public DateTime SaveTime;
        //檔案名稱(DCM)
        public string ImageFileName_dcm;
        //檔案名稱(JPG)
        public string ImageFileName_jpg;
        //該影像在標記時，亮度偏移值
        public double Optimize_Brightness;
        //該影像在標記時，對比度偏移值
        public double Optimize_Contrast;
        //影像標記點
        public List<Point> KeyPoint;

        public SaveResultV2(string dcmPath,string jpgPath)
        {
            ImageFileName_dcm = dcmPath + ".dcm";
            ImageFileName_jpg = jpgPath + ".jpg";
            KeyPoint = new List<Point>();
        }



        /// <summary>
        /// 將檔案從V1版本轉成V2版本
        /// </summary>
        /// <param name="saveobj"></param>
        /// <returns></returns>
        public static SaveResultV2 Convert(SaveResultV1 saveobj) 
        {
            SaveResultV2 Result = new SaveResultV2(saveobj.FileName,"");
            Result.SaveTime = DateTime.Now;
            Result.KeyPoint = new List<Point>();
            #region 處理塑膠管
            foreach (Point p in saveobj.tube) 
            {
                Result.KeyPoint.Add(p);
            }
            #endregion
            #region 處理氣管分岔
            foreach (List<Point> LP in saveobj.bifurcation)
            {
                foreach (Point p in LP) 
                {
                    Result.KeyPoint.Add(p);
                }
            }
            #endregion
            //巡迴KetPoint後如果點數沒有等於4+3+3+3=13，就代表點數不完整，則遺棄所有的點
            if (Result.KeyPoint.Count == 13) 
            {
                Result.KeyPoint = new List<Point>();
            }
            return Result;
        }
        /// <summary>
        /// 從檔案讀取記錄檔
        /// </summary>
        /// <param name="Path">檔案路徑</param>
        /// <returns></returns>
        public static SaveResultV2 ReadFile(string Path) 
        {
            if (Func.CheckFileExist(Path))
            {
                string str = Func.ReadText(Path);
                string JsonStr = Func.ReadText(Path);
                SaveResultV2 item = JsonConvert.DeserializeObject<SaveResultV2>(JsonStr);
                return item;
            }
            else
            {
                throw new IOException("File Not Fount");
            }
        }
        /// <summary>
        /// 將紀錄檔寫入
        /// </summary>
        /// <param name="Path">路徑</param>
        public static void SaveFile(SaveResultV2 saveobj, string Path) 
        {
            string Jsonstr = JsonConvert.SerializeObject(saveobj);
            Func.WriteText(Path, Jsonstr);
        } 
    }
}
