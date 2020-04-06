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
        private DcmInfo RightNowInfo;
        private Image<Bgr, Byte> RightNowImage, OriginalImage;
        private Bgr Color_Red;
        private Bgr Color_Blue;

        private ProgramAction RightNowMode;
        private bool IsInAction;
        private bool IsMouseDown;

        private SaveResultV2 LabelLog;

        private SaveResultConvertPage saveResultConvertPage;
        private chiYaOutPage chiYaOutPage;

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

            #region 轉換PAGE
            if (saveResultConvertPage == null)
            {
                saveResultConvertPage = new SaveResultConvertPage(SettingObj);
                saveResultConvertPage.Hide();
            }
            if (chiYaOutPage == null) 
            {
                chiYaOutPage = new chiYaOutPage();
                chiYaOutPage.Hide();
            }
            #endregion

            #region ActionGroup
            RightNowMode = ProgramAction.None;
            IsInAction = false;
            IsMouseDown = false;
            #endregion
            Color_Red = new Bgr(0, 0, 255);
            Color_Blue = new Bgr(255, 0, 0);
        }

        #region ToolBar
        private void tbOpenFile_Click(object sender, EventArgs e)
        {
            if (OriginalImage != null) 
            {
                SaveLabelFile();
            }
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
                    RightNowInfo = Image_Func.DcmDetailData(ImagePath_Dcm);
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
                    AdjustmentInit(true);
                    ImageProc();
                }
            }
        }

        private void tbSettingPage_Click(object sender, EventArgs e)
        {
            //打開系統設定UI
            SettingPage.Show();
        }

        private void tbBatchConvertResult_Click(object sender, EventArgs e)
        {
            saveResultConvertPage.Show();
            saveResultConvertPage.Focus();
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
                        AddPoint(ImageLocation);
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
                    cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
                    lblPointInfo.Text = "...";
                    break;
                case 1:
                    RightNowMode = ProgramAction.Select;
                    cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
                    lblPointInfo.Text = "...";
                    break;
                case 2:
                    RightNowMode = ProgramAction.Point;
                    cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
                    lblPointInfo.Text = GetRightNowPointInfo();
                    break;
                default:
                    RightNowMode = ProgramAction.None;
                    cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
                    lblPointInfo.Text = "...";
                    break;
            }
            lblDebug.Text = GetDescription(RightNowMode);
        }

        private void AdjustmentImage(Image<Bgr,Byte> Image,int Contrast, int Brightness) 
        {
            ImageProc();
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
                LabelLog = SaveResultReader.ReadFromFile(TargetPath,RightNowInfo);
            }
            else 
            {
                LabelLog = new SaveResultV2(DcmImagePath);
            }
        }

        /// <summary>
        /// 將Label的紀錄讀取回去
        /// </summary>
        private Image<Bgr, Byte> ImageLabelDataReLoad(Image<Bgr, Byte> Source,List<Nullable<Point>> KeyPoint) 
        {
            Image<Bgr,Byte> Img = Source.Copy();
            #region 先畫點
            foreach (Nullable<Point> Point in KeyPoint) 
            {
                if (Point != null) 
                {
                    Img = Image_Func.DrawPoint(Img, Point.Value, Color_Blue);
                }
            }
            #endregion
            #region 畫塑膠氣管
            for (int i = 1; i < 4; i++)
            {
                if (KeyPoint[i] != null && KeyPoint[i-1] != null) 
                {
                    if (KeyPoint[i] != null && KeyPoint[i - 1] != null)
                    {
                        Img = Image_Func.DrawLine(Img, KeyPoint[i - 1].Value, KeyPoint[i].Value, Color_Red);
                    }
                }
            }
            #endregion
            #region 畫肺部分岔
            for (int i = 5; i < 13; i++)
            {
                if (KeyPoint[i] != null && KeyPoint[i - 1] != null &&  (i % 3) != 1) 
                {
                    if (KeyPoint[i] != null && KeyPoint[i - 1] != null) 
                    {
                        Img = Image_Func.DrawLine(Img, KeyPoint[i - 1].Value, KeyPoint[i].Value, Color_Red);
                    }
                }
            }
            #endregion
            return Img;
        }

        /// <summary>
        /// 將Label的資料讀回到GridView裡面
        /// </summary>
        private void GridViewDataReLoad() 
        {
            List<Nullable<Point>> KeyPoints = LabelLog.KeyPoints;
            DataTable dt = ListDataToDt(KeyPoints);
            dgvKeyPoints.DataSource = dt;
        }

        /// <summary>
        /// 把標記點轉成DataTable
        /// </summary>
        /// <param name="Points"></param>
        /// <returns></returns>
        private DataTable ListDataToDt(List<Nullable<Point>> Points) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("意義");
            dt.Columns.Add("X");
            dt.Columns.Add("Y");
            for (int i = 0; i < Points.Count; i++)
            {
                if (Points[i] != null) 
                {
                    DataRow row = dt.NewRow();
                    row[0] = SaveResultV2.KeyPointMean[i];
                    row[1] = Points[i] != null ? Points[i].Value.X.ToString() : "";
                    row[2] = Points[i] != null ? Points[i].Value.Y.ToString() : "";
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        /// <summary>
        /// 存入目前的紀錄檔
        /// </summary>
        private void SaveLabelFile() 
        {
            LabelLog.Info = RightNowInfo;
            string dcmfile = ImagePath_Dcm.Substring(0, ImagePath_Dcm.Length - 4) + ".json";
            string jpgfile = ImagePath_Jpg.Substring(0, ImagePath_Jpg.Length - 4) + ".json";
            LabelLog.Optimize_Brightness = trbImageBrightness.Value;
            LabelLog.Optimize_Contrast = trbImageContrast.Value;
            SaveResultV2.SaveFile(LabelLog, dcmfile);
            SaveResultV2.SaveFile(LabelLog, jpgfile);
        }

        

        /// <summary>
        /// 打點到紀錄中
        /// </summary>
        /// <param name="point"></param>
        private void AddPoint(Point point)
        {
            for (int i = 0; i < 13; i++)
            {
                if (LabelLog.KeyPoints[i] == null)
                {
                    LabelLog.KeyPoints[i] = point;
                    break;
                }
            }
            lblPointInfo.Text = GetRightNowPointInfo();
            ImageProc();
            GridViewDataReLoad();
            if (SettingObj.AutoSave) 
            {
                SaveLabelFile();
            }
        }

        /// <summary>
        /// 取得目前新增點的描述
        /// </summary>
        /// <returns></returns>
        private string GetRightNowPointInfo() 
        {
            string Result = "";
            for (int  i = 0;  i < LabelLog.KeyPoints.Count ;  i++)
            {
                if (LabelLog.KeyPoints[i] == null) 
                {
                    Result = SaveResultV2.KeyPointMean[i];
                    break;
                }
            }
            return Result;
        }
        #endregion


        /// <summary>
        /// 要改變圖片就用這個
        /// </summary>
        private void ImageProc() 
        {
            int B_Level = trbImageBrightness.Value;
            int C_Level = trbImageContrast.Value;

            List<Nullable<Point>> KeyPoints = LabelLog.KeyPoints;
            Image<Bgr, Byte> Img = OriginalImage.Copy();
            //調亮度跟對比度
            Img = Image_Func.BrightnessAndContrast(Img, B_Level, C_Level);
            //畫點劃線
            Img = ImageLabelDataReLoad(Img, KeyPoints);
            cvImageBox.Image = Img;
        }

        private void 奇業轉出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chiYaOutPage.Show();
            chiYaOutPage.Focus();
        }
    }
}
