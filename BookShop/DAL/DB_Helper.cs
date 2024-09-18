using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace BookShop.DAL
{
    internal class DB_Helper
    {
        private static DB_Helper _Instance;
        //SqlConnection conn;
        private DB_Helper()
        {
            //conn = new SqlConnection(Connect.constr);
        }
        public static DB_Helper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DB_Helper();
                }
                return _Instance;
            }
            private set { }
        }

        public DataTable GetRecord(string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(Connect.constr))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
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
       

        /*public int GetRecordID(string s)
        {
            
            SqlCommand cmd = new SqlCommand(s, cnn);
            cnn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int i = Convert.ToInt16(dr[0].ToString());
            cnn.Close();
            return i;

        }*/

        public void ExecuteDB(string query)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(Connect.constr))
                {
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                //return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot execute query " + e.Message);
                //return false;
            }
        }
    }
}
