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

namespace presentación
{
    public partial class frmVistaProducto : Form
    {
        Producto producto = null; 
        public frmVistaProducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void frmVistaProducto_Load(object sender, EventArgs e)
        {
            if(this.producto != null)
            {
                lbTituloVistaProducto.Text = producto.Nombre;
            }
        }
    }
}
