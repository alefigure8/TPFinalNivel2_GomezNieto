namespace presentación
{
    partial class frmConfiguracionCategoriaMarca
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
            this.lbConfiguracionDescripcion = new System.Windows.Forms.Label();
            this.txtConfiguracion = new System.Windows.Forms.TextBox();
            this.btnConfiguracionEliminar = new System.Windows.Forms.Button();
            this.btnConfiguracionModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbConfiguracionDescripcion
            // 
            this.lbConfiguracionDescripcion.AutoSize = true;
            this.lbConfiguracionDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbConfiguracionDescripcion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConfiguracionDescripcion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbConfiguracionDescripcion.Location = new System.Drawing.Point(12, 24);
            this.lbConfiguracionDescripcion.Name = "lbConfiguracionDescripcion";
            this.lbConfiguracionDescripcion.Size = new System.Drawing.Size(70, 16);
            this.lbConfiguracionDescripcion.TabIndex = 1;
            this.lbConfiguracionDescripcion.Text = "Categoria";
            // 
            // txtConfiguracion
            // 
            this.txtConfiguracion.Location = new System.Drawing.Point(103, 23);
            this.txtConfiguracion.Name = "txtConfiguracion";
            this.txtConfiguracion.Size = new System.Drawing.Size(221, 20);
            this.txtConfiguracion.TabIndex = 2;
            // 
            // btnConfiguracionEliminar
            // 
            this.btnConfiguracionEliminar.BackColor = System.Drawing.Color.Brown;
            this.btnConfiguracionEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracionEliminar.FlatAppearance.BorderSize = 0;
            this.btnConfiguracionEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Tomato;
            this.btnConfiguracionEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.btnConfiguracionEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracionEliminar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracionEliminar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfiguracionEliminar.Location = new System.Drawing.Point(225, 49);
            this.btnConfiguracionEliminar.Name = "btnConfiguracionEliminar";
            this.btnConfiguracionEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnConfiguracionEliminar.TabIndex = 18;
            this.btnConfiguracionEliminar.Text = "Eliminar";
            this.btnConfiguracionEliminar.UseVisualStyleBackColor = false;
            this.btnConfiguracionEliminar.Click += new System.EventHandler(this.btnConfiguracionEliminar_Click);
            // 
            // btnConfiguracionModificar
            // 
            this.btnConfiguracionModificar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConfiguracionModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracionModificar.FlatAppearance.BorderSize = 0;
            this.btnConfiguracionModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            this.btnConfiguracionModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnConfiguracionModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracionModificar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracionModificar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(86)))), ((int)(((byte)(111)))));
            this.btnConfiguracionModificar.Location = new System.Drawing.Point(134, 49);
            this.btnConfiguracionModificar.Name = "btnConfiguracionModificar";
            this.btnConfiguracionModificar.Size = new System.Drawing.Size(75, 23);
            this.btnConfiguracionModificar.TabIndex = 17;
            this.btnConfiguracionModificar.Text = "Modificar";
            this.btnConfiguracionModificar.UseVisualStyleBackColor = false;
            this.btnConfiguracionModificar.Click += new System.EventHandler(this.btnConfiguracionModificar_Click);
            // 
            // frmConfiguracionCategoriaMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(86)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(344, 102);
            this.Controls.Add(this.btnConfiguracionEliminar);
            this.Controls.Add(this.btnConfiguracionModificar);
            this.Controls.Add(this.txtConfiguracion);
            this.Controls.Add(this.lbConfiguracionDescripcion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfiguracionCategoriaMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfiguracionCategoriaMarca_FormClosing);
            this.Load += new System.EventHandler(this.frmConfiguracionCategoriaMarca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbConfiguracionDescripcion;
        private System.Windows.Forms.TextBox txtConfiguracion;
        private System.Windows.Forms.Button btnConfiguracionEliminar;
        private System.Windows.Forms.Button btnConfiguracionModificar;
    }
}