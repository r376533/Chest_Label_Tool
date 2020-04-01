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

        private void chiYaOutPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //當使用者按下X關閉視窗，真正的行為應該是要隱藏視窗
            e.Cancel = true;
            this.Hide();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string TargetPath = txtFilePath.Text;
            string TargetPatten = "*.json";
            List<string> paths = Func.GetFilesFromDir(TargetPath, TargetPatten);
            List<SaveResultV2> Results = new List<SaveResultV2>();
            for (int i = 0; i < paths.Count; i++)
            {
                string jsonpath = paths[i];
                SaveResultV2 item = SaveResultV2.ReadFile(jsonpath);
                Results.Add(item);
            }

            for (int i = 0; i < Results.Count; i++)
            {
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
