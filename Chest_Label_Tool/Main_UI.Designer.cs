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
            this.儲存檔案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbBatchConvertResult = new System.Windows.Forms.ToolStripMenuItem();
            this.奇業轉出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批次紀錄點位邏輯驗證ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbAboutbtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.tbSettingPage = new System.Windows.Forms.ToolStripMenuItem();
            this.這個表單是多於設計現階段用不到隱藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDebug = new System.Windows.Forms.ToolStripLabel();
            this.cvImageBox = new Emgu.CV.UI.ImageBox();
            this.AdjustmentGroup = new System.Windows.Forms.GroupBox();
            this.trbImageZoom = new System.Windows.Forms.TrackBar();
            this.btnImageZoomScaleReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImageContrastReset = new System.Windows.Forms.Button();
            this.btnImageBrightnessReset = new System.Windows.Forms.Button();
            this.trbImageContrast = new System.Windows.Forms.TrackBar();
            this.trbImageBrightness = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ActionGroup = new System.Windows.Forms.GroupBox();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.lblPointInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvKeyPoints = new System.Windows.Forms.DataGridView();
            this.ToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvImageBox)).BeginInit();
            this.AdjustmentGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageBrightness)).BeginInit();
            this.ActionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbFilebtn,
            this.toolStripDropDownButton1,
            this.tbAboutbtn,
            this.lblDebug});
            this.ToolBar.Location = new System.Drawing.Point(0, 0);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(854, 25);
            this.ToolBar.TabIndex = 0;
            this.ToolBar.Text = "toolStrip1";
            // 
            // tbFilebtn
            // 
            this.tbFilebtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbFilebtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpenFile,
            this.儲存檔案ToolStripMenuItem});
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
            // 儲存檔案ToolStripMenuItem
            // 
            this.儲存檔案ToolStripMenuItem.Name = "儲存檔案ToolStripMenuItem";
            this.儲存檔案ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.儲存檔案ToolStripMenuItem.Text = "儲存檔案";
            this.儲存檔案ToolStripMenuItem.Click += new System.EventHandler(this.儲存檔案ToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBatchConvertResult,
            this.奇業轉出ToolStripMenuItem,
            this.批次紀錄點位邏輯驗證ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripDropDownButton1.Text = "批次功能";
            // 
            // tbBatchConvertResult
            // 
            this.tbBatchConvertResult.Name = "tbBatchConvertResult";
            this.tbBatchConvertResult.Size = new System.Drawing.Size(194, 22);
            this.tbBatchConvertResult.Text = "批次轉換紀錄檔";
            this.tbBatchConvertResult.Click += new System.EventHandler(this.tbBatchConvertResult_Click);
            // 
            // 奇業轉出ToolStripMenuItem
            // 
            this.奇業轉出ToolStripMenuItem.Name = "奇業轉出ToolStripMenuItem";
            this.奇業轉出ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.奇業轉出ToolStripMenuItem.Text = "奇業轉出";
            this.奇業轉出ToolStripMenuItem.Visible = false;
            this.奇業轉出ToolStripMenuItem.Click += new System.EventHandler(this.奇業轉出ToolStripMenuItem_Click);
            // 
            // 批次紀錄點位邏輯驗證ToolStripMenuItem
            // 
            this.批次紀錄點位邏輯驗證ToolStripMenuItem.Name = "批次紀錄點位邏輯驗證ToolStripMenuItem";
            this.批次紀錄點位邏輯驗證ToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.批次紀錄點位邏輯驗證ToolStripMenuItem.Text = "批次紀錄點位邏輯驗證";
            this.批次紀錄點位邏輯驗證ToolStripMenuItem.Click += new System.EventHandler(this.批次紀錄點位邏輯驗證ToolStripMenuItem_Click);
            // 
            // tbAboutbtn
            // 
            this.tbAboutbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbAboutbtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbSettingPage,
            this.這個表單是多於設計現階段用不到隱藏ToolStripMenuItem});
            this.tbAboutbtn.Image = ((System.Drawing.Image)(resources.GetObject("tbAboutbtn.Image")));
            this.tbAboutbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAboutbtn.Name = "tbAboutbtn";
            this.tbAboutbtn.Size = new System.Drawing.Size(44, 22);
            this.tbAboutbtn.Text = "關於";
            this.tbAboutbtn.Visible = false;
            // 
            // tbSettingPage
            // 
            this.tbSettingPage.Name = "tbSettingPage";
            this.tbSettingPage.Size = new System.Drawing.Size(290, 22);
            this.tbSettingPage.Text = "系統設定";
            this.tbSettingPage.Click += new System.EventHandler(this.tbSettingPage_Click);
            // 
            // 這個表單是多於設計現階段用不到隱藏ToolStripMenuItem
            // 
            this.這個表單是多於設計現階段用不到隱藏ToolStripMenuItem.Name = "這個表單是多於設計現階段用不到隱藏ToolStripMenuItem";
            this.這個表單是多於設計現階段用不到隱藏ToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.這個表單是多於設計現階段用不到隱藏ToolStripMenuItem.Text = "這個表單是多於設計，現階段用不到隱藏";
            // 
            // lblDebug
            // 
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(94, 22);
            this.lblDebug.Text = "toolStripLabel1";
            this.lblDebug.Visible = false;
            // 
            // cvImageBox
            // 
            this.cvImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cvImageBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.cvImageBox.Location = new System.Drawing.Point(12, 28);
            this.cvImageBox.Name = "cvImageBox";
            this.cvImageBox.Size = new System.Drawing.Size(523, 693);
            this.cvImageBox.TabIndex = 2;
            this.cvImageBox.TabStop = false;
            this.cvImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cvImageBox_MouseClick);
            // 
            // AdjustmentGroup
            // 
            this.AdjustmentGroup.Controls.Add(this.trbImageZoom);
            this.AdjustmentGroup.Controls.Add(this.btnImageZoomScaleReset);
            this.AdjustmentGroup.Controls.Add(this.label5);
            this.AdjustmentGroup.Controls.Add(this.btnImageContrastReset);
            this.AdjustmentGroup.Controls.Add(this.btnImageBrightnessReset);
            this.AdjustmentGroup.Controls.Add(this.trbImageContrast);
            this.AdjustmentGroup.Controls.Add(this.trbImageBrightness);
            this.AdjustmentGroup.Controls.Add(this.label2);
            this.AdjustmentGroup.Controls.Add(this.label1);
            this.AdjustmentGroup.Enabled = false;
            this.AdjustmentGroup.Location = new System.Drawing.Point(541, 28);
            this.AdjustmentGroup.Name = "AdjustmentGroup";
            this.AdjustmentGroup.Size = new System.Drawing.Size(301, 200);
            this.AdjustmentGroup.TabIndex = 3;
            this.AdjustmentGroup.TabStop = false;
            this.AdjustmentGroup.Text = "影像調整";
            // 
            // trbImageZoom
            // 
            this.trbImageZoom.Location = new System.Drawing.Point(9, 152);
            this.trbImageZoom.Maximum = 100;
            this.trbImageZoom.Name = "trbImageZoom";
            this.trbImageZoom.Size = new System.Drawing.Size(273, 45);
            this.trbImageZoom.TabIndex = 8;
            this.trbImageZoom.Scroll += new System.EventHandler(this.trbImageZoom_Scroll);
            // 
            // btnImageZoomScaleReset
            // 
            this.btnImageZoomScaleReset.Location = new System.Drawing.Point(207, 134);
            this.btnImageZoomScaleReset.Name = "btnImageZoomScaleReset";
            this.btnImageZoomScaleReset.Size = new System.Drawing.Size(75, 23);
            this.btnImageZoomScaleReset.TabIndex = 7;
            this.btnImageZoomScaleReset.Text = "Reset";
            this.btnImageZoomScaleReset.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "縮放比例";
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
            // ActionGroup
            // 
            this.ActionGroup.Controls.Add(this.cbAction);
            this.ActionGroup.Controls.Add(this.lblPointInfo);
            this.ActionGroup.Controls.Add(this.label4);
            this.ActionGroup.Controls.Add(this.label3);
            this.ActionGroup.Enabled = false;
            this.ActionGroup.Location = new System.Drawing.Point(541, 234);
            this.ActionGroup.Name = "ActionGroup";
            this.ActionGroup.Size = new System.Drawing.Size(301, 115);
            this.ActionGroup.TabIndex = 4;
            this.ActionGroup.TabStop = false;
            this.ActionGroup.Text = "行為";
            // 
            // cbAction
            // 
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Items.AddRange(new object[] {
            "縮放",
            "打點"});
            this.cbAction.Location = new System.Drawing.Point(8, 37);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(273, 20);
            this.cbAction.TabIndex = 4;
            this.cbAction.SelectedIndexChanged += new System.EventHandler(this.cbAction_SelectedIndexChanged);
            // 
            // lblPointInfo
            // 
            this.lblPointInfo.AutoSize = true;
            this.lblPointInfo.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPointInfo.Location = new System.Drawing.Point(12, 81);
            this.lblPointInfo.Name = "lblPointInfo";
            this.lblPointInfo.Size = new System.Drawing.Size(21, 19);
            this.lblPointInfo.TabIndex = 3;
            this.lblPointInfo.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "打點資訊";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "操作行為";
            // 
            // dgvKeyPoints
            // 
            this.dgvKeyPoints.AllowUserToAddRows = false;
            this.dgvKeyPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeyPoints.Location = new System.Drawing.Point(541, 355);
            this.dgvKeyPoints.Name = "dgvKeyPoints";
            this.dgvKeyPoints.ReadOnly = true;
            this.dgvKeyPoints.RowTemplate.Height = 24;
            this.dgvKeyPoints.Size = new System.Drawing.Size(301, 366);
            this.dgvKeyPoints.TabIndex = 5;
            this.dgvKeyPoints.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvKeyPoints_UserDeletingRow);
            // 
            // Main_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 733);
            this.Controls.Add(this.dgvKeyPoints);
            this.Controls.Add(this.ActionGroup);
            this.Controls.Add(this.AdjustmentGroup);
            this.Controls.Add(this.cvImageBox);
            this.Controls.Add(this.ToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_UI";
            this.Text = "胸腔影像標記程式";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_UI_FormClosing);
            this.Load += new System.EventHandler(this.Main_UI_Load);
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cvImageBox)).EndInit();
            this.AdjustmentGroup.ResumeLayout(false);
            this.AdjustmentGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbImageBrightness)).EndInit();
            this.ActionGroup.ResumeLayout(false);
            this.ActionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyPoints)).EndInit();
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
        private System.Windows.Forms.GroupBox ActionGroup;
        private System.Windows.Forms.Label lblPointInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAction;
        private System.Windows.Forms.ToolStripLabel lblDebug;
        private System.Windows.Forms.DataGridView dgvKeyPoints;
        private System.Windows.Forms.ToolStripMenuItem 這個表單是多於設計現階段用不到隱藏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tbBatchConvertResult;
        private System.Windows.Forms.ToolStripMenuItem 奇業轉出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 批次紀錄點位邏輯驗證ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 儲存檔案ToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImageZoomScaleReset;
        private System.Windows.Forms.TrackBar trbImageZoom;
    }
}

