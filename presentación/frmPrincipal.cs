using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace presentación
{
    public partial class frmPrincipal : Form
    {
        private List<Producto> listaProductos;
        public frmPrincipal()
        {
            InitializeComponent();
            LoadfrmPrincipal();
        }

        public void LoadfrmPrincipal()
        {
            ProductoNegocio productos = new ProductoNegocio();
            listaProductos = productos.listar();
            
            try
            {
                dgvProductos.DataSource = listaProductos;
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo cargar los productos");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
