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
            //常規
            ST_TP_NOR_txtSavePath.Text = SettingObj.SavePath;
            cbAutoSave.Checked = SettingObj.AutoSave;
            //影像設定
            //npPlasticTubeCount.Value = SettingObj.PlasticTubeCount;
            //npTracheaLeftCount.Value = SettingObj.TracheaLeftCount;
            //npTracheaButtomCount.Value = SettingObj.TracheaButtomCount;
            //npTracheaRightCount.Value = SettingObj.TracheaRightCount;
            cbAutoChangeType.Checked = SettingObj.AutoChangeType;
        }


        private void ReLoadSetting() 
        {
            //常規
            SettingObj.SavePath = ST_TP_NOR_txtSavePath.Text;
            SettingObj.AutoSave = cbAutoSave.Checked;
            //影像設定
            //SettingObj.PlasticTubeCount = (int)npPlasticTubeCount.Value;
            //SettingObj.TracheaLeftCount = (int)npTracheaLeftCount.Value;
            //SettingObj.TracheaButtomCount = (int)npTracheaButtomCount.Value;
            //SettingObj.TracheaRightCount = (int)npTracheaRightCount.Value;
            SettingObj.AutoChangeType = cbAutoChangeType.Checked;
        }
    }
}
