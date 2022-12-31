using System;
using System.Windows.Forms;
using dominio;
using negocio;

namespace presentación
{
    public partial class frmConfiguracionCategoriaMarca : Form
    {
        object configuracion = null;
        Form frmParent = null;
        Form frmAgregarProducto = null;
        Producto producto = null;
        public frmConfiguracionCategoriaMarca(object configuracion, Producto producto, Form parent, Form frmAgregarProducto)
        {
            this.frmAgregarProducto = frmAgregarProducto;
            frmParent = parent;
            this.producto= producto;

            InitializeComponent();
            if (configuracion.GetType() == typeof(Marca))
            {
                this.configuracion = (Marca)configuracion;
                lbConfiguracionDescripcion.Text = "Marca";
                return;
            }

            if(configuracion.GetType() == typeof(Categoria))
            {
                this.configuracion = (Categoria)configuracion;
                lbConfiguracionDescripcion.Text = "Categoria";
                return;
            }
        }

        private void frmConfiguracionCategoriaMarca_Load(object sender, EventArgs e)
        {
            txtConfiguracion.Text = configuracion.ToString();
        }

        private void btnConfiguracionModificar_Click(object sender, EventArgs e)
        {
            if (this.configuracion.GetType() == typeof(Marca))
            {
                MarcaNegocio marcaNegocio= new MarcaNegocio();
                try
                {
                    if (marcaNegocio.modificar((Marca)this.configuracion, txtConfiguracion.Text))
                        MessageBox.Show("La marca se acutualizpo con éxito");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo modificar");
                }
            }
            else
            {
                CategoriaNegocio categoriaNegocio= new CategoriaNegocio();
                try
                {
                    if(categoriaNegocio.modificar((Categoria)this.configuracion, txtConfiguracion.Text))
                        MessageBox.Show("La Categoria se acutualizpo con éxito");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo modificar");
                }
            }
        }

        private void frmConfiguracionCategoriaMarca_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frmAgregarProducto.Close();
            fmrAgregarProducto screen = new fmrAgregarProducto(producto, frmParent);
            screen.MdiParent = frmParent;
            screen.Show();
        }

        private void btnConfiguracionEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.configuracion.GetType() == typeof(Marca))
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    if (marcaNegocio.eliminar((Marca)this.configuracion))
                            MessageBox.Show("La marca se eliminó con éxito");
                    else
                        MessageBox.Show("La Marca que intenta eliminar es utilizada por otros aritíuclos");
                }
                else
                {
                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

                    if (categoriaNegocio.eliminar((Categoria)this.configuracion))
                        MessageBox.Show("La categoria se elimino con éxito");
                    else
                        MessageBox.Show("La Categoria que intenta eliminar es utilizada por otros aritíuclos");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error: No se pudo eliminar");
            }
        }
    }
}
