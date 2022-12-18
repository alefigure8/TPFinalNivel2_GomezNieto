using System.Windows.Forms;

namespace presentación
{
    partial class frmPrincipal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.labelFrmPrincipalCatalogo = new System.Windows.Forms.Label();
            this.lbShow = new System.Windows.Forms.Label();
            this.comboBoxMostrarCantidad = new System.Windows.Forms.ComboBox();
            this.lbEncontrados = new System.Windows.Forms.Label();
            this.comboBoxOrdenar = new System.Windows.Forms.ComboBox();
            this.lbOrdenar = new System.Windows.Forms.Label();
            this.lbPaginas = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.btnLast = new System.Windows.Forms.PictureBox();
            this.btnFirst = new System.Windows.Forms.PictureBox();
            this.btnPreview = new System.Windows.Forms.PictureBox();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.panelSearchTitlle = new System.Windows.Forms.Panel();
            this.lbSearchTitle = new System.Windows.Forms.Label();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbBusquedaAvanzada = new System.Windows.Forms.Label();
            this.checlBusquedaAvanzada = new System.Windows.Forms.CheckBox();
            this.lbCampo = new System.Windows.Forms.Label();
            this.lbCriterio = new System.Windows.Forms.Label();
            this.lbMarca = new System.Windows.Forms.Label();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.cbCampo = new System.Windows.Forms.ComboBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).BeginInit();
            this.panelSearch.SuspendLayout();
            this.panelSearchTitlle.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle36;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle37.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle37.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle37.NullValue = null;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle38.NullValue = null;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle38;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.WindowText;
            this.dgvProductos.Location = new System.Drawing.Point(28, 118);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle39;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 35;
            this.dgvProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle40;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(550, 252);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
            // 
            // labelFrmPrincipalCatalogo
            // 
            this.labelFrmPrincipalCatalogo.AutoSize = true;
            this.labelFrmPrincipalCatalogo.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrmPrincipalCatalogo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelFrmPrincipalCatalogo.Location = new System.Drawing.Point(33, 47);
            this.labelFrmPrincipalCatalogo.Name = "labelFrmPrincipalCatalogo";
            this.labelFrmPrincipalCatalogo.Size = new System.Drawing.Size(127, 25);
            this.labelFrmPrincipalCatalogo.TabIndex = 1;
            this.labelFrmPrincipalCatalogo.Text = "CATÁLOGO";
            // 
            // lbShow
            // 
            this.lbShow.AutoSize = true;
            this.lbShow.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShow.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbShow.Location = new System.Drawing.Point(429, 86);
            this.lbShow.Name = "lbShow";
            this.lbShow.Size = new System.Drawing.Size(59, 16);
            this.lbShow.TabIndex = 2;
            this.lbShow.Text = "Mostrar";
            // 
            // comboBoxMostrarCantidad
            // 
            this.comboBoxMostrarCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMostrarCantidad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMostrarCantidad.FormattingEnabled = true;
            this.comboBoxMostrarCantidad.Location = new System.Drawing.Point(494, 85);
            this.comboBoxMostrarCantidad.Name = "comboBoxMostrarCantidad";
            this.comboBoxMostrarCantidad.Size = new System.Drawing.Size(84, 21);
            this.comboBoxMostrarCantidad.TabIndex = 3;
            this.comboBoxMostrarCantidad.SelectedIndexChanged += new System.EventHandler(this.comboBoxMostrarCantidad_SelectedIndexChanged);
            // 
            // lbEncontrados
            // 
            this.lbEncontrados.AutoSize = true;
            this.lbEncontrados.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEncontrados.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbEncontrados.Location = new System.Drawing.Point(35, 87);
            this.lbEncontrados.Name = "lbEncontrados";
            this.lbEncontrados.Size = new System.Drawing.Size(171, 16);
            this.lbEncontrados.TabIndex = 4;
            this.lbEncontrados.Text = "5 productos encontrados";
            // 
            // comboBoxOrdenar
            // 
            this.comboBoxOrdenar.DropDownHeight = 80;
            this.comboBoxOrdenar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrdenar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxOrdenar.FormattingEnabled = true;
            this.comboBoxOrdenar.IntegralHeight = false;
            this.comboBoxOrdenar.Location = new System.Drawing.Point(339, 86);
            this.comboBoxOrdenar.Name = "comboBoxOrdenar";
            this.comboBoxOrdenar.Size = new System.Drawing.Size(84, 21);
            this.comboBoxOrdenar.TabIndex = 6;
            this.comboBoxOrdenar.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrdenar_SelectedIndexChanged);
            // 
            // lbOrdenar
            // 
            this.lbOrdenar.AutoSize = true;
            this.lbOrdenar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOrdenar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbOrdenar.Location = new System.Drawing.Point(247, 87);
            this.lbOrdenar.Name = "lbOrdenar";
            this.lbOrdenar.Size = new System.Drawing.Size(86, 16);
            this.lbOrdenar.TabIndex = 5;
            this.lbOrdenar.Text = "Ordenar por";
            // 
            // lbPaginas
            // 
            this.lbPaginas.AutoSize = true;
            this.lbPaginas.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPaginas.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbPaginas.Location = new System.Drawing.Point(276, 385);
            this.lbPaginas.Name = "lbPaginas";
            this.lbPaginas.Size = new System.Drawing.Size(57, 16);
            this.lbPaginas.TabIndex = 7;
            this.lbPaginas.Text = "Páginas";
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(339, 385);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(11, 16);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnNext.TabIndex = 8;
            this.btnNext.TabStop = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.Location = new System.Drawing.Point(356, 385);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(18, 16);
            this.btnLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLast.TabIndex = 9;
            this.btnLast.TabStop = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.Location = new System.Drawing.Point(235, 385);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(18, 16);
            this.btnFirst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFirst.TabIndex = 11;
            this.btnFirst.TabStop = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.Location = new System.Drawing.Point(259, 385);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(11, 16);
            this.btnPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPreview.TabIndex = 10;
            this.btnPreview.TabStop = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.panelSearch.Controls.Add(this.cbMarca);
            this.panelSearch.Controls.Add(this.cbCategoria);
            this.panelSearch.Controls.Add(this.cbCriterio);
            this.panelSearch.Controls.Add(this.cbCampo);
            this.panelSearch.Controls.Add(this.lbCategoria);
            this.panelSearch.Controls.Add(this.lbMarca);
            this.panelSearch.Controls.Add(this.lbCriterio);
            this.panelSearch.Controls.Add(this.lbCampo);
            this.panelSearch.Controls.Add(this.checlBusquedaAvanzada);
            this.panelSearch.Controls.Add(this.lbBusquedaAvanzada);
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txtBoxSearch);
            this.panelSearch.Location = new System.Drawing.Point(601, 142);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(307, 228);
            this.panelSearch.TabIndex = 12;
            // 
            // panelSearchTitlle
            // 
            this.panelSearchTitlle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panelSearchTitlle.Controls.Add(this.lbSearchTitle);
            this.panelSearchTitlle.Location = new System.Drawing.Point(601, 118);
            this.panelSearchTitlle.Name = "panelSearchTitlle";
            this.panelSearchTitlle.Size = new System.Drawing.Size(307, 24);
            this.panelSearchTitlle.TabIndex = 13;
            // 
            // lbSearchTitle
            // 
            this.lbSearchTitle.AutoSize = true;
            this.lbSearchTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSearchTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbSearchTitle.Location = new System.Drawing.Point(116, 5);
            this.lbSearchTitle.Name = "lbSearchTitle";
            this.lbSearchTitle.Size = new System.Drawing.Size(67, 16);
            this.lbSearchTitle.TabIndex = 0;
            this.lbSearchTitle.Text = "Buscador";
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtBoxSearch.Location = new System.Drawing.Point(21, 16);
            this.txtBoxSearch.MaxLength = 200;
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(268, 21);
            this.txtBoxSearch.TabIndex = 0;
            this.txtBoxSearch.Tag = "";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(86)))), ((int)(((byte)(111)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.Location = new System.Drawing.Point(21, 187);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // lbBusquedaAvanzada
            // 
            this.lbBusquedaAvanzada.AutoSize = true;
            this.lbBusquedaAvanzada.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBusquedaAvanzada.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbBusquedaAvanzada.Location = new System.Drawing.Point(21, 43);
            this.lbBusquedaAvanzada.Name = "lbBusquedaAvanzada";
            this.lbBusquedaAvanzada.Size = new System.Drawing.Size(139, 16);
            this.lbBusquedaAvanzada.TabIndex = 2;
            this.lbBusquedaAvanzada.Text = "Busqueda Avanzada";
            // 
            // checlBusquedaAvanzada
            // 
            this.checlBusquedaAvanzada.AutoSize = true;
            this.checlBusquedaAvanzada.Location = new System.Drawing.Point(168, 45);
            this.checlBusquedaAvanzada.Name = "checlBusquedaAvanzada";
            this.checlBusquedaAvanzada.Size = new System.Drawing.Size(15, 14);
            this.checlBusquedaAvanzada.TabIndex = 3;
            this.checlBusquedaAvanzada.UseVisualStyleBackColor = true;
            this.checlBusquedaAvanzada.CheckedChanged += new System.EventHandler(this.checlBusquedaAvanzada_CheckedChanged);
            // 
            // lbCampo
            // 
            this.lbCampo.AutoSize = true;
            this.lbCampo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCampo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbCampo.Location = new System.Drawing.Point(21, 80);
            this.lbCampo.Name = "lbCampo";
            this.lbCampo.Size = new System.Drawing.Size(49, 14);
            this.lbCampo.TabIndex = 4;
            this.lbCampo.Text = "Campo";
            // 
            // lbCriterio
            // 
            this.lbCriterio.AutoSize = true;
            this.lbCriterio.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCriterio.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbCriterio.Location = new System.Drawing.Point(171, 80);
            this.lbCriterio.Name = "lbCriterio";
            this.lbCriterio.Size = new System.Drawing.Size(52, 14);
            this.lbCriterio.TabIndex = 5;
            this.lbCriterio.Text = "Criterio";
            // 
            // lbMarca
            // 
            this.lbMarca.AutoSize = true;
            this.lbMarca.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMarca.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbMarca.Location = new System.Drawing.Point(24, 132);
            this.lbMarca.Name = "lbMarca";
            this.lbMarca.Size = new System.Drawing.Size(43, 14);
            this.lbMarca.TabIndex = 6;
            this.lbMarca.Text = "Marca";
            // 
            // lbCategoria
            // 
            this.lbCategoria.AutoSize = true;
            this.lbCategoria.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategoria.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbCategoria.Location = new System.Drawing.Point(171, 132);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(66, 14);
            this.lbCategoria.TabIndex = 7;
            this.lbCategoria.Text = "Categoria";
            // 
            // cbCampo
            // 
            this.cbCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCampo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCampo.FormattingEnabled = true;
            this.cbCampo.Location = new System.Drawing.Point(21, 97);
            this.cbCampo.Name = "cbCampo";
            this.cbCampo.Size = new System.Drawing.Size(121, 21);
            this.cbCampo.TabIndex = 8;
            this.cbCampo.SelectedIndexChanged += new System.EventHandler(this.cbCampo_SelectedIndexChanged);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(168, 97);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(121, 21);
            this.cbCriterio.TabIndex = 9;
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(169, 149);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbCategoria.TabIndex = 10;
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(21, 149);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(121, 21);
            this.cbMarca.TabIndex = 11;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(86)))), ((int)(((byte)(111)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1445, 715);
            this.ControlBox = false;
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelSearchTitlle);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lbPaginas);
            this.Controls.Add(this.comboBoxOrdenar);
            this.Controls.Add(this.lbOrdenar);
            this.Controls.Add(this.lbEncontrados);
            this.Controls.Add(this.comboBoxMostrarCantidad);
            this.Controls.Add(this.lbShow);
            this.Controls.Add(this.labelFrmPrincipalCatalogo);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreview)).EndInit();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.panelSearchTitlle.ResumeLayout(false);
            this.panelSearchTitlle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label labelFrmPrincipalCatalogo;
        private Label lbShow;
        private ComboBox comboBoxMostrarCantidad;
        private Label lbEncontrados;
        private ComboBox comboBoxOrdenar;
        private Label lbOrdenar;
        private Label lbPaginas;
        private PictureBox btnNext;
        private PictureBox btnLast;
        private PictureBox btnFirst;
        private PictureBox btnPreview;
        private Panel panelSearch;
        private Panel panelSearchTitlle;
        private Label lbSearchTitle;
        private Button btnSearch;
        private TextBox txtBoxSearch;
        private CheckBox checlBusquedaAvanzada;
        private Label lbBusquedaAvanzada;
        private Label lbCategoria;
        private Label lbMarca;
        private Label lbCriterio;
        private Label lbCampo;
        private ComboBox cbMarca;
        private ComboBox cbCategoria;
        private ComboBox cbCriterio;
        private ComboBox cbCampo;
    }
}