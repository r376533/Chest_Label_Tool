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
            this.cvibImage = new Emgu.CV.UI.ImageBox();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvibImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFilebtn,
            this.tbAboutbtn});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(800, 25);
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
            this.tbOpenFile.Size = new System.Drawing.Size(180, 22);
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
            this.tbSettingPage.Size = new System.Drawing.Size(180, 22);
            this.tbSettingPage.Text = "系統設定";
            this.tbSettingPage.Click += new System.EventHandler(this.tbSettingPage_Click);
            // 
            // cvibImage
            // 
            this.cvibImage.Location = new System.Drawing.Point(12, 28);
            this.cvibImage.Name = "cvibImage";
            this.cvibImage.Size = new System.Drawing.Size(776, 410);
            this.cvibImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cvibImage.TabIndex = 2;
            this.cvibImage.TabStop = false;
            // 
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cvibImage);
            this.Controls.Add(this.ToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main_UI";
            this.Text = "胸腔影像標記程式";
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvibImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripDropDownButton tbFilebtn;
        private System.Windows.Forms.ToolStripMenuItem tbOpenFile;
        private Emgu.CV.UI.ImageBox cvibImage;
        private System.Windows.Forms.ToolStripDropDownButton tbAboutbtn;
        private System.Windows.Forms.ToolStripMenuItem tbSettingPage;
    }
}

