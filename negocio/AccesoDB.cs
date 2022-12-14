using System;
using System.Data.SqlClient;


namespace negocio
{
    internal class AccesoDB
    {

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public AccesoDB()
        {
            string serverName = "DESKTOP-81ER52L";
            string DbName = "CATALOGO_DB";
            connection = new SqlConnection($"server={serverName}\\SQLEXPRESS; database={DbName}; integrated security=true");
            command = new SqlCommand();
        }

        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void executeReader()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void executeNonQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void closeConnection()
        {
            connection.Close();
        }
    }
}
