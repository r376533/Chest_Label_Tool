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
    public class SaveResultV1
    {
        /// <summary>
        /// 時間格式為yyyyMMdd-hhmmss
        /// </summary>
        public string SaveTime;
        /// <summary>
        /// 影像檔的路徑(因為只有在標記電腦上有意義，第二個版本取消掉)
        /// </summary>
        public string FileName;
        /// <summary>
        /// 塑膠氣管
        /// </summary>
        public List<Point> tube;
        /// <summary>
        /// 氣管分岔
        /// </summary>
        public List<List<Point>> bifurcation;

        /// <summary>
        /// 把檔案裡面的字串轉成出版存檔類型
        /// </summary>
        /// <param name="str">Json字串</param>
        /// <returns></returns>
        public static SaveResultV1 ConvertSaveFile(string str) 
        {
            SaveResultV1 Result = new SaveResultV1();
            if (!String.IsNullOrEmpty(str))
            {
                JObject obj = JObject.Parse(str);
                Result.SaveTime = obj["info"]["save_time"].ToString();
                Result.FileName = obj["info"]["file_name"].ToString();

                #region 讀取Tube
                List<Point> temptube = new List<Point>();
                JArray items = (JArray)obj["labels"]["tube"]["lines"][0];  //默認塑膠氣管只會有一組
                foreach (var item in items)
                {
                    //item是一個Tuple
                    var x = Convert.ToDouble(item[0]);
                    var y = Convert.ToDouble(item[1]);
                    x = (int)Math.Round(x);
                    y = (int)Math.Round(y);
                    Point tempPoint = new Point((int)x, (int)y);
                    temptube.Add(tempPoint);
                }
                Result.tube = temptube;
                #endregion

                #region 讀取Bifurcation
                List<List<Point>> tempbifurcation = new List<List<Point>>();
                foreach (JArray bifurcations in obj["labels"]["bifurcation"]["lines"]) 
                {
                    //巡迴每個氣管分岔的點位
                    //默認0為左緣,1為下緣,2為右緣
                    List<Point> temppoint = new List<Point>();
                    foreach (var item in bifurcations)
                    {
                        var x = Convert.ToDouble(item[0]);
                        var y = Convert.ToDouble(item[1]);
                        x = (int)Math.Round(x);
                        y = (int)Math.Round(y);
                        Point tempPoint = new Point((int)x, (int)y);
                        temppoint.Add(tempPoint);
                    }
                    tempbifurcation.Add(temppoint);
                }
                Result.bifurcation = tempbifurcation;
                #endregion
            }
            else 
            {
                throw new FormatException("輸入的字串為空字串");
            }
            return Result;
        }
        /// <summary>
        /// 從檔案讀取記錄檔
        /// </summary>
        /// <param name="Path">檔案路徑</param>
        /// <returns></returns>
        public static SaveResultV1 ReadFile(string Path) 
        {
            if (Func.CheckFileExist(Path))
            {
                string str = Func.ReadText(Path);
                SaveResultV1 Log = ConvertSaveFile(str);
                return Log;
            }
            else 
            {
                throw new IOException("File Not Fount");
            }
        }

        /// <summary>
        /// V1的坐標軸轉換
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Ps"></param>
        /// <returns></returns>
        public static List<Nullable<Point>> PointConvert(int Width, int Height, List<Point> Ps)
        {
            List<Nullable<Point>> NewPoint = new List<Nullable<Point>>();
            for (int i = 0; i < Ps.Count; i++)
            {
                if (Ps[i] != null)
                {
                    NewPoint.Add(Real_PointConvert(Width, Height, Ps[i]));
                }
                else 
                {
                    NewPoint.Add(null);
                }
            }
            return NewPoint;

        }
        /// <summary>
        /// V1的坐標軸轉換
        /// </summary>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <param name="Ps"></param>
        /// <returns></returns>
        public static Point Real_PointConvert(int Width, int Height,Point P) 
        {
            int DeltaX = 0, DeltaY = 0;
            if (Width >= 2500) 
            {
                DeltaX = (Width - 2500) / 2;
            }
            if (Height >= 2500)
            {
                DeltaY = (Height - 2500) / 2;
            }
            Point NewP = new Point(P.X + DeltaX, P.Y + DeltaY);
            return NewP;
        }

    }



}
