namespace presentación
{
    partial class frmAbout
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
            this.lbFrmAboutVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbFrmAboutVersion
            // 
            this.lbFrmAboutVersion.AutoSize = true;
            this.lbFrmAboutVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFrmAboutVersion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbFrmAboutVersion.Location = new System.Drawing.Point(58, 80);
            this.lbFrmAboutVersion.Name = "lbFrmAboutVersion";
            this.lbFrmAboutVersion.Size = new System.Drawing.Size(88, 14);
            this.lbFrmAboutVersion.TabIndex = 0;
            this.lbFrmAboutVersion.Text = "Version 0.0.1";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(86)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbFrmAboutVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAbout";
            this.Text = "frmAbout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFrmAboutVersion;
    }
}