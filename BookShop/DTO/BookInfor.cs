using BookShop.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO_ST
{
    public class BookInfor
    {
        public int BookInforID { get; set; }
        public String Cover { get; set; }
        public String Title { get; set; }
        public int CategoryID { get; set; }
        public String Category { get; set; }
        //public Category Category { get; set; }
        public int PublishYear { get; set; }
        public String Author { get; set; }
        public String Publisher { get; set; }
        public String Translator { get; set; }
        public int SalePrice { get; set; }
        public int Quantity { get; set; }
    }
}
