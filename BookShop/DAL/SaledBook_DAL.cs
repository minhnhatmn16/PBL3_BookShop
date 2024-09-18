using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL
{
    internal class SaledBook_DAL
    {
        private static SaledBook_DAL _Instance;
        public static SaledBook_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SaledBook_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private SaledBook_DAL() { }

        public DataTable getAllSaledBook_DAL()
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM SaledBook");
        }

        public DataTable getSaledBookByBookInforID(int bookInforID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM SaledBook WHERE BookInforID = " + bookInforID);
        }

        //Add Book infor to 2 table (Sach, ThongTinXuatBan) in database by key (masach)
        public void AddSaledBook_DAL(SaledBook SaledBook)
        {
            string query_insertSaledBook = string.Format("INSERT INTO SaledBook values ({0}, {1}, {2} , {3} , {4} )",
                SaledBook.BookInforID, SaledBook.SaledInvoiceID, SaledBook.Quantity, SaledBook.SaledPrice, SaledBook.ImportPrice);
            DB_Helper.Instance.ExecuteDB(query_insertSaledBook);

            int Quantity = BookInfor_BLL.Instance.getBookInforByID_BLL(SaledBook.BookInforID).Quantity;
            Quantity -= SaledBook.Quantity;
            string query_updateBookInfor = string.Format("UPDATE BookInformation SET Quantity = {0} WHERE BookInforID = {1}",
                Quantity, SaledBook.BookInforID);
            DB_Helper.Instance.ExecuteDB(query_updateBookInfor);
        }

        //update book
        public void UpdateSaledBook_DAL(SaledBook SaledBook)
        {
            string query_updateSaledBook = string.Format("UPDATE SaledBook SET BookInforID = {0}, SaledInvoiceID = {1}, SaledPrice = {2}," +
                " Quantity = {3} where ID = {4}",
                SaledBook.BookInforID, SaledBook.SaledInvoiceID, SaledBook.SaledPrice, SaledBook.Quantity);
            DB_Helper.Instance.ExecuteDB(query_updateSaledBook);
        }

        //delete book by key (SaledBookID)
        public void DeleteSaledBook_DAL(int SaledBookID)
        {
            string queryDel_Sach = "DELETE FROM SaledBook WHERE ID = " + SaledBookID;
            DB_Helper.Instance.ExecuteDB(queryDel_Sach);
        }
    }
}
