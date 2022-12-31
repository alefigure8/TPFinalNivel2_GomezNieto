using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using negocio;
using dominio;
using helper;
using configuracion;
using System.IO;

namespace presentación
{
    public partial class frmPrincipal : Form
    {
         Form parent;
        private List<Producto> listaProductos = null;
        private List<Producto> listaProductosAux;
        int pagina;

        public frmPrincipal(Form parent)
        {
            this.parent = parent;
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
                cargarImagenes();

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

        private void cargarImagenes()
        {
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory().Replace(@"\bin", "")) + Opciones.Folder.ROOTIMAGE;
            btnFirst.Load(path + Opciones.Folder.PRIMERO);
            btnLast.Load(path + Opciones.Folder.ULTIMA);
            btnNext.Load(path + Opciones.Folder.SIGUIENTE);
            btnPreview.Load(path + Opciones.Folder.ANTERIOR); 
        }

        private void cargarComboBox()
        {
            comboBoxCriterioBusquedaAvanzada();
            ComboBoxOptions.comboBoxOrdenarPor(comboBoxOrdenar);
            ComboBoxOptions.comboBoxCantidad(comboBoxMostrarCantidad);
            ComboBoxOptions.comboBoxCamposBusquedaAvanzada(cbCampo);
            ComboBoxOptions.comboBoxCategoria(cbCategoria, true);
            ComboBoxOptions.comboBoxMarca(cbMarca, true);
        
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
            catch (Exception)
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
            catch (Exception)
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
                else if(direccion == Opciones.Paginacion.PRIMERA)
                {
                    if (pagina < 0)
                        pagina = 0;
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
            paginacionProductos(Opciones.Paginacion.PRIMERA);
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Mostrar productos al hacer doble click sobre uno en el grid view
            Producto producto = new Producto();
            if(dgvProductos.CurrentRow != null)
            {
                fmrAgregarProducto screen = new fmrAgregarProducto((Producto)dgvProductos.CurrentRow.DataBoundItem, parent);
                screen.MdiParent = parent;
                screen.Show();
                
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
                string marca = cbMarca.SelectedItem.ToString() == Opciones.Buscador.TODOS ? "" : cbMarca.SelectedItem.ToString();
                string categoria = cbCategoria.SelectedItem.ToString() == Opciones.Buscador.TODOS ? "" : cbCategoria.SelectedItem.ToString();

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            fmrAgregarProducto screen = new fmrAgregarProducto(parent);
            screen.MdiParent = parent;
            screen.Show();
        }

        private void dgvProductos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex >= 0 & e.RowIndex>=0)
            {
                var cell = dgvProductos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = "Doble click para acceder a la descripción";
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog() { Filter = "Excel|*.csv", Title = "Guardar Presupuesto", FileName = $"Productos - {DateTime.Now.ToString("dddd, dd MMMM yyyy")}" })
            {
                //Validar si el gridView está vacío
                if (listaProductos.Count() == 0)
                {
                    MessageBox.Show("Selecciones algunos productos antes de generar un archivo");
                    return;
                }

                //Generar archivo
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveDialog.FileName;

                    string csv = string.Empty;

                    //Add the Header row for CSV file.
                    csv += $"Id,Codigo,Nombre,Descripcion,Precio,ImagenURL,MarcaInfo.Id,MarcaInfo.Descripcion,CategoriaInfo.Id,CategoriaInfo.Descripcion";

                    //Add new line.
                    csv += "\r\n";

                    //Adding the Rows
                    foreach (var item in listaProductos)
                    {

                        //Add the Data rows.
                        csv += $"{item.Id},{item.Codigo},{item.Nombre},{item.Descripcion},{item.Precio.ToString().Replace(",", ";")},{item.ImagenURL},{item.MarcaInfo.Id},{item.MarcaInfo.Descripcion},{item.CategoriaInfo.Id},{item.CategoriaInfo.Descripcion}";

                        //Add new line.
                        csv += "\r\n";
                    }

                    //Guardar
                    try
                    {
                       File.WriteAllText(fileName, csv);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("El archivo no se pudo guardar");
                    }
                }
            }
        }
    }
}
