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
using helper;
using configuracion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace presentación
{
    public partial class frmPrincipal : Form
    {
        private List<Producto> listaProductos = null;
        private List<Producto> listaProductosAux;
        int pagina;

        public frmPrincipal()
        {
            InitializeComponent();
            pagina = 0;

            //Cargar las listas solo una vez
            if(listaProductos == null)
                LoadfrmPrincipal();
        }

        //*****METODOS*****//
        public void LoadfrmPrincipal()
        {
            try
            {
                listarProductos();
                cargarGridView();
                cantidadEncontrada();
                cargarComboBox();

                //Panel busqueda avanzada tamaño minimozado
                if (!checlBusquedaAvanzada.Checked)
                {
                    panelSearch.Size = new Size(307, 75);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.PRODUCTOERROR);
            }
        }

        private void cargarComboBox()
        {
            comboBoxOrdenarPor();
            comboBoxCantidad();
            comboBoxCamposBusquedaAvanzada();
            comboBoxCriterioBusquedaAvanzada();
            comboBoxMarca();
            comboBoxCategoria();
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
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        public void cargarGridView(bool sort = false)
        {
            //OPCIONES GRID
            dgvProductos.DataSource = listaProductosAux;
            dgvProductos.Columns[Opciones.Campo.ID].Visible = false;
            dgvProductos.Columns[Opciones.Campo.URLIMAGEN].Visible = false;
            dgvProductos.EnableHeadersVisualStyles = false;

            //SORT
            if (sort)
                sortListaProducto();
        }

        private void sortListaProducto()
        {
            try
            {
                listaProductosAux = listaProductos;

                if (comboBoxOrdenar.SelectedItem.ToString() == Opciones.Campo.NOMBRE)
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.Nombre).ToList();
                }
                else if (comboBoxOrdenar.SelectedItem.ToString() == Opciones.Campo.MARCA)
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.MarcaInfo.Descripcion).ToList();
                }
                else if (comboBoxOrdenar.SelectedItem.ToString() == Opciones.Campo.CATEGORIA)
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.CategoriaInfo.Descripcion).ToList();
                }
                else if (comboBoxOrdenar.SelectedItem.ToString() == Opciones.Campo.PRECIO)
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.Precio).ToList();
                }
                else if (comboBoxOrdenar.SelectedItem.ToString() == Opciones.Campo.CODIGO)
                {
                    listaProductosAux = listaProductosAux.OrderBy(x => x.Codigo).ToList();
                }

                mostrarPorCantidad();
            }
            catch (Exception e)
            {
                MessageBox.Show(Opciones.MensajeError.CAMPOVACIO);
            }
        }

        private void mostrarPorCantidad()
        {
            int mostrar = Convert.ToInt32(comboBoxMostrarCantidad.SelectedItem);
            var subset = listaProductosAux.Take(mostrar).ToList();
            dgvProductos.DataSource = subset;
            cantidadEncontrada();
        }

       private void comboBoxCriterioBusquedaAvanzada()
        {
            try
            {
                listaDesplegable listaCriterio = new listaDesplegable();

                if(cbCampo.Text == Opciones.Campo.PRECIO)
                    cbCriterio.DataSource = listaCriterio.cargarBusquedaCriterioNumero();
                else
                    cbCriterio.DataSource = listaCriterio.cargarBusquedaCriterioTexto();

                cbCriterio.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR); ;
            }
        }

        private void comboBoxCamposBusquedaAvanzada()
        {
            try
            {
                listaDesplegable listaCampos = new listaDesplegable();
                cbCampo.DataSource = listaCampos.cargarBusqueraColumnas();
                cbCampo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        private void comboBoxOrdenarPor()
        {
            try
            {
                listaDesplegable listaCantidad = new listaDesplegable();
                comboBoxOrdenar.DataSource = listaCantidad.cargarBusqueraColumnas();
                comboBoxOrdenar.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        private void comboBoxCantidad()
        {
            try
            {
                listaDesplegable listaCantidad = new listaDesplegable();
                comboBoxMostrarCantidad.DataSource = listaCantidad.cargarBusquedaNumeros();
                comboBoxMostrarCantidad.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        private void comboBoxMarca()
        {
            try
            {
                listaDesplegable listaMarca = new listaDesplegable();
                cbMarca.DataSource = listaMarca.cargarMarcas();
                cbMarca.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }
        private void comboBoxCategoria()
        {
            try
            {
                listaDesplegable listaCategoria = new listaDesplegable();
                cbCategoria.DataSource = listaCategoria.cargarCategorias();
                cbCategoria.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        private void paginacionProductos(string direccion = Opciones.PaginacionControl.ADELANTE)
        {
            int mostrar = Convert.ToInt32(comboBoxMostrarCantidad.SelectedItem);
            int total = listaProductos.Count() / mostrar;

            if (pagina <= total && pagina >= 0)
            {
                //Siguiente
                if (direccion == Opciones.PaginacionControl.ADELANTE)
                {
                    pagina++;

                    if (pagina > total)
                        pagina = total;
                }
                //Anterior
                else
                {
                    pagina--;

                    if (pagina < 0)
                        pagina = 0;
                }

                //Cortar lista
                var subset = listaProductosAux.Skip(mostrar * pagina).Take(mostrar).ToList();

                //Render elementos
                lbPaginas.Text = $"{Opciones.Paginacion.PAGINA} {pagina + 1}";
                dgvProductos.DataSource = subset;
            }
        }

        private bool validarNumeros()
        {
            string filtro = txtBoxSearch.Text;
            string campo = cbCampo.SelectedItem.ToString();

            if (campo == Opciones.Campo.PRECIO && (!int.TryParse(filtro, out int validate) || string.IsNullOrEmpty(filtro)))
            {
                MessageBox.Show(Opciones.MensajeError.MENSAJENUMERO);
                return true;
            }

            return false;
        }

        private bool validarFiltro(System.Windows.Forms.ComboBox combo)
        {
            if (combo.SelectedIndex < 0)
            {
                MessageBox.Show(Opciones.MensajeError.CAMPOVACIO);
                return true;
            }

            return false;
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
            lbPaginas.Text = $"{Opciones.Paginacion.PAGINA} {pagina + 1}";
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
            paginacionProductos(Opciones.PaginacionControl.ATRAS);
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

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Mostrar productos al hacer doble click sobre uno en el grid view
            Producto producto = new Producto();
            if(dgvProductos.CurrentRow != null)
            {
                producto = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                MessageBox.Show(producto.Nombre);
            }
        }

        private void checlBusquedaAvanzada_CheckedChanged(object sender, EventArgs e)
        {
            if(checlBusquedaAvanzada.Checked)
                panelSearch.Size = new Size(307, 228);
            else
                panelSearch.Size = new Size(307, 75);
        }

        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCriterioBusquedaAvanzada();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
                ProductoNegocio productos = new ProductoNegocio();

                string filtro = txtBoxSearch.Text;
                string campo = cbCampo.SelectedItem.ToString();
                string criterio = cbCriterio.SelectedItem.ToString();
                string marca = cbMarca.SelectedItem.ToString() == "Todos" ? "" : cbMarca.SelectedItem.ToString();
                string categoria = cbCategoria.SelectedItem.ToString() == "Todos" ? "" : cbCategoria.SelectedItem.ToString();

            // Validar si es numero
            if (validarNumeros())
                return;

            //Validar si los campos estan vacios
            if (validarFiltro(cbCampo) || validarFiltro(cbCriterio))
                return;

            try
            {
                listaProductos = productos.busquedaAvanzada(filtro, campo, criterio, categoria, marca);
                listaProductosAux = listaProductos;

                //Poner pagina en cero
                pagina = 0;

                //Cargar Grid
                cargarGridView(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!checlBusquedaAvanzada.Checked)
            {
                ProductoNegocio productos = new ProductoNegocio();
                string busqueda = txtBoxSearch.Text;

                try
                {
                    if(string.IsNullOrEmpty(busqueda) || busqueda.Length > 3)
                    {
                        listaProductos =  productos.busquedaSimple(busqueda);
                        listaProductosAux = listaProductos;
                        //Poner pagina en cero
                        pagina = 0;

                        //Cargar Grid
                        cargarGridView(true);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(Opciones.MensajeError.LISTAERROR);
                }


            }
        }
    }
}
