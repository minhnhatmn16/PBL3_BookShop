using BookShop.DAL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL_ST
{
    internal class BookInfor_BLL
    {
        private static BookInfor_BLL _Instance;
        public static BookInfor_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new BookInfor_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private BookInfor_BLL()
        {
        }
        public bool ExecuteAddOrUpdate_BLL(BookInfor bookInfor)
        {
            int check = 1;
            foreach (DataRow i in BookInfor_DAL.Instance.getAllBookInfor_DAL().Rows)
            {
                if (Convert.ToInt32(i["BookInforID"]) == bookInfor.BookInforID) //if the book that is currently in database then update that book
                {
                    check = 0;
                    break;
                }
            }
            if (check == 0)
            {
                UpdateBookInfor_BLL(bookInfor);
                return true;
            }
            else if (check == 1)
            {
                AddBookInfor_BLL(bookInfor); //else add that book to database
                return true;
            }
            return false;
        }

        public void AddBookInfor_BLL(BookInfor bookInfor)
        {
            BookInfor_DAL.Instance.AddBookInfor_DAL(bookInfor);
        }
        public void UpdateBookInfor_BLL(BookInfor bookInfor)
        {
            BookInfor_DAL.Instance.UpdateBookInfor_DAL(bookInfor);
        }
        public void DeleteBookInfor_BLL(List<int> listBookInforID)
        {
            foreach (int i in listBookInforID)
            {
                BookInfor_DAL.Instance.DeleteBookInfor_DAL(i);
            }
        }
        public BookInfor getBookInforByID_BLL(int BookInforID)
        {
            BookInfor temp = new BookInfor();
            foreach(DataRow i in BookInfor_DAL.Instance.getBookInforByID(BookInforID).Rows)
            {
                temp = CSDL_OOP.Instance.GetDBBook(i);
            }
            return temp;
        }

        public int getNextBookInforID_BLL()
        {
            return BookInfor_DAL.Instance.getNextBookInforID();
        }

    }
}

//test changes
