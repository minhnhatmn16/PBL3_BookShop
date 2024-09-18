using BookShop.DAL_ST;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL_ST
{
    internal class CSDL_OOP
    {
        private static CSDL_OOP _Instance;
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null) _Instance = new CSDL_OOP();
                return _Instance;
            }
            private set
            {

            }
        }

        //getBook B1. transfer each row in datarow to actual model
        public BookInfor GetDBBook(DataRow Book)
        {
            BookInfor St = new BookInfor();
            St.BookInforID = Convert.ToInt32(Book["BookInforID"]);
            St.Cover = Convert.ToString(Book["Cover"]);
            St.Title = Convert.ToString(Book["Title"]);

            St.CategoryID = Convert.ToInt32(Book["CategoryID"]);
            St.Category = Category_BLL.Instance.GetCategoryName(St.CategoryID);
            St.Author = Convert.ToString(Book["Author"]);
            St.Publisher = Convert.ToString(Book["Publisher"]);
            St.Translator = Convert.ToString(Book["Translator"]);

            St.PublishYear = Convert.ToInt32(Book["PublishYear"]);
            St.SalePrice = Convert.ToInt32(Book["SalePrice"]);
            St.Quantity = Convert.ToInt32(Book["Quantity"]);

            return St;
        }

        //getBook B2. transfer model to a gridview
        public List<BookInfor> GetBookInfor(string Name)
        {
            List<BookInfor> St = new List<BookInfor>();

            foreach (DataRow i in Login_DAL.Instance.Get_BookInfor().Rows)
            {
                BookInfor temp = new BookInfor();
                temp = GetDBBook(i);
                if (Name == "") St.Add(temp); //get all books
                else if (searchAllField(temp, Name)) //get books that have 'title' match the text in textbox
                    St.Add(temp);
                
            }
            return St;  //return in type list<model>
        }

        public bool searchAllField(BookInfor bookInfor, String searchName) //if return false mean not found
        {
            Type type = bookInfor.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //if (fields["CategoryID"] == row[i] || row["AuthorID"] == row[i] || row["PublisherID"] == row[i]) continue;
                if (Convert.ToString(properties[i].GetValue(bookInfor)).ToLower().Contains(searchName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public List<BookInfor> GetBookInforsByCategoryID_BLL(int categoryID)
        {
            List<BookInfor> St = new List<BookInfor>();

            foreach (DataRow i in BookInfor_DAL.Instance.getBookInfosByCategoryID(categoryID).Rows)
            {
                St.Add(GetDBBook(i)); //get all books
            }
            return St;  //return in type list<model>
        }

    }
}
