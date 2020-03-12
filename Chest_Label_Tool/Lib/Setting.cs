using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;




namespace Chest_Label_Tool.Lib
{
    public class Setting
    {
        public string SettingFileName;

        #region 常規設定
        public string SavePath;
        #endregion

        #region 影像設定

        #endregion

        public Setting(string SettingFile)
        {
            SettingFileName = SettingFile;
            if (!String.IsNullOrEmpty(SettingFileName)) 
            {
                if (!File.Exists(SettingFile))
                {
                    //設定檔案不存在，建立新的設定檔案並且存檔
                    Init_Setting();
                    Save_Setting();
                }
                else
                {
                    //設定檔案存在，載入設定檔案
                    Load_Setting();
                }
                Check_Setting();
            }
        }



        /// <summary>
        /// 建立初始化設定檔案
        /// </summary>
        private void Init_Setting() 
        {
            SavePath = Environment.CurrentDirectory + "\\" + "IMG" ;
            
            
        }

        /// <summary>
        /// 讀取設定檔案
        /// </summary>
        private void Load_Setting() 
        {
            string jsonstr = Func.ReadText(SettingFileName);
            if (!String.IsNullOrEmpty(jsonstr))
            {
                //不是空檔案
                Setting obj = JsonConvert.DeserializeObject<Setting>(jsonstr);
                SavePath = obj.SavePath;
            }
            else 
            {
                //空檔案，直接初始化
                Init_Setting();
            }
        }
        /// <summary>
        /// 將設定檔案寫入硬碟
        /// </summary>
        public void Save_Setting() 
        {
            string jsonstr = JsonConvert.SerializeObject(this);
            Func.WriteText(SettingFileName, jsonstr,IsOverWrite:true);
        }
        /// <summary>
        /// 檢查設定檔的內容是否合理
        /// </summary>
        private void Check_Setting() 
        {
            #region 檢查存檔路徑是否存在
            Func.CheckDirExist(SavePath);
            #endregion
        }
    }




}
