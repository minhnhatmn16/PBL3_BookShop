using BookShop.DAL_ST;
using BookShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookShop.BLL_ST
{
    internal class Category_BLL
    {
        private static Category_BLL _Instance;
        public static Category_BLL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Category_BLL();
                return _Instance;
            }
            private set
            {

            }
        }

        //getBook B1. transfer each row in datarow to actual model
        public Category GetDBCategory(DataRow Category)
        {
            Category St = new Category();
            St.CategoryID = Convert.ToInt32(Category["CategoryID"]);
            St.CategoryName = Convert.ToString(Category["CategoryName"]);

            return St;
        }

        //getCategory B2. transfer model to a gridview
        public List<Category> GetCategoryInfor(string Name)
        {
            List<Category> St = new List<Category>();

            foreach (DataRow i in Category_DAL.Instance.Get_CategoryInfor().Rows)
            {
                if (Name == "") St.Add(GetDBCategory(i)); //get all Categorys
                else if ((Convert.ToString(i["CategoryName"])).Contains(Name)) //get Categorys that have 'title' match the text in textbox
                    St.Add(GetDBCategory(i));

            }
            return St;  //return in type list<model>
        }

        public String GetCategoryName(int CategoryID) //get Category name by id (used for other table to reference to)
        {
            String Name = "";
            foreach (DataRow i in Category_DAL.Instance.Get_CategoryInfor().Rows)
            {
                if (Convert.ToInt32(i["CategoryID"]) == CategoryID)
                {
                    Name = Convert.ToString(i["CategoryName"]);
                    break;
                }

            }
            return Name;  //return in type list<model>
        }
        public Category getCategoryByID_BLL(int CategoryID)
        {
            Category temp = new Category();
            foreach (DataRow i in Category_DAL.Instance.getCategoryByID(CategoryID).Rows)
            {
                temp = GetDBCategory(i);
            }
            return temp;
        }
        public int getNextCategoryID_BLL()
        {
            return Category_DAL.Instance.getNextCategoryID();
        }
        public void AddCategory_BLL(Category Category)
        {
            Category_DAL.Instance.AddCategory_DAL(Category);
        }
        public void UpdateCategory_BLL(Category Category)
        {
            Category_DAL.Instance.UpdateCategory_DAL(Category);
        }
    }
}
