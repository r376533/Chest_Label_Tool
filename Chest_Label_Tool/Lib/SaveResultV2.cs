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
        //塑膠ㄊ氣管的標記值，4個點位
        public List<Point> PlasticTubeSet;
        //肺部分岔的標記值，共三種(順序分別為左緣，下緣，右緣)，每種都會有三個點，最後呈現9的點為逆時鐘方式記錄
        public List<List<Point>> BifurcationSet;

        public SaveResultV2(string dcmPath,string jpgPath)
        {
            ImageFileName_dcm = FileName + ".dcm";
            ImageFileName_jpg = FileName + ".jpg";
            PlasticTubeSet = new List<Point>();
            BifurcationSet = new List<List<Point>>();
        }



        /// <summary>
        /// 將檔案從V1版本轉成V2版本
        /// </summary>
        /// <param name="saveobj"></param>
        /// <returns></returns>
        public static SaveResultV2 Convert(SaveResultV1 saveobj) 
        {
            SaveResultV2 Result = new SaveResultV2();
            Result.SaveTime = DateTime.Now;
            Result.PlasticTubeSet = saveobj.tube;
            Result.BifurcationSet = saveobj.bifurcation;
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
