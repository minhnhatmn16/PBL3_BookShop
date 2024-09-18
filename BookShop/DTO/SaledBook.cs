using BookShop.BLL_ST;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO
{
    public class SaledBook
    {
        public int ID { get; set; }
        public int SaledInvoiceID { get; set; }
        private int _BookInforID;
        public int BookInforID
        {
            get { return _BookInforID; }
            set
            {
                _BookInforID = value;
                BookInfor bookInfor = BookInfor_BLL.Instance.getBookInforByID_BLL(BookInforID);
                _Title = bookInfor.Title;
                _SaledPrice = bookInfor.SalePrice;
                _ImportPrice = ImportBook_BLL.Instance.getImportBookByBookInforID_BLL(BookInforID).ImportPrice;
            }
        }
        private String _Title;
        public String Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private double _SaledPrice;
        public double SaledPrice
        {
            get { return _SaledPrice; }
            set 
            {
                _SaledPrice = value;
                _TotalAmount = _SaledPrice * _Quantity;
            }
        }

        private double _ImportPrice;
        public double ImportPrice
        {
            get { return _ImportPrice; }
            set
            {
                _ImportPrice = value;
            }
        }

        private int _Quantity;
        public int Quantity 
        { 
            get
            {
                return _Quantity;
            }
            set
            {
                _Quantity = value;
                _TotalAmount = _SaledPrice * _Quantity;
            }
        }
        private double _TotalAmount;
        public double TotalAmount
        {
            get { return _TotalAmount; }
            set { _TotalAmount = value; }
        }
    }
}
