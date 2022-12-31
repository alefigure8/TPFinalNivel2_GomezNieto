﻿using configuracion;
using System;
using System.Linq;

using System.Windows.Forms;


namespace helper
{
    public static class ComboBoxOptions
    {
        public static void comboBoxMarca(ComboBox combo, bool todos = false)
        {
            try
            {
                listaDesplegable listaMarca = new listaDesplegable();
                combo.DataSource = listaMarca.cargarMarcas(todos).OrderBy((x) => x.Descripcion).ToList();
                combo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        public static void comboBoxCategoria(ComboBox combo, bool todos = false)
        {
            try
            {
                listaDesplegable listaCategoria = new listaDesplegable();
                combo.DataSource = listaCategoria.cargarCategorias(todos).OrderBy((x) => x.Descripcion).ToList();
                combo.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(Opciones.MensajeError.LISTAERROR);
            }
        }

        public static void comboBoxProductos(ComboBox combo)
        {
            listaDesplegable listaProducto = new listaDesplegable();
            combo.DisplayMember = "Nombre";
            combo.DataSource = listaProducto.cargarProductos().OrderBy(x => x.Nombre).ToList();
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
