using BookShop.BLL_ST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO_ST
{
    public class ImportBook
    {
        public int ID { get; set; }
        public int ImportInvoiceID { get; set; }
        private int _BookInforID;
        public int BookInforID 
        {
            get{ return _BookInforID;}
            set
            {
                _BookInforID = value;
                BookInfor bookInfor = BookInfor_BLL.Instance.getBookInforByID_BLL(BookInforID);
                _Title = bookInfor.Title;
            }
        }
        private String _Title;
        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public double ImportPrice { get; set; }
        public int Quantity { get; set; }
        
    }
}
