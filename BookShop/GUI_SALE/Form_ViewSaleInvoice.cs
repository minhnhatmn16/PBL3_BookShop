using BookShop.BLL;
using BookShop.DTO;
using BookShop.DTO_ST;
using BookShop.GUI_SALE;
using BookShop.GUI_ST;
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
    public partial class Form_ViewSaleInvoice : Form
    {
        List<SaledInvoice> listSaledInvoice = new List<SaledInvoice>();
        bool initiateDate = true;
        public Form_ViewSaleInvoice()
        {
            InitializeComponent();
            listSaledInvoice = SaledInvoice_BLL.Instance.GetSaledInvoiceInfor("");
            dataGridView1.DataSource = listSaledInvoice;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Remove("CustomerID");
            dataGridView1.Columns.Remove("StaffID");
            vietnameseDatagridView();
            initiateDate = false;
        }

        public void refreshGridView()
        {
            dataGridView1.DataSource = null;
            listSaledInvoice = SaledInvoice_BLL.Instance.GetSaledInvoiceInfor("");
            dataGridView1.DataSource = listSaledInvoice;
            initiateDate = true;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            initiateDate = false;

        }
        public void vietnameseDatagridView()
        {
            DataGridViewColumn SaledInvoiceID = dataGridView1.Columns["SaledInvoiceID"];
            SaledInvoiceID.HeaderText = "Mã hóa đơn";
            DataGridViewColumn saledTime = dataGridView1.Columns["SaledTime"];
            saledTime.HeaderText = "Thời gian";
            DataGridViewColumn phoneNumber = dataGridView1.Columns["PhoneNumber"];
            phoneNumber.HeaderText = "SĐT";
            DataGridViewColumn customerName = dataGridView1.Columns["CustomerName"];
            customerName.HeaderText = "Khách hàng";
            /*DataGridViewColumn saleTax = dataGridView1.Columns["SaleTax"];
            saleTax.HeaderText = "Thuế";*/
            DataGridViewColumn staffName = dataGridView1.Columns["StaffName"];
            staffName.HeaderText = "Nhân viên";
            DataGridViewColumn payment = dataGridView1.Columns["Payment"];
            payment.HeaderText = "Tổng trả";
            DataGridViewColumn numberOfBook = dataGridView1.Columns["NumberOfBook"];
            numberOfBook.HeaderText = "Tổng sách";
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            int SaledInvoiceID = Convert.ToInt32(selectedRow.Cells["SaledInvoiceID"].Value);
            SaledInvoice SaledInvoice = SaledInvoice_BLL.Instance.getSaledInvoiceByID_BLL(SaledInvoiceID);
            Form_DetailedSaledInvoice formDetailSaledInvoice = new Form_DetailedSaledInvoice(SaledInvoice);
            formDetailSaledInvoice.ShowDialog();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            refreshGridView();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = "";
            name = txtbSearch.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = SaledInvoice_BLL.Instance.GetSaledInvoiceInfor(name);
        }
        private void txtbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (initiateDate) return;
            if (dateTimePicker1.Value != dateTimePicker2.Value)
            {
                listSaledInvoice = SaledInvoice_BLL.Instance.GetSaledInvoiceByInterval(dateTimePicker1.Value, dateTimePicker2.Value);
                dataGridView1.DataSource = listSaledInvoice;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (initiateDate) return;
            if (dateTimePicker1.Value != dateTimePicker2.Value)
            {
                listSaledInvoice = SaledInvoice_BLL.Instance.GetSaledInvoiceByInterval(dateTimePicker1.Value, dateTimePicker2.Value);
                dataGridView1.DataSource = listSaledInvoice;
            }
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
            PropertyInfo propInfo = typeof(SaledInvoice).GetProperty(propertyName);
            if (sortDirection == ListSortDirection.Ascending)
            {
                listSaledInvoice = listSaledInvoice.OrderBy(x => propInfo.GetValue(x, null)).ToList();
            }
            else
            {
                listSaledInvoice = listSaledInvoice.OrderByDescending(x => propInfo.GetValue(x, null)).ToList();
            }

            // Clear the DataGridView's current data source and re-bind it to the sorted list
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listSaledInvoice;

            // Set the sort arrow in the column header
            dataGridView1.Columns[sortColumnIndex].HeaderCell.SortGlyphDirection = sortDirection == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

        }

        private void Form_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0); 
        }
    }
}
