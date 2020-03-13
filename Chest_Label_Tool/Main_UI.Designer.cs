namespace Chest_Label_Tool
{
    partial class Main_UI
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_UI));
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.tbFilebtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAboutbtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbSettingPage = new System.Windows.Forms.ToolStripMenuItem();
            this.cvImageBox = new Emgu.CV.UI.ImageBox();
            this.AdjustmentGroup = new System.Windows.Forms.GroupBox();
            this.btnImageContrastReset = new System.Windows.Forms.Button();
            this.btnImageBrightnessReset = new System.Windows.Forms.Button();
            this.trbImageContrast = new System.Windows.Forms.TrackBar();
            this.trbImageBrightness = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvImageBox)).BeginInit();
            this.AdjustmentGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFilebtn,
            this.tbAboutbtn});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(806, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.Text = "toolStrip1";
            // 
            // tbFilebtn
            // 
            this.tbFilebtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbFilebtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpenFile});
            this.tbFilebtn.Image = ((System.Drawing.Image)(resources.GetObject("tbFilebtn.Image")));
            this.tbFilebtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbFilebtn.Name = "tbFilebtn";
            this.tbFilebtn.Size = new System.Drawing.Size(44, 22);
            this.tbFilebtn.Text = "檔案";
            // 
            // tbOpenFile
            // 
            this.tbOpenFile.Name = "tbOpenFile";
            this.tbOpenFile.Size = new System.Drawing.Size(122, 22);
            this.tbOpenFile.Text = "開啟檔案";
            this.tbOpenFile.Click += new System.EventHandler(this.tbOpenFile_Click);
            // 
            // tbAboutbtn
            // 
            this.tbAboutbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbAboutbtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSettingPage});
            this.tbAboutbtn.Image = ((System.Drawing.Image)(resources.GetObject("tbAboutbtn.Image")));
            this.tbAboutbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAboutbtn.Name = "tbAboutbtn";
            this.tbAboutbtn.Size = new System.Drawing.Size(44, 22);
            this.tbAboutbtn.Text = "關於";
            // 
            // tbSettingPage
            // 
            this.tbSettingPage.Name = "tbSettingPage";
            this.tbSettingPage.Size = new System.Drawing.Size(122, 22);
            this.tbSettingPage.Text = "系統設定";
            this.tbSettingPage.Click += new System.EventHandler(this.tbSettingPage_Click);
            // 
            // cvImageBox
            // 
            this.cvImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
            this.cvImageBox.Location = new System.Drawing.Point(12, 28);
            this.cvImageBox.Name = "cvImageBox";
            this.cvImageBox.Size = new System.Drawing.Size(475, 561);
            this.cvImageBox.TabIndex = 2;
            this.cvImageBox.TabStop = false;
            this.cvImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cvImageBox_MouseClick);
            // 
            // AdjustmentGroup
            // 
            this.AdjustmentGroup.Controls.Add(this.btnImageContrastReset);
            this.AdjustmentGroup.Controls.Add(this.btnImageBrightnessReset);
            this.AdjustmentGroup.Controls.Add(this.trbImageContrast);
            this.AdjustmentGroup.Controls.Add(this.trbImageBrightness);
            this.AdjustmentGroup.Controls.Add(this.label2);
            this.AdjustmentGroup.Controls.Add(this.label1);
            this.AdjustmentGroup.Enabled = false;
            this.AdjustmentGroup.Location = new System.Drawing.Point(493, 28);
            this.AdjustmentGroup.Name = "AdjustmentGroup";
            this.AdjustmentGroup.Size = new System.Drawing.Size(301, 149);
            this.AdjustmentGroup.TabIndex = 3;
            this.AdjustmentGroup.TabStop = false;
            this.AdjustmentGroup.Text = "影像調整";
            // 
            // btnImageContrastReset
            // 
            this.btnImageContrastReset.Location = new System.Drawing.Point(207, 75);
            this.btnImageContrastReset.Name = "btnImageContrastReset";
            this.btnImageContrastReset.Size = new System.Drawing.Size(75, 23);
            this.btnImageContrastReset.TabIndex = 5;
            this.btnImageContrastReset.Text = "Reset";
            this.btnImageContrastReset.UseVisualStyleBackColor = true;
            this.btnImageContrastReset.Click += new System.EventHandler(this.btnImageContrastReset_Click);
            // 
            // btnImageBrightnessReset
            // 
            this.btnImageBrightnessReset.Location = new System.Drawing.Point(207, 17);
            this.btnImageBrightnessReset.Name = "btnImageBrightnessReset";
            this.btnImageBrightnessReset.Size = new System.Drawing.Size(75, 23);
            this.btnImageBrightnessReset.TabIndex = 4;
            this.btnImageBrightnessReset.Text = "Reset";
            this.btnImageBrightnessReset.UseVisualStyleBackColor = true;
            this.btnImageBrightnessReset.Click += new System.EventHandler(this.btnImageBrightnessReset_Click);
            // 
            // trbImageContrast
            // 
            this.trbImageContrast.LargeChange = 10;
            this.trbImageContrast.Location = new System.Drawing.Point(6, 101);
            this.trbImageContrast.Maximum = 100;
            this.trbImageContrast.Minimum = -100;
            this.trbImageContrast.Name = "trbImageContrast";
            this.trbImageContrast.Size = new System.Drawing.Size(286, 45);
            this.trbImageContrast.TabIndex = 3;
            this.trbImageContrast.Scroll += new System.EventHandler(this.trbImageContrast_Scroll);
            // 
            // trbImageBrightness
            // 
            this.trbImageBrightness.LargeChange = 10;
            this.trbImageBrightness.Location = new System.Drawing.Point(9, 37);
            this.trbImageBrightness.Maximum = 100;
            this.trbImageBrightness.Minimum = -100;
            this.trbImageBrightness.Name = "trbImageBrightness";
            this.trbImageBrightness.Size = new System.Drawing.Size(286, 45);
            this.trbImageBrightness.TabIndex = 2;
            this.trbImageBrightness.Scroll += new System.EventHandler(this.trbImageBrightness_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "對比度";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "亮度";
            // 
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 601);
            this.Controls.Add(this.AdjustmentGroup);
            this.Controls.Add(this.cvImageBox);
            this.Controls.Add(this.ToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main_UI";
            this.Text = "胸腔影像標記程式";
            this.Load += new System.EventHandler(this.Main_UI_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvImageBox)).EndInit();
            this.AdjustmentGroup.ResumeLayout(false);
            this.AdjustmentGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripDropDownButton tbFilebtn;
        private System.Windows.Forms.ToolStripMenuItem tbOpenFile;
        private System.Windows.Forms.ToolStripDropDownButton tbAboutbtn;
        private System.Windows.Forms.ToolStripMenuItem tbSettingPage;
        private Emgu.CV.UI.ImageBox cvImageBox;
        private System.Windows.Forms.GroupBox AdjustmentGroup;
        private System.Windows.Forms.Button btnImageContrastReset;
        private System.Windows.Forms.Button btnImageBrightnessReset;
        private System.Windows.Forms.TrackBar trbImageContrast;
        private System.Windows.Forms.TrackBar trbImageBrightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

