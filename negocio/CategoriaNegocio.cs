using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using configuracion;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listaCategoria = new List<Categoria>();
        public List<Categoria> listar()
        {
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                datoSQL.setQuery("SELECT * FROM CATEGORIAS");
                datoSQL.executeReader();

                while(datoSQL.Reader.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datoSQL.Reader["Id"];
                    aux.Descripcion = (string)datoSQL.Reader["Descripcion"];

                    listaCategoria.Add(aux);

                }

                return listaCategoria;
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

        public bool agregar(string keyword)
        {
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                datoSQL.setQuery($"INSERT INTO {Opciones.DBTablas.CATEGORIAS} ({Opciones.Campo.DESCRIPCION}) VALUES ('{keyword}')");
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

        public bool existeCategoria(string keyword)
        {
            AccesoDB datoSQL = new AccesoDB();

            try
            {
                datoSQL.setQuery($"SELECT * FROM {Opciones.DBTablas.CATEGORIAS} WHERE {Opciones.Campo.DESCRIPCION} = '{keyword}'");
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
