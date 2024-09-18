using BookShop.DAL;
using BookShop.DTO;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL_ST
{
    internal class Supplier_DAL
    {
        SqlDataAdapter da, da_;
        Connect dc;
        private static Supplier_DAL _Instance;
        public static Supplier_DAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Supplier_DAL();
                return _Instance;
            }
            private set
            {

            }
        }

        public Supplier_DAL()
        {
            dc = new Connect();
        }
        public DataTable Get_SupplierInfor()
        {
            String SQL = "SELECT * from dbo.Supplier";
            SqlConnection Con = dc.getConnect();
            da_ = new SqlDataAdapter(SQL, Con);
            Con.Open();
            DataTable TB_Staff = new DataTable();
            da_.Fill(TB_Staff);
            Con.Close();
            return TB_Staff;
        }
        public DataTable getSupplierByID(int ID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM Supplier WHERE SupplierID = " + ID);
        }

        public int getNextSupplierID()
        {
            string query = "SELECT IDENT_CURRENT('Supplier') + IDENT_INCR('Supplier') AS NextID";

            int SupplierID = -1;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                SupplierID = Convert.ToInt32(i[0]);
            }
            return SupplierID;
        }

        public void AddSupplier_DAL(Supplier supplier)
        {
            string query_insertSupplier = string.Format("INSERT INTO Supplier values (N'{0}', N'{1}', N'{2}')",
                supplier.SupplierName, supplier.PhoneNumber, supplier.Address);
            DB_Helper.Instance.ExecuteDB(query_insertSupplier);
        }

        public void UpdateSupplier_DAL(Supplier supplier)
        {
            string query_insertSupplier = string.Format("UPDATE Supplier SET SupplierName = N'{0}', PhoneNumber = N'{1}', Address = N'{2}'" +
                " WHERE SupplierID = {3}",
                supplier.SupplierName, supplier.PhoneNumber, supplier.Address, supplier.SupplierID);
            DB_Helper.Instance.ExecuteDB(query_insertSupplier);
        }

        public void DeleteSupplier_DAL(int SupplierID)
        {
            string queryDel_Account = "DELETE FROM Supplier WHERE SupplierID = " + SupplierID;
            DB_Helper.Instance.ExecuteDB(queryDel_Account);
        }
    }
}
