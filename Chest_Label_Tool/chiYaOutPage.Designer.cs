namespace Chest_Label_Tool
{
    partial class chiYaOutPage
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.btnBrowser2 = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 24);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(296, 22);
            this.txtFilePath.TabIndex = 0;
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(12, 52);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 340);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target";
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.Location = new System.Drawing.Point(12, 94);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(296, 22);
            this.txtTargetPath.TabIndex = 5;
            // 
            // btnBrowser2
            // 
            this.btnBrowser2.Location = new System.Drawing.Point(12, 123);
            this.btnBrowser2.Name = "btnBrowser2";
            this.btnBrowser2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowser2.TabIndex = 6;
            this.btnBrowser2.Text = "Browser";
            this.btnBrowser2.UseVisualStyleBackColor = true;
            this.btnBrowser2.Click += new System.EventHandler(this.btnBrowser2_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("新細明體", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMessage.Location = new System.Drawing.Point(12, 159);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(119, 37);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "Wait...";
            // 
            // chiYaOutPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 375);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnBrowser2);
            this.Controls.Add(this.txtTargetPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.txtFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "chiYaOutPage";
            this.Text = "chiYaOutPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.chiYaOutPage_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Button btnBrowser2;
        private System.Windows.Forms.Label lblMessage;
    }
}