namespace presentación
{
    partial class frmVistaProducto
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
            this.lbTituloVistaProducto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTituloVistaProducto
            // 
            this.lbTituloVistaProducto.AutoSize = true;
            this.lbTituloVistaProducto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloVistaProducto.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbTituloVistaProducto.Location = new System.Drawing.Point(37, 47);
            this.lbTituloVistaProducto.Name = "lbTituloVistaProducto";
            this.lbTituloVistaProducto.Size = new System.Drawing.Size(226, 25);
            this.lbTituloVistaProducto.TabIndex = 1;
            this.lbTituloVistaProducto.Text = "CARGAR PRODUCTO";
            // 
            // frmVistaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(86)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbTituloVistaProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmVistaProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista Producto";
            this.Load += new System.EventHandler(this.frmVistaProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTituloVistaProducto;
    }
}