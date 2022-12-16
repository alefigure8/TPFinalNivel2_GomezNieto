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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace presentación
{
    public partial class frmPrincipal : Form
    {
        private List<Producto> listaProductos;
        private List<Producto> listaProductosAux;
        int pagina;
        public frmPrincipal()
        {
            InitializeComponent();
            LoadfrmPrincipal();
            pagina = 0;
        }

        //*****METODOS*****//
        public void LoadfrmPrincipal()
        {
            try
            {
                listarProductos();
                cargarGridView();
                cantidadEncontrada();
                comboBoxOrdenarPor();
                comboBoxCantidad();
            }
            catch (Exception)
            {

                MessageBox.Show("No se pudo cargar los productos");
            }
        }

        private void cantidadEncontrada()
        {
            lbEncontrados.Text = $"{listaProductosAux.Count} productos encontrados";
        }

        private void listarProductos()
        {
            try
            {
                ProductoNegocio productos = new ProductoNegocio();
                listaProductos = productos.listar();
                listaProductosAux = listaProductos;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public void cargarGridView(bool sort = false)
        {
            //OPCIONES GRID
            dgvProductos.DataSource = listaProductos;
            dgvProductos.Columns["Id"].Visible = false;
            dgvProductos.Columns["ImagenUrl"].Visible = false;
            dgvProductos.EnableHeadersVisualStyles = false;

            //SORT
            if (sort)
            {
                sortListaProducto();
            }
        }

        private void sortListaProducto()
        {
            try
            {
                listaProductosAux = listaProductos;

            if (comboBoxOrdenar.SelectedItem.ToString() == "Nombre")
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.Nombre).ToList();
                }
                else if (comboBoxOrdenar.SelectedItem.ToString() == "Marca")
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.MarcaInfo.Descripcion).ToList();
                }
                else if (comboBoxOrdenar.SelectedItem.ToString() == "Categoria")
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.CategoriaInfo.Descripcion).ToList();
                }
                else if (comboBoxOrdenar.SelectedItem.ToString() == "Precio")
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.Precio).ToList();
                }

                mostrarPorCantidad();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        private void mostrarPorCantidad()
        {
            int mostrar = Convert.ToInt32(comboBoxMostrarCantidad.SelectedItem);
            var subset = listaProductosAux.Take(mostrar).ToList();
            dgvProductos.DataSource = subset;
            cantidadEncontrada();
        }

        private void comboBoxOrdenarPor()
        {
            comboBoxOrdenar.Items.Add("Nombre");
            comboBoxOrdenar.Items.Add("Marca");
            comboBoxOrdenar.Items.Add("Categoria");
            comboBoxOrdenar.Items.Add("Precio");
            comboBoxOrdenar.SelectedIndex = 0;
        }

        private void comboBoxCantidad()
        {
            comboBoxMostrarCantidad.Items.Add("10");
            comboBoxMostrarCantidad.Items.Add("3");
            comboBoxMostrarCantidad.Items.Add("2");
            comboBoxMostrarCantidad.Items.Add("1");
            comboBoxMostrarCantidad.SelectedIndex = 0;
        }

        private void paginacionProductos(string direccion = "adelante")
        {
            int mostrar = Convert.ToInt32(comboBoxMostrarCantidad.SelectedItem);
            int total = listaProductos.Count() / mostrar;

            if (pagina <= total && pagina >= 0)
            {
                //Siguiente
                if (direccion == "adelante")
                {
                    pagina++;

                    if (pagina > total)
                    {
                        pagina = total;
                    }
                }
                else
                {
                    pagina--;

                    if (pagina < 0)
                    {
                        pagina = 0;
                    }
                }

                //Cortar lista
                var subset = listaProductosAux.Skip(mostrar * pagina).Take(mostrar).ToList();

                //Render
                lbPaginas.Text = $"Página {pagina + 1}";
                dgvProductos.DataSource = subset;
            }
        }

        //*****EVENTOS*****//
        private void comboBoxOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            pagina = 0;
            cargarGridView(true);
        }

        private void comboBoxMostrarCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            pagina = 0;
            cargarGridView(true);
            lbPaginas.Text = $"Página {pagina + 1}";
            mostrarPorCantidad();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //Siguiente pagina
            paginacionProductos();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //Pagina anterior
            paginacionProductos("anterior");
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            //Ultima pagina
            int mostrar = Convert.ToInt32(comboBoxMostrarCantidad.SelectedItem);
            int total = listaProductos.Count() / mostrar;
            pagina = total;
            paginacionProductos();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            //Primera Pagina
            pagina = 0;
            paginacionProductos();
        }
    }
}
