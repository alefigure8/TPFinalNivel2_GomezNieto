﻿using configuracion;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace presentación
{
    public partial class presentacion : Form
    {

        public presentacion()
        {
            InitializeComponent();
            LoadPresentacion();
        }

        private void LoadPresentacion()
        {
            frmPrincipal screen = new frmPrincipal(this);
            screen.MdiParent = this;
            screen.Show();
            propiedadesBtn();
            cargarFecha(); 
            cargarImagenes();
        }

        private void cargarFecha()
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void cargarImagenes()
        {
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
            picLogo.Load(path + Opciones.Folder.ICONO);
            this.Icon = new Icon(path + Opciones.Folder.ICONO);
        }

        protected override void OnLoad(EventArgs e)
        {
            //Remover Bordes MDIContainer
            var mdiclient = this.Controls.OfType<MdiClient>().Single();
            this.SuspendLayout();
            mdiclient.SuspendLayout();
            var hdiff = mdiclient.Size.Width - mdiclient.ClientSize.Width;
            var vdiff = mdiclient.Size.Height - mdiclient.ClientSize.Height;
            var size = new Size(mdiclient.Width + hdiff, mdiclient.Height + vdiff);
            var location = new Point(mdiclient.Left - (hdiff / 2), mdiclient.Top - (vdiff / 2));
            mdiclient.Dock = DockStyle.None;
            mdiclient.Size = size;
            mdiclient.Location = location;
            mdiclient.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            mdiclient.ResumeLayout(true);
            this.ResumeLayout(true);
            base.OnLoad(e);

            //Remover Menu MDIContainer
            this.MainMenuStrip = new MenuStrip();
            this.MainMenuStrip.Visible = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            frmAbout screen = new frmAbout();
            screen.MdiParent = this;
            screen.Show();
            propiedadesBtn();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            frmPrincipal screen = new frmPrincipal(this);
            screen.MdiParent = this;
            screen.Show();
            propiedadesBtn();
        }

        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            frmPresupuesto screen = new frmPresupuesto();
            screen.MdiParent = this;
            screen.Show();
            propiedadesBtn();
        }

        private void propiedadesBtn()
        {
            Color btnNonSelected = Color.FromArgb(38,62,79);
            Color btnSelected = Color.FromArgb(27, 44, 56);

            foreach (var views in this.MdiChildren)
            {
                if (views is frmPrincipal)
                {
                    panelBtnAbout.Visible = false;
                    panelBtnPresupuesto.Visible = false;
                    panelBtnPrincipal.Visible = true;
                    btnPresupuesto.BackColor = btnNonSelected;
                    btnAbout.BackColor = btnNonSelected;
                    btnCatalogo.BackColor = btnSelected;
                }
                else if(views is frmAbout)
                {
                    panelBtnAbout.Visible = true;
                    panelBtnPrincipal.Visible = false;
                    panelBtnPresupuesto.Visible = false;
                    btnPresupuesto.BackColor = btnNonSelected;
                    btnAbout.BackColor = btnSelected;
                    btnCatalogo.BackColor = btnNonSelected;
                }
                else if(views is frmPresupuesto)
                {
                    panelBtnAbout.Visible = false;
                    panelBtnPresupuesto.Visible = true;
                    panelBtnPrincipal.Visible = false;
                    btnPresupuesto.BackColor = btnSelected;
                    btnAbout.BackColor = btnNonSelected;
                    btnCatalogo.BackColor = btnNonSelected;
                }
            }
        }
    }
}
