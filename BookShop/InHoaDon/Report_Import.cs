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
    public partial class Report_Import : Form
    {
        private int val_ImportInvoiceID;
        private string val_Supplier, val_PhoneNumber, val_Address, val_TotalBook, val_Total, val_UserID, val_UserName;
        public Report_Import(int _ImportInvoiceID, string _Supplier, string _PhoneNumber, string _Address, string _TotalBook, string _Total, string _UserID, string _Username)
        {
            val_ImportInvoiceID = _ImportInvoiceID;
            val_Supplier = _Supplier;
            val_PhoneNumber = _PhoneNumber;
            val_Address = _Address;
            val_TotalBook = _TotalBook;
            val_Total = _Total;
            val_UserID = _UserID;
            val_UserName = _Username;
            InitializeComponent();
        }

        private void Report_Import_Load(object sender, EventArgs e)
        {
            //reportViewer1.LocalReport.ReportPath = @"C:\Users\PC\OneDrive - The University of Technology\Desktop\CuongNew\BookShop_edit01\BookShop\BookShop\Report_Import.rdlc";
            reportViewer1.LocalReport.ReportEmbeddedResource = "BookShop.Report_Import.rdlc";

            SqlConnection connection = new SqlConnection(Connect.constr);
            string query = " select ImportBook.ID as ID, BookInformation.Title as Title,ImportBook.ImportPrice as ImportPrice ,ImportBook.Quantity as Quantity, ImportBook.Quantity * ImportBook.ImportPrice as Total " +
                           " from BookInformation " +
                           " inner join ImportBook on BookInformation.BookInforID = ImportBook.BookInforID " +
                           " where ImportBook.ImportInvoiceID = " + val_ImportInvoiceID;
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameterCollection parameters = new ReportParameterCollection();
            parameters.Add(new ReportParameter("val_Supplier", val_Supplier));
            parameters.Add(new ReportParameter("val_PhoneNumber", val_PhoneNumber));
            parameters.Add(new ReportParameter("val_Address", val_Address));
            parameters.Add(new ReportParameter("val_Quantity", val_TotalBook));
            parameters.Add(new ReportParameter("val_Total", val_Total));
            parameters.Add(new ReportParameter("UserID", val_UserID));
            parameters.Add(new ReportParameter("UserName", val_UserName));
            parameters.Add(new ReportParameter("ImportInvoiceID", val_ImportInvoiceID.ToString()));
            reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();
        }
    }
}
