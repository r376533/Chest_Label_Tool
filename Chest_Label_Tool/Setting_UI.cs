using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Chest_Label_Tool.Lib;

namespace Chest_Label_Tool
{
    public partial class Setting_UI : Form
    {
        public Setting SettingObj;
        public Setting_UI(Setting settingobj)
        {
            InitializeComponent();
            SettingObj = settingobj;
            SettingInit();
        }



        /// <summary>
        /// 將設定檔載入畫面
        /// </summary>
        private void SettingInit() 
        {
            ST_TP_NOR_txtSavePath.Text = SettingObj.SavePath;
        }
    }
}
