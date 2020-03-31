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
        public bool AutoSave;
        #endregion

        #region 影像設定
        public bool AutoChangeType;
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
            }
        }

        /// <summary>
        /// 建立初始化設定檔案
        /// </summary>
        private void Init_Setting() 
        {
            //常規設定
            SavePath = Environment.CurrentDirectory + "\\" + "IMG" ;
            AutoSave = true;
            //影像相關
            AutoChangeType = true;
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
                AutoSave = obj.AutoSave;
                AutoChangeType = obj.AutoChangeType;
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
            string prettyJson = JValue.Parse(jsonstr).ToString(Formatting.Indented);
            Func.WriteText(SettingFileName, prettyJson, IsOverWrite:true);
        }
    }




}
