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
        public string ResultVersion;
        //記錄檔生成時間
        public DateTime SaveTime;
        //檔案名稱(DCM)
        public string ImageFileName;
        //該影像在標記時，亮度偏移值
        public double Optimize_Brightness;
        //該影像在標記時，對比度偏移值
        public double Optimize_Contrast;
        //影像標記點
        public List<Nullable<Point>> KeyPoints;
        //Dcm影像資料
        public DcmInfo Info;

        public SaveResultV2(string FileName)
        {
            ImageFileName = FileName;
            KeyPoints = new List<Nullable<Point>>() { null,null, null, null, null, null, null, null, null, null, null, null, null };
            ResultVersion = "2";
        }



        /// <summary>
        /// 將檔案從V1版本轉成V2版本
        /// </summary>
        /// <param name="saveobj"></param>
        /// <returns></returns>
        public static SaveResultV2 Convert(SaveResultV1 saveobj,DcmInfo info) 
        {
            SaveResultV2 Result = new SaveResultV2(saveobj.FileName);
            Result.SaveTime = DateTime.Now;
            Result.KeyPoints = new List<Nullable<Point>>();
            #region 處理塑膠管
            Result.KeyPoints.AddRange(SaveResultV1.PointConvert(info.Width, info.Height, saveobj.tube));
            //foreach (Point p in saveobj.tube) 
            //{
            //    Result.KeyPoints.Add(p);
            //}
            #endregion
            #region 處理氣管分岔
            foreach (List<Point> LP in saveobj.bifurcation)
            {
                Result.KeyPoints.AddRange(SaveResultV1.PointConvert(info.Width, info.Height, LP));
                //foreach (Point p in LP) 
                //{
                //    Result.KeyPoints.Add(p);
                //}
            }
            #endregion
            //巡迴KetPoint後如果點數沒有等於4+3+3+3=13，就代表點數不完整，則遺棄所有的點
            if (Result.KeyPoints.Count != 13) 
            {
                Result.KeyPoints = new List<Nullable<Point>>();
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
            string prettyJson = JValue.Parse(Jsonstr).ToString(Formatting.Indented);
            Func.WriteText(Path, prettyJson);
        }

        /// <summary>
        /// 檢查是否是第二版本
        /// </summary>
        /// <param name="Jsonstr"></param>
        /// <returns></returns>
        public static bool IsVersion2(string Jsonstr) 
        {
            bool Result = false;
            Result = Jsonstr.Contains("ResultVersion");
            return Result;
        }


        public static string[] KeyPointMean = { "塑膠氣管左上點", "塑膠氣管左下點", "塑膠氣管右下點", "塑膠氣管右上點",
            "氣管分岔左緣上點", "氣管分岔左緣中點", "氣管分岔左緣下點",
            "氣管分岔下緣左點", "氣管分岔下緣中點", "氣管分岔下緣右點",
            "氣管分岔右緣下點", "氣管分岔右緣中點", "氣管分岔右緣上點" };

    }
}
