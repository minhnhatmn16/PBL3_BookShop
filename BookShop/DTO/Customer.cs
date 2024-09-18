using BookShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO
{
    public class Customer
    {
        private int _CustomerID;
        public int CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
                TotalBook = Customer_BLL.Instance.getNumberOfBookCustomer_BLL(CustomerID);
                Total = Customer_BLL.Instance.getTotalPaymentCustomer_BLL(CustomerID);
            }
        }
        public String CustomerName { get; set; }
        private int _SexID;
        public int SexID
        { 
            get {    return _SexID; }
            set 
            {
                _SexID = value;
                SexName = Gender.ID[_SexID];
            }
        }
        public String SexName { get; set; }
        public String PhoneNumber { get; set; }
        public int TotalBook { get; set; }
        public Double Total { get; set; }
    }
}
