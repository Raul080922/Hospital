using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1e.config
{

    public  class Conexion
    {
        private static string connectionString = "Server=DESKTOP-PS51K8K\\SQLEXPRESS;Database=Hospital;User Id=sa;Password=12345;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

    }

}