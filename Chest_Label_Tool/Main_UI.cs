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

        private Image<Bgr, Byte> RightNowImage, OriginalImage;

        public Main_UI()
        {
            InitializeComponent();
        }
        private void Main_UI_Load(object sender, EventArgs e)
        {
            #region 設定
            SettingObj = new Setting(ConfigurationManager.AppSettings["SettingFileName"]);
            if (SettingPage == null)
            {
                SettingPage = new Setting_UI(SettingObj);
                SettingPage.Hide();
            }
            #endregion
            #region ActionGroup

            #endregion
        }



        #region ToolBar
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
                    Image<Bgr,Byte> img = new Image<Bgr, Byte>(targetFilePath);
                    SettingImage(img);
                    
                }
            }
        }

        private void tbSettingPage_Click(object sender, EventArgs e)
        {
            //打開系統設定UI
            SettingPage.Show();
        }
        #endregion

        #region cvImageBox
        private void panAndZoomPictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (RightNowImage != null)
            {
                MouseEventArgs MouseEvent = (MouseEventArgs)e;
                string mess = String.Format("{0}\n{1}", MouseEvent.Location.ToString(), cvImageBox.ZoomScale);
                MessageBox.Show(mess, "Point", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cvImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (cvImageBox.Image != null)
            {
                Point ImagePoint = Image_Func.GetImagePointFromImageBox(cvImageBox, e);
                MessageBox.Show(ImagePoint.ToString(), "OK");
            }
        }

        /// <summary>
        /// 設定影像到ImageBox
        /// </summary>
        /// <param name="Img">影像</param>
        /// <param name="Img">是否經過編輯</param>
        private void SettingImage(Image<Bgr, Byte> Img) 
        {
            RightNowImage = Img;
            OriginalImage = Img;
            Size ImageWindoeSize = cvImageBox.Size;
            Size ImageSize = RightNowImage.Size;
            double X_Zoom_Rate = (double)ImageWindoeSize.Width / (double)ImageSize.Width;
            double Y_Zoom_Rate = (double)ImageWindoeSize.Height / (double)ImageSize.Height;
            double Final_Zoom_Rate = (X_Zoom_Rate + Y_Zoom_Rate) / 2;
            cvImageBox.Image = RightNowImage;
            cvImageBox.SetZoomScale(Final_Zoom_Rate, new Point(ImageWindoeSize.Width / 2, ImageWindoeSize.Height / 2));
            cvImageBox.HorizontalScrollBar.Visible = true;
            cvImageBox.VerticalScrollBar.Visible = true;
            AdjustmentGroup.Enabled = true;
            ActionGroup.Enabled = true;
        }

        #endregion

        #region 影像微調設定

        private void AdjustmentInit(bool IsEnable) 
        {
            AdjustmentGroup.Enabled = IsEnable;

            if (IsEnable) 
            {
                trbImageBrightness.Value = 0;
                trbImageContrast.Value = 0;
            }
        }

        private void trbImageBrightness_Scroll(object sender, EventArgs e)
        {
            if (RightNowImage != null) 
            {
                int Blevel = trbImageBrightness.Value;
                int Clevel = trbImageContrast.Value;
                AdjustmentImage(OriginalImage, Clevel, Blevel);
            }
        }
        private void btnImageBrightnessReset_Click(object sender, EventArgs e)
        {
            trbImageBrightness.Value = 0;
            //要觸發亮度調整的方法
            trbImageBrightness_Scroll(null,null);
        }
        private void trbImageContrast_Scroll(object sender, EventArgs e)
        {
            if (RightNowImage != null)
            {
                int Blevel = trbImageBrightness.Value;
                int Clevel = trbImageContrast.Value;
                AdjustmentImage(OriginalImage, Clevel, Blevel);
            }
        }
        private void btnImageContrastReset_Click(object sender, EventArgs e)
        {
            trbImageContrast.Value = 0;
            //要觸發對比度調整的方法
            trbImageContrast_Scroll(null, null);
        }

        private void AdjustmentImage(Image<Bgr,Byte> Image,int Contrast, int Brightness) 
        {
            Image<Bgr, Byte> after = Image_Func.BrightnessAndContrast(Image, Brightness, Contrast);
            RightNowImage = after;
            cvImageBox.Image = after;
        }
        #endregion

    }
}
