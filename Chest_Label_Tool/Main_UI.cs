using System;
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

        public Main_UI()
        {
            InitializeComponent();
            SettingObj = new Setting(ConfigurationManager.AppSettings["SettingFileName"]);
            if (SettingPage == null) 
            {
                SettingPage = new Setting_UI(SettingObj);
                SettingPage.Show();
            }

        }

        private void tbOpenFile_Click(object sender, EventArgs e)
        {

            //using (OpenFileDialog dialog = new OpenFileDialog()) 
            //{
            //    dialog.Filter = "*.dcm|*.dcm|All File(*.*)|*.*";
            //    if (dialog.ShowDialog() == DialogResult.OK) 
            //    {
            //        Image<Gray, Int16> img = new Image<Gray, short>(dialog.FileName);
            //        cvibImage.Image = img;
            //    }
            //}
            string FileName = "Z070001.dcm";
            var dcmimage = new DicomImage(FileName);
            dcmimage.RenderImage().AsBitmap().Save("Rander.jpg");
            MessageBox.Show("OK", "OK");
        }

        private void tbSettingPage_Click(object sender, EventArgs e)
        {
            //打開系統設定UI

        }
    }
}
