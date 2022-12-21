using configuracion;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static configuracion.Opciones;

namespace helper
{
    public static class ComboBoxOptions
    {
        public static void comboBoxMarca(ComboBox combo)
        {
            try
            {
                listaDesplegable listaMarca = new listaDesplegable();
                combo.DataSource = listaMarca.cargarMarcas();
                combo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }
        public static void comboBoxCategoria(ComboBox combo)
        {
            try
            {
                listaDesplegable listaCategoria = new listaDesplegable();
                combo.DataSource = listaCategoria.cargarCategorias();
                combo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        public static void comboBoxCamposBusquedaAvanzada(ComboBox combo)
        {
            try
            {
                listaDesplegable listaCampos = new listaDesplegable();
                combo.DataSource = listaCampos.cargarBusqueraColumnas();
                combo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        public static void comboBoxOrdenarPor(ComboBox combo)
        {
            try
            {
                listaDesplegable listaCantidad = new listaDesplegable();
                combo.DataSource = listaCantidad.cargarBusqueraColumnas();
                combo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        public static void comboBoxCantidad(ComboBox combo)
        {
            try
            {
                listaDesplegable listaCantidad = new listaDesplegable();
                combo.DataSource = listaCantidad.cargarBusquedaNumeros();
                combo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }
    }

}
