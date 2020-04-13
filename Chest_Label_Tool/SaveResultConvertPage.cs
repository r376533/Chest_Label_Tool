using System;
using System.IO;
using System.Threading;
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
        private ProcessBarPage ProcessBarPage;

        private string SourcePath;
        private List<string> DcmNotExistPath;

        private delegate void ShowOKMessage();

        public SaveResultConvertPage(Setting setting)
        {
            InitializeComponent();
            SettingObj = setting;
        }
        

        private void SaveResultConvertPage_Load(object sender, EventArgs e)
        {

            #region 隱藏放大視窗按鈕
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            #endregion
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

            BtnStartProcess.Enabled = Result;
        }

        private void BtnStartProcess_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSourcePath.Text)) 
            {
                this.SourcePath = txtSourcePath.Text;
                ProcessBarPage = new ProcessBarPage();
                ProcessBarPage.Show();
                ProcessBarPage.Focus();
                Thread thread = new Thread(ConvertThread);
                thread.Start();
            }
        }


        public void ConvertThread() 
        {
            if (String.IsNullOrEmpty(SourcePath)) 
            {
                return;
            }

            //準備資料
            string JsonSourcePath = this.SourcePath;
            string BackupPath = System.IO.Path.Combine(JsonSourcePath, "BackUp");
            Func.CheckDirExist(BackupPath);
            string SourceFilePatten = "*.json";
            List<string> JsonFilePathSet = Func.GetFilesFromDir(JsonSourcePath, SourceFilePatten, true);
            ProcessBarPage.SetMaxAndMin(0, JsonFilePathSet.Count);
            ProcessBarPage.SetProgressValue(0);
            DcmNotExistPath = new List<string>();


            #region 開始轉換

            #endregion
            for (int i = 0; i < JsonFilePathSet.Count; i++)
            {
                ProcessBarPage.SetProgressValue(i);
                string JsonFilePath = JsonFilePathSet[i];
                string ImageFileNameWithOutExt = System.IO.Path.GetFileNameWithoutExtension(JsonFilePath);
                string DcmFilePath = JsonFilePath.Substring(0, JsonFilePath.Length - 5) + ".dcm";
                DcmInfo TempDcmInfo;
                if (Func.CheckFileExist(DcmFilePath))
                {
                    TempDcmInfo = Image_Func.DcmDetailData(DcmFilePath);
                }
                else 
                {
                    //如果Json路徑下沒有dcm檔案則跳過此次轉換
                    DcmNotExistPath.Add(JsonFilePath);
                    continue;
                }
                #region 備份檔案到備份路徑
                string V1LogStr = Func.ReadText(JsonFilePath);
                string BackUpPath = System.IO.Path.Combine(BackupPath, ImageFileNameWithOutExt + ".json");
                Func.WriteText(BackUpPath, V1LogStr);
                #endregion
                //讀取V1檔案
                SaveResultV1 V1Log = SaveResultV1.ReadFile(JsonFilePath);
                //轉V2
                SaveResultV2 V2Log = SaveResultV2.Convert(V1Log, TempDcmInfo);
                //複寫V1版本
                SaveResultV2.SaveFile(V2Log, JsonFilePath);

            }
            ProcessBarPage.CloseWindows();
            OK();

        }


        private void OK() 
        {
            if (this.InvokeRequired)
            {
                ShowOKMessage ok = new ShowOKMessage(OK);
                this.Invoke(ok);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (DcmNotExistPath.Count > 0)
                {
                    sb.Append("以下檔案在JSON檔的相同路徑找不到檔案" + Environment.NewLine);
                    foreach (string ErrorPath in DcmNotExistPath)
                    {
                        sb.Append(String.Format("{0}{1}", ErrorPath, Environment.NewLine));
                    }
                    string ReightNowWorkPath = Directory.GetCurrentDirectory();
                    string ErrorWorkPath = String.Format("ConvertError_{0}.txt", DateTime.Now.ToString("yyyyMMddHHmm"));
                    string ErrorLogPath = Path.Combine(ReightNowWorkPath, ErrorWorkPath);
                    Func.WriteText(ErrorLogPath, sb.ToString());
                    MessageBox.Show(sb.ToString(), "錯誤訊息",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else 
                {
                    MessageBox.Show("處理完成", "訊息");
                }
            }
        }


    }
}
