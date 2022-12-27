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
using System.IO;
using System.Drawing.Printing;
using System.Xml.Linq;
using System.Drawing.Imaging;

namespace presentación
{
    public partial class frmPresupuesto : Form
    {
        List<Presupuesto> listaPresupuesto = null;
        List<Producto> listaProducto = null;
        ProductoNegocio productoNegocio = null;
        bool GridViewOpen = false;
        Presupuesto auxModificar = null;

        public frmPresupuesto()
        {
            InitializeComponent();
        }

        private void frmPresupuesto_Load(object sender, EventArgs e)
        {
            listaPresupuesto = new List<Presupuesto>();
            productoNegocio = new ProductoNegocio();
            panelPrespuesto.Height = 50;

            fechaPresupuesto.Text = DateTime.Now.ToShortDateString();

            ComboBoxOptions.comboBoxProductos(cbAgregarPresupuesto);

            listaProducto = productoNegocio.listar();

            OptionGridViewOpen(GridViewOpen);
            opcionModificar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GridViewOpen = !GridViewOpen;

            if(!GridViewOpen)
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show("¿Seguro quiere eliminar el presupuesto?", "Eliminar presupuesto", btn);
                if(result == DialogResult.OK)
                {
                    OptionGridViewOpen(GridViewOpen);
                }

                return;
            }

            OptionGridViewOpen(GridViewOpen);
        }

        private void btnAgregarPrespuesto_Click(object sender, EventArgs e)
        {
            if(GridViewOpen)
            {
                if (listaProducto.Any(x => x.Nombre == cbAgregarPresupuesto.Text))
                {
                    Producto producto = (Producto)cbAgregarPresupuesto.SelectedValue;
                    decimal cantidad = numericPrespuesto.Value;

                    Presupuesto productoAux = new Presupuesto();

                    productoAux.Id = producto.Id;
                    productoAux.Codigo = producto.Codigo;
                    productoAux.Nombre = producto.Nombre;
                    productoAux.Descripcion = producto.Descripcion;
                    productoAux.Precio = producto.Precio;
                    productoAux.ImagenURL = producto.ImagenURL;
                    Categoria categoriaAux = new Categoria();
                    categoriaAux.Id = producto.CategoriaInfo.Id;
                    categoriaAux.Descripcion = producto.CategoriaInfo.Descripcion;
                    Marca marcaAux = new Marca();
                    marcaAux.Id = producto.MarcaInfo.Id;
                    marcaAux.Descripcion = producto.Descripcion;
                    productoAux.CategoriaInfo = categoriaAux;
                    productoAux.MarcaInfo = marcaAux;
                    productoAux.total = producto.Precio * cantidad;
                    productoAux.cantidad = (int)numericPrespuesto.Value;

                    listaPresupuesto.Add(productoAux);
                    numericPrespuesto.Value = 1;

                    cargarGridView();
                    Total();

                }
                else
                {
                    //Producto Custom
                }
            }
            else
            {
                MessageBox.Show("Debe crear un presupuesto primero");
            }

        }

        private void OptionGridViewOpen(bool isOpen)
        {
            panelDescarga.Visible = isOpen;
            panelPrecioTotal.Visible = isOpen;
            fechaPresupuesto.Visible = isOpen;

            if(isOpen)
            {
                lbAgregarPresupuesto.Text = "PRESUPUESTO";
                panelPrespuesto.Height = 300;
                btnAgregarGrid.Text = "-";
            }
            else
            {
                lbAgregarPresupuesto.Text = "Iniciar nuevo presupuesto";
                btnAgregarGrid.Text = "+";
                panelPrespuesto.Height = 50;
                dgvPresupuesto.DataSource = null;
            }
        }

        private void btEliminarProducto_Click(object sender, EventArgs e)
        {
            auxModificar = (Presupuesto)dgvPresupuesto.CurrentRow.DataBoundItem;
            auxModificar = listaPresupuesto.Find(x => x.Id == auxModificar.Id);
            listaPresupuesto.Remove(auxModificar);
            auxModificar = null;

            cargarGridView();
            Total();
        }

