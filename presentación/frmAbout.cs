using configuracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentación
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
            pbVersion.Load(path + Opciones.Folder.VERSION);
            pbAutor.Load(path + Opciones.Folder.AUTOR);
            pbGitHub.Load(path + Opciones.Folder.GITHUB);
            pbWeb.Load(path + Opciones.Folder.WEB);
            pbMail.Load(path + Opciones.Folder.MAIL);
        }

        private void lbGithHub_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/alefigure8/TPFinalNivel2_GomezNieto");
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede acceder al link");
            }
        }

        private void lbWeb_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://alegomeznieto.tech");
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede acceder al link");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            { 
                Process.Start("mailto:gomeznieto@gmail.com");
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede acceder al link");
            }
        }
    }
}
