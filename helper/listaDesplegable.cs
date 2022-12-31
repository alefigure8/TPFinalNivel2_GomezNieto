using System;
using System.Collections.Generic;
using negocio;
using dominio;
using configuracion;

namespace helper
{
    public class listaDesplegable
    {
        private List<string> columnasProductos;
        private List<string> cantidadPorPagina;
        private List<string> criterioBusquedaTexto;
        private List<string> criterioBusquedaNumero;

        public List<string>  cargarBusqueraColumnas()
        {
            columnasProductos = new List<string>()
            {
                Opciones.Campo.NOMBRE,
                Opciones.Campo.CODIGO,
                Opciones.Campo.PRECIO,
                Opciones.Campo.DESCRIPCION,
            };
            return columnasProductos;
        }

       public List<string> cargarBusquedaNumeros()
        {
            cantidadPorPagina = new List<string>()
            {
                Opciones.Numero.CINCUENTA,
                Opciones.Numero.TREINTA,
                Opciones.Numero.VEINTE,
                Opciones.Numero.DIEZ,
            };
            return cantidadPorPagina;
        }

        public List<string> cargarBusquedaCriterioTexto()
        {
            criterioBusquedaTexto = new List<string>()
            {
                Opciones.CriterioTexto.CONTIENE,
                Opciones.CriterioTexto.INCLUYE,
                Opciones.CriterioTexto.EMPIEZA,
            };
            return criterioBusquedaTexto;
        }

        public List<string> cargarBusquedaCriterioNumero()
        {
            criterioBusquedaNumero = new List<string>()
            {
                Opciones.CriterioNumero.IGUAL,
                Opciones.CriterioNumero.MAYOR,
                Opciones.CriterioNumero.MENOR
            };
            return criterioBusquedaNumero;
        }

        public List<Producto> cargarProductos()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaProducto = productoNegocio.listar();
            return listaProducto;
        }

        public List<Categoria> cargarCategorias (bool todos = false)
        {
            try
            {
                CategoriaNegocio categoriaLista = new CategoriaNegocio();
                List<Categoria> aux = categoriaLista.listar();

                if (todos)
                {
                    Categoria OpcionTodos = new Categoria();
                    OpcionTodos.Descripcion = Opciones.Buscador.TODOS;
                    OpcionTodos.Id = 0;
                    aux.Insert(0, OpcionTodos);
                }

                return aux;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Marca> cargarMarcas(bool todos = false)
        {
            try
            {
                MarcaNegocio marcaLista = new MarcaNegocio();
                List<Marca> aux = marcaLista.listar();

                if(todos)
                {
                    Marca OpcionTodos = new Marca();
                    OpcionTodos.Descripcion = Opciones.Buscador.TODOS;
                    OpcionTodos.Id = 0;
                    aux.Insert(0, OpcionTodos);
                }
                
                return aux;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
