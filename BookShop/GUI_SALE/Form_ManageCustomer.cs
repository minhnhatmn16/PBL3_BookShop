using BookShop.BLL;
using BookShop.DTO;
using BookShop.DTO_ST;
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

namespace BookShop.GUI_Sale
{
    public partial class Form_ManageCustomer : Form
    {
        List<Customer> listCustomer = new List<Customer>();
        public Form_ManageCustomer()
        {
            InitializeComponent();
            listCustomer = Customer_BLL.Instance.GetCustomerInfor("");
            dataGridView1.DataSource = listCustomer;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Remove("SexID");
            vietnameseDatagridView();
        }
        public void refreshGridView()
        {
            dataGridView1.DataSource = null;
            listCustomer = Customer_BLL.Instance.GetCustomerInfor("");
            dataGridView1.DataSource = listCustomer;

        }
        public void vietnameseDatagridView()
        {
            DataGridViewColumn customerID = dataGridView1.Columns["CustomerID"];
            customerID.HeaderText = "Mã khách hàng";
            DataGridViewColumn customerName = dataGridView1.Columns["CustomerName"];
            customerName.HeaderText = "Tên khách hàng";
            DataGridViewColumn sexName = dataGridView1.Columns["SexName"];
            sexName.HeaderText = "Giới tính";
            DataGridViewColumn phoneNumber = dataGridView1.Columns["PhoneNumber"];
            phoneNumber.HeaderText = "SĐT";
            DataGridViewColumn totalBook = dataGridView1.Columns["TotalBook"];
            totalBook.HeaderText = "Tổng sách";
            DataGridViewColumn total = dataGridView1.Columns["Total"];
            total.HeaderText = "Tổng thanh toán";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            name = txtbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Customer_BLL.Instance.GetCustomerInfor(name);
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Không có khách hàng này!");
            }
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Form_Customer form = new Form_Customer();
            form.ShowDialog();
            refreshGridView();
        }

        private void txtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        public Customer choosenCustomer;
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            choosenCustomer = new Customer();
            choosenCustomer = listCustomer[idx];
            this.Dispose();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int idx = selectedRow.Index;
            choosenCustomer = new Customer();
            choosenCustomer = listCustomer[idx];
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
            PropertyInfo propInfo = typeof(Customer).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                listCustomer = listCustomer.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                listCustomer = listCustomer.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listCustomer;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

        }
    }
}
