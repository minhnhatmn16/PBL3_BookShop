using BookShop.BLL_ST;
using BookShop.DAL;
using BookShop.DAL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookShop.BLL
{
    internal class ImportInvoice_BLL
    {
        private static ImportInvoice_BLL _Instance;
        public static ImportInvoice_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ImportInvoice_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private ImportInvoice_BLL()
        {
        }
        //getBook B1. transfer each row in datarow to actual model
        public ImportInvoice GetDBImportInvoice(DataRow ImportInvoice)
        {
            ImportInvoice St = new ImportInvoice();
            St.ImportInvoiceID = Convert.ToInt32(ImportInvoice["ImportInvoiceID"]);
            St.ImportTime = Convert.ToString(ImportInvoice["ImportTime"]);
            St.SupplierID = Convert.ToInt32(ImportInvoice["SupplierID"]);
            St.Purchase = Convert.ToInt32(ImportInvoice["Purchase"]);
            St.StaffID = Convert.ToInt32(ImportInvoice["StaffID"]);

            return St;
        }

        //getImportInvoice B2. transfer model to a gridview
        public List<ImportInvoice> GetImportInvoiceInfor(string Name)
        {
            List<ImportInvoice> St = new List<ImportInvoice>();

            foreach (DataRow i in ImportInvoice_DAL.Instance.getAllImportInvoice_DAL().Rows)
            {
                ImportInvoice temp = new ImportInvoice();
                temp = GetDBImportInvoice(i);
                if (Name == "") St.Add(temp); //get all ImportInvoices
                else if (searchAllField(temp, Name)) //get ImportInvoices that have 'title' match the text in textbox
                    St.Add(temp);

            }
            return St;  //return in type list<model>
        }

        public bool searchAllField(ImportInvoice ImportInvoice, String searchName) //if return false mean not found
        {
            Type type = ImportInvoice.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                //if (fields["CategoryID"] == row[i] || row["AuthorID"] == row[i] || row["PublisherID"] == row[i]) continue;
                if (Convert.ToString(properties[i].GetValue(ImportInvoice)).ToLower().Contains(searchName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddImportInvoice_BLL(ImportInvoice ImportInvoice)
        {
            ImportInvoice_DAL.Instance.AddImportInvoice_DAL(ImportInvoice);
        }
        public void UpdateImportInvoice_BLL(ImportInvoice ImportInvoice)
        {
            ImportInvoice_DAL.Instance.UpdateImportInvoice_DAL(ImportInvoice);
        }

        public int getNextImportInvoiceID_BLL()
        {
            return ImportInvoice_DAL.Instance.getNextImportInvoiceID();
        }
        public int getNumberOfBookImportInvoice_BLL(int importInvoiceID)
        {
            return ImportInvoice_DAL.Instance.getNumberOfBookImportInvoice(importInvoiceID);
        }
        public double getTotalAmountImportInvoice_BLL(int importInvoiceID)
        {
            return ImportInvoice_DAL.Instance.getTotalAmountImportInvoice(importInvoiceID);
        }
        public ImportInvoice getImportInvoiceByID_BLL(int importInvoiceID)
        {
            ImportInvoice temp = new ImportInvoice();
            foreach (DataRow i in ImportInvoice_DAL.Instance.getImportInvoiceByID(importInvoiceID).Rows)
            {
                temp = GetDBImportInvoice(i);
            }
            return temp;
        }
        public List<ImportInvoice> GetImportInvoiceByInterval(DateTime dt1, DateTime dt2)
        {
            List<ImportInvoice> St = new List<ImportInvoice>();

            foreach (DataRow i in ImportInvoice_DAL.Instance.getImportInvoiceByInterval(dt1, dt2).Rows)
            {
                 St.Add(GetDBImportInvoice(i));
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
