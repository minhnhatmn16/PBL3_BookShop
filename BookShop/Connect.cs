using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    class Connect
    {
        public static string constr = @"Data Source=MINHNHAT\SQLEXPRESS;Initial Catalog=NhaSachv3_export04;Integrated Security=True";
        public Connect()
        {
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(constr);
        }
    }
}
