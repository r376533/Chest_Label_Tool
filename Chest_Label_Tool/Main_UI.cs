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
using static Chest_Label_Tool.Lib.Enums;

namespace Chest_Label_Tool
{
    public partial class Main_UI : Form
    {
        private Setting SettingObj;
        private Setting_UI SettingPage;

        private string ImagePath_Dcm, ImagePath_Jpg;
        private Image<Bgr, Byte> RightNowImage, OriginalImage;
        private Bgr DrawColor;

        private ProgramAction RightNowMode;
        private bool IsInAction;
        private bool IsMouseDown;

        private SaveResultV2 LabelLog;

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
            RightNowMode = ProgramAction.None;
            IsInAction = false;
            IsMouseDown = false;
            #endregion
            DrawColor = new Bgr(0, 0, 255);
        }



        #region ToolBar
        private void tbOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "*.dcm|*.dcm|All File(*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ImagePath_Dcm = dialog.FileName;
                    string dcmFileName = System.IO.Path.GetFileNameWithoutExtension(ImagePath_Dcm);
                    string targetFileName = dcmFileName + ".jpg";
                    //檢查存檔路徑是否跟讀取影像有相同的影像，如果有則直接載入影像，如果沒有則轉檔載入
                    string targetFilePath = Path.Combine(SettingObj.SavePath, targetFileName);
                    if (!Func.CheckFileExist(targetFilePath))
                    {
                        //檔案不存在
                        string jpgFilePath = Image_Func.DcmToJPG(ImagePath_Dcm, SettingObj.SavePath);
                        targetFilePath = jpgFilePath;
                    }
                    ImagePath_Jpg = targetFilePath;
                    //顯示在ImageBox
                    Image<Bgr,Byte> img = new Image<Bgr, Byte>(targetFilePath);
                    SettingImage(img);
                    LoadingLabelFile(ImagePath_Dcm, ImagePath_Jpg);

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
        private void cvImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (cvImageBox.Image != null)
            {
                //抓出影像中的點
                Point ImageLocation = Image_Func.GetImagePointFromImageBox(cvImageBox, e);
                switch (RightNowMode) 
                {
                    case ProgramAction.Zoom:
                        break;
                    case ProgramAction.Select:
                        break;
                    case ProgramAction.Point:

                        break;
                }
            }
        }
        private void cvImageBox_MouseEnter(object sender, EventArgs e)
        {
            if (cvImageBox.Image != null) 
            {
                IsInAction = true;
                lblDebug.Text = "Action Enter";
                switch (RightNowMode)
                {
                    case ProgramAction.Zoom:
                        cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
                        break;
                }
            }
        }

        private void cvImageBox_MouseLeave(object sender, EventArgs e)
        {
            if (cvImageBox.Image != null)
            {
                IsInAction = false;
                cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
                lblDebug.Text = "Action Leave";
                switch (RightNowMode)
                {
                    case ProgramAction.Zoom:
                        
                        break;
                }
            }
        }

        private void cvImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (cvImageBox.Image != null)
            {
                lblDebug.Text = "Action Mouse Down";
                IsMouseDown = true;
            }
        }

        private void cvImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (cvImageBox.Image != null && IsInAction && IsMouseDown)
            {
                //當前有圖片且有按下滑鼠時
                lblDebug.Text = "Action Mouse Down";
                int RightNowXValue = cvImageBox.HorizontalScrollBar.Value;
                int RightNowYValue = cvImageBox.HorizontalScrollBar.Value;
                int MaxXValue = cvImageBox.HorizontalScrollBar.Maximum;
                int MinXValue = cvImageBox.HorizontalScrollBar.Minimum;
                int MaxYValue = cvImageBox.VerticalScrollBar.Maximum;
                int MinYValue = cvImageBox.VerticalScrollBar.Minimum;
                double ZoomRate = cvImageBox.ZoomScale;
                switch (RightNowMode)
                {

                }
            }
        }

        private void cvImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (cvImageBox.Image != null)
            {
                lblDebug.Text = "Action Mouse Down";
                IsMouseDown = false;
                switch (RightNowMode)
                {

                }
            }
        }
        /// <summary>
        /// 設定影像到ImageBox
        /// </summary>
        /// <param name="Img">影像</param>
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
            cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            AdjustmentGroup.Enabled = true;
            ActionGroup.Enabled = true;
            cbAction.SelectedIndex = 0;

        }


        private void DrawPoint() 
        {
            


            Image<Bgr, Byte> Image = Image_Func.DrawPoint(OriginalImage, point, color);
            
            RightNowImage = Image;
            cvImageBox.Image = RightNowImage;
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

        private void cbAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Action發生更動的話要處理的事情
            int index = cbAction.SelectedIndex;
            switch (index) 
            {
                case 0:
                    RightNowMode = ProgramAction.Zoom;
                    break;
                case 1:
                    RightNowMode = ProgramAction.Select;
                    break;
                case 2:
                    RightNowMode = ProgramAction.Point;
                    break;
                default:
                    RightNowMode = ProgramAction.None;
                    break;
            }
            lblDebug.Text = GetDescription(RightNowMode);
        }

        

        private void AdjustmentImage(Image<Bgr,Byte> Image,int Contrast, int Brightness) 
        {
            Image<Bgr, Byte> after = Image_Func.BrightnessAndContrast(Image, Brightness, Contrast);
            RightNowImage = after;
            cvImageBox.Image = after;
        }
        #endregion

        #region 標籤記錄檔
        /// <summary>
        /// 載入標籤紀錄檔的方法
        /// </summary>
        /// <param name="DcmImagePath"></param>
        private void LoadingLabelFile(string DcmImagePath,string JPGImagePath) 
        {
            string TargetPath = String.Empty ;
            //先檢查紀錄檔案的路徑
            #region 判斷路徑，最後會把決定好要讀檔的路徑放在TargetPath
            if (!String.IsNullOrEmpty(DcmImagePath) && !String.IsNullOrEmpty(JPGImagePath))
            {
                string dcmLabelLogPath = DcmImagePath.Remove(DcmImagePath.Length - 4, 4) + ".json";
                string jpgLabelLogPath = JPGImagePath.Remove(JPGImagePath.Length - 4, 4) + ".json";
                if (Func.CheckFileExist(dcmLabelLogPath))
                {
                    TargetPath = dcmLabelLogPath;
                }
                else if (Func.CheckFileExist(jpgLabelLogPath))
                {
                    TargetPath = jpgLabelLogPath;
                }
                else 
                {
                    //該影像沒有紀錄檔
                }
            }
            else 
            {
                return;
            }
            #endregion

            if (!String.IsNullOrEmpty(TargetPath))
            {
                LabelLog = SaveResultReader.ReadFromFile(TargetPath);
            }
            else 
            {
                LabelLog = new SaveResultV2(DcmImagePath, JPGImagePath);
            }
            LabelLogReLoad();
        }

        /// <summary>
        /// 將Label的紀錄讀取回去
        /// </summary>
        private void LabelLogReLoad() 
        {
            SaveResultV2 Log = LabelLog;
            Image<Bgr,Byte> Img = OriginalImage.Copy();
            if (Log != null) 
            {
                List<Point> TubeSet = Log.PlasticTubeSet;
                List<List<Point>> BifurcationSet = Log.BifurcationSet;
                #region 讀取塑膠氣管
                if (TubeSet != null && TubeSet.Count > 0)
                {
                    for (int i = 0; i < TubeSet.Count; i++)
                    {
                        Point p = TubeSet[i];
                        Img = Image_Func.DrawPoint(Img, p, DrawColor);
                        if (i > 0) 
                        {
                            Img = Image_Func.DrawLine(Img,p, TubeSet[i-1],DrawColor);
                        }
                    }
                }
                #endregion

                #region 讀取肺部分岔
                if (BifurcationSet != null && BifurcationSet.Count > 0)
                {
                    foreach (List<Point> Bifurcation in BifurcationSet)
                    {
                        //巡迴氣管分岔，依序是左緣，下緣，右緣
                        for (int i = 0; i < Bifurcation.Count; i++)
                        {
                            //巡迴標記點，用逆時鐘的方式
                            Point p = Bifurcation[i];
                            Img = Image_Func.DrawPoint(Img, p, DrawColor);
                            if (i > 0)
                            {
                                Img = Image_Func.DrawLine(Img, p, TubeSet[i - 1], DrawColor);
                            }
                        }
                    }
                }
                #endregion

            }
            RightNowImage = Img;
            cvImageBox.Image = RightNowImage;
        }

        /// <summary>
        /// 存入目前的紀錄檔
        /// </summary>
        private void SaveLabelFile() 
        {
        
        }
        #endregion

        #region 處理標記
        /// <summary>
        /// 檢查目前標記的點是哪個點
        /// </summary>
        /// <returns></returns>
        private string GetRightNowPointInfo() 
        {
            string Result = "";
            List<Point> TubeSet = LabelLog.PlasticTubeSet;
            List<List<Point>> BifurcationSet = LabelLog.BifurcationSet;
            switch (TubeSet.Count) 
            {
                case 0:
                    Result = "塑膠氣管左上";
                    break;
                case 1:
                    Result = "塑膠氣管左下";
                    break;
                case 2:
                    Result = "塑膠氣管右下";
                    break;
                case 3:
                    Result = "塑膠氣管右上";
                    break;
            }
            if (Result == "") 
            {
                switch (BifurcationSet.Count) 
                {
                    case 0:
                        Result = "氣管左緣";
                        switch (BifurcationSet[0].Count) 
                        {
                            case 0:
                                Result += "上點";
                                break;
                            case 1:
                                Result += "中點";
                                break;
                            case 2:
                                Result += "下點";
                                break;
                        }
                        break;
                    case 1:
                        Result = "氣管下緣";
                        switch (BifurcationSet[0].Count)
                        {
                            case 0:
                                Result += "左點";
                                break;
                            case 1:
                                Result += "中點";
                                break;
                            case 2:
                                Result += "右點";
                                break;
                        }
                        break;
                    case 2:
                        Result = "氣管右緣";
                        switch (BifurcationSet[0].Count)
                        {
                            case 0:
                                Result += "下點";
                                break;
                            case 1:
                                Result += "中點";
                                break;
                            case 2:
                                Result += "上點";
                                break;
                        }
                        break;
                }
            }
            return Result;
        }

        /// <summary>
        /// 打點到紀錄中
        /// </summary>
        /// <param name="point"></param>
        private void SetPoint(Point point) 
        {
            
        }

        #endregion
    }
}
