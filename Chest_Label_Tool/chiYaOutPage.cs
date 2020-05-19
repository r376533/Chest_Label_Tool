using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Chest_Label_Tool.Lib;

namespace Chest_Label_Tool
{
    public partial class chiYaOutPage : Form
    {
        int Ext = 5;
        public chiYaOutPage()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string SelectPath = dialog.SelectedPath;
                    txtFilePath.Text = SelectPath;
                }
            }
        }
        private void btnBrowser2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string SelectPath = dialog.SelectedPath;
                    txtTargetPath.Text = SelectPath;
                }
            }
        }
        private void chiYaOutPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //當使用者按下X關閉視窗，真正的行為應該是要隱藏視窗
            e.Cancel = true;
            this.Hide();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string SourcePath = txtFilePath.Text;
            string SourcePatten = "*.json";
            string TargetPath = txtTargetPath.Text;
            List<string> paths = Func.GetFilesFromDir(SourcePath, SourcePatten);
            List<SaveResultV2> Results = new List<SaveResultV2>();
            StringBuilder ErrorBuilder = new StringBuilder();
            for (int i = 0; i < paths.Count; i++)
            {
                string jsonpath = paths[i];
                string dcmPath = jsonpath.Replace(".json", ".dcm");
                string FileName = Path.GetFileName(dcmPath);
                SaveResultV2 item = SaveResultV2.ReadFile(jsonpath);
                //判斷是否是V2版本存檔跟是否有滿足13個點
                if (item.ResultVersion == "2" && item.KeyPoints.Count == 13 ) 
                {
                    string Message = String.Format("Check:{0}/{1}", i, paths.Count);
                    lblMessage.Text = Message;
                    bool HaveNullNode = true;
                    foreach (Nullable<Point> point in item.KeyPoints)
                    {
                        if (point == null) 
                        {
                            HaveNullNode = false;
                            break;
                        }
                    }
                    if (HaveNullNode)
                    {
                        Func.CopyFile(dcmPath, TargetPath + @"\" + FileName);
                        Results.Add(item);
                    }
                    else 
                    {
                        ErrorBuilder.Append(String.Format("{0}{1}", jsonpath, Environment.NewLine));
                    }
                }
            }

            for (int i = 0; i < Results.Count; i++)
            {
                string Message = String.Format("Proc:{0}/{1}", i, Results.Count);
                lblMessage.Text = Message;
                if (i == Results.Count - 1)
                {
                    ProcessFile(ref sb, Results[i], false);
                }
                else 
                {
                    ProcessFile(ref sb, Results[i], true);
                }
            }

            Func.WriteText(TargetPath + @"\"+"Total.txt", sb.ToString());
            Func.WriteText(TargetPath + @"\" + "Error.txt", ErrorBuilder.ToString());
            MessageBox.Show("OK", "OK");
        }

        private void ProcessFile(ref StringBuilder sb, SaveResultV2 LabelLog, bool ChangeLine = true) 
        {
            if (LabelLog.KeyPoints.Count == 13) 
            {
                string FileName = System.IO.Path.GetFileNameWithoutExtension(LabelLog.ImageFileName);
                int[] plasticROI = GetROI(LabelLog.KeyPoints.GetRange(0, 4));
                int[] tracheaROI = GetROI(LabelLog.KeyPoints.GetRange(4, 9));
                sb.Append(string.Format("{0} {1} {2} {3} {4} {5}", FileName, "0", plasticROI[0], plasticROI[1], plasticROI[2], plasticROI[3]));
                sb.Append(Environment.NewLine);
                sb.Append(string.Format("{0} {1} {2} {3} {4} {5}", FileName, "1", tracheaROI[0], tracheaROI[1], tracheaROI[2], tracheaROI[3]));
                if (ChangeLine)
                {
                    sb.Append(Environment.NewLine);
                }
            }
        }


        private int[] GetROI(List<Nullable<Point>> Points) 
        {
            int X_min = int.MaxValue;
            int Y_min = int.MaxValue;
            int X_max = 0;
            int Y_max = 0;

            foreach (var item in Points)
            {
                if (item != null) 
                {
                    Point p = item.Value;
                    //Min X
                    X_min = p.X <= X_min ? p.X : X_min;
                    //Min Y
                    Y_min = p.Y <= Y_min ? p.Y : Y_min;
                    //Max X
                    X_max = p.X >= X_max ? p.X : X_max;
                    //Max Y
                    Y_max = p.Y >= Y_max ? p.Y : Y_max;
                }
            }

            X_min = (X_min - Ext) < 0 ? 0 : (X_min - Ext);
            Y_min = (Y_min - Ext) < 0 ? 0 : (Y_min - Ext);
            X_max += Ext;
            Y_max += Ext;

            return new int[] { X_min, Y_min, X_max, Y_max };
        }

        
    }
}
