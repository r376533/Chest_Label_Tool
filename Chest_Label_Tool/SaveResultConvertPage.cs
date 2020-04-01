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
    public partial class SaveResultConvertPage : Form
    {
        private Setting SettingObj;
        public SaveResultConvertPage(Setting setting)
        {
            InitializeComponent();
            SettingObj = setting;
        }
        

        private void SaveResultConvertPage_Load(object sender, EventArgs e)
        {
            txtSourcePath.Text = "";
            txtTargetPath.Text = "";
            cbIsOverWrite.Checked = false;
        }

        private void SaveResultConvertPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //當使用者按下X關閉視窗，真正的行為應該是要隱藏視窗
            e.Cancel = true;
            this.Hide();
        }

        private void btnSourcePathBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()) 
            {
                if (dialog.ShowDialog() == DialogResult.OK) 
                {
                    string SelectPath = dialog.SelectedPath;
                    txtSourcePath.Text = SelectPath;
                }
            }
            CheckProcButtonIsAvalible();
        }

        private void btnTargetPathBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string SelectPath = dialog.SelectedPath;
                    txtTargetPath.Text = SelectPath;
                }
            }
            CheckProcButtonIsAvalible();
        }
        private void cbIsOverWrite_CheckedChanged(object sender, EventArgs e)
        {
            CheckProcButtonIsAvalible();
        }

        /// <summary>
        /// 檢查是否可以執行
        /// </summary>
        private void CheckProcButtonIsAvalible() 
        {
            bool Result = true;
            #region 檢查來源
            if (Result && String.IsNullOrEmpty(txtSourcePath.Text)) 
            {
                Result = false;
            }
            #endregion

            #region 檢查輸出
            if (Result) 
            {
                if (!cbIsOverWrite.Checked && String.IsNullOrEmpty(txtTargetPath.Text)) 
                {
                    Result = false;
                }
            }
            #endregion
            BtnStartProcess.Enabled = Result;
        }

        private void BtnStartProcess_Click(object sender, EventArgs e)
        {
            string SourcePath = txtSourcePath.Text;
            string SourceFilePatten = "*.json";
            string TargetPath = txtTargetPath.Text;
            Color temp = this.BackColor;
            this.BackColor = Color.Red;
            List<string> JsonFilePathSet = new List<string>();

            #region 從來源資料夾遞迴搜尋所有json檔案(限定V1)
            JsonFilePathSet = Func.GetFilesFromDir(SourcePath, SourceFilePatten, true);
            #endregion

            //ConvertJPGToDir(JsonFilePathSet);
            List<SaveResultV2> LabelSet = ConvertFile(JsonFilePathSet);
            
            SaveLog(LabelSet, JsonFilePathSet);
            this.BackColor = temp;
            MessageBox.Show(String.Format("已經處理完成共 {0} 個", LabelSet.Count) , "批次轉換", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ConvertJPGToDir(List<string> Paths) 
        {
            string JPGDirPath = SettingObj.SavePath;
            foreach (string str in Paths) 
            {
                string FileName = System.IO.Path.GetFileNameWithoutExtension(str);
                string DcmFilePath = str.Substring(0, str.Length - 5) + ".dcm";
                string DCMTargetFilePath = str; //要複寫的
                Image_Func.DcmToJPG(DcmFilePath, JPGDirPath);
            }
        }


        /// <summary>
        /// 批次將Json檔案轉成SaveResultV2
        /// </summary>
        /// <param name="Paths">路徑集合</param>
        /// <returns></returns>
        private List<SaveResultV2> ConvertFile(List<string> Paths) 
        {
            List<SaveResultV2> Set = new List<SaveResultV2>();
            foreach (var path in Paths)
            {
                string dcmpath = path.Substring(0, path.Length - 5) + ".dcm";
                DcmInfo info = Image_Func.DcmDetailData(dcmpath);
                SaveResultV1 temp = SaveResultV1.ReadFile(path);
                SaveResultV2 newitem = SaveResultV2.Convert(temp, info);
                newitem.Optimize_Brightness = 0;
                newitem.Optimize_Contrast = 0;
                newitem.Info = info;
                Set.Add(newitem);
            }
            return Set;
        }

        private void SaveLog(List<SaveResultV2> LabelSet,List<string> JsonFilePathSet) 
        {
            if (cbIsOverWrite.Checked) 
            {
                //如果要複寫檔案
                for (int i = 0; i < JsonFilePathSet.Count; i++)
                {
                    string path = JsonFilePathSet[i];
                    SaveResultV2.SaveFile(LabelSet[i], path);
                }
            }
            if (!String.IsNullOrEmpty(txtTargetPath.Text)) 
            {
                foreach (SaveResultV2 Label in LabelSet) 
                {
                    string FileName = System.IO.Path.GetFileNameWithoutExtension(Label.ImageFileName);
                    string TargetFileName = System.IO.Path.Combine(txtTargetPath.Text, FileName + ".json");
                    SaveResultV2.SaveFile(Label, TargetFileName);
                }
            }

            if (!String.IsNullOrEmpty(SettingObj.SavePath)) 
            {
                for (int i = 0; i < JsonFilePathSet.Count; i++)
                {
                    string FileName = System.IO.Path.GetFileNameWithoutExtension(JsonFilePathSet[i]);
                    string TargetFileName = System.IO.Path.Combine(SettingObj.SavePath, FileName + ".json");
                    SaveResultV2.SaveFile(LabelSet[i], TargetFileName);
                }
            }

        }

    }
}
