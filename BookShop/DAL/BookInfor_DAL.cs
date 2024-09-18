using BookShop.DAL;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DAL_ST
{
    internal class BookInfor_DAL
    {
        private static BookInfor_DAL _Instance;
        public static BookInfor_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BookInfor_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private BookInfor_DAL() { }

        public DataTable getAllBookInfor_DAL()
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM BookInformation");
        }

        public DataTable getBookInfosByCategoryID(int categoryID) //use for filter
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM BookInformation Where CategoryID = " + categoryID);
        }

        public DataTable getBookInforByID(int ID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM BookInformation WHERE BookInforID = " + ID);
        }

        public void AddBookInfor_DAL(BookInfor bookInfor)
        {
            string query_insertBookInfor = string.Format("INSERT INTO BookInformation values (N'{0}', N'{1}', {2}, {3}, N'{4}', " +
                "N'{5}', N'{6}', {7}, {8})",
                bookInfor.Cover, bookInfor.Title, bookInfor.CategoryID, bookInfor.PublishYear, bookInfor.Author,
                bookInfor.Publisher, bookInfor.Translator, bookInfor.SalePrice, bookInfor.Quantity);
            DB_Helper.Instance.ExecuteDB(query_insertBookInfor);
        }

        //update book
        public void UpdateBookInfor_DAL(BookInfor bookInfor)
        {
            string query_updateBookInfor = string.Format("UPDATE BookInformation SET Cover = N'{0}', Title = N'{1}', CategoryID = {2}," +
                " PublishYear = {3}, Author = N'{4}', Publisher = N'{5}', Translator = N'{6}', SalePrice = {7}, Quantity = {8} where BookInforID = {9}",
                bookInfor.Cover, bookInfor.Title, bookInfor.CategoryID, bookInfor.PublishYear, bookInfor.Author,
                bookInfor.Publisher, bookInfor.Translator, bookInfor.SalePrice, bookInfor.Quantity, bookInfor.BookInforID);
            DB_Helper.Instance.ExecuteDB(query_updateBookInfor);
            
        }

        //delete book by key (bookInforID)
        public void DeleteBookInfor_DAL(int bookInforID)
        {
            string queryDel_Sach = "DELETE FROM BookInformation WHERE BookInforID = " + bookInforID;
            DB_Helper.Instance.ExecuteDB(queryDel_Sach);
        }

        public int getNextBookInforID()
        {
            string query = "SELECT IDENT_CURRENT('BookInformation') + IDENT_INCR('BookInformation') AS NextID";

            int BookInforID = -1;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                BookInforID = Convert.ToInt32(i[0]);
            }
            return BookInforID;
        }
    }
}
