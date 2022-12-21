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
        Producto producto = null;
        private OpenFileDialog file = null;
        List<Marca> listaMarca;
        List<Producto> listaProducto;

        public fmrAgregarProducto()
        {
            InitializeComponent();
        }

        public fmrAgregarProducto(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void fmrAgregarProducto_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            ComboBoxOptions.comboBoxMarca(cbAgregarMarca);
            ComboBoxOptions.comboBoxMarca(cbMarca);
            ComboBoxOptions.comboBoxCategoria(cbAgregarcategoria);
            ComboBoxOptions.comboBoxCategoria(cbCategoria);

            listaMarca = marcaNegocio.listar();
            listaProducto = productoNegocio.listar();

            errorInvisible();

            if (producto != null)
            {
                //TODO cargar formulario
                lbTituloCargarProducto.Text = "MODIFICAR PRODUCTO";
                btnAgregarProducto.Text = "Modificar";
            }
            else
            {
                producto = new Producto();
            }
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
                            //Recargar ComboBoxes
                            ComboBoxOptions.comboBoxCategoria(cbAgregarcategoria);
                            ComboBoxOptions.comboBoxCategoria(cbCategoria);

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
                    MessageBoxButtons btnAgregar = MessageBoxButtons.OKCancel;
                    DialogResult respuesta = MessageBox.Show($"¿Está seguro que quiere agregar a Marca {cbAgregarcategoria.Text}?", "Agregar Marca", btnAgregar);

                    if(respuesta == DialogResult.OK)
                    {
                        if (negocio.agregar(cbAgregarMarca.Text))
                        {
                            //Recargar ComboBoxes
                            ComboBoxOptions.comboBoxMarca(cbAgregarMarca);
                            ComboBoxOptions.comboBoxMarca(cbMarca);
                            MessageBox.Show(Opciones.MensajeExito.EXITOCARGARMENSAJE);
                        }
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
            string codigo = txtAgregarCodigo.Text;
            string nombre = txtAgregarArticulo.Text;
            string precio = txtAgregarPrecio.Text;
            
            if(string.IsNullOrEmpty(precio) && string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(codigo))
            {
                 this.Close();
            }
            else
            {
                MessageBoxButtons btn = MessageBoxButtons.OKCancel;
                DialogResult result =  MessageBox.Show("Si cancela todos los datos se perderan", "Advertencia", btn);

                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Variables formulario
            string precio = txtAgregarPrecio.Text.Trim();
            string codigo = txtAgregarCodigo.Text.Trim();
            string nombre = txtAgregarArticulo.Text.Trim();
            string descripcion = txtAgregarDescripcion.Text.Trim();
            string imagenURL = txtAgregarImagen.Text.Trim();
            Marca marca;
            Categoria categoria;

            //Validar si codigo ya se encuentra cargado
            if (listaProducto.Any(prod => prod.Codigo.ToLower() == codigo.ToLower()))
            {
                MessageBox.Show("El codigo que intenta ingresar ya existe");
                return;
            }

            //Validar ComboBox
            if (Validacion.estaSeleccionado(cbMarca) && Validacion.estaSeleccionado(cbCategoria))
            {
               marca  = (Marca)cbMarca.SelectedItem;
               categoria  = (Categoria)cbCategoria.SelectedItem;
            }
            else
            {
                MessageBox.Show("Marca o Categoria sin seleccionar");
                return;
            }

            // Validar Campos Vacíos
            List<string> listaValidar = new List<string>()
            {
                nombre,
                codigo,
                precio,
                descripcion,
                imagenURL,
            };

            if(Validacion.estaVacio(listaValidar))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            //Validar Numeros
            if(!Validacion.esNumero(precio))
            {
                MessageBox.Show("El precio solo puede ser un número");
                return;
            }

            producto.Codigo = codigo;
            producto.Precio = decimal.Parse(precio);
            producto.Nombre = nombre;
            producto.Descripcion = descripcion;
            producto.ImagenURL = imagenURL;
            producto.MarcaInfo= marca;
            producto.CategoriaInfo= categoria;

            try
            {
                Metodos.cargarimagen(pbCargarProducto, imagenURL);
            }
            catch(Exception ex)
            {
                MessageBox.Show("La iamgen no pudo ser cargada");
            }

            ProductoNegocio productoNegocio = new ProductoNegocio();

            //Agregara la Base de Datos
            try
            {
                try
                {
                    if(file != null && !txtAgregarImagen.Text.ToLower().Contains("http"))
                    {
                        Metodos.copiarImagen(producto, file);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Cambie la imagen y luego intenté guardar nuevamente");
                    file = null;
                    txtAgregarImagen.Text = "";
                    return;
                }

                if (productoNegocio.agregar(producto))
                {
                    MessageBox.Show("El Producto fue agregado con éxito");

                    //Reset Formulario
                    txtAgregarPrecio.Text = "";
                    txtAgregarCodigo.Text = "";
                    txtAgregarArticulo.Text = "";
                    txtAgregarDescripcion.Text = "";
                    txtAgregarImagen.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El producto no pudo ser cargado");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            file = new OpenFileDialog();
            file.Filter = "All|*|Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Tiff Image (.tiff)|*.tiff|Wmf Image (.wmf)|*.wmf";
            
            if (file.ShowDialog() == DialogResult.OK)
            {
                txtAgregarImagen.Text = file.FileName;
                try
                {
                    Metodos.cargarimagen(pbCargarProducto, file.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La iamgen no pudo ser cargada");
                }
            }
        }

        private void errorInvisible()
        {
            lbErrorArticulo.Visible = false;
            lbErrorCodigo.Visible = false;
            lbErrorDescripcion.Visible = false;
            lbErrorPrecio.Visible = false;
        }
    }
}
