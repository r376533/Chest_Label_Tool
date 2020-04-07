namespace Chest_Label_Tool
{
    partial class ProcessBarPage
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
            this.pgbProcBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // pgbProcBar
            // 
            this.pgbProcBar.Location = new System.Drawing.Point(12, 12);
            this.pgbProcBar.Name = "pgbProcBar";
            this.pgbProcBar.Size = new System.Drawing.Size(554, 23);
            this.pgbProcBar.TabIndex = 0;
            // 
            // ProcessBarPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 50);
            this.Controls.Add(this.pgbProcBar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProcessBarPage";
            this.Text = "ProcessBarPage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbProcBar;
    }
}