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
    }
}
