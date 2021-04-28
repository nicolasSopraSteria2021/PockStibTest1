using System.Data.SqlClient;

namespace PockStibTest1
{
    public class DBUtils
    {
        //metholde permettant de se connecter a la db
        public static SqlConnection GetDBConnection()
        {
            //nom de la base de donnée
            string datasource = @"fake_Db_STIB";

            //appel de la methode GetDBConnection de la classe DBSQLServerUtils
            return DBSQLServerUtils.GetDBConnection(datasource);
        }
    }
}