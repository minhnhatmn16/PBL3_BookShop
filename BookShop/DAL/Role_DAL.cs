using BookShop.DAL_ST;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    internal class Role_DAL
    {
        SqlDataAdapter da, da_;
        Connect dc;
        private static Role_DAL _Instance;
        public static Role_DAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Role_DAL();
                return _Instance;
            }
            private set
            {

            }
        }

        public Role_DAL()
        {
            dc = new Connect();
        }
        public DataTable Get_RoleInfor()
        {
            String SQL = "SELECT RoleID, RoleName from dbo.Role";
            SqlConnection Con = dc.getConnect();
            da_ = new SqlDataAdapter(SQL, Con);
            Con.Open();
            DataTable TB_Staff = new DataTable();
            da_.Fill(TB_Staff);
            Con.Close();
            return TB_Staff;
        }
    }
}
