using BookShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    internal class ImportInvoice_DAL
    {
        private static ImportInvoice_DAL _Instance;
        public static ImportInvoice_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ImportInvoice_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private ImportInvoice_DAL() { }

        public DataTable getAllImportInvoice_DAL()
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM ImportInvoice");
        }

        public DataTable getImportInvoiceByID(int ID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM ImportInvoice WHERE ImportInvoiceID = " + ID);
        }
        public DataTable getImportInvoiceByInterval(DateTime dt1, DateTime dt2)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM ImportInvoice WHERE ImportTime BETWEEN '" + dt1.ToString("yyyy/MM/dd hh:mm:ss") + "' AND '" + dt2.ToString("yyyy/MM/dd hh:mm:ss") + "'");
        }

        public void AddImportInvoice_DAL(ImportInvoice ImportInvoice)
        {
            string query_insertImportInvoice = string.Format("INSERT INTO ImportInvoice values (N'{0}', {1}, {2}, {3})",
                ImportInvoice.ImportTime, ImportInvoice.SupplierID, ImportInvoice.Purchase, ImportInvoice.StaffID);
            DB_Helper.Instance.ExecuteDB(query_insertImportInvoice);
        }

        //Update ImportInvoice
        public void UpdateImportInvoice_DAL(ImportInvoice ImportInvoice)
        {
            string query_updateImportInvoice = string.Format("UPDATE ImportInvoice SET ImportTime = N'{0}', SupplierID = N'{1}', Purchase = {2}," +
                " StaffID = {3} where ImportInvoiceID = {4}",
                ImportInvoice.ImportTime, ImportInvoice.SupplierID, ImportInvoice.Purchase, ImportInvoice.StaffID);
            DB_Helper.Instance.ExecuteDB(query_updateImportInvoice);

        }

        //Delete ImportInvoice by key (ImportInvoiceID)
        public void DeleteImportInvoice_DAL(int ImportInvoiceID)
        {
            string queryDel_Sach = "DELETE FROM ImportInvoice WHERE ImportInvoiceID = " + ImportInvoiceID;
            DB_Helper.Instance.ExecuteDB(queryDel_Sach);
        }

        public int getNextImportInvoiceID()
        {
            string query = "SELECT IDENT_CURRENT('ImportInvoice') + IDENT_INCR('ImportInvoice') AS NextID";

            int ImportInvoiceID = -1;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                ImportInvoiceID = Convert.ToInt32(i[0]);
            }
            return ImportInvoiceID;
        }

        public int getNumberOfBookImportInvoice(int ImportInvoiceID)
        {
            string query = "SELECT Quantity From ImportBook WHERE ImportInvoiceID = " + ImportInvoiceID;
            int totalQuantity = 0;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                totalQuantity += Convert.ToInt32(i["Quantity"]);
            }
            return totalQuantity;
        }
        public double getTotalAmountImportInvoice(int ImportInvoiceID)
        {
            string query = "SELECT ImportPrice From ImportBook WHERE ImportInvoiceID = " + ImportInvoiceID;
            double totalAmount = 0;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                totalAmount += Convert.ToDouble(i["ImportPrice"]) * getNumberOfBookImportInvoice(ImportInvoiceID);
            }
            return totalAmount;
        }
    }
}
