using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI;
using BookShop.GUI_SALE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShop.GUI_ST
{
    public partial class Form_DetailImportInvoice : Form
    {
        Supplier supplier = new Supplier();
        List<ImportBook> importBooks = new List<ImportBook>();
        ImportInvoice importInvoice = new ImportInvoice();
        public Form_DetailImportInvoice(ImportInvoice ip)
        {
            InitializeComponent();
            importInvoice = ip;
            supplier = Supplier_BLL.Instance.getSupplierByID_BLL(importInvoice.SupplierID);
            importBooks = ImportBook_BLL.Instance.getImportBookByImportInvoiceID_BLL(importInvoice.ImportInvoiceID);
            resetForm();
            vietnameseDatagridView();
        }
        public void resetForm()
        {

            txtbAddress.ReadOnly = true;
            txtbPhoneNumber.ReadOnly = true;
            txtbTotal.ReadOnly = true;
            txtbTotalBook.ReadOnly = true;
            txtbUserID.Enabled = false;
            txtbUserName.Enabled = false;
            txtbImportInvoiceID.Enabled = false;

            txtbTime.Text = importInvoice.ImportTime.ToString();
            txtbSupplier.Text = supplier.SupplierName.ToString();
            txtbPhoneNumber.Text = supplier.PhoneNumber.ToString();
            txtbAddress.Text = supplier.Address.ToString();

            txtbUserID.Text = importInvoice.StaffID.ToString();
            txtbUserName.Text = importInvoice.StaffName.ToString();
            txtbImportInvoiceID.Text = importInvoice.ImportInvoiceID.ToString();

            txtbTotalBook.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(ImportInvoice_BLL.Instance.getNumberOfBookImportInvoice_BLL(importInvoice.ImportInvoiceID).ToString());
            txtbTotal.Text = ImportInvoice_BLL.Instance.ConvertToMoneyFormat(ImportInvoice_BLL.Instance.getTotalAmountImportInvoice_BLL(importInvoice.ImportInvoiceID).ToString());

            dataGridView1.DataSource = importBooks;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int bookInforID = Convert.ToInt32(selectedRow.Cells["BookInforID"].Value);
            BookInfor bookInfor = BookInfor_BLL.Instance.getBookInforByID_BLL(bookInforID);
            Form_ViewDetailedBook formBookDetail = new Form_ViewDetailedBook(bookInfor);
            formBookDetail.ShowDialog();
        }

        public void vietnameseDatagridView()
        {
            DataGridViewColumn ImportInvoiceID = dataGridView1.Columns["ImportInvoiceID"];
            ImportInvoiceID.HeaderText = "Mã hóa đơn nhập sách";
            DataGridViewColumn bookInforID = dataGridView1.Columns["bookInforID"];
            bookInforID.HeaderText = "Mã thông tin sách";
            DataGridViewColumn Title = dataGridView1.Columns["Title"];
            Title.HeaderText = "Tên sách";
            DataGridViewColumn ImportPrice = dataGridView1.Columns["ImportPrice"];
            ImportPrice.HeaderText = "Giá nhập";
            DataGridViewColumn PublishYear = dataGridView1.Columns["Quantity"];
            PublishYear.HeaderText = "Số lượng";

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private int sortColumnIndex = -1;
        private ListSortDirection sortDirection = ListSortDirection.Ascending;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // If the same column header was clicked twice, reverse the sort direction
            if (e.ColumnIndex == sortColumnIndex)
            {
                sortDirection = sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending;
            }
            else // Otherwise, sort by the new column header
            {
                sortColumnIndex = e.ColumnIndex;
                sortDirection = ListSortDirection.Ascending;
            }

            // Sort the list using the appropriate property and sort direction
            string propertyName = dataGridView1.Columns[sortColumnIndex].DataPropertyName;
            PropertyInfo propInfo = typeof(ImportBook).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                importBooks = importBooks.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                importBooks = importBooks.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = importBooks;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

        }
    }
}
