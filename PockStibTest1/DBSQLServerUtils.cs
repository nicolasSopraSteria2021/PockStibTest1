using System.Data.SqlClient;

namespace PockStibTest1
{
    public class DBSQLServerUtils
    {
        //methode permettant de retourner une connexion a la base de donnée
        public static SqlConnection GetDBConnection(string datasource)
        {
           //paramètre de la connection a la db
            string connString = @"Server=.\SQLEXPRESS;Database=" + datasource + ";Integrated Security=SSPI";

            SqlConnection connection = new SqlConnection(connString);

            return connection;
        }
    }
}
