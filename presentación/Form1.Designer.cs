using System.Windows.Forms;

namespace presentación
{
    partial class presentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(presentacion));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.sidePanel = new System.Windows.Forms.Panel();
            this.panelBtnPresupuesto = new System.Windows.Forms.Panel();
            this.btnPresupuesto = new System.Windows.Forms.Button();
            this.panelBtnAbout = new System.Windows.Forms.Panel();
            this.panelBtnPrincipal = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnCatalogo = new System.Windows.Forms.Button();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.sidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.headerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.headerPanel.Controls.Add(this.picLogo);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1079, 88);
            this.headerPanel.TabIndex = 5;
            // 
            // picLogo
            // 
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.InitialImage = null;
            this.picLogo.Location = new System.Drawing.Point(30, 7);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(78, 76);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.sidePanel.Controls.Add(this.panelBtnPresupuesto);
            this.sidePanel.Controls.Add(this.btnPresupuesto);
            this.sidePanel.Controls.Add(this.panelBtnAbout);
            this.sidePanel.Controls.Add(this.panelBtnPrincipal);
            this.sidePanel.Controls.Add(this.btnAbout);
            this.sidePanel.Controls.Add(this.btnCatalogo);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.ForeColor = System.Drawing.SystemColors.Control;
            this.sidePanel.Location = new System.Drawing.Point(0, 88);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(141, 481);
            this.sidePanel.TabIndex = 6;
            // 
            // panelBtnPresupuesto
            // 
            this.panelBtnPresupuesto.BackColor = System.Drawing.Color.Gold;
            this.panelBtnPresupuesto.Location = new System.Drawing.Point(3, 53);
            this.panelBtnPresupuesto.Name = "panelBtnPresupuesto";
            this.panelBtnPresupuesto.Size = new System.Drawing.Size(10, 53);
            this.panelBtnPresupuesto.TabIndex = 3;
            // 
            // btnPresupuesto
            // 
            this.btnPresupuesto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.btnPresupuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPresupuesto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPresupuesto.FlatAppearance.BorderSize = 0;
            this.btnPresupuesto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPresupuesto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnPresupuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresupuesto.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresupuesto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPresupuesto.Location = new System.Drawing.Point(0, 53);
            this.btnPresupuesto.Name = "btnPresupuesto";
            this.btnPresupuesto.Size = new System.Drawing.Size(141, 53);
            this.btnPresupuesto.TabIndex = 1;
            this.btnPresupuesto.Text = "     Presupuesto";
            this.btnPresupuesto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPresupuesto.UseVisualStyleBackColor = false;
            this.btnPresupuesto.Click += new System.EventHandler(this.btnPresupuesto_Click);
            // 
            // panelBtnAbout
            // 
            this.panelBtnAbout.BackColor = System.Drawing.Color.MediumOrchid;
            this.panelBtnAbout.Location = new System.Drawing.Point(3, 428);
            this.panelBtnAbout.Name = "panelBtnAbout";
            this.panelBtnAbout.Size = new System.Drawing.Size(10, 53);
            this.panelBtnAbout.TabIndex = 3;
            // 
            // panelBtnPrincipal
            // 
            this.panelBtnPrincipal.BackColor = System.Drawing.Color.Lime;
            this.panelBtnPrincipal.Location = new System.Drawing.Point(3, 0);
            this.panelBtnPrincipal.Name = "panelBtnPrincipal";
            this.panelBtnPrincipal.Size = new System.Drawing.Size(10, 53);
            this.panelBtnPrincipal.TabIndex = 2;
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAbout.Location = new System.Drawing.Point(0, 428);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(141, 53);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "     About";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnCatalogo
            // 
            this.btnCatalogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.btnCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatalogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCatalogo.FlatAppearance.BorderSize = 0;
            this.btnCatalogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCatalogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.btnCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatalogo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCatalogo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCatalogo.Location = new System.Drawing.Point(0, 0);
            this.btnCatalogo.Name = "btnCatalogo";
            this.btnCatalogo.Size = new System.Drawing.Size(141, 53);
            this.btnCatalogo.TabIndex = 0;
            this.btnCatalogo.Text = "     Catalogo";
            this.btnCatalogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCatalogo.UseVisualStyleBackColor = false;
            this.btnCatalogo.Click += new System.EventHandler(this.btnCatalogo_Click);
            // 
            // presentacion
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1079, 569);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.headerPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "presentacion";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo";
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button btnCatalogo;
        private System.Windows.Forms.Panel headerPanel;
        private PictureBox picLogo;
        private Button btnAbout;
        private Panel panelBtnPrincipal;
        private Panel panelBtnAbout;
        private Button btnPresupuesto;
        private Panel panelBtnPresupuesto;
    }
}

