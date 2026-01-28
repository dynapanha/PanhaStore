using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    internal class DataConnection
    {
        public static SqlConnection DataCon { get; set; }
        public static string Seller { get; set; }


        public static void ConnectionDB(string ip,string dbname,string username,string password)
        {
            string connection_string = $"Server= {ip}; Database= {dbname}; User ID= {username}; Password= {password};\r\n";
            DataCon = new SqlConnection(connection_string);
            DataCon.Open();
            Seller = username;

        }
    }
}
