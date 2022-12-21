using configuracion;
using helper;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using helper;
using configuracion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace presentación
{
    public partial class fmrAgregarProducto : Form
    {
        List<Marca> listaMarca;
        public fmrAgregarProducto()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            InitializeComponent();
            ComboBoxOptions.comboBoxMarca(cbAgregarMarca);
            ComboBoxOptions.comboBoxCategoria(cbAgregarcategoria);
            listaMarca = marcaNegocio.listar();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoria = new CategoriaNegocio();

            if (string.IsNullOrEmpty(cbAgregarcategoria.Text))
            {
                MessageBox.Show(Opciones.MensajeError.CAMPOVACIOTEXTO);
                return;
            }

            if (!categoria.existeCategoria(cbAgregarcategoria.Text))
            {
                try
                {
                    MessageBoxButtons btnAgregar = MessageBoxButtons.OKCancel;
                    DialogResult respuesta =  MessageBox.Show($"¿Está seguro que quiere agregar a Categoría {cbAgregarcategoria.Text}?", "Agregar Categoria", btnAgregar);

                    if (respuesta == DialogResult.OK)
                    { 
                        if (categoria.agregar(cbAgregarcategoria.Text))
                        {
                            ComboBoxOptions.comboBoxCategoria(cbAgregarcategoria);
                            MessageBox.Show(Opciones.MensajeExito.EXITOCARGARMENSAJE);
                        }
                    }

                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Opciones.MensajeError.ERRORCARGAMARCA);
                }

                return;
            }

            MessageBox.Show(Opciones.MensajeError.MARCAYAEXISTE);
        }

        private void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio= new MarcaNegocio();

            if (string.IsNullOrEmpty(cbAgregarMarca.Text))
            {
                MessageBox.Show(Opciones.MensajeError.CAMPOVACIOTEXTO);
                return;
            }

            if (!negocio.existeMarca(cbAgregarMarca.Text))
            {
                try
                {
                    if (negocio.agregar(cbAgregarMarca.Text))
                    {
                        ComboBoxOptions.comboBoxMarca(cbAgregarMarca);
                        MessageBox.Show(Opciones.MensajeExito.EXITOCARGARMENSAJE);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Opciones.MensajeError.ERRORCARGAMARCA);
                }

                return;
            }

            MessageBox.Show(Opciones.MensajeError.MARCAYAEXISTE);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //TODO: Validar en caso de que haya campos completos.
            this.Close();
        }
    }
}
