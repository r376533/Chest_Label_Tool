using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chest_Label_Tool.Lib
{
    public static class Func
    {
        /// <summary>
        /// 檢查該檔案存不存在
        /// </summary>
        /// <param name="Path">目標檔案</param>
        /// <returns>True存在，False不存在</returns>
        public static bool CheckFileExist(string Path) 
        {
            bool Result = false;
            if (File.Exists(Path)) 
            {
                Result = true;
            }
            return Result;
        }
        /// <summary>
        /// 檢查該路徑存不存在，不存在自動生成
        /// </summary>
        /// <param name="Path">目標路徑</param>
        public static void CheckDirExist(string Path) 
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(@Path);   //@表示不考慮溢出位元
            }
        }
        /// <summary>
        /// 將文字寫成檔案
        /// </summary>
        /// <param name="FilePath">目標檔案</param>
        /// <param name="Message">訊息內容</param>
        /// <param name="IsOverWrite">是否複寫</param>
        /// <param name="IsAppend">是否附加訊息</param>
        /// <param name="ChangeLine">在結束時是否換行</param>
        public static void WriteText(string FilePath,string Message,bool IsOverWrite = true,bool IsAppend = false,bool ChangeLine=false) 
        {
            #region 處理檔案是否存在問題
            if (CheckFileExist(FilePath)) 
            {
                //檔案存在
                if (IsOverWrite)
                {
                    //強制複寫，檔案刪除後再建立新檔案
                    System.IO.File.Delete(FilePath);
                }
                else 
                {
                    //不強制複寫
                    if (IsAppend)
                    {
                        //不複寫，附加，直接將檔案開啟後寫入
                    }
                    else
                    {
                        //不複寫，不附加，則退出該子程式
                        return;
                    }
                }
            }
            #endregion
            using (StreamWriter sw = new StreamWriter(FilePath, IsAppend,Encoding.UTF8)) 
            {
                sw.Write(Message);
                if (ChangeLine) 
                {
                    sw.Write(Environment.NewLine);
                }
                sw.Flush();
            }
        }
        /// <summary>
        /// 讀取文字檔案的內容
        /// </summary>
        /// <param name="FilePath">目標檔案</param>
        public static string ReadText(string FilePath) 
        {
            string Result = String.Empty;
            if (CheckFileExist(FilePath)) 
            {
                //如果檔案存在才讀取
                using (StreamReader sr = new StreamReader(FilePath, Encoding.UTF8))
                {
                    Result = sr.ReadToEnd();
                }
            }
            return Result;
        }
        /// <summary>
        /// 計算兩個Point的X、Y移動量
        /// </summary>
        /// <param name="point1">點位1</param>
        /// <param name="point2">點位2</param>
        /// <returns></returns>
        public static int[] TowPointDiff(Point point1, Point point2) 
        {
            int x_diff = point1.X - point2.X;
            int y_diff = point1.Y - point2.Y;
            return new int[2] { x_diff, y_diff };
        }
        /// <summary>
        /// 檢查值是否在某個區間中
        /// </summary>
        /// <param name="CheckValue">要檢查的值</param>
        /// <param name="MaxValue">最大值</param>
        /// <param name="MinValue"></param>
        /// <param name="IsContentMaxMin">是否包含最大值與最小值</param>
        /// <returns></returns>
        public static bool CheckValueIsBetween(int CheckValue, int MaxValue, int MinValue,bool IsContentMaxMin=false) 
        {
            bool Result = false;
            if (IsContentMaxMin)
            {
                Result = CheckValue <= MaxValue && CheckValue >= MinValue ? true : false;
            }
            else 
            {
                Result = CheckValue < MaxValue && CheckValue > MinValue ? true : false;
            }
            return Result;
        }
    }
}
