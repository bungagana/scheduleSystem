using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab3
{
    public class DbConnection
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source =.\\SQLEXPRESS01; Initial Catalog = projectDotnet;Integrated Security=True");
  
            return sqlConnection;
        }
    }
}