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
        }

        private void Setting_UI_Load(object sender, EventArgs e)
        {

            SettingInit();
        }

        

        private void Setting_UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //當使用者按下X關閉視窗，真正的行為應該是要隱藏視窗
            e.Cancel = true;
            this.Hide();
            //對目前畫面上所有設定值紀錄
            ReLoadSetting();
            SettingObj.Save_Setting();
        }


        /// <summary>
        /// 將設定檔載入畫面
        /// </summary>
        private void SettingInit()
        {
            ST_TP_NOR_txtSavePath.Text = SettingObj.SavePath;
        }


        private void ReLoadSetting() 
        {
            SettingObj.SavePath = ST_TP_NOR_txtSavePath.Text;
        }
    }
}
