using BookShop.BLL;
using BookShop.BLL_ST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO
{
    public class ImportInvoice
    {
        private int _ImportInvoiceID;
        public int ImportInvoiceID
        {
            get { return _ImportInvoiceID; }
            set 
            { 
                _ImportInvoiceID = value;
                _NumberOfBook = ImportInvoice_BLL.Instance.getNumberOfBookImportInvoice_BLL(ImportInvoiceID);
            }
        }

        public String ImportTime { get; set; }

        private int _SupplierID;
        public int SupplierID
        {
            get { return _SupplierID; }
            set 
            {
                _SupplierID = value;
                _SupplierName = Supplier_BLL.Instance.GetSupplierName(SupplierID);
            }
        }
        private String _SupplierName;
        public String SupplierName
        {
            get { return _SupplierName; }
            set { _SupplierName = value; }
        }

        public double Purchase { get; set; }

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
