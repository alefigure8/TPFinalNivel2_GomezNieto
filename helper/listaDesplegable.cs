using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using negocio;
using dominio;
using configuracion;

namespace helper
{
    public class listaDesplegable
    {
        private List<string> categorias;
        private List<string> marcas;
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
                //Opciones.Campo.MARCA,
                //Opciones.Campo.CATEGORIA,
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

        public List<Categoria> cargarCategorias (bool todos = false)
        {
            try
            {
                CategoriaNegocio categoriaLista = new CategoriaNegocio();
                List<Categoria> aux = categoriaLista.listar();

                if (todos)
                {
                    Categoria OpcionTodos = new Categoria();
                    OpcionTodos.Descripcion = "Todos";
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
                    OpcionTodos.Descripcion = "Todos";
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
