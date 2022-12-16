using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using negocio;
using dominio;

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
                "Nombre",
                "Codigo",
                "Marca",
                "Categoria",
                "Precio"
            };
            return columnasProductos;
        }

       public List<string> cargarBusquedaNumeros()
        {
            cantidadPorPagina = new List<string>()
            {
                "50",
                "30",
                "20",
                "10"
            };
            return cantidadPorPagina;
        }

        public List<string> cargarBusquedaCriterioTexto()
        {
            criterioBusquedaTexto = new List<string>()
            {
                "Empieza con",
                "Contiene",
                "Incluye algunas"
            };
            return criterioBusquedaTexto;
        }

        public List<string> cargarBusquedaCriterioNumero()
        {
            criterioBusquedaNumero = new List<string>()
            {
                "Mayor a",
                "Igual a",
                "Menor a",
            };
            return criterioBusquedaNumero;
        }

        public List<string> cargarCategorias ()
        {
            try
            {
                CategoriaNegocio categoriaLista = new CategoriaNegocio();
                List<Categoria> aux = categoriaLista.listar();
                categorias = new List<string>();

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
                marcas = new List<string>();

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
