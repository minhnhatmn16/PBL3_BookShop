using BookShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DTO
{
    internal class RevenueBook
    {
        private int _BooKInforID;
        public int BookInforID
        {
            get { return _BooKInforID; }
            set
            {
                _BooKInforID = value;
                TotalAmount = SaledBook_BLL.Instance.getTotalSaledPriceByBookInforID(_BooKInforID);
                TotalAmount = ImportInvoice_BLL.Instance.getTotalAmountImportInvoice_BLL(_BooKInforID);

            }
        }
        public string Title { get; set; }
        public int NumberRemainBook { get; set; } 
        public int NumberSaledBook { get; set; }
        public double TotalImport { get; set; }
        public double TotalAmount { get; set; }
        public double Profit { get; set; }
    }
}
