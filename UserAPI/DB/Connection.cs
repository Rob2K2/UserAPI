using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.DB
{
    public class Connection
    {
        private static string mySQLConnection = "Data Source=localhost; port=3306; Initial Catalog=kudos_usuarios; User Id=root; password=password; SSLMode=none;";

        public static MySqlConnection ConexionMysql()
        {
            var mySQL = new MySqlConnection(mySQLConnection);

            return mySQL;
        }
    }
}
