using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listaProductos = new List<Producto>();

        public List<Producto> listar()
        {
            AccesoDB datoSQL = new AccesoDB();
            try
            {
                datoSQL.setQuery(
                    "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.IdMarca, A.IdCategoria, C.Descripcion as CategoriaDescripcion, M.Descripcion as MarcaDescripcion, A.Precio " +
                    "from ARTICULOS A, CATEGORIAS C, MARCAS M " +
                    "where A.IdCategoria = C.Id AND A.IdMarca = M.Id"
                    );
                datoSQL.executeReader();

                while (datoSQL.Reader.Read())
                {
                    Producto aux = new Producto();

                    //***** PRODUCTO ***** //
                    aux.Id = (int)datoSQL.Reader["Id"];
                    aux.Codigo = (string)datoSQL.Reader["Codigo"];
                    aux.Nombre = (string)datoSQL.Reader["Nombre"];
                    aux.Descripcion = (string)datoSQL.Reader["Descripcion"];
                    aux.Precio = (decimal)datoSQL.Reader["Precio"];
                    aux.ImagenURL = (string)datoSQL.Reader["ImagenUrl"];

                    //***** MARCA ***** //
                    aux.MarcaInfo = new Marca();
                    aux.MarcaInfo.Id = (int)datoSQL.Reader["IdMarca"];
                    aux.MarcaInfo.Descripcion = (string)datoSQL.Reader["MarcaDescripcion"];
                    
                    //***** CATEGORIA ***** ///
                    aux.CategoriaInfo = new Categoria();
                    aux.CategoriaInfo.Id = (int)datoSQL.Reader["IdCategoria"];
                    aux.CategoriaInfo.Descripcion = (string)datoSQL.Reader["CategoriaDescripcion"];

                    listaProductos.Add(aux);
                }

                return listaProductos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datoSQL.closeConnection();
            }
        }

        public List<Producto> busquedaAvanzada(string filtro, string campo, string criterio)
        {
            List<Producto> aux = new List<Producto>();
            AccesoDB datosSQL = new AccesoDB();

            try
            {
                string query = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.IdMarca, A.IdCategoria, C.Descripcion as CategoriaDescripcion, M.Descripcion as MarcaDescripcion, A.Precio " +
                    "from ARTICULOS A, CATEGORIAS C, MARCAS M " +
                    "where A.IdCategoria = C.Id AND A.IdMarca = M.Id" +
                    $"AND ";

                //switch

                datosSQL.setQuery(query);
                datosSQL.executeReader();

                while(datosSQL.Reader.Read())
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datosSQL.closeConnection();
            }


            return listaProductos;
        }
    }
}
