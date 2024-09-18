using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;
using System.Collections;
using System.Security.Cryptography;
using BookShop.BLL;
using BookShop.DAL;

namespace BookShop.DAL_ST
{
    internal class Login_DAL
    {
        SqlDataAdapter da, da_;
        Connect dc;
        
        private static Login_DAL _Instance;
        public string Acc = "";
        public string Pass = "";
        private DataTable dt;

        public int ID_USER = 0;
        public string ID_Pos = "";
        public string status = "";

        public static Login_DAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Login_DAL();
                return _Instance;
            }
            private set
            {

            }
        }

        public Login_DAL()
        {
            dc = new Connect();
        }

        public DataTable Get_BookInfor()
        {
            String SQL = "SELECT * from dbo.BookInformation";
            SqlConnection Con = new SqlConnection(Connect.constr);
            da_ = new SqlDataAdapter(SQL, Con);
            Con.Open();
            DataTable TB_Staff = new DataTable();
            da_.Fill(TB_Staff);
            Con.Close();
            return TB_Staff;
        }

        public bool checkHashPassword(string Account, string Password)
        {
            // Hash
            if (getPasswordByAccountName(Account) == "")
            {
                return false;
            }
            var hash = getPasswordByAccountName(Account);

            // Verify
            var result = SecurePasswordHasher.Verify(Password, hash);
            return result;
        }

        //Take User Account when fisrt login
        public DataTable Staff_Infor(string Account, string Password)
        {
            try
            {
                Acc = Account;
                Pass = Password;
                string query = "SELECT UserID, RoleID, Status FROM Account WHERE AccountName=N'" + Account + "'";
                
                using (SqlConnection cnn = new SqlConnection(Connect.constr))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    cnn.Open();
                    da.Fill(dt);
                    cnn.Close();
                    return dt;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error " + e.Message);
                return null;
            }
            
        }

        public String getPasswordByAccountName(String AccountName)
        {
            string query = "SELECT Password FROM Account WHERE AccountName = N'" + AccountName +"'";

            String passHash = "";
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                passHash = Convert.ToString(i[0]);
            }
            return passHash;
        }

        public DataTable Get_Infor_Staff()
        {
            foreach (DataRow i in dt.Rows)
            {
                ID_USER = Convert.ToInt32(i["UserID"]);
                ID_Pos = Convert.ToString(i["RoleID"]);
                status = Convert.ToString(i["Status"]);
            }
            string Staff_In4 = "SELECT * FROM Account WHERE UserID = " + ID_USER;
            SqlConnection Con = dc.getConnect();
            da_ = new SqlDataAdapter(Staff_In4, Con);
            Con.Open();
            DataTable TB_Staff = new DataTable();
            da_.Fill(TB_Staff);
            if (TB_Staff.Rows.Count == 0) MessageBox.Show("Invalid Login please check" + ID_USER + " username and password");
            Con.Close();
            return TB_Staff;
        }
    }
}
