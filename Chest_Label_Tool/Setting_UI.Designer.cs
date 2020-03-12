namespace Chest_Label_Tool
{
    partial class Setting_UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ST_TabControl = new System.Windows.Forms.TabControl();
            this.ST_TP_Normal = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.ST_TP_NOR_btOpenFileBrowser = new System.Windows.Forms.Button();
            this.ST_TP_NOR_btSavePathSetting = new System.Windows.Forms.Button();
            this.ST_TP_NOR_txtSavePath = new System.Windows.Forms.TextBox();
            this.ST_TP_NOR_lbSavePath = new System.Windows.Forms.Label();
            this.ST_TP_Image = new System.Windows.Forms.TabPage();
            this.ST_TabControl.SuspendLayout();
            this.ST_TP_Normal.SuspendLayout();
            this.SuspendLayout();
            // 
            // ST_TabControl
            // 
            this.ST_TabControl.Controls.Add(this.ST_TP_Normal);
            this.ST_TabControl.Controls.Add(this.ST_TP_Image);
            this.ST_TabControl.Location = new System.Drawing.Point(12, 12);
            this.ST_TabControl.Name = "ST_TabControl";
            this.ST_TabControl.SelectedIndex = 0;
            this.ST_TabControl.Size = new System.Drawing.Size(293, 426);
            this.ST_TabControl.TabIndex = 0;
            // 
            // ST_TP_Normal
            // 
            this.ST_TP_Normal.Controls.Add(this.label1);
            this.ST_TP_Normal.Controls.Add(this.ST_TP_NOR_btOpenFileBrowser);
            this.ST_TP_Normal.Controls.Add(this.ST_TP_NOR_btSavePathSetting);
            this.ST_TP_Normal.Controls.Add(this.ST_TP_NOR_txtSavePath);
            this.ST_TP_Normal.Controls.Add(this.ST_TP_NOR_lbSavePath);
            this.ST_TP_Normal.Location = new System.Drawing.Point(4, 22);
            this.ST_TP_Normal.Name = "ST_TP_Normal";
            this.ST_TP_Normal.Padding = new System.Windows.Forms.Padding(3);
            this.ST_TP_Normal.Size = new System.Drawing.Size(285, 400);
            this.ST_TP_Normal.TabIndex = 0;
            this.ST_TP_Normal.Text = "系統常規設定";
            this.ST_TP_Normal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 4;
            // 
            // ST_TP_NOR_btOpenFileBrowser
            // 
            this.ST_TP_NOR_btOpenFileBrowser.Location = new System.Drawing.Point(240, 7);
            this.ST_TP_NOR_btOpenFileBrowser.Name = "ST_TP_NOR_btOpenFileBrowser";
            this.ST_TP_NOR_btOpenFileBrowser.Size = new System.Drawing.Size(39, 23);
            this.ST_TP_NOR_btOpenFileBrowser.TabIndex = 3;
            this.ST_TP_NOR_btOpenFileBrowser.Text = "瀏覽";
            this.ST_TP_NOR_btOpenFileBrowser.UseVisualStyleBackColor = true;
            // 
            // ST_TP_NOR_btSavePathSetting
            // 
            this.ST_TP_NOR_btSavePathSetting.Location = new System.Drawing.Point(196, 7);
            this.ST_TP_NOR_btSavePathSetting.Name = "ST_TP_NOR_btSavePathSetting";
            this.ST_TP_NOR_btSavePathSetting.Size = new System.Drawing.Size(38, 23);
            this.ST_TP_NOR_btSavePathSetting.TabIndex = 2;
            this.ST_TP_NOR_btSavePathSetting.Text = "設定";
            this.ST_TP_NOR_btSavePathSetting.UseVisualStyleBackColor = true;
            // 
            // ST_TP_NOR_txtSavePath
            // 
            this.ST_TP_NOR_txtSavePath.Location = new System.Drawing.Point(9, 35);
            this.ST_TP_NOR_txtSavePath.Name = "ST_TP_NOR_txtSavePath";
            this.ST_TP_NOR_txtSavePath.Size = new System.Drawing.Size(270, 22);
            this.ST_TP_NOR_txtSavePath.TabIndex = 1;
            // 
            // ST_TP_NOR_lbSavePath
            // 
            this.ST_TP_NOR_lbSavePath.AutoSize = true;
            this.ST_TP_NOR_lbSavePath.Location = new System.Drawing.Point(7, 12);
            this.ST_TP_NOR_lbSavePath.Name = "ST_TP_NOR_lbSavePath";
            this.ST_TP_NOR_lbSavePath.Size = new System.Drawing.Size(53, 12);
            this.ST_TP_NOR_lbSavePath.TabIndex = 0;
            this.ST_TP_NOR_lbSavePath.Text = "儲存路徑";
            // 
            // ST_TP_Image
            // 
            this.ST_TP_Image.Location = new System.Drawing.Point(4, 22);
            this.ST_TP_Image.Name = "ST_TP_Image";
            this.ST_TP_Image.Padding = new System.Windows.Forms.Padding(3);
            this.ST_TP_Image.Size = new System.Drawing.Size(285, 400);
            this.ST_TP_Image.TabIndex = 1;
            this.ST_TP_Image.Text = "影像設定";
            this.ST_TP_Image.UseVisualStyleBackColor = true;
            // 
            // Setting_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 450);
            this.Controls.Add(this.ST_TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Setting_UI";
            this.Text = "系統設定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_UI_FormClosing);
            this.Load += new System.EventHandler(this.Setting_UI_Load);
            this.ST_TabControl.ResumeLayout(false);
            this.ST_TP_Normal.ResumeLayout(false);
            this.ST_TP_Normal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ST_TabControl;
        private System.Windows.Forms.TabPage ST_TP_Normal;
        private System.Windows.Forms.TabPage ST_TP_Image;
        private System.Windows.Forms.Button ST_TP_NOR_btOpenFileBrowser;
        private System.Windows.Forms.Button ST_TP_NOR_btSavePathSetting;
        private System.Windows.Forms.TextBox ST_TP_NOR_txtSavePath;
        private System.Windows.Forms.Label ST_TP_NOR_lbSavePath;
        private System.Windows.Forms.Label label1;
    }
}