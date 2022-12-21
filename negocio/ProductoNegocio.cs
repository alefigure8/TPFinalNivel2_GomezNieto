using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using configuracion;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Collections;

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
                    $"from {Opciones.DBTablas.ARTICULOS} A, {Opciones.DBTablas.CATEGORIAS} C, {Opciones.DBTablas.MARCAS} M " +
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

        public List<Producto> busquedaAvanzada(string filtro, string campo, string criterio, string categoria, string marca)
        {
            List<Producto> listaProducto = new List<Producto>();
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                string query = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.IdMarca, A.IdCategoria, C.Descripcion as CategoriaDescripcion, M.Descripcion as MarcaDescripcion, A.Precio " +
                    $"from {Opciones.DBTablas.ARTICULOS} A, {Opciones.DBTablas.CATEGORIAS} C, {Opciones.DBTablas.MARCAS} M " +
                    "where A.IdCategoria = C.Id AND A.IdMarca = M.Id " +
                    $"AND M.Descripcion LIKE '%{marca}%' AND C.Descripcion LIKE '%{categoria}%' ";

                switch(campo)
                {
                    case Opciones.Campo.NOMBRE:
                        {
                            switch(criterio)
                            {
                                case Opciones.CriterioTexto.CONTIENE:
                                    query += $"AND A.Nombre LIKE '%{filtro}%'";
                                    break;
                                case Opciones.CriterioTexto.EMPIEZA:
                                    query += $"AND A.Nombre LIKE '{filtro}%'";
                                    break;
                                case Opciones.CriterioTexto.INCLUYE:
                                    {
                                        bool encontrado = false;
                                        string[] vFiltro = filtro.Split(' ');

                                        foreach(string item in vFiltro)
                                        {
                                            datoSQL.setQuery($"select Nombre from ARTICULOS where Nombre LIKE '%{item}%'");
                                            datoSQL.executeReader();

                                            if (datoSQL.Reader.HasRows)
                                            {
                                                query += $"AND A.Nombre LIKE '%{item}%'";
                                                encontrado= true;
                                                break;  
                                            }

                                            datoSQL.closeConnection();
                                        }

                                        if(!encontrado)
                                        {
                                            query += $"AND A.Nombre LIKE '%{filtro}%'";
                                        }

                                        datoSQL.closeConnection();
                                    }
                                    break;
                                default:
                                    query += $"";
                                    break;
                            }
                        }
                        break;
                    case Opciones.Campo.CODIGO:
                        {
                            switch(criterio)
                            {
                                case Opciones.CriterioTexto.CONTIENE:
                                    query += $"AND A.Codigo LIKE '%{filtro}%'";
                                    break;
                                case Opciones.CriterioTexto.EMPIEZA:
                                    query += $"AND A.Codigo LIKE '{filtro}%'";
                                    break;
                                case Opciones.CriterioTexto.INCLUYE:
                                    {
                                        bool encontrado = false;
                                        string[] vFiltro = filtro.Split(' ');

                                        foreach (string item in vFiltro)
                                        {
                                            datoSQL.setQuery($"select Codigo from ARTICULOS where Codigo LIKE '%{item}%'");
                                            datoSQL.executeReader();

                                            if (datoSQL.Reader.HasRows)
                                            {
                                                query += $"AND A.Codigo LIKE '%{item}%'";
                                                encontrado = true;
                                                break;
                                            }

                                            datoSQL.closeConnection();
                                        }

                                        if (!encontrado)
                                        {
                                            query += $"AND A.Codigo LIKE '%{filtro}%'";
                                        }

                                        datoSQL.closeConnection();
                                    }
                                    break;
                                default:
                                    query += $"";
                                    break;
                            }
                        }
                        break;
                    case Opciones.Campo.DESCRIPCION:
                        {
                            switch (criterio)
                            {
                                case Opciones.CriterioTexto.CONTIENE:
                                    query += $"AND A.Descripcion LIKE '%{filtro}%'";
                                    break;
                                case Opciones.CriterioTexto.EMPIEZA:
                                    query += $"AND A.Descripcion LIKE '{filtro}%'";
                                    break;
                                case Opciones.CriterioTexto.INCLUYE:
                                    {
                                        bool encontrado = false;
                                        string[] vFiltro = filtro.Split(' ');

                                        foreach (string item in vFiltro)
                                        {
                                            datoSQL.setQuery($"select Descripcion from ARTICULOS where Descripcion LIKE '%{item}%'");
                                            datoSQL.executeReader();

                                            if (datoSQL.Reader.HasRows)
                                            {
                                                query += $"AND A.Descripcion LIKE '%{item}%'";
                                                encontrado = true;
                                                break;
                                            }

                                            datoSQL.closeConnection();
                                        }

                                        if (!encontrado)
                                        {
                                            query += $"AND A.Descripcion LIKE '%{filtro}%'";
                                        }

                                        datoSQL.closeConnection();
                                    }
                                    break;
                                default:
                                    query += $"";
                                    break;
                            }
                        }
                        break;
                    //case Opciones.Campo.MARCA:
                    //    {
                    //        switch (criterio)
                    //        {
                    //            case Opciones.CriterioTexto.CONTIENE:
                    //                query += $"AND M.Descripcion LIKE '%{filtro}%'";
                    //                break;
                    //            case Opciones.CriterioTexto.EMPIEZA:
                    //                query += $"AND M.Descripcion LIKE '{filtro}%'";
                    //                break;
                    //            case Opciones.CriterioTexto.TERMINA:
                    //                query += $"AND M.Descripcion LIKE '%{filtro}'";
                    //                break;
                    //            default:
                    //                query += $"";
                    //                break;
                    //        }
                    //    }
                    //    break;
                    //case Opciones.Campo.CATEGORIA:
                    //    {
                    //        switch (criterio)
                    //        {
                    //            case Opciones.CriterioTexto.CONTIENE:
                    //                query += $"AND C.Descripcion LIKE '%{filtro}%'";
                    //                break;
                    //            case Opciones.CriterioTexto.EMPIEZA:
                    //                query += $"AND C.Descripcion LIKE '{filtro}%'";
                    //                break;
                    //            case Opciones.CriterioTexto.TERMINA:
                    //                query += $"AND C.Descripcion LIKE '%{filtro}'";
                    //                break;
                    //            default:
                    //                query += $"";
                    //                break;
                    //        }
                    //    }
                    //    break;
                    case Opciones.Campo.PRECIO:
                        {
                            switch (criterio)
                            {
                                case Opciones.CriterioNumero.MAYOR:
                                    query += $"AND A.Precio > {filtro}";
                                    break;
                                case Opciones.CriterioNumero.MENOR:
                                    query += $"AND A.Precio < {filtro}";
                                    break;
                                case Opciones.CriterioNumero.IGUAL:
                                    query += $"AND A.Precio = {filtro}";
                                    break;
                                default:
                                    query += $"";
                                    break;
                            }
                        }
                        break;
                    default:
                            query += $"A.Nombre LIKE '%'";
                        break;
                }

                datoSQL.setQuery(query);
                datoSQL.executeReader();

                while(datoSQL.Reader.Read())
                {
                    Producto aux = new Producto();

                    //***** PRODUCTO ***** //
                   aux.Id = (int)datoSQL.Reader[Opciones.Campo.ID];
                   aux.Codigo = (string)datoSQL.Reader[Opciones.Campo.CODIGO];
                   aux.Nombre = (string)datoSQL.Reader[Opciones.Campo.NOMBRE];
                   aux.Descripcion = (string)datoSQL.Reader[Opciones.Campo.DESCRIPCION];
                   aux.Precio = (decimal)datoSQL.Reader[Opciones.Campo.PRECIO];
                   aux.ImagenURL = (string)datoSQL.Reader[Opciones.Campo.URLIMAGEN];
                   
                   //**** MARCA ***** //
                   aux.MarcaInfo = new Marca();
                   aux.MarcaInfo.Id = (int)datoSQL.Reader[Opciones.Campo.IDMARCA];
                   aux.MarcaInfo.Descripcion = (string)datoSQL.Reader[Opciones.Campo.DESCMARCA];
                   
                   //**** CATEGORIA ***** ///
                   aux.CategoriaInfo = new Categoria();
                   aux.CategoriaInfo.Id = (int)datoSQL.Reader[Opciones.Campo.IDCATEGORIA];
                   aux.CategoriaInfo.Descripcion = (string)datoSQL.Reader[Opciones.Campo.DESCCATEGORIA];

                    listaProducto.Add(aux);
                }

                return listaProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datoSQL.closeConnection();
            }
        }

        public List<Producto> busquedaSimple(string filtro)
        {
            List<Producto> listaProducto = new List<Producto>();
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                string query =
                    "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.IdMarca, A.IdCategoria, C.Descripcion as CategoriaDescripcion, M.Descripcion as MarcaDescripcion, A.Precio " +
                    "from ARTICULOS A, CATEGORIAS C, MARCAS M " +
                    "where  A.IdCategoria = C.Id AND A.IdMarca = M.Id ";
                bool encontrado = false;
                string[] vFiltro = filtro.Split(' ');

                foreach (string item in vFiltro)
                {
                    datoSQL.setQuery($"SELECT Nombre FROM ARTICULOS WHERE Nombre LIKE '%{item}%' ");
                    datoSQL.executeReader();

                    if (datoSQL.Reader.HasRows)
                    {
                        Console.WriteLine("Entra " + item);
                        query += $"AND A.Nombre LIKE '%{item}%'";
                        encontrado = true;
                        datoSQL.closeConnection();
                        break;
                    }

                    datoSQL.closeConnection();
                }

                if (!encontrado)
                {
                    query += $"AND A.Nombre LIKE '%{filtro}%'";
                }
                Console.WriteLine(query);

                datoSQL.setQuery(query);
                datoSQL.executeReader();

                while (datoSQL.Reader.Read())
                {
                    Producto aux = new Producto();

                    //***** PRODUCTO ***** //
                    aux.Id = (int)datoSQL.Reader[Opciones.Campo.ID];
                    aux.Codigo = (string)datoSQL.Reader[Opciones.Campo.CODIGO];
                    aux.Nombre = (string)datoSQL.Reader[Opciones.Campo.NOMBRE];
                    aux.Descripcion = (string)datoSQL.Reader[Opciones.Campo.DESCRIPCION];
                    aux.Precio = (decimal)datoSQL.Reader[Opciones.Campo.PRECIO];
                    aux.ImagenURL = (string)datoSQL.Reader[Opciones.Campo.URLIMAGEN];

                    //**** MARCA ***** //
                    aux.MarcaInfo = new Marca();
                    aux.MarcaInfo.Id = (int)datoSQL.Reader[Opciones.Campo.IDMARCA];
                    aux.MarcaInfo.Descripcion = (string)datoSQL.Reader[Opciones.Campo.DESCMARCA];

                    //**** CATEGORIA ***** ///
                    aux.CategoriaInfo = new Categoria();
                    aux.CategoriaInfo.Id = (int)datoSQL.Reader[Opciones.Campo.IDCATEGORIA];
                    aux.CategoriaInfo.Descripcion = (string)datoSQL.Reader[Opciones.Campo.DESCCATEGORIA];

                    listaProducto.Add(aux);
                }
                return listaProducto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool existeMarca(string keyword)
        {
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                datoSQL.setQuery($"SELECT * FROM {Opciones.DBTablas.ARTICULOS} WHERE {Opciones.Campo.DESCRIPCION} = '{keyword}'");
                datoSQL.executeReader();

                if (datoSQL.Reader.Read())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datoSQL.closeConnection();
            }
        }
    }
}
