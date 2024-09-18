using BookShop.BLL_ST;
using BookShop.DAL;
using BookShop.DTO;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    internal class SaledBook_BLL
    {
        private static SaledBook_BLL _Instance;
        public static SaledBook_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SaledBook_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private SaledBook_BLL()
        {
        }
        public SaledBook GetDBSaledBook(DataRow SaledBook)
        {
            SaledBook St = new SaledBook();
            St.ID = Convert.ToInt32(SaledBook["ID"]);
            St.BookInforID = Convert.ToInt32(SaledBook["BookInforID"]);
            St.SaledInvoiceID = Convert.ToInt32(SaledBook["SaledInvoiceID"]);
            St.Quantity = Convert.ToInt32(SaledBook["Quantity"]);

            return St;
        }

        //getSaledBook B2. transfer model to a gridview
        public List<SaledBook> GetSaledBookInfor(string Name)
        {
            List<SaledBook> St = new List<SaledBook>();

            foreach (DataRow i in SaledBook_DAL.Instance.getAllSaledBook_DAL().Rows)
            {
                SaledBook temp = new SaledBook();
                temp = GetDBSaledBook(i);
                if (Name == "") St.Add(temp); //get all SaledBooks
                else if (searchAllField(temp, Name)) //get SaledBooks that have 'title' match the text in textbox
                    St.Add(GetDBSaledBook(i));

            }
            return St;  //return in type list<model>
        }

        public bool searchAllField(SaledBook saledBook, String searchName) //if return false mean not found
        {
            Type type = saledBook.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //if (fields["CategoryID"] == row[i] || row["AuthorID"] == row[i] || row["PublisherID"] == row[i]) continue;
                if (Convert.ToString(properties[i].GetValue(saledBook)).ToLower().Contains(searchName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExecuteAddOrUpdate_BLL(SaledBook SaledBook)
        {
            int check = 1;
            foreach (DataRow i in SaledBook_DAL.Instance.getAllSaledBook_DAL().Rows)
            {
                if (Convert.ToInt32(i["ID"]) == SaledBook.ID) //if the book that is currently in database then update that book
                {
                    check = 0;
                    break;
                }
            }
            if (check == 0)
            {
                UpdateSaledBook_BLL(SaledBook);
                return true;
            }
            else if (check == 1)
            {
                AddSaledBook_BLL(SaledBook); //else add that book to database
                return true;
            }
            return false;
        }

        public void AddSaledBook_BLL(SaledBook SaledBook)
        {
            SaledBook_DAL.Instance.AddSaledBook_DAL(SaledBook);
        }
        public void UpdateSaledBook_BLL(SaledBook SaledBook)
        {
            SaledBook_DAL.Instance.UpdateSaledBook_DAL(SaledBook);
        }
        public void DeleteSaledBook_BLL(List<int> listSaledBookID)
        {
            foreach (int i in listSaledBookID)
            {
                SaledBook_DAL.Instance.DeleteSaledBook_DAL(i);
            }
        }
        public List<SaledBook> getSaledBookBySaledInvoiceID_BLL(int saledInvoiceID)
        {
            List<SaledBook> list = new List<SaledBook>();
            SaledBook temp = new SaledBook();
            foreach (DataRow i in SaledBook_DAL.Instance.getAllSaledBook_DAL().Rows)
            {
                if (Convert.ToInt32(i["SaledInvoiceID"]) == saledInvoiceID)
                {
                    temp = GetDBSaledBook(i);
                    list.Add(temp);
                }
            }
            return list;
        }

        public double getTotalSaledPriceByBookInforID(int bookInforID)
        {
            SaledBook temp = new SaledBook();
            double total = 0;
            foreach (DataRow i in SaledBook_DAL.Instance.getSaledBookByBookInforID(bookInforID).Rows)
            {
                temp = GetDBSaledBook(i);
                total += temp.SaledPrice;
            }
            return total;
        }

        public double getNumberOfSaledBookByBookInforID(int bookInforID)
        {
            SaledBook temp = new SaledBook();
            double total = 0;
            foreach (DataRow i in SaledBook_DAL.Instance.getSaledBookByBookInforID(bookInforID).Rows)
            {
                temp = GetDBSaledBook(i);
                total += temp.Quantity;
            }
            return total;
        }
    }
}
