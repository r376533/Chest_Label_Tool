using System;
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
    public partial class KeyPointCheckPage : Form
    {
        private delegate void ShowOKMessage();

        private Setting SettingObj;
        private ProcessBarPage ProcessBarPage;
        public KeyPointCheckPage(Setting setting)
        {
            InitializeComponent();
            SettingObj = setting;
        }

        private void KeyPointCheckPage_Load(object sender, EventArgs e)
        {
            ProcessBarPage = new ProcessBarPage();
            ProcessBarPage.Hide();
        }

        private void KeyPointCheckPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //當使用者按下X關閉視窗，真正的行為應該是要隱藏視窗
            e.Cancel = true;
            this.Hide();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string SelectPath = dialog.SelectedPath;
                    txtPath.Text = SelectPath;
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPath.Text)) 
            {
                DirPath = txtPath.Text;
                ProcessBarPage.Show();
                ProcessBarPage.Focus();
                Thread ProcThread = new Thread(ProcessFile);
                ProcThread.Start();
            }
        }



        private string DirPath;
        private void ProcessFile() 
        {
            List<string> Files = Func.GetFilesFromDir(DirPath, "*.json"); 
            List<SaveResultV2> Saves = SaveResultV2.ReadFile(Files);
            ProcessBarPage.SetMaxAndMin(0, Saves.Count);
            for (int i = 0; i < Saves.Count; i++)
            {
                ProcessBarPage.SetProgressValue(i);
                Saves[i].CheckKeyPoints();
                SaveResultV2.SaveFile(Saves[i], Files[i]);
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
                MessageBox.Show("處理完成", "訊息");
            }
        }


    }
}
