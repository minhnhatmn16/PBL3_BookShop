using BookShop.BLL;
using BookShop.BLL_ST;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI_Sale;
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

namespace BookShop.GUI_SALE
{
    public partial class Form_DetailedSaledInvoice : Form
    {
        Customer customer = new Customer();
        List<SaledBook> saledBooks = new List<SaledBook>();
        SaledInvoice saledInvoice = new SaledInvoice();
        public Form_DetailedSaledInvoice(SaledInvoice si)
        {
            InitializeComponent();
            saledInvoice = si;
            customer = Customer_BLL.Instance.getCustomerByID_BLL(saledInvoice.CustomerID);
            saledBooks = SaledBook_BLL.Instance.getSaledBookBySaledInvoiceID_BLL(saledInvoice.SaledInvoiceID);
            
            resetForm();
            vietnameseDatagridView();
        }
        bool initial = false;
        public void resetForm()
        {
            txtbPhoneNumber.ReadOnly = true;
            txtbTotal.ReadOnly = true;
            txtbTotalBook.ReadOnly = true;
            txtbUserID.Enabled = false;
            txtbUserName.Enabled = false;
            txtbSaledInvoiceID.Enabled = false;

            txtbTime.Text = saledInvoice.SaledTime.ToString();
            txtbCustomer.Text = customer.CustomerName.ToString();
            txtbPhoneNumber.Text = customer.PhoneNumber.ToString();

            txtbUserID.Text = saledInvoice.StaffID.ToString();
            txtbUserName.Text = saledInvoice.StaffName.ToString();
            txtbSaledInvoiceID.Text = saledInvoice.SaledInvoiceID.ToString();

            txtbTotalBook.Text = SaledInvoice_BLL.Instance.ConvertToMoneyFormat(SaledInvoice_BLL.Instance.getNumberOfBookSaledInvoice_BLL(saledInvoice.SaledInvoiceID).ToString());
            txtbTotal.Text = SaledInvoice_BLL.Instance.ConvertToMoneyFormat(SaledInvoice_BLL.Instance.getTotalAmountSaledInvoice_BLL(saledInvoice.SaledInvoiceID).ToString());

            dataGridView1.DataSource = saledBooks;
            if (!initial)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.Columns.Remove("ImportPrice"); //remove the property that not necessary when display to viewer
            }
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
            DataGridViewColumn SaledBookID = dataGridView1.Columns["SaledInvoiceID"];
            SaledBookID.HeaderText = "Mã hóa đơn bán sách";
            DataGridViewColumn bookInforID = dataGridView1.Columns["BookInforID"];
            bookInforID.HeaderText = "Mã thông tin sách";
            DataGridViewColumn Title = dataGridView1.Columns["Title"];
            Title.HeaderText = "Tên sách";
            DataGridViewColumn SaledPrice = dataGridView1.Columns["SaledPrice"];
            SaledPrice.HeaderText = "Giá bán";
            DataGridViewColumn PublishYear = dataGridView1.Columns["Quantity"];
            PublishYear.HeaderText = "Số lượng";
            DataGridViewColumn TotalAmount = dataGridView1.Columns["TotalAmount"];
            TotalAmount.HeaderText = "Tổng giá";

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
            PropertyInfo propInfo = typeof(SaledBook).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                saledBooks = saledBooks.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                saledBooks = saledBooks.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = saledBooks;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;
            vietnameseDatagridView();
        }
    }
}
