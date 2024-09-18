using BookShop.BLL_ST;
using BookShop.DAL_ST;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    internal class ImportBook_DAL
    {
        private static ImportBook_DAL _Instance;
        public static ImportBook_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ImportBook_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private ImportBook_DAL() { }

        public DataTable getAllImportBook_DAL()
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM ImportBook");
        }

        public DataTable getImportBookByBookInforID(int bookInforID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM ImportBook WHERE BookInforID = " + bookInforID);
        }

        //Add Book infor to 2 table (Sach, ThongTinXuatBan) in database by key (masach)
        public void AddImportBook_DAL(ImportBook ImportBook)
        {
            string query_insertImportBook = string.Format("INSERT INTO ImportBook values ({0}, {1}, {2}, {3})",
                ImportBook.BookInforID, ImportBook.ImportInvoiceID, ImportBook.ImportPrice, ImportBook.Quantity);
            DB_Helper.Instance.ExecuteDB(query_insertImportBook);

            int Quantity = BookInfor_BLL.Instance.getBookInforByID_BLL(ImportBook.BookInforID).Quantity;
            Quantity += ImportBook.Quantity;
            string query_updateBookInfor = string.Format("UPDATE BookInformation SET Quantity = {0} WHERE BookInforID = {1}",
                Quantity, ImportBook.BookInforID);
            DB_Helper.Instance.ExecuteDB(query_updateBookInfor);
        }

        //update book
        public void UpdateImportBook_DAL(ImportBook ImportBook)
        {
            string query_updateImportBook = string.Format("UPDATE ImportBook SET BookInforID = {0}, ImportInvoiceID = {1}, ImportPrice = {2}," +
                " Quantity = {3} where ID = {4}",
                ImportBook.BookInforID, ImportBook.ImportInvoiceID, ImportBook.ImportPrice, ImportBook.Quantity);
            DB_Helper.Instance.ExecuteDB(query_updateImportBook);
        }

        //delete book by key (ImportBookID)
        public void DeleteImportBook_DAL(int ImportBookID)
        {
            string queryDel_Sach = "DELETE FROM ImportBook WHERE ID = " + ImportBookID;
            DB_Helper.Instance.ExecuteDB(queryDel_Sach);
        }
        public DataTable getTheLastImportBookByBookInforID(int bookInforID)
        {
            return DB_Helper.Instance.GetRecord("SELECT TOP 1 * FROM ImportBook WHERE BookInforID = " + bookInforID + " Order By ID DESC ");
        }
    }
}
