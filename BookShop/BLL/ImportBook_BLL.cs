using BookShop.DAL;
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
    internal class ImportBook_BLL
    {
        private static ImportBook_BLL _Instance;
        public static ImportBook_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ImportBook_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private ImportBook_BLL()
        {
        }
        public ImportBook GetDBImportBook(DataRow ImportBook)
        {
            ImportBook St = new ImportBook();
            St.ID = Convert.ToInt32(ImportBook["ID"]);
            St.BookInforID = Convert.ToInt32(ImportBook["BookInforID"]);
            St.ImportInvoiceID = Convert.ToInt32(ImportBook["ImportInvoiceID"]);
            St.ImportPrice = Convert.ToDouble(ImportBook["ImportPrice"]);
            St.Quantity = Convert.ToInt32(ImportBook["Quantity"]);

            return St;
        }
        public bool ExecuteAddOrUpdate_BLL(ImportBook ImportBook)
        {
            int check = 1;
            foreach (DataRow i in ImportBook_DAL.Instance.getAllImportBook_DAL().Rows)
            {
                if (Convert.ToInt32(i["ID"]) == ImportBook.ID) //if the book that is currently in database then update that book
                {
                    check = 0;
                    break;
                }
            }
            if (check == 0)
            {
                UpdateImportBook_BLL(ImportBook);
                return true;
            }
            else if (check == 1)
            {
                AddImportBook_BLL(ImportBook); //else add that book to database
                return true;
            }
            return false;
        }

        public void AddImportBook_BLL(ImportBook ImportBook)
        {
            ImportBook_DAL.Instance.AddImportBook_DAL(ImportBook);
        }
        public void UpdateImportBook_BLL(ImportBook ImportBook)
        {
            ImportBook_DAL.Instance.UpdateImportBook_DAL(ImportBook);
        }
        public void DeleteImportBook_BLL(List<int> listImportBookID)
        {
            foreach (int i in listImportBookID)
            {
                ImportBook_DAL.Instance.DeleteImportBook_DAL(i);
            }
        }
        public List<ImportBook> getImportBookByImportInvoiceID_BLL(int importInvoiceID)
        {
            List<ImportBook> list = new List<ImportBook>();
            ImportBook temp = new ImportBook();
            foreach (DataRow i in ImportBook_DAL.Instance.getAllImportBook_DAL().Rows)
            {
                if (Convert.ToInt32(i["ImportInvoiceID"]) == importInvoiceID)
                {
                    temp = GetDBImportBook(i);
                    list.Add(temp);
                }
            }
            return list;
        }

        public ImportBook getImportBookByBookInforID_BLL(int bookInforID)
        {
            ImportBook temp = new ImportBook();
            foreach (DataRow i in ImportBook_DAL.Instance.getTheLastImportBookByBookInforID(bookInforID).Rows)
            {
                    temp = GetDBImportBook(i);
            }
            return temp;
        }

        public double getTotalImportPriceByBookInforID(int bookInforID)
        {
            ImportBook temp = new ImportBook();
            double total = 0;
            foreach (DataRow i in ImportBook_DAL.Instance.getImportBookByBookInforID(bookInforID).Rows)
            {
                temp = GetDBImportBook(i);
                total += temp.ImportPrice;
            }
            return total;
        }
        public double getNumberOfImportBookByBookInforID(int bookInforID)
        {
            ImportBook temp = new ImportBook();
            double total = 0;
            foreach (DataRow i in ImportBook_DAL.Instance.getImportBookByBookInforID(bookInforID).Rows)
            {
                temp = GetDBImportBook(i);
                total += temp.Quantity;
            }
            return total;
        }
    }
}
