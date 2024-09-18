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
    internal class Customer_DAL
    {
        private static Customer_DAL _Instance;
        public static Customer_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Customer_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private Customer_DAL() { }

        public DataTable getAllCustomer_DAL()
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM Customer");
        }

        public DataTable getCustomerByID(int ID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM Customer WHERE CustomerID = " + ID);
        }

        public void AddCustomer_DAL(Customer Customer)
        {
            string query_insertCustomer = string.Format("INSERT INTO Customer values (N'{0}', {1}, '{2}')",
                Customer.CustomerName, Customer.SexID, Customer.PhoneNumber);
            DB_Helper.Instance.ExecuteDB(query_insertCustomer);
        }

        //Update Customer
        public void UpdateCustomer_DAL(Customer Customer)
        {
            /*string query_updateCustomer = string.Format("UPDATE Customer SET ImportTime = N'{0}', SupplierID = N'{1}', Purchase = {2}," +
                " StaffID = {3} where CustomerID = {4}",
                Customer.ImportTime, Customer.SupplierID, Customer.Purchase, Customer.StaffID);
            DB_Helper.Instance.ExecuteDB(query_updateCustomer);*/

        }

        //Delete Customer by key (CustomerID)
        public void DeleteCustomer_DAL(int CustomerID)
        {
            string queryDel_Sach = "DELETE FROM Customer WHERE CustomerID = " + CustomerID;
            DB_Helper.Instance.ExecuteDB(queryDel_Sach);
        }

        public int getNextCustomerID()
        {
            string query = "SELECT IDENT_CURRENT('Customer') + IDENT_INCR('Customer') AS NextID";

            int CustomerID = -1;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                CustomerID = Convert.ToInt32(i[0]);
            }
            return CustomerID;
        }
        public int getNumberOfBookCustomer(int CustomerID)
        {
            string query = "SELECT SaledInvoiceID From SaledInvoice WHERE CustomerID = " + CustomerID;
            int totalQuantity = 0;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                totalQuantity += SaledInvoice_BLL.Instance.getNumberOfBookSaledInvoice_BLL(Convert.ToInt32(i["SaledInvoiceID"]));
            }
            return totalQuantity;
        }
        public Double getTotalPaymentCustomer(int CustomerID)
        {
            string query = "SELECT Payment From SaledInvoice WHERE CustomerID = " + CustomerID;
            Double totalPayment = 0;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                totalPayment += Convert.ToDouble(i["Payment"]);
            }
            return totalPayment;
        }
    }
}
