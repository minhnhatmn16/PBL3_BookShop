using BookShop.BLL;
using BookShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    internal class SaledInvoice_DAL
    {
        private static SaledInvoice_DAL _Instance;
        public static SaledInvoice_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SaledInvoice_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private SaledInvoice_DAL() { }

        public DataTable getAllSaledInvoice_DAL()
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM SaledInvoice");
        }

        public DataTable getSaledInvoiceByID(int ID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM SaledInvoice WHERE SaledInvoiceID = " + ID);
        }
        public DataTable getSaledInvoiceByInterval(DateTime dt1, DateTime dt2)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM SaledInvoice WHERE SaleTime BETWEEN '" + dt1.ToString("yyyy/MM/dd hh:mm:ss") + "' AND '" + dt2.ToString("yyyy/MM/dd hh:mm:ss") + "'");
        }

        public void AddSaledInvoice_DAL(SaledInvoice SaledInvoice)
        {
            string query_insertSaledInvoice = string.Format("INSERT INTO SaledInvoice values (N'{0}', {1}, {2}, {3})",
                SaledInvoice.SaledTime, SaledInvoice.CustomerID, SaledInvoice.Payment, SaledInvoice.StaffID);
            DB_Helper.Instance.ExecuteDB(query_insertSaledInvoice);
        }

        //Update SaledInvoice
        public void UpdateSaledInvoice_DAL(SaledInvoice SaledInvoice)
        {
            /*string query_updateSaledInvoice = string.Format("UPDATE SaledInvoice SET SaledTime = N'{0}', SupplierID = N'{1}', Purchase = {2}," +
                " StaffID = {3} where SaledInvoiceID = {4}",
                SaledInvoice.SaledTime, SaledInvoice.SupplierID, SaledInvoice.Purchase, SaledInvoice.StaffID);
            DB_Helper.Instance.ExecuteDB(query_updateSaledInvoice);*/

        }

        //Delete SaledInvoice by key (SaledInvoiceID)
        public void DeleteSaledInvoice_DAL(int SaledInvoiceID)
        {
            string queryDel_Sach = "DELETE FROM SaledInvoice WHERE SaledInvoiceID = " + SaledInvoiceID;
            DB_Helper.Instance.ExecuteDB(queryDel_Sach);
        }

        public int getNextSaledInvoiceID()
        {
            string query = "SELECT IDENT_CURRENT('SaledInvoice') + IDENT_INCR('SaledInvoice') AS NextID";

            int SaledInvoiceID = -1;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                SaledInvoiceID = Convert.ToInt32(i[0]);
            }
            return SaledInvoiceID;
        }

        public int getNumberOfBookSaledInvoice(int SaledInvoiceID)
        {
            string query = "SELECT Quantity From SaledBook WHERE SaledInvoiceID = " + SaledInvoiceID;
            int totalQuantity = 0;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                totalQuantity += Convert.ToInt32(i["Quantity"]);
            }
            return totalQuantity;
        }
    }
}
