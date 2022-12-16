using dominio;
using System;
using System.Collections.Generic;
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
    }
}
