using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;

using Dicom;
using Dicom.Imaging;


using Chest_Label_Tool.Lib;

namespace Chest_Label_Tool
{
    public partial class Main_UI : Form
    {
        private Setting SettingObj;
        private Setting_UI SettingPage;

        private Image<Bgr, Int32> RightNowImage;

        public Main_UI()
        {
            InitializeComponent();
        }
        private void Main_UI_Load(object sender, EventArgs e)
        {
            SettingObj = new Setting(ConfigurationManager.AppSettings["SettingFileName"]);
            if (SettingPage == null)
            {
                SettingPage = new Setting_UI(SettingObj);
                SettingPage.Hide();
            }
        }

        private void tbOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "*.dcm|*.dcm|All File(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string dcmFilePath = dialog.FileName;
                    string dcmFileName = System.IO.Path.GetFileNameWithoutExtension(dcmFilePath);
                    string targetFileName = dcmFileName + ".jpg";
                    //檢查存檔路徑是否跟讀取影像有相同的影像，如果有則直接載入影像，如果沒有則轉檔載入
                    string targetFilePath = Path.Combine(SettingObj.SavePath, targetFileName);
                    if (!Func.CheckFileExist(targetFilePath)) 
                    {
                        //檔案不存在
                        string jpgFilePath = Image_Func.DcmToJPG(dcmFilePath, SettingObj.SavePath);
                        targetFilePath = jpgFilePath;
                    }
                    //顯示在ImageBox
                    cvImageBox.Image = Image.FromFile(targetFilePath);
                }
            }
        }

        private void tbSettingPage_Click(object sender, EventArgs e)
        {
            //打開系統設定UI
            SettingPage.Show();
        }
        private void panAndZoomPictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (RightNowImage != null)
            {
                MouseEventArgs MouseEvent = (MouseEventArgs)e;
                string mess = String.Format("{0}\n{1}", MouseEvent.Location.ToString(), cvImageBox.ZoomScale);
                MessageBox.Show(mess, "Point", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
