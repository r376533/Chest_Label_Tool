using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="IsAppend">是否附加訊息</param>
        /// <param name="ChangeLine">在結束時是否換行</param>
        public static void WriteText(string FilePath,string Message,bool IsAppend = false,bool ChangeLine=false) 
        {
            if (CheckFileExist(FilePath)) 
            {
                //檔案如果存在，則要檢查是否附加，不附加則程式直接跳出
                if (!IsAppend) 
                {
                    return;
                }
            }
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
    }
}