        private void Total()
        {
            decimal totalPresupuesto = 0;

            foreach (var item in listaPresupuesto)
            {
                totalPresupuesto += item.total;
            }

            if(string.IsNullOrEmpty(txtDescuento.Text))
            {
                 lbPrecio.Text = totalPresupuesto.ToString("0.00");
            }
            else
            {
                if(Validacion.esNumero(txtDescuento.Text))
                {
                    decimal descuento = Convert.ToDecimal(txtDescuento.Text);
                    lbPrecio.Text = (totalPresupuesto - ((descuento * totalPresupuesto) / 100)).ToString("0.00");
                }
            }

        }

        private void cargarGridView()
        {
            dgvPresupuesto.DataSource = null;
            dgvPresupuesto.DataSource = listaPresupuesto;
            dgvPresupuesto.Columns[Opciones.Campo.ID].Visible = false;
            dgvPresupuesto.Columns[Opciones.Campo.URLIMAGEN].Visible = false;
            dgvPresupuesto.EnableHeadersVisualStyles = false;
        }

        private void dgvPresupuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            auxModificar = (Presupuesto)dgvPresupuesto.CurrentRow.DataBoundItem;
            numericModificarPresupuesto.Value = auxModificar.cantidad;
            opcionModificar(true);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            auxModificar.cantidad = (int)numericModificarPresupuesto.Value;
            auxModificar.total = auxModificar.cantidad * auxModificar.Precio;
            listaPresupuesto.Remove(auxModificar);
            listaPresupuesto.Add(auxModificar);
            cargarGridView();
            Total();
            opcionModificar();
        }

        private void  opcionModificar(bool isModicado = false)
        {
            btnModificar.Visible = isModicado;
            numericModificarPresupuesto.Visible = isModicado;
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            dialog.Title = "Presupuesto";
            dialog.RestoreDirectory = true;

            string value = "";

            value += "PRESUPUESTO";
            value += "\t \t \t \t \t \t \t \t FECHA: " + fechaPresupuesto.Text + "\n \n"; 
            
            foreach(var item in listaPresupuesto)
            {
                value += $"{item.Nombre} - Cantidad: {item.cantidad} - Precio unitario: ${item.Precio} - SubTotal: ${item.total} \n";
            }

            value += "\n\n";

            value += $"\t \t \t \t \t \t \t \t TOTAL A PAGAR: {lbPrecio.Text}";

            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine(value);
                sw.Close();
            }
        }

        private void printPresupuesto_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Tahoma", 18, FontStyle.Bold);
            Font fontProductos = new Font("Tahoma", 14);
            int width = 800;
            int y = 80;
            Bitmap myBitmap = new Bitmap(@"C:\imageApp\logo.png");
            
            e.Graphics.DrawImage(myBitmap, new Rectangle(400, 20, 50, 50));
            e.Graphics.DrawString("PRESUPUESTO", font, Brushes.Black, new RectangleF(40, y, width, 40 ));
            e.Graphics.DrawString($"FECHA: {fechaPresupuesto.Text}", font, Brushes.Black, new RectangleF(550, y, width, 40 ));

            y += 40;

            foreach(var item in listaPresupuesto)
            {
                e.Graphics.DrawString($"{item.Nombre} - Precio: ${item.Precio} - Cantidad {item.cantidad} - Total ${item.total}", fontProductos, Brushes.Black, new RectangleF(40, y += 20, width, 20));
            }
            y += 40;
            e.Graphics.DrawString($"TOTAL: {lbPrecio.Text}", font, Brushes.Black, new RectangleF(550, y, width, 40));
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            Button btnSave = new Button();
            btnSave.Text = "Save";

            
            printPresupuesto = new PrintDocument();
            PrinterSettings printerSetting = new PrinterSettings();
            printPresupuesto.PrinterSettings = printerSetting;
            printPresupuesto.PrintPage += printPresupuesto_PrintPage;

            PrintPreviewDialog printPreview = new PrintPreviewDialog();
            printPreview.MinimumSize = new Size(375, 250);
            printPreview.SetBounds(100, -550, 800, 800);
            printPreview.Document = printPresupuesto;

            printPreview.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Total();

        }
    }
}
