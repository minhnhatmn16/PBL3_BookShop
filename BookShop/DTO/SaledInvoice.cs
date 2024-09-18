using BookShop.BLL;
using BookShop.BLL_ST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO
{
    public class SaledInvoice
    {
        private int _SaledInvoiceID;
        public int SaledInvoiceID
        {
            get { return _SaledInvoiceID; }
            set
            {
                _SaledInvoiceID = value;
                _NumberOfBook = SaledInvoice_BLL.Instance.getNumberOfBookSaledInvoice_BLL(SaledInvoiceID);
            }
        }

        public String SaledTime { get; set; }

        private int _CustomerID;
        public int CustomerID
        {
            get { return _CustomerID; }
            set
            {
                _CustomerID = value;
                _CustomerName = Customer_BLL.Instance.getCustomerByID_BLL(CustomerID).CustomerName;
                _PhoneNumber = Customer_BLL.Instance.getCustomerByID_BLL(CustomerID).PhoneNumber;
            }
        }
        private String _PhoneNumber;
        public String PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                _PhoneNumber = value;
            }
        }
        private String _CustomerName;
        public String CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        //public double SaleTax { get; set; }
        public double Payment { get; set; }

        private int _StaffID;
        public int StaffID
        {
            get { return _StaffID; }
            set
            {
                _StaffID = value;
                _StaffName = Account_BLL.Instance.GetAccountName(StaffID);
            }
        }

        private String _StaffName;
        public String StaffName
        {
            get { return _StaffName; }
            set { _StaffName = value; }
        }

        private int _NumberOfBook;
        public int NumberOfBook
        {
            get { return _NumberOfBook; }
            set { _NumberOfBook = value; }
        }
    }
}
