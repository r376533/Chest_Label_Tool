namespace Chest_Label_Tool
{
    partial class SaveResultConvertPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveResultConvertPage));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnSourcePathBrowser = new System.Windows.Forms.Button();
            this.BtnStartProcess = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.BtnStartProcess);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(393, 131);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "JSON檔批次轉換功能";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(13, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "V1資料來源";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtSourcePath);
            this.flowLayoutPanel2.Controls.Add(this.btnSourcePathBrowser);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(362, 40);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // txtSourcePath
            // 
            this.txtSourcePath.Enabled = false;
            this.txtSourcePath.Location = new System.Drawing.Point(8, 8);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(249, 22);
            this.txtSourcePath.TabIndex = 0;
            // 
            // btnSourcePathBrowser
            // 
            this.btnSourcePathBrowser.Location = new System.Drawing.Point(263, 8);
            this.btnSourcePathBrowser.Name = "btnSourcePathBrowser";
            this.btnSourcePathBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnSourcePathBrowser.TabIndex = 1;
            this.btnSourcePathBrowser.Text = "開啟";
            this.btnSourcePathBrowser.UseVisualStyleBackColor = true;
            this.btnSourcePathBrowser.Click += new System.EventHandler(this.btnSourcePathBrowser_Click);
            // 
            // BtnStartProcess
            // 
            this.BtnStartProcess.Enabled = false;
            this.BtnStartProcess.Location = new System.Drawing.Point(13, 92);
            this.BtnStartProcess.Name = "BtnStartProcess";
            this.BtnStartProcess.Size = new System.Drawing.Size(365, 23);
            this.BtnStartProcess.TabIndex = 3;
            this.BtnStartProcess.Text = "執行";
            this.BtnStartProcess.UseVisualStyleBackColor = true;
            this.BtnStartProcess.Click += new System.EventHandler(this.BtnStartProcess_Click);
            // 
            // SaveResultConvertPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 131);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SaveResultConvertPage";
            this.Text = "紀錄檔批次轉換";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveResultConvertPage_FormClosing);
            this.Load += new System.EventHandler(this.SaveResultConvertPage_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnSourcePathBrowser;
        private System.Windows.Forms.Button BtnStartProcess;
    }
}