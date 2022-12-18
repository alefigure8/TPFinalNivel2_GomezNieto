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
                Opciones.Campo.MARCA,
                Opciones.Campo.CATEGORIA,
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

        public List<string> cargarCategorias ()
        {
            try
            {
                CategoriaNegocio categoriaLista = new CategoriaNegocio();
                List<Categoria> aux = categoriaLista.listar();
                categorias = new List<string>(){ "Todos" };
 
                foreach (Categoria categoria in aux)
                {
                    categorias.Add(categoria.Descripcion);
                }

                return categorias;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> cargarMarcas()
        {
            try
            {
                MarcaNegocio marcaLista = new MarcaNegocio();
                List<Marca> aux = marcaLista.listar();
                marcas = new List<string>(){"Todos"};

                foreach (Marca categoria in aux)
                {
                    marcas.Add(categoria.Descripcion);
                }

                return marcas;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
    }
}
