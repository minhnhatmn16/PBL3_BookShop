using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.DAL;
using BookShop.DTO;

namespace BookShop.DAL_ST
{
    internal class Category_DAL
    {
        SqlDataAdapter da, da_;
        Connect dc;
        private static Category_DAL _Instance;
        public static Category_DAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Category_DAL();
                return _Instance;
            }
            private set
            {

            }
        }

        public Category_DAL()
        {
            dc = new Connect();
        }
        public DataTable Get_CategoryInfor()
        {
            String SQL = "SELECT CategoryID, CategoryName from dbo.Category";
            SqlConnection Con = dc.getConnect();
            da_ = new SqlDataAdapter(SQL, Con);
            Con.Open();
            DataTable TB_Staff = new DataTable();
            da_.Fill(TB_Staff);
            Con.Close();
            return TB_Staff;
        }
        public DataTable getCategoryByID(int ID)
        {
            return DB_Helper.Instance.GetRecord("SELECT * FROM Category WHERE CategoryID = " + ID);
        }

        public int getNextCategoryID()
        {
            string query = "SELECT IDENT_CURRENT('Category') + IDENT_INCR('Category') AS NextID";

            int CategoryID = -1;
            foreach (DataRow i in DB_Helper.Instance.GetRecord(query).Rows)
            {
                CategoryID = Convert.ToInt32(i[0]);
            }
            return CategoryID;
        }

        public void AddCategory_DAL(Category Category)
        {
            string query_insertCategory = string.Format("INSERT INTO Category values (N'{0}')", Category.CategoryName);
            DB_Helper.Instance.ExecuteDB(query_insertCategory);
        }

        public void UpdateCategory_DAL(Category Category)
        {
            string query_insertCategory = string.Format("UPDATE Category SET CategoryName = N'{0}' WHERE CategoryID = {1}", Category.CategoryName, Category.CategoryID);
            DB_Helper.Instance.ExecuteDB(query_insertCategory);
        }
    }
}
