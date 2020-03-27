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
            this.cbAutoSave = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ST_TP_NOR_btOpenFileBrowser = new System.Windows.Forms.Button();
            this.ST_TP_NOR_btSavePathSetting = new System.Windows.Forms.Button();
            this.ST_TP_NOR_txtSavePath = new System.Windows.Forms.TextBox();
            this.ST_TP_NOR_lbSavePath = new System.Windows.Forms.Label();
            this.ST_TP_Image = new System.Windows.Forms.TabPage();
            this.cbAutoChangeType = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.npTracheaRightCount = new System.Windows.Forms.NumericUpDown();
            this.npTracheaLeftCount = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.npTracheaButtomCount = new System.Windows.Forms.NumericUpDown();
            this.npPlasticTubeCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ST_TabControl.SuspendLayout();
            this.ST_TP_Normal.SuspendLayout();
            this.ST_TP_Image.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npTracheaRightCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npTracheaLeftCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npTracheaButtomCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npPlasticTubeCount)).BeginInit();
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
            this.ST_TP_Normal.Controls.Add(this.cbAutoSave);
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
            // cbAutoSave
            // 
            this.cbAutoSave.AutoSize = true;
            this.cbAutoSave.Location = new System.Drawing.Point(14, 64);
            this.cbAutoSave.Name = "cbAutoSave";
            this.cbAutoSave.Size = new System.Drawing.Size(72, 16);
            this.cbAutoSave.TabIndex = 5;
            this.cbAutoSave.Text = "自動記錄";
            this.cbAutoSave.UseVisualStyleBackColor = true;
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
            this.ST_TP_Image.Controls.Add(this.cbAutoChangeType);
            this.ST_TP_Image.Controls.Add(this.groupBox1);
            this.ST_TP_Image.Location = new System.Drawing.Point(4, 22);
            this.ST_TP_Image.Name = "ST_TP_Image";
            this.ST_TP_Image.Padding = new System.Windows.Forms.Padding(3);
            this.ST_TP_Image.Size = new System.Drawing.Size(285, 400);
            this.ST_TP_Image.TabIndex = 1;
            this.ST_TP_Image.Text = "影像設定";
            this.ST_TP_Image.UseVisualStyleBackColor = true;
            // 
            // cbAutoChangeType
            // 
            this.cbAutoChangeType.AutoSize = true;
            this.cbAutoChangeType.Location = new System.Drawing.Point(16, 118);
            this.cbAutoChangeType.Name = "cbAutoChangeType";
            this.cbAutoChangeType.Size = new System.Drawing.Size(120, 16);
            this.cbAutoChangeType.TabIndex = 9;
            this.cbAutoChangeType.Text = "自動切換標記種類";
            this.cbAutoChangeType.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.npTracheaRightCount);
            this.groupBox1.Controls.Add(this.npTracheaLeftCount);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.npTracheaButtomCount);
            this.groupBox1.Controls.Add(this.npPlasticTubeCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 105);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "標記點數";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "塑膠氣管點數";
            // 
            // npTracheaRightCount
            // 
            this.npTracheaRightCount.Location = new System.Drawing.Point(145, 73);
            this.npTracheaRightCount.Name = "npTracheaRightCount";
            this.npTracheaRightCount.Size = new System.Drawing.Size(101, 22);
            this.npTracheaRightCount.TabIndex = 6;
            // 
            // npTracheaLeftCount
            // 
            this.npTracheaLeftCount.Location = new System.Drawing.Point(147, 33);
            this.npTracheaLeftCount.Name = "npTracheaLeftCount";
            this.npTracheaLeftCount.Size = new System.Drawing.Size(99, 22);
            this.npTracheaLeftCount.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "氣管分岔右緣點數";
            // 
            // npTracheaButtomCount
            // 
            this.npTracheaButtomCount.Location = new System.Drawing.Point(8, 72);
            this.npTracheaButtomCount.Name = "npTracheaButtomCount";
            this.npTracheaButtomCount.Size = new System.Drawing.Size(99, 22);
            this.npTracheaButtomCount.TabIndex = 5;
            // 
            // npPlasticTubeCount
            // 
            this.npPlasticTubeCount.Location = new System.Drawing.Point(8, 33);
            this.npPlasticTubeCount.Name = "npPlasticTubeCount";
            this.npPlasticTubeCount.Size = new System.Drawing.Size(99, 22);
            this.npPlasticTubeCount.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "氣管分岔左緣點數";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "氣管分岔下緣點數";
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
            this.ST_TP_Image.ResumeLayout(false);
            this.ST_TP_Image.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npTracheaRightCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npTracheaLeftCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npTracheaButtomCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npPlasticTubeCount)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown npTracheaLeftCount;
        private System.Windows.Forms.NumericUpDown npTracheaRightCount;
        private System.Windows.Forms.NumericUpDown npTracheaButtomCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown npPlasticTubeCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAutoChangeType;
        private System.Windows.Forms.CheckBox cbAutoSave;
    }
}