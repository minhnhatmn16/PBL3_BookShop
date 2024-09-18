using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.InHoaDon
{
    
    public partial class Report_Sale : Form
    {
        private int SaledInvoiceID;
        string Customer, PhoneNumber, UserID, UserName, TotalBook, Total;
        public Report_Sale(int saledInvoiceID, string customer, string phoneNumber, string userID, string userName, string totalBook, string total)
        {
            SaledInvoiceID = saledInvoiceID;
            Customer = customer;
            PhoneNumber = phoneNumber;
            UserID = userID;
            UserName = userName;
            TotalBook = totalBook;
            Total = total;
            InitializeComponent();
        }

        private void Report_Sale_Load(object sender, EventArgs e)
        {
            //reportViewer1.LocalReport.ReportPath = @"C:\Users\PC\OneDrive - The University of Technology\Desktop\CuongNew\BookShop_\BookShop_edit01\BookShop\BookShop\Report_Sale.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "BookShop.Report_Sale.rdlc";
            SqlConnection connection = new SqlConnection(Connect.constr);
            string query = " select SaledBook.ID, BookInformation.Title, SaledBook.SalePrice, SaledBook.Quantity, SaledBook.Quantity*SaledBook.SalePrice as Total " +
                           " from SaledBook " +
                           " inner join BookInformation on SaledBook.BookInforID = BookInformation.BookInforID " +
                           " where SaledBook.SaledInvoiceID =  " + SaledInvoiceID.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("ID", SaledInvoiceID.ToString()));
            parameters.Add(new ReportParameter("Name_Customer", Customer));
            parameters.Add(new ReportParameter("PhoneNumber", PhoneNumber));
            parameters.Add(new ReportParameter("UserID", UserID));
            parameters.Add(new ReportParameter("Name_User", UserName));
            parameters.Add(new ReportParameter("Quantity", TotalBook));
            parameters.Add(new ReportParameter("Total", Total));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
