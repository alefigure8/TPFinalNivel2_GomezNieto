using configuracion;
using dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listaMarca = new List<Marca>();

        public List<Marca> listar()
        {
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                datoSQL.setQuery("SELECT * FROM MARCAS");
                datoSQL.executeReader();

                while (datoSQL.Reader.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datoSQL.Reader["Id"];
                    aux.Descripcion = (string)datoSQL.Reader["Descripcion"];

                    listaMarca.Add(aux);

                }

                return listaMarca;
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

        public List<Marca> buscar(string filtro)
        {
            AccesoDB datoSQL = new AccesoDB();
            List<Marca> listaMarca = new List<Marca>();

            try
            {
                datoSQL.setQuery($"select * from {Opciones.DBTablas.MARCAS} where descripcion like '%{filtro}%'");
                datoSQL.executeReader();
                while (datoSQL.Reader.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datoSQL.Reader[Opciones.Campo.ID];
                    aux.Descripcion = (string)datoSQL.Reader[Opciones.Campo.DESCRIPCION];

                    listaMarca.Add(aux);
                }
                return listaMarca;
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

        public bool agregar(string keyword)
        {
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                datoSQL.setQuery($"INSERT INTO {Opciones.DBTablas.MARCAS} ({Opciones.Campo.DESCRIPCION}) VALUES ('{keyword}')");
                if (datoSQL.executeNonQuery())
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datoSQL.closeConnection();
            }

            return false;
        }

        public bool modificar(Marca marca, string change)
        {
            AccesoDB datoSQL = new AccesoDB();
            try
            {
                datoSQL.setQuery($"UPDATE {Opciones.DBTablas.MARCAS} SET {Opciones.Campo.DESCRIPCION} = '{change}' WHERE {Opciones.Campo.ID} = {marca.Id}");
                if (datoSQL.executeNonQuery())
                {
                    datoSQL.closeConnection();
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public bool eliminar(Marca marca)
        {
            AccesoDB datoSQL = new AccesoDB();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            List<Producto> listaProductos = productoNegocio.listar();

            try
            {
                if (listaProductos.All(x => x.MarcaInfo.Id != marca.Id))
                {
                    datoSQL.setQuery($"DELETE {Opciones.DBTablas.MARCAS} WHERE {Opciones.Campo.ID} = {marca.Id}");

                    if (datoSQL.executeNonQuery())
                    {
                        datoSQL.closeConnection();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datoSQL.closeConnection(); 
            }

            return false;
        }

        public bool existeMarca(string keyword)
        {
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                datoSQL.setQuery($"SELECT * FROM {Opciones.DBTablas.MARCAS} WHERE {Opciones.Campo.DESCRIPCION} = '{keyword}'");
                datoSQL.executeReader();

                if(datoSQL.Reader.Read())
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
