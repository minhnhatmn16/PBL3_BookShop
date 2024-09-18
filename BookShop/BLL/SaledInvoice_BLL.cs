using BookShop.DAL;
using BookShop.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.BLL
{
    internal class SaledInvoice_BLL
    {
        private static SaledInvoice_BLL _Instance;
        public static SaledInvoice_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SaledInvoice_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private SaledInvoice_BLL()
        {
        }
        //getBook B1. transfer each row in datarow to actual model
        public SaledInvoice GetDBSaledInvoice(DataRow SaledInvoice)
        {
            SaledInvoice St = new SaledInvoice();
            St.SaledInvoiceID = Convert.ToInt32(SaledInvoice["SaledInvoiceID"]);
            St.SaledTime = Convert.ToString(SaledInvoice["SaleTime"]);
            St.CustomerID = Convert.ToInt32(SaledInvoice["CustomerID"]);
            //St.SaleTax = Convert.ToDouble(SaledInvoice["SaleTax"]);
            St.Payment = Convert.ToDouble(SaledInvoice["Payment"]);
            St.StaffID = Convert.ToInt32(SaledInvoice["StaffID"]);

            return St;
        }

        //getSaledInvoice B2. transfer model to a gridview
        public List<SaledInvoice> GetSaledInvoiceInfor(string Name)
        {
            List<SaledInvoice> St = new List<SaledInvoice>();

            foreach (DataRow i in SaledInvoice_DAL.Instance.getAllSaledInvoice_DAL().Rows)
            {
                SaledInvoice temp = new SaledInvoice();
                temp = GetDBSaledInvoice(i);
                if (Name == "") St.Add(temp); //get all SaledInvoices
                else if (searchAllField(temp, Name)) //get SaledInvoices that have 'title' match the text in textbox
                    St.Add(GetDBSaledInvoice(i));

            }
            return St;  //return in type list<model>
        }

        public bool searchAllField(SaledInvoice saledInvoice, String searchName) //if return false mean not found
        {
            Type type = saledInvoice.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //if (fields["CategoryID"] == row[i] || row["AuthorID"] == row[i] || row["PublisherID"] == row[i]) continue;
                if (Convert.ToString(properties[i].GetValue(saledInvoice)).ToLower().Contains(searchName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddSaledInvoice_BLL(SaledInvoice SaledInvoice)
        {
            SaledInvoice_DAL.Instance.AddSaledInvoice_DAL(SaledInvoice);
        }
        public void UpdateSaledInvoice_BLL(SaledInvoice SaledInvoice)
        {
            SaledInvoice_DAL.Instance.UpdateSaledInvoice_DAL(SaledInvoice);
        }

        public int getNextSaledInvoiceID_BLL()
        {
            return SaledInvoice_DAL.Instance.getNextSaledInvoiceID();
        }
        public int getNumberOfBookSaledInvoice_BLL(int SaledInvoiceID)
        {
            return SaledInvoice_DAL.Instance.getNumberOfBookSaledInvoice(SaledInvoiceID);
        }
        public double getTotalAmountSaledInvoice_BLL(int SaledInvoiceID)
        {
            double total = 0;
            foreach (SaledBook temp in SaledBook_BLL.Instance.getSaledBookBySaledInvoiceID_BLL(SaledInvoiceID))
            {
                total += temp.TotalAmount;
            }
            return total;
        }
        public SaledInvoice getSaledInvoiceByID_BLL(int SaledInvoiceID)
        {
            SaledInvoice temp = new SaledInvoice();
            foreach (DataRow i in SaledInvoice_DAL.Instance.getSaledInvoiceByID(SaledInvoiceID).Rows)
            {
                temp = GetDBSaledInvoice(i);
            }
            return temp;
        }
        public List<SaledInvoice> GetSaledInvoiceByInterval(DateTime dt1, DateTime dt2)
        {
            List<SaledInvoice> St = new List<SaledInvoice>();

            foreach (DataRow i in SaledInvoice_DAL.Instance.getSaledInvoiceByInterval(dt1, dt2).Rows)
            {
                St.Add(GetDBSaledInvoice(i));
            }
            return St;  //return in type list<model>
        }

        public string ConvertToMoneyFormat(string numberString)
        {
            // Remove any existing commas or spaces from the input string
            string cleanedString = numberString.Replace(",", "").Replace(" ", "");

            // Parse the string to a numeric value
            if (decimal.TryParse(cleanedString, out decimal number))
            {
                // Convert the numeric value to a money format with a blank space every three digits
                string formattedNumber = number.ToString("#,##0");

                // Return the formatted number
                return formattedNumber;
            }

            // Return the original string if conversion fails
            return numberString;
        }
    }
}
